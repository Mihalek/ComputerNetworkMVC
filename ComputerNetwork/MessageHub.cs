using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerNetwork
{
    public class MessageHub : Hub

    {
        public async Task AddNetworks (string message)
        {
            Thread.Sleep(500);
            await Clients.All.SendAsync("ReceiveMessage", message +" "+ DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));
        }

        public async Task CleanNetworks()
        {
            Thread.Sleep(500);
            await Clients.All.SendAsync("CleanMessage");
        }

        public async Task DeleteOneNetwork(string message)
        {
            Thread.Sleep(500);
            await Clients.All.SendAsync("DeleteNetworkMessage", message);
        }

        public async Task UpdateNetwork(string message)
        {
            Thread.Sleep(500);
            await Clients.Others.SendAsync("UpdateNetworkMessage",message);
        }
    }
}
