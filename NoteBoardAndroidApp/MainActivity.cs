using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace NoteBoardAndroidApp
{
	[Activity(Label = "NoteBoardAndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private SpeechHandler.SpeechHandler speechHandler = new SpeechHandler.SpeechHandler();

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
		}

		private void StartRecordingButtonOnClick(object sender, EventArgs e)
		{
			this.StartActivityForResult(speechHandler.StartRecording(), SpeechHandler.SpeechHandler.EndOfRecording);
		}

		protected override void OnActivityResult(int requestCode, Result resultVal, Intent data)
		{
			if (requestCode == SpeechHandler.SpeechHandler.EndOfRecording)
			{
				if (resultVal == Result.Ok)
				{
					
				}
			}
			base.OnActivityResult(requestCode, resultVal, data);
		}
	}
}

