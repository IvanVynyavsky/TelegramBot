using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotApp.Models;
using TelegramBotApp.Models.Commands;

namespace TelegramBotApp.Controllers
{
    public class UpdateController : ApiController
    {
        [Route(@"api/update")] //webhook uri part
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();

            switch (update.Type)
            {
                case UpdateType.CallbackQuery:
                    CallbackQuery callbackQuery = update.CallbackQuery;
                    await client.AnswerCallbackQueryAsync(callbackQuery.Id, $"Received {callbackQuery.Data}");
                    string callBackData = callbackQuery.Data;
                    switch (callbackQuery.Data)
                    {
                        case "Понеділок":
                            string Monday = "8:30 - 9:50 Нереаліційні бази даних \n10:10 - 11:30 Нереаліційні бази даних\n";
                            await client.SendTextMessageAsync(callbackQuery.Message.Chat.Id, Monday);
                            break;
                        case "Вівторок":
                            string Tuesday = "11:50 - 13:10 Чисельні методи \n13:30 - 14:50 Чисельні методи\n15:05 - 16:25Чисельні методи\n";
                            await client.SendTextMessageAsync(callbackQuery.Message.Chat.Id, Tuesday);
                            break;
                        case "Середа":
                            string Wednesday = "8:30 - 9:50 ML \n10:10 - 11:30 ML\n";
                            await client.SendTextMessageAsync(callbackQuery.Message.Chat.Id, Wednesday);
                            break;
                        case "Четвер":
                            string Thursday = "15:05 - 16:25 КомпМоделі \n16:40 - 18:00 КомпМоделі\n";
                            await client.SendTextMessageAsync(callbackQuery.Message.Chat.Id, Thursday);
                            break;
                        case "Пятниця":
                            string Friday = "11:50 - 13:10 Операційні системи\n13:30 - 14:50 Операційні системи\n15:05 - 16:25 МатМоделі МСС\n";
                            await client.SendTextMessageAsync(callbackQuery.Message.Chat.Id, Friday);
                            break;
                        default:
                            break;
                    }

                    break;
                default:
                    break;
            }

            return Ok();



        }
    }
}
