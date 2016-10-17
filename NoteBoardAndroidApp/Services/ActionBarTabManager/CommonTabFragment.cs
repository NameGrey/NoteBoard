using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace NoteBoardAndroidApp.Services.ActionBarTabManager
{
	public class CommonTabFragment : Fragment
	{
		private IEnumerable<string> items;

		public EventHandler<string> ItemClick;

		public CommonTabFragment(IEnumerable<string> items)
		{
			this.items = items;
		}

		public override View OnCreateView(LayoutInflater inflater,
		ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			var view = inflater.Inflate(
				Resource.Layout.TabLayout, container, false);

			foreach (var item in items)
			{
				var button = CreateButton(item);

				view.FindViewById<LinearLayout>(Resource.Id.linearVerticalLayout).AddView(button);
			}

			return view;
		}

		private Button CreateButton(string text)
		{
			var button = new Button(this.Context);
			button.SetText(text, TextView.BufferType.Normal);
			button.Click += OnItemClick;

			return button;
		}

		public void CreateNewNoteButton(string noteText)
		{
			var button = CreateButton(noteText);
			this.View.FindViewById<LinearLayout>(Resource.Id.linearVerticalLayout).AddView(button);
		}

		private void OnItemClick(object sender, EventArgs e)
		{
			if (ItemClick != null)
			{
				Button button = (Button) sender;
				string args = button.Text;

				ItemClick(sender, args);
			}
		}
	}
}

