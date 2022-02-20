using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqResAutomationFrameWork.Models.Response
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ResourceData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string year { get; set; }
        public string color { get; set; }
        public string pantone_value { get; set; }
    }

    public class ResourceSupport
    {
        public string url { get; set; }
        public string text { get; set; }
    }

    public class ListResourcesResponseDTO
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<ResourceData> data { get; set; }
        public ResourceSupport support { get; set; }
    }


}
