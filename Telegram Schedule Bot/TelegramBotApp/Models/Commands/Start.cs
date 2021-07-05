using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace TelegramBotApp.Models.Commands
{
    public class Start : Command
    {
        public override string Name => "start";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            client.SendTextMessageAsync(chatId, "Привіт" + " \n Цей бот для перегляду розкладу \n");
        }

      
    }
}