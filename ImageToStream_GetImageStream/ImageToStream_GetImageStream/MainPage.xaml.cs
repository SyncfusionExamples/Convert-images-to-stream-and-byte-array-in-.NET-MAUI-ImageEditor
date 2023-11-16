using Syncfusion.Maui.ImageEditor;

namespace ImageToStream_GetImageStream;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
    private async void OnImageSaving(object sender, ImageSavingEventArgs e)
    {
        var stream = await imageEditor.GetImageStream();
        e.Cancel = true;
        var bytes = GetImageStreamAsBytes(stream);
    }
    private byte[] GetImageStreamAsBytes(Stream input)
    {
        var buffer = new byte[16 * 1024];
        using (MemoryStream ms = new MemoryStream())
        {
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }

            return ms.ToArray();
        }
    }
}