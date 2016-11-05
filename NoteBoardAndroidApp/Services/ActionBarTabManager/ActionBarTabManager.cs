using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Android.App;
using Android.Widget;
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
		private TextView textField;
		private IEntityServices<Note> noteService;

		public ActionBarTabManager(ActionBar actionBar, FragmentManager fragmentManager, int containerId, TextView textField, IEnumerable<string> namesOfTabs, IEntityServices<Note> noteService)
		{
			if(actionBar == null)
				throw new InvalidParameterException("ActionBar parameter should be initialized");

			if (fragmentManager == null)
				throw new InvalidParameterException("FragmentManager parameter should be initialized");

			if (textField == null)
				throw new InvalidParameterException("TextField parameter should be initialized");

			this.actionBar = actionBar;
			this.fragmentManager = fragmentManager;
			this.containerId = containerId;
			this.textField = textField;
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
				var tabFragment = CreateTabFragment(items);

			var tab = actionBar.NewTab();

				tab.SetText(tabName);
				tab.TabSelected += (sender, e) =>
				{
					var fragment = fragmentManager.FindFragmentById(containerId);
					if (fragment != null)
						e.FragmentTransaction.Remove(fragment);

					items = noteService.GetCollection().Where(i => i.GroupName == tabName).Select(i => i.Name);
					tabFragment = CreateTabFragment(items);
					e.FragmentTransaction.Add(containerId, tabFragment);
				};
				tab.TabUnselected += (sender, e) =>
				{
					e.FragmentTransaction.Remove(tabFragment);
				};

				actionBar.AddTab(tab);
			}
		}

		private CommonTabFragment CreateTabFragment(IEnumerable<string> tabs)
		{
			var tabFragment = new CommonTabFragment(tabs);

			tabFragment.ItemClick += (sender, clickedItemName) =>
			{
				noteService.Remove(clickedItemName);
			};

			return tabFragment;
		}

		private bool CheckEnteredNoteName(string noteName)
		{
			var regex = new Regex("\\n");

			return !String.IsNullOrEmpty(noteName) && !regex.IsMatch(noteName); // return true if noteName is proper
		}

		public void CreateNewNoteButton(string noteText)
		{
			if (!String.IsNullOrEmpty(noteText))
			{
				var fragment = fragmentManager.FindFragmentById(containerId) as CommonTabFragment;

				if (fragment != null)
				{
					var groupName = actionBar.SelectedTab.Text;

					if (CheckEnteredNoteName(noteText))
					{
						textField.Text = String.Empty;
						fragment.CreateNewNoteButton(noteText);
						noteService.Add(new Note() {GroupName = groupName, Name = noteText});
					}
				}
			}
		}
	}
}