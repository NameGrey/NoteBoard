using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NoteBoardAndroidApp.Models;

namespace NoteBoardAndroidApp.Services.JsonTransformer
{
	public class NoteGroupJsonTransformer: IJsonTransformer<NoteGroup>
	{
		public string FromEntityToJson(NoteGroup entity)
		{
			return JsonConvert.SerializeObject(entity);
		}

		public ICollection<NoteGroup> FromJsonToCollection(string data)
		{
			return JsonConvert.DeserializeObject<ICollection<NoteGroup>>(data);
		}

		public NoteGroup FromJsonToEntity(string data)
		{
			return JsonConvert.DeserializeObject<NoteGroup>(data);
		}
	}
}