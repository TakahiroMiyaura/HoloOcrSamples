# HoloOcrSamples
This project is a sample that perform optical character recognition by HoloLens

## Develop Environment

* Windows 10 Pro
* Windows SDK 10.0.14393.0
* Visual Studio 2015 Community Edition update 3
* Unity 5.5.0P2 Personal
* HoloToolkit 1.5.5.0

## Export Form Unity

1. Open This Unity project(HoloOcrSamples). 

2. Open [Mixed Reality Toolkit]-[Configure]-[Apply UWP Capability Settings]

3. In the Apply UWP Capability Settings dialog,and check:

![Apply UWP Capability Settings](https://github.com/TakahiroMiyaura/HoloOcrSamples/blob/master/External/ReadMeImage/ApplyUWPCapabilitySettings.png)

 - Microphone
 - Webcam

4. Select Apply

5. Open the File menu and select Build Settings...

6. In the Build Settings dialog, choose the following options to export for HoloLens:

 - **Scene In Build** : HoloOcrSamples
 - **Platform** : Windows Store
 - **SDK** : Universal 10
 - **UWP Build Type** : XAML
 
7. Open Player Settings...

8. Select the Settings for Windows Store tab

9. Expand the Other Settings group

In the Rendering section, check the Virtual Reality Supported checkbox to add a new Virtual Reality Devices list and confirm "Windows Holographic" is listed as a supported device.

10. Select Build

11. Select the folder "UWP".

12. Open UWP/HoloOcrSamples.sln

13. Build Solution.

14. Deploy Hololens!
