using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Threading;
using System.Threading.Tasks;
using Android.Content;

namespace FileFolders
{
	[Activity(MainLauncher = true, Theme = "@style/Splash", NoHistory = true)]
	public class MainActivity : Activity
	{
		protected override void OnResume()
		{
			base.OnResume();

			Task.Run(async () =>
			{
				await Task.Delay(5000); //simulate loading delay
				StartActivity(new Intent(Application.Context, typeof(FoldersActivity)));
			});
		}
	}


	[Activity(Label = "Folders", Icon = "@mipmap/icon")]
	public class FoldersActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);

			FindViewById<TextView>(Resource.Id.filesDir).Text = FilesDir.AbsolutePath;
			FindViewById<TextView>(Resource.Id.picturesDir).Text = GetExternalFilesDir(Android.OS.Environment.DirectoryPictures).AbsolutePath;
			FindViewById<TextView>(Resource.Id.documentsDir).Text = GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments).AbsolutePath;
			                       
		}

		protected override void OnResume()
		{
			base.OnResume();
		}
	}
}

