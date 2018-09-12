// Copyright(c) 2018 Takahiro Miyaura
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using System;

public class OcrServiceBaseStub : OcrServiceBase
{
    /// <summary>
    ///     Perform optical character recognition
    /// </summary>
    public override void Recognize()
    {
        if (OnRecognized != null) OnRecognized("Sample" + DateTime.Now);
    }
}