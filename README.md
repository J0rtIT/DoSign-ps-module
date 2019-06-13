# README #

When this compiles: it will create a "DoSign.dll"

How to Add it into My Powershell's computers environment:


### What is this repository for? ###

* Quick summary
* Version
* [Learn Markdown](https://bitbucket.org/tutorials/markdowndemo)

### How do I get set up? ###

Quite easily, Open a powershell console and run this: $env:PSModulePath.Split(";")

This will bring something like this:
D:\Cloud\Dropbox\Documents\WindowsPowerShell\Modules
C:\Program Files\WindowsPowerShell\Modules
C:\WINDOWS\system32\WindowsPowerShell\v1.0\Modules
C:\Program Files\Intel\
C:\Program Files\WindowsPowerShell\Modules\
C:\Program Files (x86)\Microsoft SDKs\Azure\PowerShell\ResourceManager\AzureResourceManager\
C:\Program Files (x86)\Microsoft SDKs\Azure\PowerShell\ServiceManagement\
C:\Program Files (x86)\Microsoft SDKs\Azure\PowerShell\Storage\

So I'll take the 1st item, (basically  because "My Documents" folders is syncronized using Dropbox Just my way to not lose information).

In the 1st item we need to create a folder with the name of the Module, in this case is "DoSign" and move or copy all the files optained in the compiled folder there

So copying or moving this files:
DoSign.Dll
DoSigh.pdb
System.Management.Automation.dll

The final path would be : 
D:\Cloud\Dropbox\Documents\WindowsPowerShell\Modules\DoSign


Then open a new powershell console and do:
Import-Module DoSign

### Who do I talk to? ###

* Admin: Jose Ortega, Skype for business and emails : jortega@j0rt3g4.com
