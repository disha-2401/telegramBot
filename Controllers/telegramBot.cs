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
            var privatechat = payload.ToObject<botUpdates>();
            var channelmsg = payload.ToObject<BotChannelMsg>();
            string value = ((dynamic)payload).message.message_id.ToString();
           // var b=value.Toprivatechatect<Telegram.Bot.Types.Message>();
            Console.WriteLine("hello");
            //payload.Toprivatechatect<Telegram.Bot.Types.Message>();
            var botClient = new TelegramBotClient("1770785118:AAF6d9W3xbI1G4n-EW4Nz4MiK6BgdjM9EN0");
            var me = botClient.GetMeAsync().Result;

            Console.WriteLine(
              $"Hello, World! I am user {me.Username} and my name is {me.FirstName}.");
            if (privatechat.Message != null)
            { 
                if (privatechat.Message.Text == "/hello")
                {
                    botClient.SendTextMessageAsync(
                        chatId: privatechat.Message.Chat.Id,
                        text: "hello " + privatechat.Message.From.FirstName);
                }
                else if (privatechat.Message.Text == "/disha")
                {
                    botClient.SendTextMessageAsync(
                        chatId: privatechat.Message.Chat.Id,
                        text: privatechat.Message.From.FirstName + " called Disha");
                }
                else if (privatechat.Message.Text == "tell me time")
                {
                    botClient.SendTextMessageAsync(
                        chatId: privatechat.Message.Chat.Id,
                        text: "Current time is = " + DateTime.Now.ToString("h:mm:ss tt"));
                }
                else if (privatechat.Message.Text.StartsWith("/"))
                {
                    botClient.SendTextMessageAsync(
                        chatId: privatechat.Message.Chat.Id,
                        text: "hello " + privatechat.Message.From.FirstName + " you said \n" + privatechat.Message.Text);
                }
                return Ok(payload.ToString());

            }
            else if (channelmsg.ChannelPost != null)
            {
                Console.WriteLine(channelmsg.UpdateId);
                Console.WriteLine(channelmsg.ChannelPost.SenderChat.Username);

                botClient.SendTextMessageAsync(
                        chatId: channelmsg.ChannelPost.SenderChat.Username,
                        text: "channel msg");
                return Ok(payload.ToString());
            }
            else
            {
                return Ok(payload.ToString());
            }
            var abc = payload.ToString();
            botUpdates data = JsonConvert.DeserializeObject<botUpdates>(abc);
            var msgid = data.Message.Text;
            Console.WriteLine(payload.ToString());
            Console.WriteLine(msgid);

            return Ok();
        }


    }
}
