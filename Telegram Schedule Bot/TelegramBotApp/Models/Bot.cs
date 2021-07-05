using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Args;
using TelegramBotApp.Models.Commands;

namespace TelegramBotApp.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandsList;
    

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }

            commandsList = new List<Command>();
            commandsList.Add(new HelloCommand());
            commandsList.Add(new TimeTable());
            commandsList.Add(new Start());
            //commandsList.Add(new Keyboard());
            //TODO: Add more commands

            client = new TelegramBotClient(AppSettings.Key);
           
            var hook = string.Format(AppSettings.Url, "api/update");
            await client.SetWebhookAsync(hook);           
            return client;
        }
       
    }
}