using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using NoteBoardAndroidApp.Services.ActionBarTabManager;

namespace NoteBoardAndroidApp
{
	[Activity(Label = "NoteBoardAndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private SpeechHandler.SpeechHandler speechHandler = new SpeechHandler.SpeechHandler();

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.Main);

			ActionBarTabManager tabManager = new ActionBarTabManager(this.ActionBar, this.FragmentManager,
				Resource.Id.actionMenuView, new List<string>() {"First Tab", "Second Tab"});
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

