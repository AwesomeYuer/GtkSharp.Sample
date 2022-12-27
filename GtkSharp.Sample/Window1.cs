using Gtk;
namespace Microshaoft
{
    public class Window1 : Window
    {
        public Window1(string title) : base(WindowType.Toplevel)
        {
            Title = title;
            var button = new Button()
            {
                Label = "戳我呀"
                , Visible = true
                , WidthRequest = 20
                , HeightRequest = 20
            };
            button.Clicked += (s, e) => 
            {
                var md = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.YesNo, button.Label);
                md.WidthRequest = 50;
                md.HeightRequest = 50;
                md.Title = button.Label;
                var result = (ResponseType) md.Run();
                Console.WriteLine(result);
                md.Destroy();
            };

            Add(button);
            
            DeleteEvent += (s, e) =>
            { 
                Application.Quit();
            };
        }
    }
}
