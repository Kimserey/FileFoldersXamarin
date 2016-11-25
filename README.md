# Splash screen example with Xamarin.Android

This is a simple implementation of a splash screen in Xamarin.Android

# File folder paths example

Related resource:
[Internal vs external storage](https://developer.android.com/training/basics/data-storage/files.html)

```
public class PathService: IPathService
{
	public string PersonalDirectory
	{
		get 
		{ 
			return Android.App.Application.Context.FilesDir.AbsolutePath;
		}
	}

	public string CacheDirectory
	{ 
		get
		{
			return Android.App.Application.Context.CacheDir.AbsolutePath;
		}
	}

	public string ExternalStorageDirectory
	{
		get 
		{
			return Android.OS.Environment.ExternalStorageDirectory.AbsolutePath; 
		}
	}
}
```
