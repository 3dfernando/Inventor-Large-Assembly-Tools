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