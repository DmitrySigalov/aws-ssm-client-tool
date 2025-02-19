# aws-ssm-client

[![Build](https://github.com/dmitrysigalov/aws-ssm-cli/workflows/Build/badge.svg)](https://github.com/dmitrysigalov/aws-ssm-cli/actions/workflows/build.yml)
[![License](https://badgen.net/github/license/dmitrysigalov/aws-ssm-cli)](https://github.com/dmitrysigalov/aws-ssm-cli/blob/main/LICENSE)

A dotnet open source which provides aws system manager using tool

## :gift: Features:
- Best practice for the environment variables names according to system parameters configured in AWS system manager store
- Configuration of ssm paths
- Synchronization of environment variables with system parameters values
- View current synchronization state of environment variables

## :sunny: .NET Runtime
This project is built with DotNet 8.0 and is mandatory to install before using.

You can find and install it [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

Verify your dotnet version:

![image](https://user-images.githubusercontent.com/31489258/153608978-cced639e-af42-4485-8c15-5333325b0883.png)

## :gift: Installation

The Installer publishes the code to the machine applications directory and adds it to your system's path.

Installation steps:
1. Download latest release to local machine
2. Un-puck sources (installer and src folders)

- ### Windows
  - Run Installer.exe (as Administrator)

- ### macOS
  - It will be easier to run the installer correctly with the following command, while in its directory (cd command):
```
sudo dotnet Installer.dll
```

3. Open terminal / cmd and run:
```
aws-ssm-cli help
```
or
```
ascli help
```
If everything ran smoothly, you should see the list of supported commands

## :tada: Usage

The user should be authenticated (selected role) according to aws environment with access to AWS System Manager.
Recommended external tools:
- [okta-aws-cli](https://github.com/nizanrosh/okta-aws-cli)
- ...

Command line:
```cmd
aws-ssm-cli
```
FYI - The CLI can be executed using the commands `ascli` or `aws-ssm-cli`.

## :clipboard: Profile configuration

First time for the profile configuration recommended to run/select command:
```cmd
aws-ssm-cli config
```
- Set profile name - "default"
- Recommendation to set prefix for the environment variable(s) - "SSM_"
- Add ssm-path 
- You can export already valid profile configuration in the json format (example):
```json
{
  "EnvironmentVariablePrefix": "SSM_",
  "SsmPaths": [
    "/demo1",
    "/demo2"
  ]
}
```
- Complete/exit configuration

## :books: Commands using

### `set-env`
Using to synchronize environment variables with SSM parameters.
#### macOS
For the activation of environment variables required to recreate a process (terminal, Rider, ...)

### `get-env`
Using to view current synchronization status of the environment with SSM parameters

### `clean-env`
Using to clean environment variables

### `view`
Using for the easy configuration of infrastructure parameters (mapping ssm parameters to and environment variable names)


## :gift: New Release Creation Process

- Update VersionPrefix (major, minor and build numbers) in the file [Directory.Build.props](Directory.Build.props).
- After merge into main
- Create a new release:
  - Create new tag contains prefix 'v' and VersionPrefix. Example - 'v1.0.0'
  - Release name is based on created tag name
  - Mark a new release as latest
- Every day command line check if changed a new latest release and indicate about changes with instructions.


## License

This project is licensed under the [MIT License](https://github.com/dmitrysigalov/aws-ssm-cli/blob/main/LICENSE).
