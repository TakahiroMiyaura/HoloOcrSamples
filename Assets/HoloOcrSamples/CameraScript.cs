// Copyright(c) 2017 Takahiro Miyaura
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{

    /// <summary>
    /// Execution interval of optical character recognition processing(number of frames).
    /// </summary>
    private static readonly int FrameInterval = 120;

    /// <summary>
    /// Unitty Text Object
    /// </summary>
    public Text OcrDatas;

    /// <summary>
    /// Gets or sets the instance of <see cref="IOcrService"/>.
    /// </summary>
    public IOcrService Service { set; private get; }

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.frameCount % FrameInterval == 0)
        {
            //Initialize
            if (Service == null)
            {
                Service = UWPBridgeService.GetService<IOcrService>();
                Service.OnRecognized = SetString;
            }

            //Perform optical character recognition
            Service.Recognize();
        }
    }

    /// <summary>
    /// Set processing result to <see cref="Text"/>.
    /// </summary>
    /// <param name="text">Processing result.</param>
    private void SetString(string text)
    {
        OcrDatas.text = text;
    }

    /// <summary>
    /// Represents a class that optical character recognition processing.
    /// </summary>
    public abstract class IOcrService : UWPBridgeService.IUWPBridgeService
    {
        public delegate void SetRecognizeText(string text);

        /// <summary>
        /// Gets or sets the action to be performed after optical character recognition processing.
        /// </summary>
        public SetRecognizeText OnRecognized;

        /// <summary>
        /// Perform optical character recognition 
        /// </summary>
        public abstract void Recognize();
    }
}