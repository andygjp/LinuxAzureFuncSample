# LinuxAzureFuncSample

A Hello World Azure Function that is deployed, using `az` and Azure Pipeline, to Windows and Linux based hosts.

I created this to help diagnose why [deploying to the Linux based host failed](https://github.com/Azure/azure-cli/issues/20390).
I originally thought there was a problem with `az functionapp deployment source config-zip`, but it turned out 
it was down to how I was creating the zip file.

Powershells `Compress-Archive` doesn't archive hidden files. (The [issue](https://github.com/PowerShell/Microsoft.PowerShell.Archive/issues/66)
is fixed but I'm still waiting for it to be [released](https://www.powershellgallery.com/packages/Microsoft.PowerShell.Archive/1.2.5).)

My workaround:

```powershell
Get-ChildItem -Path ./output/Sample-Win/ -Force | Compress-Archive -DestinationPath ./output/Sample-Win-Full.zip
```

Archived the hidden files, but it didn't include the folder structure. It seems that doesn't cause an issue on
Windows based hosts, but it does on Linux based hosts.

In the end, the solution was to use 7zip instead.
