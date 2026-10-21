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

The project imports signing settings from
`release-signing/AndroidHelloWorld.signing.props` when that local file exists.
Create that private MSBuild props file with a `PropertyGroup` conditioned on
`'$(Configuration)' == 'Release'`, setting:

- `AndroidKeyStore` to `true`
- `AndroidSigningKeyStore` to the absolute path of your keystore
- `AndroidSigningKeyAlias` to your signing alias
- `AndroidSigningStorePass` to `env:ANDROID_KEYSTORE_PASSWORD`
- `AndroidSigningKeyPass` to `env:ANDROID_KEY_PASSWORD`

Set those two password environment variables before publishing. Generate a
keystore with the JDK's interactive `keytool -genkeypair` command if you do not
already have one. Keep the keystore inside `release-signing/` or another secure
location outside the repository. The key and private props must never be committed.

Without this configuration, the CLI can still publish for build verification, but
the `-Signed.apk` uses the SDK's development key, not a production signing key.
The adjacent `com.example.androidhelloworld.apk` is unsigned.

Back up the entire `release-signing\` directory securely. Every future APK update must use the same key. Losing the key or credentials prevents new builds from updating an installed copy of the app.

The installable output is:

`bin\Release\net10.0-android36.0\publish\android-arm64\com.example.androidhelloworld-Signed.apk`

## GitHub releases

Configure these repository Actions secrets using your existing production
keystore (or a new, securely backed-up key for the first release):

- `ANDROID_KEYSTORE_BASE64`: the base64-encoded keystore file
- `ANDROID_KEY_ALIAS`: the alias in that keystore
- `ANDROID_KEYSTORE_PASSWORD`: the keystore password
- `ANDROID_KEY_PASSWORD`: the private key password

After merging and verifying CI, create a tag beginning with `v`, such as `v1.0.0`,
on the commit you want to release, and push the tag to GitHub. The workflow builds
both configurations, signs and verifies the ARM64 APK with the supplied key, and
publishes it as a GitHub release asset. Missing secrets fail the release job
without publishing a development-signed APK. Pull request builds never use these
secrets and cannot publish releases.

Increment `ApplicationVersion` in the project for every Android update and set
`ApplicationDisplayVersion` to the corresponding user-visible version before
tagging. GitHub release publishing does not submit the app to Google Play.
