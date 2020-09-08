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
        private List<ChatModule> _allChats;

        private Dictionary<string, TcpClient> _allSockets;
        public GroupChatCreatorOption(List<ChatModule> allChats, Dictionary<string, TcpClient> allSockets)
        {
            _allChats = allChats;
            _allSockets = allSockets;
        }

        public void Operation(MainRequest chatData)
        {
           var data =  chatData as GroupChatMessageModel;
            ChatModule newGroupChat = new GroupChat(data.GroupName);
            foreach (var clientName in data.lsUsers)
            {
                if (_allSockets.ContainsKey(clientName))
                {
                    ClientModel client = new ClientModel(clientName, _allSockets[clientName]);
                    newGroupChat.AddClient(client);
                }
            }
            _allChats.Add(newGroupChat);
        }
    }
}
