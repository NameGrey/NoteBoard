using System;
using System.Collections.Generic;
using AzureNoteService.DAL.Entities;

namespace AzureNoteService.Services.SmsService.SmsBodyFormer
{
	public class NotesSmsBodyFormer:ISmsBodyFormer<Note>
	{
		public const string delimiter = ",";
		public string CreateSmsBody(IEnumerable<Note> entities)
		{
			string result = String.Empty;
			foreach (var entity in entities)
			{
				result += entity.Name + delimiter;
			}

			return result;
		}
	}
}