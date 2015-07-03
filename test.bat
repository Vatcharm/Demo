@echo off
packages\xunit.runner.console.2.0.0\tools\xunit.console ^
	Demo\bin\Debug\Demo.dll ^
	-parallel all ^
	-html Result.html ^
	-nologo -quiet
@echo on 