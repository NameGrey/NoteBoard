using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AzureNoteService.Controllers
{
	[RoutePrefix("api")]
	public class NoteController : ApiController
	{
		[Route("notes")]
		public string GetCollection()
		{
			return "Hello World";
		}

	}
}
