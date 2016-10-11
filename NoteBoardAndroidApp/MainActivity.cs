using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using NoteBoardAndroidApp.Models;
using NoteBoardAndroidApp.Services.ActionBarTabManager;
using NoteBoardAndroidApp.Services.AzureServiceCommunicator;
using NoteBoardAndroidApp.Services.EntityServices;
using NoteBoardAndroidApp.Services.JsonTransformer;

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

			var azureCommunicator = new AzureServiceCommunicator();
			var noteService = new NoteService(azureCommunicator, new JsonTransformer<Note>());
			var noteGroupService = new NoteGroupService(azureCommunicator, new JsonTransformer<NoteGroup>());

			ActionBarTabManager tabManager = new ActionBarTabManager(this.ActionBar, this.FragmentManager,
				Resource.Id.actionMenuView, noteGroupService.GetCollection().Select(i=>i.Name), noteService);
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

