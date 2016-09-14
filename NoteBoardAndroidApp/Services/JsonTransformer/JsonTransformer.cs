using System.Collections.Generic;
using Newtonsoft.Json;

namespace NoteBoardAndroidApp.Services.JsonTransformer
{
	public class JsonTransformer<T>: IJsonTransformer<T>
	{
		public string FromEntityToJson(T entity)
		{
			return JsonConvert.SerializeObject(entity);
		}

		public ICollection<T> FromJsonToCollection(string data)
		{
			return JsonConvert.DeserializeObject<ICollection<T>>(data);
		}

		public T FromJsonToEntity(string data)
		{
			return JsonConvert.DeserializeObject<T>(data);
		}
	}
}