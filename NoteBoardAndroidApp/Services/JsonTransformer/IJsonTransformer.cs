using System.Collections.Generic;

namespace NoteBoardAndroidApp.Services.JsonTransformer
{
	public interface IJsonTransformer<E>
	{
		string FromEntityToJson(E entity);

		ICollection<E> FromJsonToCollection(string data);
		E FromJsonToEntity(string data);
	}
}