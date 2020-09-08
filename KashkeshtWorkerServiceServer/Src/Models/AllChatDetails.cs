﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KashkeshtWorkerServiceServer.Src.Enums;
using KashkeshtWorkerServiceServer.Src.Models.ChatModel;

namespace KashkeshtWorkerServiceServer.Src.Models
{
    public class AllChatDetails
    {
        public List<ChatModule> AllChats { get; set; }

        public List<ClientModel> AllClients { get; set; }
        
        public AllChatDetails()
        {
            AllChats = new List<ChatModule>();
            AllClients = new List<ClientModel>();
        }

        public bool IsExistChatWithSamePeaple(List<ClientModel> users,ChatType chatType) 
        {
            var allChats = AllChats.Where(c => c.ChatType == chatType).ToList();
            if (allChats.Count() == 0) 
            {
                return false;
            }
            foreach (var chat in allChats)
            {
                foreach (var client in users)
                {
                    if (!chat.IsClientExistInChat(client)) 
                    {
                        return false;
                    }
                }
                
            }
            return true;
        }

        public bool IsClientExist(string name) 
        {
            return AllClients.Any(c => c.Name == name);
        }

        public void UpdateCurrentChat(ClientModel clientModel,ChatModule chat) 
        {
            var clientFromClients = GetClientByName(clientModel.Name);
            var clientFromChat = GetClientByNameFromChat(clientModel.Name);
            if (chat != null)
            {
                var clientFromChat2 = chat.GetClient(clientModel.Name);
                if (clientFromChat2 != null)
                {
                    clientFromChat2.CurrentConnectChat = chat;
                }
            }

            clientFromClients.CurrentConnectChat = chat;
            clientFromChat.CurrentConnectChat = chat;
        }

        public ChatModule GetChatById(string chatId) 
        {
            return AllChats.FirstOrDefault(chat => chat.ChatId == chatId);
        }

        public List<ClientModel> GetAllUsers() 
        {
            return AllClients;
        }

        public List<ChatModule> GetAllChatThatClientExist(string name) 
        {
            return AllChats.Where(c => c.IsClientExistInChat(name)).ToList();
        }


        public List<ChatModule> GetAllChatByType(ChatType chatType) 
        {
            return AllChats.Where(c => c.ChatType == chatType).ToList();
        }

        public ClientModel GetClientByName(string name) 
        {
            return AllClients.FirstOrDefault(c => c.Name == name);
        }

        public ClientModel GetClientByNameFromChat(string name)
        {
            foreach (var chat in AllChats)
            {
                foreach (var client in chat.Clients)
                {
                    if (client.Name == name) 
                    {
                        return client; 
                    }
                }
            }
            return null;
        }

        public void AddClient(ClientModel client) 
        {
            AllClients.Add(client);
        }

        public void RemoveClient(ClientModel client)
        {
            AllClients.Remove(client);
        }

        public void AddChat(ChatModule chat) 
        {
            AllChats.Add(chat);
        }

        public void RemoveChat(ChatModule chat)
        {
            AllChats.Remove(chat);
        }
    }
}
