namespace Telegram_Bot.models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BotChannelMsg
    {
        [JsonProperty("update_id")]
        public long UpdateId { get; set; }

        [JsonProperty("channel_post")]
        public ChannelPost ChannelPost { get; set; }
    }

    public partial class ChannelPost
    {
        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        [JsonProperty("sender_chat")]
        public Chatchannel SenderChat { get; set; }

        [JsonProperty("chatchannel")]
        public Chatchannel Chat { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class Chatchannel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
