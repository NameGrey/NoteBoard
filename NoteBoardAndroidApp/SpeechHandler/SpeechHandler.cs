using Android.Content;
using Android.Speech;

namespace NoteBoardAndroidApp.SpeechHandler
{
	public class SpeechHandler
	{
		public const int EndOfRecording = 1000;
		public const string NoSpeechRecognized = "No speech was recognised";
		public const string SpeakNow = "Please, speak";

		public Intent StartRecording()
		{
			var voiceIntent = new Intent(RecognizerIntent.ActionRecognizeSpeech);

			voiceIntent.PutExtra(RecognizerIntent.ExtraLanguageModel, RecognizerIntent.LanguageModelFreeForm);
			voiceIntent.PutExtra(RecognizerIntent.ExtraPrompt, SpeakNow);
			voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputCompleteSilenceLengthMillis, 1500);
			voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputPossiblyCompleteSilenceLengthMillis, 1500);
			voiceIntent.PutExtra(RecognizerIntent.ExtraSpeechInputMinimumLengthMillis, 15000);
			voiceIntent.PutExtra(RecognizerIntent.ExtraMaxResults, 1);
			voiceIntent.PutExtra(RecognizerIntent.ExtraLanguage, Java.Util.Locale.Default);

			return voiceIntent;
		}

		public string GetResultString(Intent data)
		{
			var matches = data.GetStringArrayListExtra(RecognizerIntent.ExtraResults);
			var result = matches.Count != 0 ? matches[0] : NoSpeechRecognized;

			return result;
		}
	}
}