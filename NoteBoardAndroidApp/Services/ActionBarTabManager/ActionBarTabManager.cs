using System.Collections.Generic;
using System.Linq;
using Android.App;
using Java.Security;
using NoteBoardAndroidApp.Models;
using NoteBoardAndroidApp.Services.EntityServices;

namespace NoteBoardAndroidApp.Services.ActionBarTabManager
{
	public class ActionBarTabManager
	{
		private ActionBar actionBar;
		private FragmentManager fragmentManager;
		private int containerId;
		private IEntityServices<Note> noteService;

		public ActionBarTabManager(ActionBar actionBar, FragmentManager fragmentManager,
			int containerId, IEnumerable<string> namesOfTabs, IEntityServices<Note> noteService)
		{
			if(actionBar == null)
				throw new InvalidParameterException("ActionBar should be initialized");

			if (fragmentManager == null)
				throw new InvalidParameterException("FragmentManager should be initialized");

			this.actionBar = actionBar;
			this.fragmentManager = fragmentManager;
			this.containerId = containerId;
			this.noteService = noteService;

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
				// TODO: use names as primary keys
				// TODO: use group service here instaed of list of names for groups
				var items = noteService.GetCollection().Where(i=>i.GroupName == tabName).Select(i=>i.Name);
				var tabFragment = new CommonTabFragment(items);
				tabFragment.ItemClick += (sender, clickedItemName) =>
				{
					noteService.Remove(clickedItemName);
				};

			var tab = actionBar.NewTab();

				tab.SetText(tabName);
				tab.TabSelected += (sender, e) =>
				{
					var fragment = fragmentManager.FindFragmentById(containerId);
					if (fragment != null)
						e.FragmentTransaction.Remove(fragment);

					
					e.FragmentTransaction.Add(containerId, tabFragment);
				};
				tab.TabUnselected += (sender, e) =>
				{
					e.FragmentTransaction.Remove(tabFragment);
				};

				actionBar.AddTab(tab);
			}
		}
	}
}