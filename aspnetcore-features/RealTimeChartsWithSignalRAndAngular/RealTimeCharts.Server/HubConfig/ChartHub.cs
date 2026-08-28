using Microsoft.AspNetCore.SignalR;
using RealTimeCharts.Server.Models;

namespace RealTimeCharts.Server.HubConfig
{
    public class ChartHub : Hub
    {
        public async Task BroadcastChartData(List<ChartModel> data) =>
            await Clients.All.SendAsync("broadcastchartdata", data);

        public async Task BroadcastChartDataToClient(List<ChartModel> data, string connectionId) =>
            await Clients.Client(connectionId).SendAsync("broadcastchartdata", data);

        public string GetConnectionId() => Context.ConnectionId;

        public async Task BroadcastToConnection(string data, string connectionId)
            => await Clients.Client(connectionId).SendAsync("broadcasttoclient", data);

        public async Task BroadcastToUser(string data, string userId)
            => await Clients.User(userId).SendAsync("broadcasttouser", data);

        public async Task AddToGroup(string groupName)
            => await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        public async Task RemoveFromGroup(string groupName)
            => await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

        public async Task BroadcastToGroup(string groupName) => await Clients.Group(groupName)
            .SendAsync("broadcasttogroup", $"{Context.ConnectionId} has joined the group {groupName}.");
    }
}
