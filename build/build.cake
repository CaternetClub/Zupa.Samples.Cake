var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var solutionFolder = "../";
var solutionFile = solutionFolder + "Zupa.POC.Cake.sln";

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build");

Task("Clean")
    .Does(() => {
        DotNetCoreClean(solutionFile);
});

Task("Restore")
    .Does(() => {
        DotNetCoreRestore(solutionFile);
});

Task("Build")
    .Does(() => {
        DotNetCoreBuild(
            solutionFile, 
            new DotNetCoreBuildSettings
            {
                Configuration = configuration
            });
});

RunTarget(target);