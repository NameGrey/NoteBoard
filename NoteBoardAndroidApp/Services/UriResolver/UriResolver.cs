using System;
using AzureNoteService.DAL.Entities;

namespace NoteBoardAndroidApp.Services.UriResolver
{
	public static class UriResolver
	{
		private const string GetNotesUrl = "/notes";
		private const string GetNoteByIdUrl = "/note/{0}";
		private const string AddNewNoteUrl = "/note";
		private const string DeleteNoteUrl = "/note/{0}";

		private const string GetGroupsOfNotesUrl = "/noteGroups";
		private const string GetGroupOfNoteByIdUrl = "/noteGroups/{0}";
		private const string AddNewGroupOfNoteUrl = "/noteGroups";
		private const string DeleteGroupOfNoteUrl = "/noteGroups/{0}";

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

		public static string GetAddNewUrl(Type entityType)
		{
			if (entityType == typeof(Note))
				return AddNewNoteUrl;
			else
				return AddNewGroupOfNoteUrl;
		}

		public static string GetDeleteActionUrl(Type entityType)
		{
			if (entityType == typeof(Note))
				return DeleteNoteUrl;
			else
				return DeleteGroupOfNoteUrl;
		}
	}
}