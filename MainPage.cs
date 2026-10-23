namespace AndroidHelloWorld;

public class MainPage : ContentPage
{
    public MainPage()
    {
        Title = "Hello";

        Content = new VerticalStackLayout
        {
            Padding = 24,
            Spacing = 12,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            Children =
            {
                new Label
                {
                    Text = "Hello, World!",
                    FontSize = 32,
                    HorizontalOptions = LayoutOptions.Center
                }
            }
        };
    }
}