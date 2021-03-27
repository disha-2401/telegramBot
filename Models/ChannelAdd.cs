using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Telegram_Bot.Models
{
    public class ChannelAdd
    {
        [JsonProperty("update_id")]
        public long UpdateId { get; set; }

        [JsonProperty("my_chat_member")]
        public MyChatMember MyChatMember { get; set; }
    }
    public partial class MyChatMember
    {
        [JsonProperty("chat")]
        public Chat Chat { get; set; }

        [JsonProperty("from")]
        public From From { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("old_chat_member")]
        public OldChatMember OldChatMember { get; set; }

        [JsonProperty("new_chat_member")]
        public NewChatMember NewChatMember { get; set; }
    }

    public partial class Chat
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

    public partial class From
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("is_bot")]
        public bool IsBot { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("language_code")]
        public string LanguageCode { get; set; }
    }

    public partial class NewChatMember
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("can_be_edited")]
        public bool CanBeEdited { get; set; }

        [JsonProperty("can_manage_chat")]
        public bool CanManageChat { get; set; }

        [JsonProperty("can_change_info")]
        public bool CanChangeInfo { get; set; }

        [JsonProperty("can_post_messages")]
        public bool CanPostMessages { get; set; }

        [JsonProperty("can_edit_messages")]
        public bool CanEditMessages { get; set; }

        [JsonProperty("can_delete_messages")]
        public bool CanDeleteMessages { get; set; }

        [JsonProperty("can_invite_users")]
        public bool CanInviteUsers { get; set; }

        [JsonProperty("can_restrict_members")]
        public bool CanRestrictMembers { get; set; }

        [JsonProperty("can_promote_members")]
        public bool CanPromoteMembers { get; set; }

        [JsonProperty("can_manage_voice_chats")]
        public bool CanManageVoiceChats { get; set; }

        [JsonProperty("is_anonymous")]
        public bool IsAnonymous { get; set; }
    }

    public partial class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("is_bot")]
        public bool IsBot { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    public partial class OldChatMember
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}


