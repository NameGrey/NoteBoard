using System;
using System.Collections.Generic;
using NoteBoardAndroidApp.Services.AzureServiceCommunicator;
using NoteBoardAndroidApp.Services.JsonTransformer;
using Debug = System.Diagnostics.Debug;

namespace NoteBoardAndroidApp.Services.EntityServices
{
	public class GenericEntityService<E> : IEntityServices<E> 
	{
		private IAzureServiceCommunicator azureCommunicator;
		private readonly IJsonTransformer<E> jsonTransformer;

		public GenericEntityService(IAzureServiceCommunicator azureCommunicator, IJsonTransformer<E> jsonTransformer )
		{
			this.azureCommunicator = azureCommunicator;
			this.jsonTransformer = jsonTransformer;
		}

		public E GetEntityById(int id)
		{
			E result = default(E);
			var response = azureCommunicator.SendRequest(String.Empty, UriResolver.UriResolver.GetEntityByIdUrl(typeof (E)),
				"GET");

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
			throw new NotImplementedException();
		}

		public void Add(E entity)
		{
			throw new NotImplementedException();
		}

		public void Remove(int id)
		{
			throw new NotImplementedException();
		}
	}
}