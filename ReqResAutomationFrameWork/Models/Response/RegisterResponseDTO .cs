using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqResAutomationFrameWork.Models.Response
{


	public class RegisterResponseDTO
	{
		public string id { get; set; }
		public string token { get; set; }

		public string error { get; set; }

	}
}
