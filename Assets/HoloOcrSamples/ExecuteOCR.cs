// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.UI;

public partial class ExecuteOCR : MonoBehaviour, IInputClickHandler
{
    /// <summary>
    ///     Execution interval of optical character recognition processing(number of frames).
    /// </summary>
    private static readonly int FrameInterval = 120;

    /// <summary>
    ///     Unitty Text Object
    /// </summary>
    public Text OcrDatas;

    /// <summary>
    ///     Gets or sets the instance of <see cref="OcrServiceBase" />.
    /// </summary>
    public OcrServiceBase ServiceBase { set; private get; }

    // Use this for initialization
    private void Start()
    {
#if UNITY_EDITOR
        UWPBridgeService.Instance.AddService<OcrServiceBase>(new OcrServiceBaseStub());
#endif
        ServiceBase = UWPBridgeService.Instance.GetService<OcrServiceBase>();
        ServiceBase.OnRecognized = SetString;
    }

    float _timer = 0;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < 5f)
        {
            return;
        }
        _timer = 0;

        
        ServiceBase.Recognize();

    }

    /// <summary>
    ///     Set processing result to <see cref="Text" />.
    /// </summary>
    /// <param name="text">Processing result.</param>
    private void SetString(string text)
    {
        OcrDatas.text = text;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        //Perform optical character recognition
        ServiceBase.Recognize();
    }
}