using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotApp.Models.Commands
{
    public class TimeTable : Command
    {
        public override string Name => "timetable";
        

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            var inlineKeyBoard = new InlineKeyboardMarkup(new[] {
                         new [] {
                             InlineKeyboardButton.WithCallbackData("Понеділок"),
                             InlineKeyboardButton.WithCallbackData("Вівторок")

                         },
                         new [] {
                             InlineKeyboardButton.WithCallbackData("Середа"),
                             InlineKeyboardButton.WithCallbackData("Четвер")

                         },
                         new [] {
                             InlineKeyboardButton.WithCallbackData("Пятниця")
                         }

                     });
            client.SendTextMessageAsync(message.Chat.Id, "Виберіть день який Вас цікавить", replyMarkup: inlineKeyBoard);

        }
      

    }
}