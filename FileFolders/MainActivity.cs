using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using System.IO;

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

			FindViewById<TextView>(Resource.Id.filesDir).Text =
				FilesDir.AbsolutePath;

			FindViewById<TextView>(Resource.Id.appfilesDir).Text =
				Application.Context.FilesDir.AbsolutePath;

			FindViewById<TextView>(Resource.Id.externalfilefolderprivate).Text =
				Application.Context.GetExternalFilesDir(null).AbsolutePath;
			
			FindViewById<TextView>(Resource.Id.specialFolder).Text =
				System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

			FindViewById<TextView>(Resource.Id.rootdirectory).Text =
				Android.OS.Environment.RootDirectory.AbsolutePath;
			
			FindViewById<TextView>(Resource.Id.externalstorageprivate).Text =
				Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;

			FindViewById<TextView>(Resource.Id.picturesDir).Text =
				Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).AbsolutePath;

			FindViewById<TextView>(Resource.Id.documentsDir).Text =
				Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).AbsolutePath;



			var dir = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "Hello");
			Directory.CreateDirectory(dir);

			File.WriteAllText(Path.Combine(dir, "myfile.txt"), "hello world");

		 	dir = Path.Combine(Application.Context.FilesDir.AbsolutePath, "Hoy");
			Directory.CreateDirectory(dir);

			File.WriteAllText(Path.Combine(dir, "myfile2.txt"), "hello world");
		}

		protected override void OnResume()
		{
			base.OnResume();
		}
	}
}

