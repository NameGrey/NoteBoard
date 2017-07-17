using NoteBoardAndroidApp.Services.Serializer;
using System.Collections.Generic;

namespace NoteBoardAndroidApp.Services.JsonTransformer
{
	public class JsonTransformer<T> : IJsonTransformer<T>
	{
		ISerializer _serializer;

		public JsonTransformer(ISerializer serializer)
		{
			_serializer = serializer;
		}

		public string FromEntityToJson(T entity)
		{
			return _serializer.Serialize(entity);
		}

		public ICollection<T> FromJsonToCollection(string data)
		{
			return _serializer.Deserialize<List<T>>(data);
		}

		public T FromJsonToEntity(string data)
		{
			return _serializer.Deserialize<T>(data);
		}
	}
}