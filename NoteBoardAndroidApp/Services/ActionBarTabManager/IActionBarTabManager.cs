using System;
using System.Collections.Generic;
using Android.App;

namespace NoteBoardAndroidApp.Services.ActionBarTabManager
{
	public interface IActionBarTabManager
	{
		event EventHandler<ActionBar.TabEventArgs> OnSelected;
		event EventHandler<ActionBar.TabEventArgs> OnUnSelected;

		IEnumerable<ActionBar.Tab> CreateAllTabs(IEnumerable<string> names);
	}
}