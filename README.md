# Android Hello World

A simple Android Hello World application built with .NET MAUI.

## Requirements

- .NET 10 SDK with the MAUI Android workload
- Android SDK 36
- Visual Studio 2026 or the .NET CLI
- Android 7.0 (API 24) or later

The configured release publish target is Android ARM64.

## Build

```powershell
dotnet build AndroidHelloWorld.csproj
```

## Publish

```powershell
dotnet publish AndroidHelloWorld.csproj -c Release -p:PublishProfile=FolderProfile
```

The installable signed APK is written to:

```text
bin\Release\net10.0-android36.0\publish\android-arm64\com.example.androidhelloworld-Signed.apk
```

Release signing is loaded from the local `release-signing` directory. That directory is excluded from Git and must never be committed. Back it up securely because Android updates must be signed with the same key.
