using KashkeshtWorkerServiceServer.Src.Enums;
using KashkeshtWorkerServiceServer.Src.Models.ChatData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KashkeshtWorkerServiceServer.Src.Models.ChatModel
{
    [Serializable]
    public class PrivateChatMessageModel : MainRequest
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> lsUsers { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ChatType ChatType { get; set; }

    }
}
