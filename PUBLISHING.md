# Publishing AndroidHelloWorld for Android

## Visual Studio 2026

1. Open `AndroidHelloWorld.sln`.
2. Select the `Release` solution configuration.
3. Right-click the `AndroidHelloWorld` project and select **Publish**.
4. Select the existing `FolderProfile` profile.
5. Publish the project.

The ARM64 output is written to:

`bin\Release\net10.0-android36.0\publish\android-arm64\`

## Command line

From the directory containing `AndroidHelloWorld.csproj`, run:

`dotnet publish AndroidHelloWorld.csproj -c Release -p:PublishProfile=FolderProfile`

## Signing

Release builds import signing settings from `release-signing\AndroidHelloWorld.signing.props` when that local file exists. The signing key and credentials in `release-signing\` are excluded from source control.

Back up the entire `release-signing\` directory securely. Every future APK update must use the same key. Losing the key or credentials prevents new builds from updating an installed copy of the app.

The installable output is:

`bin\Release\net10.0-android36.0\publish\android-arm64\com.example.androidhelloworld-Signed.apk`
