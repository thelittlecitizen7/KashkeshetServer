using KashkeshtWorkerServiceServer.Src.Enums;
using KashkeshtWorkerServiceServer.Src.Models;
using KashkeshtWorkerServiceServer.Src.Models.ChatData;
using KashkeshtWorkerServiceServer.Src.Models.ChatModel;
using KashkeshtWorkerServiceServer.Src.Models.ChatsModels;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace KashkeshtWorkerServiceServer.Src.ServerOptions
{
    public class GroupChatCreatorOption : IOption
    {
        private AllChatDetails _allChatDetails;

        private string Name { get; set; }
        public GroupChatCreatorOption(string name, AllChatDetails allChatDetails)
        {
            Name = name;
            _allChatDetails = allChatDetails;
        }


        public void Operation(MainRequest chatData)
        {
           var data =  chatData as GroupChatMessageModel;
            ChatModule newGroupChat = new GroupChat(data.GroupName);
            ClientModel senerClient = _allChatDetails.GetClientByName(Name);
            
            List<ClientModel> clients = new List<ClientModel>();
            clients.Add(senerClient);
            if (data.lsUsers.Count ==  0) 
            {
                return;
            }
            newGroupChat.AddClient(senerClient);
            foreach (var clientName in data.lsUsers)
            {
                if (_allChatDetails.IsClientExist(clientName))
                {
                    ClientModel client = _allChatDetails.GetClientByName(clientName);
                    clients.Add(client);
                    newGroupChat.AddClient(client);
                }
            }
            if (!_allChatDetails.IsExistChatWithSamePeaple(clients, ChatType.Group))
            {
                _allChatDetails.AddChat(newGroupChat);
            }
        }
    }
}
