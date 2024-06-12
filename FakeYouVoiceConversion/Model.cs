using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FakeYouVoiceConversion
{
    public class ApiResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("models")]
        public List<Model> Models { get; set; }
    }
    public class Model
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("model_type")]
        public string ModelType { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("creator")]
        public Creator Creator { get; set; }

        [JsonPropertyName("creator_set_visibility")]
        public string CreatorSetVisibility { get; set; }

        [JsonPropertyName("ietf_language_tag")]
        public string IetfLanguageTag { get; set; }

        [JsonPropertyName("ietf_primary_language_subtag")]
        public string IetfPrimaryLanguageSubtag { get; set; }

        [JsonPropertyName("is_front_page_featured")]
        public bool IsFrontPageFeatured { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
    public class Creator
    {
        [JsonPropertyName("user_token")]
        public string UserToken { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("gravatar_hash")]
        public string GravatarHash { get; set; }

        [JsonPropertyName("default_avatar")]
        public DefaultAvatar DefaultAvatar { get; set; }
    }
    public class DefaultAvatar
    {
        [JsonPropertyName("image_index")]
        public int ImageIndex { get; set; }

        [JsonPropertyName("color_index")]
        public int ColorIndex { get; set; }
    }
}
