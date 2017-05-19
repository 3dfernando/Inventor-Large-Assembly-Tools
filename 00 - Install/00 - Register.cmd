cd /d %~dp0
copy "PDFemMassa.dll" "C:\Program Files\Autodesk\Inventor 2014\bin\PDFemMassa.dll" /y 
copy "WinControls.ListView.dll" "C:\Program Files\Autodesk\Inventor 2014\bin\WinControls.ListView.dll" /y 
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe /codebase "C:\Program Files\Autodesk\Inventor 2014\bin\PDFemMassa.dll"

call cmd