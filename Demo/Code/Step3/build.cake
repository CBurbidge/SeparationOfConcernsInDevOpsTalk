#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#tool "nuget:?package=GitVersion.CommandLine"
var target = Argument("target", "Default");

// import the common functions
#load "common.csx"

var branchName = GitVersion().BranchName;
Information("Branch is {0}", branchName);

var buildDir = "./.build";
EnsureDirectoryExists(buildDir);
Task("Clean").Does(() => {
  CleanDirectories("./**/bin/Release");
  CleanDirectories(buildDir);
});

Task("Build").IsDependentOn("Clean").Does(() => {
  MSBuild("./UsefulLibrary.sln", settings => settings.SetConfiguration("Release"));
});

Task("Run_Tests").IsDependentOn("Build").Does(() => {
  NUnit3("./**/bin/Release/*.Tests.dll");
});

Task("Nuget_Beta").IsDependentOn("Run_Tests")
.WithCriteria(() => branchName == "develop")
.Does(() => {
  var ver = getVersionFromNuspecFile("./Package.nuspec");
  Information("Version is {0}", ver);
  NuGetPack("./Package.nuspec", new NuGetPackSettings { 
    OutputDirectory = buildDir,
    Version = (ver + "-beta")
  });
});

Task("Nuget").IsDependentOn("Nuget_Beta")
.WithCriteria(() => branchName == "master")
.Does(() => {
  NuGetPack("./Package.nuspec", new NuGetPackSettings { 
    OutputDirectory = buildDir 
  });
});

Task("Default").IsDependentOn("Nuget").Does(() => {});
RunTarget(target);