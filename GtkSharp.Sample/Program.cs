using Gtk;
using Microshaoft;

Application.Init();
var App = new Application("AwesomeYuer", GLib.ApplicationFlags.None);
App.Register(GLib.Cancellable.Current);

var provider = new CssProvider();
StyleContext.AddProviderForScreen(Gdk.Screen.Default, provider, 800);

var mainWindow = new Window1("于斯人也AwesomeYuer");

mainWindow.SetSizeRequest(400, 400);
mainWindow.SetPosition
                (
                    WindowPosition.Center
                );
//mainWindow.Maximize();

mainWindow.Show();
App.AddWindow(mainWindow);

Application.Run();
Console.WriteLine($"Application.Run() finished!");
