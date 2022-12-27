using Gtk;
using Microshaoft;

Application.Init();
var App = new Application("LBH.SerialPortTools", GLib.ApplicationFlags.None);
App.Register(GLib.Cancellable.Current);

var provider = new CssProvider();
StyleContext.AddProviderForScreen(Gdk.Screen.Default, provider, 800);

var window1 = new Window1("于斯人也");

window1.SetSizeRequest(400, 400);
window1.SetPosition
                (
                    WindowPosition.Center
                );
//mainWindow.Maximize();

window1.Show();
App.AddWindow(window1);

Application.Run();
Console.WriteLine($"Application.Run() finished!");
