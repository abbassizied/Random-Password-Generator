using System.ComponentModel;

namespace RandomPasswordGen;

public partial class ResultPage : ContentPage 
{
    //public string receivedPwd { get; private set; } 

    public ResultPage(string receivedPwd)
	{
		InitializeComponent();
        BindingContext = this;
        genPassword.Text = receivedPwd;
    }

    private void OnCopyPasswordClicked(object sender, EventArgs e)
    {
        CopyTextToClipboard(genPassword); // Replace "entry" with your Entry instance name
        copiedPassword.Text = "Copied!";
    }

    private async void CopyTextToClipboard(Entry entry)
    {
        if (string.IsNullOrEmpty(entry.Text))
        {
            return; // Handle empty text case (optional)
        }

        await Clipboard.Default.SetTextAsync(entry.Text);
    }
}