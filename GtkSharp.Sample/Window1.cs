namespace Microshaoft
{
    using Gtk;
    public class Window1 : Window
    {
        public Window1(string title) : base(WindowType.Toplevel)
        {
            Title = title;
            
            Button button1 = new ("Button");
            button1.SetSizeRequest(80, 40);

            Entry entry1 = new ()
            {
                Text = Title
            };

            Fixed fix = new ();
            fix.Put(entry1, 20, 30);
            fix.Put(button1, 200, 30);
            Add(fix);

            button1.Clicked += (s, e) =>
            {
                var messageDialog = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.YesNo, button1.Label);
                messageDialog.WidthRequest = 50;
                messageDialog.HeightRequest = 50;
                messageDialog.Title = button1.Label;
                messageDialog.Text = entry1.Text;
                var result = (ResponseType)messageDialog.Run();
                Console.WriteLine(result);
                messageDialog.Destroy();
            };

            DeleteEvent += (s, e) =>
            { 
                Application.Quit();
            };
            ShowAll();
        }
    }
}
