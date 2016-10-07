using System.Collections.Generic;

using Android.App;
using Java.Security;

namespace NoteBoardAndroidApp.Services.ActionBarTabManager
{
	public class ActionBarTabManager
	{
		private ActionBar actionBar;
		private FragmentManager fragmentManager;
		private int containerId;

		public ActionBarTabManager(ActionBar actionBar, FragmentManager fragmentManager,
			int containerId, IEnumerable<string> namesOfTabs)
		{
			if(actionBar == null)
				throw new InvalidParameterException("ActionBar should be initialized");

			if (fragmentManager == null)
				throw new InvalidParameterException("FragmentManager should be initialized");

			this.actionBar = actionBar;
			this.fragmentManager = fragmentManager;
			this.containerId = containerId;

			CustomizeActionBar();
			InitializeActionBar(namesOfTabs);
		}

		private void CustomizeActionBar()
		{
			actionBar.NavigationMode = ActionBarNavigationMode.Tabs;
		}

		private void InitializeActionBar(IEnumerable<string> tabNames)
		{
			foreach (var tabName in tabNames)
			{
				// TODO: add refreshing of items of the tab
				var items = new List<string>() { "first item", "secondItem" };
				items.Add(tabName); 

				var tab = actionBar.NewTab();

				tab.SetText(tabName);
				tab.TabSelected += (sender, e) =>
				{
					var fragment = fragmentManager.FindFragmentById(containerId);
					if (fragment != null)
						e.FragmentTransaction.Remove(fragment);
					e.FragmentTransaction.Add(containerId, new CommonTabFragment(items));
				};
				tab.TabUnselected += (sender, e) =>
				{
					e.FragmentTransaction.Remove(new CommonTabFragment(items));
				};

				actionBar.AddTab(tab);
			}
		}
	}
}