using System;
using System.IO;
using System.Net;

namespace NoteBoardAndroidApp.Services.AzureServiceCommunicator
{
	public class AzureServiceCommunicator: IAzureServiceCommunicator
	{
		// TODO: it's better to create a new service who can take this value from configuration
		const string baseUrl = "http://noteboardwebapiservice.azurewebsites.net/api";

		public AzureResponse SendRequest(string data, string uri, string method)
		{
			AzureResponse result = new AzureResponse();
			HttpWebRequest request = WebRequest.CreateHttp(String.Format("{0}{1}", baseUrl, uri));
			request.ContentType = "application/json";
			request.Method = method;

			try
			{
				result = FillInAzureResponse(request.GetResponse());
			}
			catch (WebException ex)
			{
				result.ErrorMessage = ex.Message;
				result.Status = (int) ((HttpWebResponse) ex.Response).StatusCode;
			}

			return result;
		}

		private AzureResponse FillInAzureResponse(WebResponse response)
		{
			AzureResponse result = new AzureResponse();

			using (StreamReader reader = new StreamReader(response.GetResponseStream()))
			{
				result.Data = reader.ReadToEnd();
				result.Status = (int) ((HttpWebResponse) response).StatusCode;
				result.ErrorMessage = String.Empty;
			}

			return result;
		}
	}
}