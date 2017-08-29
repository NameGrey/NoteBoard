using System;
using System.IO;
using System.Net;

namespace NoteBoardAndroidApp.Services.BackendServiceCommunicator
{
	public class BackendServiceCommunicator: IBackendServiceCommunicator
	{
		// TODO: it's better to create a new service who can take this value from configuration
		const string baseUrl = "http://noteboardwebapiservice.azurewebsites.net/api";

		public BackendResponse SendRequest(string data, string uri, string method)
		{
			BackendResponse result = new BackendResponse();
			HttpWebRequest request = WebRequest.CreateHttp(String.Format("{0}{1}", baseUrl, uri));
			request.ContentType = "application/json";
			request.Method = method;

			if (method == "POST")
			{
				using (var streamWriter = new StreamWriter(request.GetRequestStream()))
				{
					streamWriter.Write(data);
				}
			}

			try
			{
				result = HandleResponse(request.GetResponse());
			}
			catch (WebException ex)
			{
				result.ErrorMessage = ex.Message;
				result.Status = (int) ((HttpWebResponse) ex.Response).StatusCode;
			}

			return result;
		}

		private BackendResponse HandleResponse(WebResponse response)
		{
			BackendResponse result = new BackendResponse();

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