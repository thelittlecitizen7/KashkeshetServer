using KashkeshtWorkerServiceServer.Src.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KashkeshtWorkerServiceServer.Src.Models.ChatModel
{
    public class GlobalChat : ChatModule
    {
        public GlobalChat() : base(ChatType.Globaly)
        {
        }
    }
}
