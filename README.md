# HoloOcrSamples
This project is a sample that perform optical character recognition by HoloLens

## Develop Environment

* Windows 10 Pro
* Windows SDK 10.0.17134.0
* Visual Studio 2017 
* Unity 2017.2.1p2
* Mixed Reality Toolkit 2017.2.1.0

## Export Form Unity

1. Open This Unity project(HoloOcrSamples). 

2. Open [Mixed Reality Toolkit]-[Configure]-[Apply Mixed Reality Project Settings]

3. In the Apply Mixed Reality Project Settings dialog,and check:

![Apply Mixed Reality Project Settings](https://github.com/TakahiroMiyaura/HoloOcrSamples/blob/Unity2017.2.X/External/ReadMeImage/ApplyMixedRealityProjectSettings.png)

 - Target Windows Universal UWP
 - Enable XR
 - Build for Direct3D
 - Enable .NET scripting backend

4. Select Apply

5. Open [Mixed Reality Toolkit]-[Configure]-[Apply UWP Capability Settings]

6. In the Apply UWP Capability Settings dialog,and check:

![Apply UWP Capability Settings](https://github.com/TakahiroMiyaura/HoloOcrSamples/blob/Unity2017.2.X/External/ReadMeImage/ApplyUWPCapabilitySettings.png)

 - Microphone
 - Webcam

7. Select Apply

8. Open the File menu and select Build Settings...

9. In the Build Settings dialog, choose the following options to export for HoloLens:

 - **Scene In Build:**HoloOcrSamples
 - **Platform:**Windows Store
 - **SDK:**Universal 10
 - **UWP Build Type:**D3D

10. Select Build

11. Select the folder "UWP".

12. Open UWP/HoloOcrSamples.sln in Visual Studio

13. Include UWP/HoloOcrSamples/Service/OcrService.cs in HoloOcrSamples(Universal Windows) Project

14. Build Solution.

15. Deploy Hololens!
