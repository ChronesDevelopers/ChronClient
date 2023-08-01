using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordRPC;
using DiscordRPC.Logging;

namespace ChronClient.Discord
{
    public static class DiscordRPC
    {
        public static DiscordRpcClient client;

		public static async void StartAsync()
        {
			Start();
        }

        public static void Start()
        {
            client = new DiscordRpcClient("744124262343901244");

			client.Logger = new ConsoleLogger() { Level = LogLevel.Info };

			//Subscribe to events
			client.OnReady += (sender, e) =>
			{
				Debug.WriteLine("Received Ready from user {0}", e.User.Username);
			};

			client.OnPresenceUpdate += (sender, e) =>
			{
				Debug.WriteLine("Received Update! {0}", e.Presence);
			};

			//Connect to the RPC
			client.Initialize();

			//Set the rich presence
			//Call this as many times as you want and anywhere in your code.
			string newDetails = "";
			if (!ChronClient.Data.GlobalData.ApplicationData.IsChronLite && ChronClient.Data.GlobalData.ApplicationData.IsPlusVersion)
				newDetails = $@"ChronClient⧫ v{ChronClient.Data.GlobalData.ApplicationData.VERSION}";
			if (!ChronClient.Data.GlobalData.ApplicationData.IsChronLite && !ChronClient.Data.GlobalData.ApplicationData.IsPlusVersion)
				newDetails = $@"ChronClient v{ChronClient.Data.GlobalData.ApplicationData.VERSION}";
			if (ChronClient.Data.GlobalData.ApplicationData.IsChronLite && ChronClient.Data.GlobalData.ApplicationData.IsPlusVersion)
				newDetails = $@"ChronClient⧫ Lite v{ChronClient.Data.GlobalData.ChronLiteData.VERSION}";
			if (ChronClient.Data.GlobalData.ApplicationData.IsChronLite && !ChronClient.Data.GlobalData.ApplicationData.IsPlusVersion)
				newDetails = $@"ChronClient Lite v{ChronClient.Data.GlobalData.ChronLiteData.VERSION}";

			client.SetPresence(new RichPresence()
			{
				Details = newDetails,
				State = "",
				Assets = new Assets()
				{
					LargeImageKey = "discord-rps-1000",
					LargeImageText = newDetails,
				}
			});
		}

		public static async void CloseAsync()
		{
			Close();
		}
		public static void Close()
        {
			if (client != null)
			{
				client.Dispose();
			}
		}
    }
}
