namespace LocationDisplayer;

public partial class ExportPage : ContentPage
{
    public ExportPage(string text)
    {
        InitializeComponent();
        ExportEditor.Text = text;
    }

    private async void Close_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private async void Copy_Clicked(object sender, EventArgs e)
    {
        await Clipboard.Default.SetTextAsync(ExportEditor.Text);

        await DisplayAlert("Copied", "Data copied to clipboard", "OK");
    }
}