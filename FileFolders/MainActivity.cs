using Android.App;
using Android.Widget;
using Android.OS;

namespace FileFolders
{
	[Activity(Label = "FileFolders", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);

			FindViewById<TextView>(Resource.Id.filesDir).Text = FilesDir.AbsolutePath;
			FindViewById<TextView>(Resource.Id.picturesDir).Text = GetExternalFilesDir(Environment.DirectoryPictures).AbsolutePath;
			FindViewById<TextView>(Resource.Id.documentsDir).Text = GetExternalFilesDir(Environment.DirectoryDocuments).AbsolutePath;
			                       
		}
	}
}

