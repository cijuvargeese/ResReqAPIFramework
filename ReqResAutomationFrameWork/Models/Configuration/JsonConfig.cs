using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqResAutomationFrameWork.Models.Configuration
{

	public class ReqResApplication
	{
		public string Base_URL { get; set; }
		public string User_URL { get; set; }
		public string Resource_URL { get; set; }
		public string Register_URL { get; set; }
		public string Login_URL { get; set; }
	}

	public class JsonConfig
	{
		public ReqResApplication ReqResApplication { get; set; }
	}



}