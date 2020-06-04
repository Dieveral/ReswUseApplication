using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ReswUseApplication
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public string DefaultText
		{
			get { return (string)GetValue(DefaultTextProperty); }
			set { SetValue(DefaultTextProperty, value); }
		}
		public static readonly DependencyProperty DefaultTextProperty =
			DependencyProperty.Register(nameof(DefaultText), typeof(string), typeof(MainPage), new PropertyMetadata(""));

		public string CustomText
		{
			get { return (string)GetValue(CustomTextProperty); }
			set { SetValue(CustomTextProperty, value); }
		}
		public static readonly DependencyProperty CustomTextProperty =
			DependencyProperty.Register(nameof(CustomText), typeof(string), typeof(MainPage), new PropertyMetadata(""));

		public MainPage()
		{
			this.InitializeComponent();

			var resourceLoader = ResourceLoader.GetForCurrentView();
			DefaultText = resourceLoader.GetString("SomeText");
			CustomText = resourceLoader.GetString("/Custom/SomeText");
		}
	}
}
