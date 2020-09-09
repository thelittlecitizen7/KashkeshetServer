﻿using KashkeshtWorkerServiceServer.Src.Enums;
using KashkeshtWorkerServiceServer.Src.Models;
using KashkeshtWorkerServiceServer.Src.Models.ChatData;
using KashkeshtWorkerServiceServer.Src.Models.ChatModel;
using KashkeshtWorkerServiceServer.Src.Models.ChatsModels;
using KashkeshtWorkerServiceServer.Src.RequestsHandler;
using KashkeshtWorkerServiceServer.Src.ResponsesHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace KashkeshtWorkerServiceServer.Src.ServerOptions
{
    public class GetAllChatOption : IOption
    {
        private AllChatDetails _allChatDetails { get; set; }

        private IServerRequestHandler _requestHandler;
        private IServerResponseHandler _responseHandler;

        private string _name;

        public GetAllChatOption(string name, AllChatDetails allChatDetails)
        {
            _requestHandler = new ServerRequestHandler();
            _responseHandler = new ServerResponseHandler();
            _allChatDetails = allChatDetails;
            _name = name;
        }

        public void Operation(MainRequest request)
        {
            var allChatsMessageModel = new AllChatsMessage
            {
                RequestType = "GetAllChats",
                Chats = new List<ChatMessageModel>()
            };
            var allChats = _allChatDetails.GetAllChatThatClientExist(_name);
            foreach (var chat in allChats)
            {
                allChatsMessageModel.Chats.Add(new ChatMessageModel
                {
                    ChatId = chat.ChatId,
                    Names = chat.GetAllNamesInChat(),
                    ChatType = chat.ChatType,
                    GroupName = (chat.GetType() == typeof(GroupChat)) ? ((GroupChat)chat).GroupName : null
                });
            }
            string msg = Utils.SerlizeObject(allChatsMessageModel);
            _requestHandler.SendData(_allChatDetails.GetClientByName(_name).Client, msg);
        }
    }
}
