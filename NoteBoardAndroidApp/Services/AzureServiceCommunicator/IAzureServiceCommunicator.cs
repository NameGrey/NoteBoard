namespace NoteBoardAndroidApp.Services.AzureServiceCommunicator
{
	public interface IAzureServiceCommunicator
	{
		/// <summary>
		/// Send request to specified uri
		/// </summary>
		/// <param name="data">JSON formatted data</param>
		/// <param name="uri">URI to send</param>
		/// <param name="method">Method to send(GET,POST,PUT,DELETE)</param>
		/// <returns></returns>
		AzureResponse SendRequest(string data, string uri, string method);
	}
}