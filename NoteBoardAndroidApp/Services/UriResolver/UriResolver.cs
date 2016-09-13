using System;
using NoteBoardAndroidApp.Models;

namespace NoteBoardAndroidApp.Services.UriResolver
{
	public static class UriResolver
	{
		private const string GetNotesUrl = "\notes";
		private const string GetNoteByIdUrl = "\note\\{0}";
		private const string AddNewNoteUrl = "\note\\{0}";
		private const string DeleteNoteUrl = "\note\\{0}";

		private const string GetGroupsOfNotesUrl = "\notes";
		private const string GetGroupOfNoteByIdUrl = "\note\\{0}";
		private const string AddNewGroupOfNoteUrl = "\note\\{0}";
		private const string DeleteGroupOfNoteUrl = "\note\\{0}";

		public static string GetCollectionUrl(Type entityType)
		{
			if (entityType == typeof (Note))
				return GetNotesUrl;
			else
				return GetGroupsOfNotesUrl;
		}

		public static string GetEntityByIdUrl(Type entityType)
		{
			if (entityType == typeof(Note))
				return GetNoteByIdUrl;
			else
				return GetGroupOfNoteByIdUrl;
		}

		public static string GetAddNewNoteUrl(Type entityType)
		{
			if (entityType == typeof(Note))
				return AddNewNoteUrl;
			else
				return AddNewGroupOfNoteUrl;
		}

		public static string GetDeleteNoteUrl(Type entityType)
		{
			if (entityType == typeof(Note))
				return DeleteNoteUrl;
			else
				return DeleteGroupOfNoteUrl;
		}
	}
}