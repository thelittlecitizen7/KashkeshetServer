﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KashkeshtWorkerServiceServer.Src.Models.ChatData
{
    [Serializable]
    public class NewChatMessage : MainRequest
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }
}
