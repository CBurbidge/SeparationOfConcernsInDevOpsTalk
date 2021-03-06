
function step($num){
    $dir = "C:\Dev\SeperationOfConcernsInDevops\Demo"
    $lib = "$dir\UsefulLibrary"
    
    Switch ($num) 
    {
        0{ 
            rm "$lib\build.ps1"
            rm "$lib\build.cake"
            rm "$lib\common.csx"
            rm "$lib\TestResult.xml"
            rm "$lib\tools" -Recurse 
        }         
        1{ Write-host "Hello world" } 
        2{ Write-host "Basic use case, multiple targets" } 
        3{ 
            Write-host "More involved use case, git interaction"
            git checkout master
         } 
        4{ 
            Write-host "an error!"
            git checkout develop
         } 
    }
    copy-item "$dir\Code\Step$num\*" $lib
    
}
