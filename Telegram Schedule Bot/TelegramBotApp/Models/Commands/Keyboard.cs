using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotApp.Models.Commands
{
    public class Keyboard : Command
    {
        public override string Name => "keyboard";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var replyKeyboard = new ReplyKeyboardMarkup(new[]{
                new[]{
                    new KeyboardButton("Моя геолокація"){ RequestLocation = true},
                    new KeyboardButton("Мій контакт"){ RequestContact = true} 
                }

            });
            client.SendTextMessageAsync(message.Chat.Id,"Вибери що тебе цікавить",replyMarkup:replyKeyboard);
        }
    }
}