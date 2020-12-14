using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace HappyTravel.MultiLanguage
{
    public class MultiLanguage<T>
    {
        [JsonPropertyName("ar")]
        public T Ar
        {
            get => GetValue(Languages.Arabic);
            set => SetValue(Languages.Arabic, value);
        }

        [JsonPropertyName("en")]
        public T En
        {
            get => GetValue(Languages.English);
            set => SetValue(Languages.English, value);
        }

        [JsonPropertyName("ru")]
        public T Ru
        {
            get => GetValue(Languages.Russian);
            set => SetValue(Languages.Russian, value);
        }

        [JsonPropertyName("bg")]
        public T Bg
        {
            get => GetValue(Languages.Bulgarian);
            set => SetValue(Languages.Bulgarian, value);
        }

        [JsonPropertyName("de")]
        public T De
        {
            get => GetValue(Languages.German);
            set => SetValue(Languages.German, value);
        }

        [JsonPropertyName("el")]
        public T El
        {
            get => GetValue(Languages.Greek);
            set => SetValue(Languages.Greek, value);
        }

        [JsonPropertyName("es")]
        public T Es
        {
            get => GetValue(Languages.Spanish);
            set => SetValue(Languages.Spanish, value);
        }

        [JsonPropertyName("fr")]
        public T Fr
        {
            get => GetValue(Languages.French);
            set => SetValue(Languages.French, value);
        }

        [JsonPropertyName("it")]
        public T It
        {
            get => GetValue(Languages.Italian);
            set => SetValue(Languages.Italian, value);
        }


        [JsonPropertyName("hu")]
        public T Hu
        {
            get => GetValue(Languages.Hungarian);
            set => SetValue(Languages.Hungarian, value);
        }

        [JsonPropertyName("pl")]
        public T Pl
        {
            get => GetValue(Languages.Polish);
            set => SetValue(Languages.Polish, value);
        }

        [JsonPropertyName("pt")]
        public T Pt
        {
            get => GetValue(Languages.Portuguese);
            set => SetValue(Languages.Portuguese, value);
        }

        [JsonPropertyName("ro")]
        public T Ro
        {
            get => GetValue(Languages.Romanian);
            set => SetValue(Languages.Romanian, value);
        }

        [JsonPropertyName("sr")]
        public T Sr
        {
            get => GetValue(Languages.Serbian);
            set => SetValue(Languages.Serbian, value);
        }

        [JsonPropertyName("tr")]
        public T Tr
        {
            get => GetValue(Languages.Turkish);
            set => SetValue(Languages.Turkish, value);
        }


        public bool TryGetValue(string languageCode, out T value)
        {
            value = default;

            return LanguagesHelper.TryGetLanguage(languageCode, out var language) &&
                _languageStore.TryGetValue(language, out value);
        }


        public bool TryGetValueOrDefault(string languageCode, out T value)
        {
            if (TryGetValue(languageCode, out value))
                return true;

            var defaultLanguageCode = LanguagesHelper.GetLanguageCode(LanguagesHelper.DefaultLanguage);

            return TryGetValue(defaultLanguageCode, out value);
        }


        public bool TrySetValue(string languageCode, T value)
        {
            if (!LanguagesHelper.TryGetLanguage(languageCode, out var language))
                return false;

            SetValue(language, value);

            return true;
        }


        public void SetValue(Languages language, T value)
        {
            if (!_languageStore.TryAdd(language, value))
                _languageStore[language] = value;
        }


        public IEnumerable<T> GetValues() => _languageStore.Values.Where(i => i != null);


        public List<(string languageCode, T value)> GetAll() => _languageStore.Select(kv => (LanguagesHelper.GetLanguageCode(kv.Key), kv.Value)).ToList();


        private T GetValue(Languages language)
        {
            _languageStore.TryGetValue(language, out var value);
            return value;
        }


        public override bool Equals(object? obj) => obj is MultiLanguage<T> other && Equals(other);


        public bool Equals(MultiLanguage<T> other) => JsonConvert.SerializeObject(this).Equals(JsonConvert.SerializeObject(other, _serializeSettings));


        public override int GetHashCode() => HashCode.Combine(JsonConvert.SerializeObject(this, _serializeSettings));


        private readonly Dictionary<Languages, T> _languageStore = new Dictionary<Languages, T>();


        private readonly JsonSerializerSettings _serializeSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            MaxDepth = 5,
            Culture = CultureInfo.InvariantCulture
        };
    }
}