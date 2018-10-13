using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TradingBot
{
    public class BotController
    {
        public static ITelegramBotClient BotClient;
        public static List<InlineKeyboardButton> ButtonList = new List<InlineKeyboardButton>();

        public BotController()
        {
            BotClient = new TelegramBotClient("630987517:AAFMu_xNCbyDKOt_4t4LeEtk7lvXs5bB_mA");
            var me = BotClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );
            BotClient.OnMessage += Bot_OnMessage;
            ButtonList.Add(InlineKeyboardButton.WithCallbackData("Help"));
            ButtonList.Add(InlineKeyboardButton.WithCallbackData("Get data"));
            BotClient.StartReceiving();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            switch (e.Message.Text)
            {
                case "hi":
                    await BotClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "Hi, i am CryptoTradingBot\n Help:");
                    break;
                default:
                    Console.WriteLine($"Message: {e.Message.Text}");
                    Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                    await BotClient.SendTextMessageAsync(
                      chatId: e.Message.Chat,
                      text: "You said:\n" + e.Message.Text
                    );
                    break;
            }

            await BotClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: "<b>Help<b>",
                replyMarkup: new InlineKeyboardMarkup(ButtonList));
        }
    }
}
