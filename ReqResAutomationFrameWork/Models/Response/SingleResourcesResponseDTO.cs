using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqResAutomationFrameWork.Models.Response
{
    
    public class SingleResourceData
    {
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public string pantone_value { get; set; }
    }

    public class SingleResourceSupport
    {
        public string url { get; set; }
        public string text { get; set; }
    }

    public class SingleResourcesResponseDTO
    {
        public SingleResourceData data { get; set; }
        public SingleResourceSupport support { get; set; }
    }


}
