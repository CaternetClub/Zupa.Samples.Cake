# Cake Example

This example repo shows how to use [Cake](https://cakebuild.net) to build a simple .NET Core solution.

## Adding Cake

1. Given a new solution, add the Cake bootloader by using this PowerShell command:

```ps
Invoke-WebRequest https://cakebuild.net/download/bootstrapper/windows -OutFile build.ps1
```

2. Then create the Cake build script, by adding a new file called `build.cake`. This script is made of a series of tasks, each run a specific part of the build process, such as restoring or running unit tests. This repo contains a [more complicated example](/build/build.cake), however a simple build script with just one task would look like this:

```csharp
var target = Argument("target", "Default");

Task("Default").Does(() =>
{
    DotNetCoreBuild(
        "Zupa.POC.Cake.sln", 
        new DotNetCoreBuildSettings
        {
            Configuration = "Release"
        });
});

RunTarget(target);
```

## Running Cake

The Cake script can be run, either locally or on a build server using the following PowerShell and any failures will be reported in the console:

```ps
.\build\build.ps1
```

## Cake at Zupa

Following our coding standards, we put both the bootloader and build script in the `/build` folder and update the `.gitignore` file to exclude any Cake tools that are downloaded, as these can be restored on a subsequent run.