using System;
using System.Collections.Generic;
using NoteBoardAndroidApp.Models;

namespace NoteBoardAndroidApp.Services.JsonTransformer
{
	public class NotesJsonTransformer:IJsonTransformer<Note>
	{
		public string FromEntityToJson(Note entity)
		{
			throw new NotImplementedException();
		}

		public ICollection<Note> FromJsonToCollection(string data)
		{
			throw new NotImplementedException();
		}

		public Note FromJsonToEntity(string data)
		{
			throw new NotImplementedException();
		}
	}
}