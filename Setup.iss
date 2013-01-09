[Files]
Source: ..\Muhimbi.PDFConverter.6.1.0.69\PDF Converter\Windows Service Installer\Setup.msi; DestDir: {app}
Source: BethesdaEConsentsSetup\Debug\BethesdaEConsentsSetup.msi; DestDir: {app}
Source: BethesdaEConsentsSetup\Debug\setup.exe; DestDir: {app}
Source: BethesdaConsentFormWCFSvcSetup.msi; DestDir: {app}
Source: WCFsetup.exe; DestDir: {app}
[Run]
Filename: {app}\setup.exe; Flags: runmaximized
Filename: {app}\Setup.msi; Flags: shellexec runmaximized
Filename: {app}\WCFsetup.exe; Flags: waituntilidle
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
