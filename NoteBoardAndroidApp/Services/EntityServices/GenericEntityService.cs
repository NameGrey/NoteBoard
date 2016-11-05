using System;
using System.Collections.Generic;
using System.Threading;
using NoteBoardAndroidApp.Services.AzureServiceCommunicator;
using NoteBoardAndroidApp.Services.JsonTransformer;
using Debug = System.Diagnostics.Debug;

namespace NoteBoardAndroidApp.Services.EntityServices
{
	public class GenericEntityService<E>: IEntityServices<E>
	{
		private IAzureServiceCommunicator azureCommunicator;
		private readonly IJsonTransformer<E> jsonTransformer;

		public GenericEntityService(IAzureServiceCommunicator azureCommunicator, IJsonTransformer<E> jsonTransformer)
		{
			this.azureCommunicator = azureCommunicator;
			this.jsonTransformer = jsonTransformer;
		}

		public E GetEntityById(int id)
		{
			E result = default(E);
			var url = String.Format(UriResolver.UriResolver.GetEntityByIdUrl(typeof(E)), id);
			var response = azureCommunicator.SendRequest(String.Empty, url, "GET");

			if (response.Status == 200)
			{
				result = jsonTransformer.FromJsonToEntity(response.Data);
			}
			else
			{
				Debug.Print("Server Error: {0}", response.ErrorMessage);
			}

			return result;
		}

		public IEnumerable<E> GetCollection()
		{
			IEnumerable<E> result = default(IEnumerable<E>);

			var response = azureCommunicator.SendRequest(String.Empty, UriResolver.UriResolver.GetCollectionUrl(typeof(E)),
				"GET");

			if (response.Status == 200)
			{
				result = jsonTransformer.FromJsonToCollection(response.Data);
			}
			else
			{
				Debug.Print("Server Error: {0}", response.ErrorMessage);
			}

			return result;
		}

		public void Add(E entity)
		{
			var data = jsonTransformer.FromEntityToJson(entity);

			Thread thread = new Thread(() =>
			{
				var response = azureCommunicator.SendRequest(data, UriResolver.UriResolver.GetAddNewUrl(typeof(E)),
				"POST");

				if (response.Status != 200)
				{
					Debug.Print("Server Error: {0}", response.ErrorMessage);
				}
			});
			thread.Start();
		}

		public void Remove(string name)
		{
			var url = String.Format(UriResolver.UriResolver.GetDeleteActionUrl(typeof (E)), name);
			Thread thread = new Thread(() =>
			{
				var response = azureCommunicator.SendRequest(String.Empty, url, "DELETE");

				if (response.Status != 200)
				{
					Debug.Print("Server Error: {0}", response.ErrorMessage);
				}
			});
			thread.Start();
		}
	}
}