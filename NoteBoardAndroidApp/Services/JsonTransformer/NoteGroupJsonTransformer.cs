using System;
using System.Collections.Generic;
using NoteBoardAndroidApp.Models;

namespace NoteBoardAndroidApp.Services.JsonTransformer
{
	public class NoteGroupJsonTransformer: IJsonTransformer<NoteGroup>
	{
		public string FromCollectionToJson(IEnumerable<NoteGroup> collection)
		{
			throw new NotImplementedException();
		}

		public ICollection<NoteGroup> FromJsonToCollection(string data)
		{
			throw new NotImplementedException();
		}

		public NoteGroup FromJsonToEntity(string data)
		{
			throw new NotImplementedException();
		}
	}
}