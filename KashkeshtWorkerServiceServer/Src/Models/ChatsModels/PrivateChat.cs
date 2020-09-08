using System;
using System.Collections.Generic;
using System.Text;

namespace KashkeshtWorkerServiceServer.Src.Models.ChatModel
{
    public class PrivateChat : ChatModule
    {
        public PrivateChat() : base(Enums.ChatType.Private)
        {
        }
    }
}
