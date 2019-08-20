# HOW TO USE THIS MODULE

When this compiles: it will create a "DoSign.dll"

How to Add it into My Powershell's computers environment:

## What is this repository for?
* It's done to sign packages and strings from strings (to authenticate twitter or facebook calls, and lately "bitso calls" or anything that requires HMAC signature.

* Version : 2.0

## How do I get set up? ###

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
* DoSign.Dll
* DoSigh.pdb
* System.Management.Automation.dll

The final path would be : 
```Powershell
D:\Cloud\Dropbox\Documents\WindowsPowerShell\Modules\DoSign
```

Then open a new powershell console and do:

```Powershell
Import-Module DoSign
```

## What are the Cmdlets that this Module gives me?
4 Cmdlets so far:
- **Get-Signed** Signature any string using sha256,sha384,sha512,sha1 with a given key or a random one.
- **Convert-NowtoSeconds** Convert now Datetime into seconds
- **Convert-TimeFromSeconds** Convert a given time into seconds
- **Convert-TimetoSeconds** Convert a time in seconds into date.

## Who do I talk to if I need help? ###

###Admin: Jose Ortega, Skype for business and emails : jortega@faboit.com
