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

		public string TextFromLibrary
		{
			get { return (string)GetValue(TextFromLibraryProperty); }
			set { SetValue(TextFromLibraryProperty, value); }
		}
		public static readonly DependencyProperty TextFromLibraryProperty =
			DependencyProperty.Register(nameof(TextFromLibrary), typeof(string), typeof(MainPage), new PropertyMetadata(""));

		public MainPage()
		{
			this.InitializeComponent();

#if (__ANDROID__ || __IOS__)
            Uno.UI.Toolkit.VisibleBoundsPadding.SetPaddingMask(PageGrid, Uno.UI.Toolkit.VisibleBoundsPadding.PaddingMask.All);
#endif

			// Get string resources from different (.resw) files
			
			var resourceLoader = ResourceLoader.GetForCurrentView();
			DefaultText = resourceLoader.GetString("SomeText");
			CustomText = resourceLoader.GetString("/Custom/SomeText");

#if __ANDROID__ || __IOS__
			TextFromLibrary = resourceLoader.GetString("/Library/SomeText");
#elif NETFX_CORE
			resourceLoader = ResourceLoader.GetForCurrentView("LibraryWithResw");
			TextFromLibrary = resourceLoader.GetString("Library/SomeText");
#endif
		}
	}
}
