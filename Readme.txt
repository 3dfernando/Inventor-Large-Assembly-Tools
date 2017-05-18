================================ENGLISH=================================
In order to install the last compiled version, copy the two *.dll files under
the folder 00 - Install\ to the folder \Program Files\Autodes\Inventor 20XX\bin

The DLLs need to be registered. I wrote the routine "00 - Register.cmd" to do that but 
it is programmed for Inventor 2014. You can edit the .cmd file through Notepad to change 
for the correct the file paths.

In the case you don't trust the .cmd or it's not working, here's the procedure to install it manually:

1. Make sure you have the Microsoft .NET Framework v4.0.30319 or newer
2. Make sure you copied the files to the bin folder as described above
3. Open cmd as administrator
4. type in cmd the text below and press Enter:
	C:\Windows\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe /codebase "C:\Program Files\Autodesk\Inventor 20XX\bin\PDFemMassa.dll"

	*keep the quotes and replace XX by the year of your Inventor install

5. A message like "Type registration performed successfuly" should appear.
In case it doesn't or it throws an error, make sure you executed cmd as admin. Also make sure Inventor is closed.

6. If the installation was successful, when you open Inventor the buttons "Batch Renaming" and "Batch Export" will appear under the 
	tools ribbon and in the main menu.

Any questions contact me at fzigunov@gmail.com

***DISCLAIMER:***
THIS TOOL WAS HOME-BREW TO SOLVE A COMPANY'S PROBLEM, WAS ONLY TESTED ON INVENTOR 2014 AND 2016 SYSTEMS WITH WIN7. IT MIGHT HAVE
BUGS OR EXCEPTIONS FOR OTHER OPERATING SYSTEMS. PLEASE USE IT WITH CAUTION AND MAKE SURE TO ALWAYS BACKUP YOUR DATA. I CANNOT BE
HELD RESPONSIBLE FOR ANY DESIGN OR DATA LOSS!


Author: Fernando Zigunov - Creative Commons 3.0 License
Please if you would like to share or build onto this code, do it referring to this Github page or to 
my blog at http://zigunov.com so I can have feedback from other users. That'll also motivate me to do more stuff like this ^.^


================================PORTUGUÊS=================================
Para instalar a última versão compilada, é necessário copiar 
os dois *.dll dentro de "00 - Instalar" para a pasta \Arquivos de Programas\Autodesk\Inventor 20XX\bin

Além disso, é preciso registrar as dlls. A rotina "00 - Register.cmd" foi escrita com essa
finalidade, mas ela está programada para o Inventor 2014. Se você quiser programar para outra versão,
abra-a no bloco de notas e edite o caminho da pasta do Inventor.

Abaixo o que deve ser feito para instalar, caso desconfie ou não queira usar o *.cmd:

1. Abra o command prompt (Iniciar, pesquise por "cmd", execute como administrador)
2. digite:
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe /codebase "C:\Program Files\Autodesk\Inventor 2014\bin\PDFemMassa.dll"

<Para isto você terá que ter o Microsoft .NET Framework v4.0.30319 ou superior.>

3. Deve aparecer uma mensagem "Registro de tipos efetuado com sucesso". Caso não apareça, verifique se executou como admin. Também tem que estar com o Inventor fechado nesta etapa.
4. Abra o Inventor e verifique se os novos botões da ferramenta aparecem nas barras de ferramentas Ribbon e no menu principal.

Dúvidas enviar para fzigunov@gmail.com

***NÃO ME RESPONSABILIZO POR NENHUMA PERDA DE DADOS DEVIDO AO USO DESTA FERRAMENTA!!! USE-A COM CAUTELA E CONSCIÊNCIA!****


Autor: Fernando Zigunov - Licença Creative Commons 3.0