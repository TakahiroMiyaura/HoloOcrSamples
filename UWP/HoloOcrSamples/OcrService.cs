// Copyright(c) 2017 Takahiro Miyaura

using System;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Globalization;
using Windows.Graphics.Imaging;
using Windows.Media;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Media.Ocr;
using UnityPlayer;

namespace HoloOcrSamples
{
    public class OcrService : CameraScript.IOcrService
    {
        private bool _isRecognizing;
        private readonly MediaCapture _mediaCapture;
        private VideoFrame _videoFrame;

        public delegate Task SetMediaCaptureObjectAsync(MediaCapture capture);

/// <summary>
/// constructer.
/// </summary>
/// <param name="mediaCapture">Sets <see cref="MediaCapture"/> used for optical character recognition</param>
public OcrService(MediaCapture mediaCapture)
{
    _mediaCapture = mediaCapture;
}


/// <summary>
///     Prepare the device to perform optical character recognition and initialize the <see cref="OcrService" />.
/// </summary>
public static async Task InitializeOcrServiceAsync(SetMediaCaptureObjectAsync action)
{
    //Get camera device of HoloLens.
    var deviceInformationCollection = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
    var deviceInformation = deviceInformationCollection[0];

    var captureElementSource = new MediaCapture();
    await captureElementSource.InitializeAsync(new MediaCaptureInitializationSettings
    {
        VideoDeviceId = deviceInformation.Id
    });

    await action(captureElementSource);

    UWPBridgeService.AddService<CameraScript.IOcrService>(new OcrService(captureElementSource));
}

/// <summary>
/// Perform optical character recognition.
/// </summary>
public override void Recognize()
{
    if (_isRecognizing) return;
    _isRecognizing = true;
    var item = new AppCallbackItem(async () =>
    {
        var previewProperties =
            _mediaCapture.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.VideoPreview)
                as VideoEncodingProperties;
        if (previewProperties == null)
            return;

        var videoFrame = new VideoFrame(BitmapPixelFormat.Rgba8, (int) previewProperties.Width,
            (int) previewProperties.Height);

        _videoFrame = await _mediaCapture.GetPreviewFrameAsync(videoFrame);
        var ocrEngine = OcrEngine.TryCreateFromUserProfileLanguages();
        if (ocrEngine == null)
            return;
        var recognizeAsync = await ocrEngine.RecognizeAsync(_videoFrame.SoftwareBitmap);
        var str = new StringBuilder();
        foreach (var ocrLine in recognizeAsync.Lines)
            str.AppendLine(ocrLine.Text);
        var recoginzeText = str.ToString();

        _isRecognizing = false;
        if (OnRecognized != null)
            AppCallbacks.Instance.InvokeOnAppThread(() => { OnRecognized(recoginzeText); }, false);
    });
    AppCallbacks.Instance.InvokeOnUIThread(item, false);
}
    }
}