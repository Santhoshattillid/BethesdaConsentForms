[Files]
Source: ..\..\Muhimbi.PDFConverter.6.1.0.69\PDF Converter\Windows Service Installer\Setup.msi; DestDir: {tmp}
Source: ..\BethesdaEConsentsSetup\Debug\BethesdaEConsentsSetup.msi; DestDir: {tmp}
Source: ..\BethesdaEConsentsSetup\Debug\setup.exe; DestDir: {tmp}
Source: ..\BethesdaConsentFormWCFSvcSetup\Debug\BethesdaConsentFormWCFSvcSetup.msi; DestDir: {tmp}
Source: Styles\Office2007.bmp; DestDir: {tmp}
Source: Styles\Office2007.cjstyles; DestDir: {tmp}
Source: Styles\Office2007Gray.bmp; DestDir: {tmp}
Source: Styles\Vista.cjstyles; DestDir: {tmp}
Source: Styles\WinXP.Luna.cjstyles; DestDir: {tmp}
Source: ISSkin.dll; DestDir: {tmp}
Source: ISSkinU.dll; DestDir: {tmp}
Source: ..\SequenceInstaller\bin\Debug\SequenceInstaller.exe; DestDir: {tmp}
Source: ..\..\..\..\..\..\..\Program Files (x86)\Telerik\RadControls for WinForms Q3 2012\Bin\Telerik.WinControls.dll; Flags: regserver noregerror gacinstall; StrongAssemblyName: Telerik; DestDir: {sys}
Source: ..\..\..\..\..\..\..\Program Files (x86)\Telerik\RadControls for WinForms Q3 2012\Bin\Telerik.WinControls.Themes.Office2007Black.dll; Flags: regserver noregerror gacinstall; StrongAssemblyName: Telerik; DestDir: {sys}
Source: ..\..\..\..\..\..\..\Program Files (x86)\Telerik\RadControls for WinForms Q3 2012\Bin\Telerik.WinControls.UI.dll; Flags: regserver noregerror gacinstall; StrongAssemblyName: Telerik; DestDir: {sys}
Source: ..\..\..\..\..\..\..\Program Files (x86)\Telerik\RadControls for WinForms Q3 2012\Bin\TelerikCommon.dll; Flags: regserver noregerror gacinstall; StrongAssemblyName: Telerik; DestDir: {sys}

[Run]
Filename: {tmp}\SequenceInstaller.exe

[Setup]
VersionInfoVersion=1.0
VersionInfoCompany=ApptechBizz
OutputDir=C:\Users\santhosh\Desktop\My Works\Bethesda\BethesdaConsentForms
OutputBaseFilename=BethesdaE-Consents
AppName=Bethesda E-Consents
AppVerName=1.0
CreateAppDir=false
DisableProgramGroupPage=true
UsePreviousGroup=false
DisableReadyMemo=true
DisableReadyPage=true
AppPublisher=ApptechBizz
AppVersion=1.0
[Dirs]
Name: {tmp}\Styles

[Code]
// Importing LoadSkin API from ISSkin.DLL
procedure LoadSkin(lpszPath: String; lpszIniFileName: String);
external 'LoadSkin@files:isskin.dll stdcall';

// Importing UnloadSkin API from ISSkin.DLL
procedure UnloadSkin();
external 'UnloadSkin@files:isskin.dll stdcall';

// Importing ShowWindow Windows API from User32.DLL
function ShowWindow(hWnd: Integer; uType: Integer): Integer;
external 'ShowWindow@user32.dll stdcall';

function InitializeSetup(): Boolean;
begin
	ExtractTemporaryFile('Office2007.cjstyles');
	LoadSkin(ExpandConstant('{tmp}\Office2007.cjstyles'), 'NormalBlack.ini');
	Result := True;
end;

procedure DeinitializeSetup();
begin
	// Hide Window before unloading skin so user does not get
	// a glimse of an unskinned window before it is closed.
	ShowWindow(StrToInt(ExpandConstant('{wizardhwnd}')), 0);
	UnloadSkin();
end;
