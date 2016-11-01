using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
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
		private ActionBarTabManager tabManager;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			SetContentView(Resource.Layout.Main);

			var azureCommunicator = new AzureServiceCommunicator();
			var noteService = new NoteService(azureCommunicator, new JsonTransformer<Note>());
			var noteGroupService = new NoteGroupService(azureCommunicator, new JsonTransformer<NoteGroup>());

			FindViewById(Resource.Id.AddNoteButton).Click += AddNewNote;
			var textField = FindViewById(Resource.Id.textField) as TextView;

			tabManager = new ActionBarTabManager(this.ActionBar, this.FragmentManager,
				Resource.Id.actionMenuView, textField, noteGroupService.GetCollection().Select(i=>i.Name), noteService);
		}

		private void AddNewNote(object sender, EventArgs e)
		{
			string noteText = FindViewById<TextView>(Resource.Id.textField).Text;

			tabManager.CreateNewNoteButton(noteText);
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

