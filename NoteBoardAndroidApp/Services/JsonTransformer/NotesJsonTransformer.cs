using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NoteBoardAndroidApp.Models;

namespace NoteBoardAndroidApp.Services.JsonTransformer
{
	public class NotesJsonTransformer:IJsonTransformer<Note>
	{
		public string FromEntityToJson(Note entity)
		{
			return JsonConvert.SerializeObject(entity);
		}

		public ICollection<Note> FromJsonToCollection(string data)
		{
			return JsonConvert.DeserializeObject<ICollection<Note>>(data);
		}

		public Note FromJsonToEntity(string data)
		{
			return JsonConvert.DeserializeObject<Note>(data);
		}
	}
}