namespace Microshaoft
{
    using Gtk;
    using System.Reflection;

    public class Window1 : Window
    {
        public Window1(string title) : base(WindowType.Toplevel)
        {
            Title = title;
            
            Button button0 = new ("Button");
            button0.SetSizeRequest(80, 40);

            Entry entry1 = new ()
            {
                Text = Title
            };

            Fixed fix = new ();
            fix.Put(entry1, 20, 30);
            fix.Put(button0, 200, 30);



            MethodInfo methodInfo = null!;
            var assembly = Assembly.GetExecutingAssembly();
            var methodInfos = assembly
                        .GetTypes()
                        .Where
                            (
                                (x) =>
                                {
                                    methodInfo = x.GetMethod
                                                            (
                                                                "Main"
                                                                //, BindingFlags.Static
                                                            )!;
                                    var r = methodInfo != null;
                                    return r;
                                }
                            )
                        .Select
                            (
                                (x) =>
                                {
                                    return
                                        methodInfo;
                                }
                            );


            var buttonWidth = 400;
            var buttonHeight = 30;
            var x0 = 50;
            var y0 = 50;
            var x = x0;
            var y = y0;
            var margin = 10;
            var i = 0;
            foreach (var method in methodInfos)
            {
                Button button = new($"Sample({i + 1}): {method.DeclaringType!.FullName}");
                button.Clicked += (s, e) =>
                {
                    object?[]? args = null!;
                    var parameters = method
                                            .GetParameters();

                    var parametersLength = parameters.Length;
                    if (parameters.Length > 0)
                    { 
                        args = parameters.Select
                                                (
                                                    (x) =>
                                                    {
                                                        object o = null!;
                                                        return o;
                                                    }
                                                ).ToArray();

                    }
                    method.Invoke(null, args);
                };

                button.SetSizeRequest(buttonWidth, buttonHeight);
                button.GetSizeRequest(out var width, out var height);
                if (i % 3 != 0)
                {
                    x += width + margin;
                }
                else
                {
                    x = x0;
                    y += height + margin;                
                }
                fix.Put(button, x, y);
                i++;
            }




            Add(fix);

            button0.Clicked += (s, e) =>
            {

               
                var messageDialog = new MessageDialog
                                                (
                                                    this
                                                    , DialogFlags.Modal
                                                    , MessageType.Info
                                                    , ButtonsType.YesNo
                                                    , button0.Label
                                                );
                messageDialog.WidthRequest = 50;
                messageDialog.HeightRequest = 50;
                messageDialog.Title = button0.Label;
                messageDialog.Text = entry1.Text;
                var result = (ResponseType) messageDialog.Run();
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
