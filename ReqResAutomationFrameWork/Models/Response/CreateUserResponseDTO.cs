using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqResAutomationFrameWork.Models.Response
{


	public class CreateUserResponseDTO
	{
		public string name { get; set; }
		public string job { get; set; }
		public string id { get; set; }
		public string createdAt { get; set; }
	}
}
