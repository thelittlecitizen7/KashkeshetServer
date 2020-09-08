using KashkeshtWorkerServiceServer.Src.Models.ChatData;
using KashkeshtWorkerServiceServer.Src.Models.ChatModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace KashkeshtWorkerServiceServer.Src.ServerOptions
{
    public interface IOption
    {
        void Operation(MainRequest chatData);
    }
}
