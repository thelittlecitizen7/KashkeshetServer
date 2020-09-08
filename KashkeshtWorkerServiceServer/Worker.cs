using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KashkeshtWorkerServiceServer.Src;
using KashkeshtWorkerServiceServer.Src.Models.ChatData;
using KashkeshtWorkerServiceServer.Src.Models.ChatModel;
using KashkeshtWorkerServiceServer.Src.SocketsHandler;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace KashkeshtWorkerServiceServer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ServerSocket serverSocket = new ServerSocket(11111);
            serverSocket.Listen();
           
        }
    }
}
