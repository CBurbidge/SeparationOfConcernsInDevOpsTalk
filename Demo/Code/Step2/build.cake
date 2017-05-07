#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0

var target = Argument("target", "Default");

Task("Clean").Does(() => {
  CleanDirectories("./**/bin/Release");
});

Task("Build").IsDependentOn("Clean").Does(() => {
  MSBuild("./UsefulLibrary.sln",
      settings => settings.SetConfiguration("Release")
              .SetMSBuildPlatform(MSBuildPlatform.x64)
              .SetPlatformTarget(PlatformTarget.MSIL));
});

Task("Run_Tests").IsDependentOn("Build").Does(() => {
  NUnit3("./**/bin/Release/*.Tests.dll");
});

Task("Run_Long_Tests").IsDependentOn("Build").Does(() => {
  NUnit3("./**/bin/Release/*.LongRunningTests.dll");
});

Task("Default").IsDependentOn("Run_Tests").Does(() => {});
RunTarget(target);