# SimplePingListener

This application listens the port configured (in the source code), so services that monitor your machine uptime can pick it up without having to install  a seperate webserver (IIS, Apache2, NGINX, etc.) for such simple function. Do not forget to port-forward the selected port in your operating system & network devices!

I've only tested it on a handful Windows machines, because that's what I use the most.

There is no license attached to this code, feel free to edit/publish it to your liking. :)

## How-To Compile

### Windows
Requires: [.Net 6.0](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-6.0.100-windows-x64-installer)

Run `Build_Windows.bat` and then navigate into the /bin folder and select the compiled release folder (debug/release). Afterwards launch it by clicking the .exe

## Contribute
Found an exploit or bug? Feel free to create a GitHub issue or make a pull-request with your fix!
