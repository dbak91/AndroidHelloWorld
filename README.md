# Android Hello World

A simple Android Hello World application built with .NET MAUI.

## Requirements

- .NET 10 SDK with the MAUI Android workload
- Android SDK 36
- JDK 21 (`JAVA_HOME` should point to it)
- Visual Studio 2026 or the .NET CLI
- Android 7.0 (API 24) or later

The configured release publish target is Android ARM64.

## Build

```sh
dotnet workload install maui-android
dotnet build AndroidHelloWorld.sln -c Debug
```

## Debug

Open `AndroidHelloWorld.sln` in Visual Studio with the .NET MAUI workload installed.
Select **Debug**, select an Android emulator or a USB-connected device with USB
debugging enabled, set a breakpoint in `MainPage.xaml.cs`, and press **F5**.

To install and launch from the CLI on a running emulator or connected device:

```sh
dotnet build AndroidHelloWorld.csproj -c Debug -t:Run
```

The CLI command launches the app; use Visual Studio to attach the managed debugger.
For a self-contained debug APK that can be installed without the IDE's fast
deployment, build with `-p:EmbedAssembliesIntoApk=true`.
Release builds are not debuggable.

## Publish

```powershell
dotnet publish AndroidHelloWorld.csproj -c Release -p:PublishProfile=FolderProfile
```

The installable signed APK is written to:

```text
bin\Release\net10.0-android36.0\publish\android-arm64\com.example.androidhelloworld-Signed.apk
```

Without a private signing configuration, .NET uses a development key even in
Release. Do not distribute that APK as a production release. See
[PUBLISHING.md](PUBLISHING.md) for private signing and GitHub release setup.

## CI and releases

The **Android build and release** workflow builds Debug and ARM64 Release on
pushes, pull requests, and manual runs. Download `android-debug` for an installable
development APK, or `android-release-unsigned` for an APK that needs signing.
Tags beginning with `v` also publish a signed GitHub release when the signing
secrets documented in [PUBLISHING.md](PUBLISHING.md) are configured.
