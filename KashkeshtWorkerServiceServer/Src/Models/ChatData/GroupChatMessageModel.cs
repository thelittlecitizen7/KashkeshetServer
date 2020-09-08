using KashkeshtWorkerServiceServer.Src.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KashkeshtWorkerServiceServer.Src.Models.ChatData
{
    public class GroupChatMessageModel : MainRequest
    {
        public string GroupName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> lsUsers { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ChatType ChatType { get; set; }
    }
}
