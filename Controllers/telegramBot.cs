using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Newtonsoft.Json;
using System.Web;
using Telegram_Bot.models;

namespace Telegram_Bot.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class telegramBot : ControllerBase
    {
        //botClient = new TelegramBotClient("1770785118:AAF6d9W3xbI1G4n-EW4Nz4MiK6BgdjM9EN0");
        [HttpGet]
        public IActionResult Get()
        {

            return Ok("hello world");
        }

        [HttpPost]
        public IActionResult Post(JObject payload)
        {

            var hey = payload.ToObject<botUpdates>();
            var myDetails = payload.ToString();
            botUpdates data = JsonConvert.DeserializeObject<botUpdates>(myDetails);
            var msgid = data.Message.Text;
            Console.WriteLine(payload.ToString());
            Console.WriteLine(msgid);
            var botClient = new TelegramBotClient("1770785118:AAF6d9W3xbI1G4n-EW4Nz4MiK6BgdjM9EN0");
            // var me = botClient.GetMeAsync().Result;
            // Console.WriteLine(
            //   $"Hello, World! I am user {me.Username} and my name is {me.FirstName}."
            // );
            if (data.Message.Text == "/hello")
            {
                botClient.SendTextMessageAsync(
                    chatId: data.Message.Chat.Id,
                    text: "hello " + data.Message.From.FirstName);
            }
            else if (data.Message.Text == "/disha")
            {
                botClient.SendTextMessageAsync(
                    chatId: data.Message.Chat.Id,
                    text: data.Message.From.FirstName + " called Disha");
            }
            else if (data.Message.Chat.Type == "private")
            {
                if (data.Message.Text == "tell me time")
                {
                    botClient.SendTextMessageAsync(
                        chatId: data.Message.Chat.Id,
                        text: "Current time is = " + DateTime.Now.ToString("h:mm:ss tt"));
                }
            }
            else if (data.Message.Text.StartsWith("/"))
            {
                botClient.SendTextMessageAsync(
                    chatId: data.Message.Chat.Id,
                    text: "hello " + data.Message.From.FirstName + " you said \n" + data.Message.Text);
            }


            return Ok(payload.ToString());
        }


    }
}
