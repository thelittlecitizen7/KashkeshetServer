﻿using KashkeshtWorkerServiceServer.Src.Models;
using KashkeshtWorkerServiceServer.Src.Models.ChatData;
using KashkeshtWorkerServiceServer.Src.RequestsHandler;
using KashkeshtWorkerServiceServer.Src.ResponsesHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KashkeshtWorkerServiceServer.Src.ServerOptions.ManagerOptions
{
    public class RemoveAdminPermissionOption : IOption
    {
        private AllChatDetails _allChatDetails;

        private string Name { get; set; }

        private IServerRequestHandler _requestHandler;
        private IServerResponseHandler _responseHandler;
        public RemoveAdminPermissionOption(string name, AllChatDetails allChatDetails)
        {
            _requestHandler = new ServerRequestHandler();
            _responseHandler = new ServerResponseHandler();
            Name = name;
            _allChatDetails = allChatDetails;
        }
        public void Operation(MainRequest chatData)
        {
            var data = chatData as GroupChatMessageModel;
            var groupChat = _allChatDetails.GetGroupByName(data.GroupName);
            var client = _allChatDetails.GetClientByName(Name);

            if (!groupChat.IsClientManager(client))
            {
                var errorBody = new ErrorMessage
                {
                    RequestType = "ErrorResponse",
                    Error = $"The user name {Name} cannot remove admin permission beacuse he has not permission"
                };
                _requestHandler.SendData(client.Client, Utils.SerlizeObject(errorBody));
                return;
            }
            var alClientsToAdd = data.lsUsers.Where(c => groupChat.IsClientExistInChat(_allChatDetails.GetClientByName(c))).Select(u => _allChatDetails.GetClientByName(u)).ToList();
            groupChat.RemoveMultiManagrs(alClientsToAdd);
            var successBody = new OkResponseMessage
            {
                RequestType = "SuccessResponse",
                Message = $"Group {data.GroupName} users updated"
            };
            _requestHandler.SendData(client.Client, Utils.SerlizeObject(successBody));
        }
    }
}
