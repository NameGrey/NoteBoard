using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using NoteBoardAndroidApp.Models;
using NoteBoardAndroidApp.Services.ActionBarTabManager;
using NoteBoardAndroidApp.Services.AzureServiceCommunicator;
using NoteBoardAndroidApp.Services.EntityServices;
using NoteBoardAndroidApp.Services.JsonTransformer;
using NoteBoardAndroidApp.Services.Serializer;

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
			var noteService = new NoteService(azureCommunicator, new JsonTransformer<Note>(new JsonSerializer()));
			var noteGroupService = new NoteGroupService(azureCommunicator, new JsonTransformer<NoteGroup>(new JsonSerializer()));

			FindViewById(Resource.Id.AddNoteButton).Click += AddNewNote;
			FindViewById(Resource.Id.RecordButton).Click += StartRecordingButtonOnClick;

			var textField = FindViewById(Resource.Id.textField) as TextView;

			tabManager = new ActionBarTabManager(this.ActionBar, this.FragmentManager,
				Resource.Id.actionMenuView, textField, noteGroupService.GetCollection().Select(i=>i.Name), noteService);

			Window.SetSoftInputMode(SoftInput.StateAlwaysHidden);
			Window.DecorView.SetBackgroundColor(new Color(48,48,48));
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
					var resultString = speechHandler.GetResultString(data);

					if (!String.IsNullOrEmpty(resultString))
					{
						tabManager.CreateNewNoteButton(resultString);
					}
				}
			}
			base.OnActivityResult(requestCode, resultVal, data);
		}
	}
}

