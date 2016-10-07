using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace NoteBoardAndroidApp
{
	public class CommonTabFragment : Fragment
	{
		public override View OnCreateView(LayoutInflater inflater,
		ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			var view = inflater.Inflate(
				Resource.Layout.TabLayout, container, false);

			//TODO: Create list of items 

			return view;
		}
	}
}

