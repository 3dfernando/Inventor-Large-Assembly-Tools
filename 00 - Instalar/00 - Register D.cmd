cd /d %~dp0
copy "PDFemMassa.dll" "D:\Program Files\Autodesk\Inventor 2014\bin\PDFemMassa.dll" /y 
copy "WinControls.ListView.dll" "D:\Program Files\Autodesk\Inventor 2014\bin\WinControls.ListView.dll" /y 
D:\Windows\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe /codebase "D:\Program Files\Autodesk\Inventor 2014\bin\PDFemMassa.dll"

call cmd