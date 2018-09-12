// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

/// <summary>
///     Represents a class that optical character recognition processing.
/// </summary>
public abstract class OcrServiceBase : UWPBridgeService.IUWPBridgeService
{
    public delegate void SetRecognizeText(string text);

    /// <summary>
    ///     Gets or sets the action to be performed after optical character recognition processing.
    /// </summary>
    public SetRecognizeText OnRecognized;

    /// <summary>
    ///     Perform optical character recognition
    /// </summary>
    public abstract void Recognize();
}