using Gtk;
using LBH.SerialPortTools;
Application.Init();
var App = new Application("LBH.SerialPortTools", GLib.ApplicationFlags.None);
App.Register(GLib.Cancellable.Current);

CssProvider provider = new CssProvider();
//provider.LoadFromPath("sp.css");
StyleContext.AddProviderForScreen(Gdk.Screen.Default, provider, 800);

var mainWindow = new Window1();

//mainWindow.SetSizeRequest(400, 400);
//mainWindow.SetPosition
//                (
//                    WindowPosition.Center
//                );
//mainWindow.Maximize();
//mainWindow.SetIconFromFile("logo.png");
//mainWindow.Show();
App.AddWindow(mainWindow);

Application.Run();
Console.WriteLine($"Application.Run() finished!");
