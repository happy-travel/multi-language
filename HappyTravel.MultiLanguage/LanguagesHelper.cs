using System;

namespace HappyTravel.MultiLanguage
{
    public class LanguagesHelper
    {
        public static string GetLanguageCode(Languages language)
        {
            var languageCode = language switch
            {
                Languages.Arabic => ArabicLanguageCode,
                Languages.English => EnglishLanguageCode,
                Languages.Russian => RussianLanguageCode,
                Languages.Bulgarian => BulgarianLanguageCode,
                Languages.French => FrenchLanguageCode,
                Languages.German => GermanLanguageCode,
                Languages.Greek => GreekLanguageCode,
                Languages.Hungarian => HungarianLanguageCode,
                Languages.Italian => ItalianLanguageCode,
                Languages.Polish => PolishLanguageCode,
                Languages.Portuguese => PortugueseLanguageCode,
                Languages.Romanian => RomanianLanguageCode,
                Languages.Serbian => SerbianLanguageCode,
                Languages.Spanish => SpanishLanguageCode,
                Languages.Turkish => TurkishLanguageCode,
                Languages.Unknown => throw new ArgumentException("Language is unknown"),
                _ => throw new ArgumentOutOfRangeException(nameof(language), language, null)
            };
            return languageCode.ToLowerInvariant();
        }


        public static bool TryGetLanguage(string languageCode, out Languages language)
        {
            language = languageCode.ToUpperInvariant() switch
            {
                ArabicLanguageCode => Languages.Arabic,
                BulgarianLanguageCode => Languages.Bulgarian,
                GermanLanguageCode => Languages.German,
                GreekLanguageCode => Languages.Greek,
                EnglishLanguageCode => Languages.English,
                SpanishLanguageCode => Languages.Spanish,
                FrenchLanguageCode => Languages.French,
                ItalianLanguageCode => Languages.Italian,
                HungarianLanguageCode => Languages.Hungarian,
                PolishLanguageCode => Languages.Polish,
                PortugueseLanguageCode => Languages.Portuguese,
                RomanianLanguageCode => Languages.Romanian,
                RussianLanguageCode => Languages.Russian,
                SerbianLanguageCode => Languages.Serbian,
                TurkishLanguageCode => Languages.Turkish,
                _ => Languages.Unknown
            };

            return language != Languages.Unknown;
        }


        public const Languages DefaultLanguage = Languages.English;

        private const string ArabicLanguageCode = "AR";
        private const string BulgarianLanguageCode = "BG";
        private const string GermanLanguageCode = "DE";
        private const string GreekLanguageCode = "EL";
        private const string EnglishLanguageCode = "EN";
        private const string SpanishLanguageCode = "ES";
        private const string FrenchLanguageCode = "FR";
        private const string ItalianLanguageCode = "IT";
        private const string HungarianLanguageCode = "HU";
        private const string PolishLanguageCode = "PL";
        private const string PortugueseLanguageCode = "PT";
        private const string RomanianLanguageCode = "RO";
        private const string RussianLanguageCode = "RU";
        private const string SerbianLanguageCode = "SR";
        private const string TurkishLanguageCode = "TR";
    }
}