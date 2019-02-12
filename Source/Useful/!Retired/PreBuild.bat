rem echo *** Useful.dll Prebuild ***
rem echo *** Generating config class ***
rem "%HOMEDRIVE%\Program Files\Microsoft Visual Studio 8\SDK\v2.0\Bin\xsd.exe" /classes "%~1Config\Useful.Config.xsd" /namespace:"Useful" /out:"%~1Config" /nologo
rem echo *** End Generating config class ***
rem echo *** End Useful.dll Prebuild ***

echo *** Useful.Console Prebuild ***
echo *** Getting Discovery ***
rem "C:\Program Files\Microsoft Visual Studio 8\SDK\v2.0\Bin\disco.exe" /out:"%~1\Web References" /nologo "http://zeus/UsefulWeb/DataService.asmx"
echo *** End Getting Discovery ***

echo *** Generating class ***
rem "C:\Program Files\Microsoft Visual Studio 8\SDK\v2.0\Bin\wsdl.exe" /out:"%~1\Web References\DataService.cs" /namespace:"Useful.Console" /nologo "%~1Web References\DataService.wsdl" /appsettingurlkey:"webserviceUrl"
echo *** End Generating class ***
echo *** End Useful.Console Prebuild ***