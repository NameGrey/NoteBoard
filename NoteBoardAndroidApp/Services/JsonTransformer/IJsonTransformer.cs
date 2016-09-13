using System.Collections.Generic;

namespace NoteBoardAndroidApp.Services.JsonTransformer
{
	public interface IJsonTransformer<E>
	{
		string FromCollectionToJson(IEnumerable<E> collection);

		ICollection<E> FromJsonToCollection(string data);
		E FromJsonToEntity(string data);
	}
}