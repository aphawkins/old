@echo off
if %1==NET11 (
	echo ".NET 1.1"
	call "%VS71COMNTOOLS%vsvars32.bat"
)
if %1==NET20 (
	echo ".NET 2.0"
	call "%VS100COMNTOOLS%vsvars32.bat"
)
ilasm ThrowerLib.il /dll
if %1==NET11 (
	md NET11
	move ThrowerLib.dll NET11 
)
if %1==NET20 (
	md NET20
	move ThrowerLib.dll NET20 
)