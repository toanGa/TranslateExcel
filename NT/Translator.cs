// Copyright (c) 2015 Ravi Bhavnani
// License: Code Project Open License
// http://www.codeproject.com/info/cpol10.aspx

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
namespace RavSoft.GoogleTranslator
{
    /// <summary>
    /// Translates text using Google's online language tools.
    /// </summary>
    public class Translator
    {
        #region Properties

        /// <summary>
        /// Gets the supported languages.
        /// </summary>
        public static IEnumerable<string> Languages
        {
            get
            {
                Translator.EnsureInitialized();
                return Translator._languageModeMap.Keys.OrderBy(p => p);
            }
        }

        /// <summary>
        /// Gets the time taken to perform the translation.
        /// </summary>
        public TimeSpan TranslationTime
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the url used to speak the translation.
        /// </summary>
        /// <value>The url used to speak the translation.</value>
        public string TranslationSpeechUrl
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        public Exception Error
        {
            get;
            private set;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Translates the specified source text.
        /// </summary>
        /// <param name="sourceText">The source text.</param>
        /// <param name="sourceLanguage">The source language.</param>
        /// <param name="targetLanguage">The target language.</param>
        /// <returns>The translation.</returns>
        public string Translate
            (string sourceText,
             string sourceLanguage,
             string targetLanguage)
        {
            // Initialize
            this.Error = null;
            this.TranslationSpeechUrl = null;
            this.TranslationTime = TimeSpan.Zero;
            DateTime tmStart = DateTime.Now;
            string translation = string.Empty;

            try
            {
                // Download translation
                string url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
                                            Translator.LanguageEnumToIdentifier(sourceLanguage),
                                            Translator.LanguageEnumToIdentifier(targetLanguage),
                                            WebUtility.UrlEncode(sourceText));
                string outputFile = Path.GetTempFileName();
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
                    wc.DownloadFile(url, outputFile);
                }

                // Get translated text
                if (File.Exists(outputFile))
                {
                    // Get phrase collection
                    string text = File.ReadAllText(outputFile);

                    translation = ParseResut(text);
                }
            }
            catch (Exception ex)
            {
                this.Error = ex;
                Console.WriteLine(ex.ToString());
            }

            // Return result
            this.TranslationTime = DateTime.Now - tmStart;
            return translation;
        }

        #endregion

        #region Private methods

        // to debug first
        public static string ParseResut(string input)
        {
            string result = "";
            string seperate = "\",\"";
            string langTrans = "vi_en";
            bool firstParse = true;

            int idxSeperate;
            int i;
            int idxStart;
            int idxEnd;
            int idxParseNext;

            string trimParse = input;

            while(trimParse.Contains(seperate))
            {
                i = trimParse.IndexOf(seperate);
                if(trimParse.Substring(i + seperate.Length, langTrans.Length).Equals(langTrans))
                {
                    trimParse = trimParse.Substring(i + seperate.Length);
                    continue;
                }

                idxStart = i;
                idxEnd = i;
                // not \"
                while ((trimParse[i - 1] != '\"') || (trimParse[i - 2] == '\\'))
                {
                    idxStart --;
                    i--;
                }
                string parsed = trimParse.Substring(idxStart, idxEnd - idxStart);
                Console.WriteLine("\\n");
                parsed = parsed.Replace("\\n", Environment.NewLine);

                if(firstParse)
                {
                    if (parsed[0] == '=' || parsed[0] == '+' || parsed[0] == '-')
                    {
                        parsed = "\'" + parsed;
                    }
                }
                firstParse = false;

                result += parsed;

                trimParse = trimParse.Substring(idxEnd + seperate.Length);

                
                Console.WriteLine(parsed);
                Console.WriteLine(trimParse);
            }

            return result;
        }
        /// <summary>
        /// Converts a language to its identifier.
        /// </summary>
        /// <param name="language">The language."</param>
        /// <returns>The identifier or <see cref="string.Empty"/> if none.</returns>
        private static string LanguageEnumToIdentifier
            (string language)
        {
            string mode = string.Empty;
            Translator.EnsureInitialized();
            Translator._languageModeMap.TryGetValue(language, out mode);
            return mode;
        }

        /// <summary>
        /// Ensures the translator has been initialized.
        /// </summary>
        private static void EnsureInitialized()
        {
            if (Translator._languageModeMap == null)
            {
                Translator._languageModeMap = new Dictionary<string, string>();
                Translator._languageModeMap.Add("Afrikaans", "af");
                Translator._languageModeMap.Add("Albanian", "sq");
                Translator._languageModeMap.Add("Arabic", "ar");
                Translator._languageModeMap.Add("Armenian", "hy");
                Translator._languageModeMap.Add("Azerbaijani", "az");
                Translator._languageModeMap.Add("Basque", "eu");
                Translator._languageModeMap.Add("Belarusian", "be");
                Translator._languageModeMap.Add("Bengali", "bn");
                Translator._languageModeMap.Add("Bulgarian", "bg");
                Translator._languageModeMap.Add("Catalan", "ca");
                Translator._languageModeMap.Add("Chinese", "zh-CN");
                Translator._languageModeMap.Add("Croatian", "hr");
                Translator._languageModeMap.Add("Czech", "cs");
                Translator._languageModeMap.Add("Danish", "da");
                Translator._languageModeMap.Add("Dutch", "nl");
                Translator._languageModeMap.Add("English", "en");
                Translator._languageModeMap.Add("Esperanto", "eo");
                Translator._languageModeMap.Add("Estonian", "et");
                Translator._languageModeMap.Add("Filipino", "tl");
                Translator._languageModeMap.Add("Finnish", "fi");
                Translator._languageModeMap.Add("French", "fr");
                Translator._languageModeMap.Add("Galician", "gl");
                Translator._languageModeMap.Add("German", "de");
                Translator._languageModeMap.Add("Georgian", "ka");
                Translator._languageModeMap.Add("Greek", "el");
                Translator._languageModeMap.Add("Haitian Creole", "ht");
                Translator._languageModeMap.Add("Hebrew", "iw");
                Translator._languageModeMap.Add("Hindi", "hi");
                Translator._languageModeMap.Add("Hungarian", "hu");
                Translator._languageModeMap.Add("Icelandic", "is");
                Translator._languageModeMap.Add("Indonesian", "id");
                Translator._languageModeMap.Add("Irish", "ga");
                Translator._languageModeMap.Add("Italian", "it");
                Translator._languageModeMap.Add("Japanese", "ja");
                Translator._languageModeMap.Add("Korean", "ko");
                Translator._languageModeMap.Add("Lao", "lo");
                Translator._languageModeMap.Add("Latin", "la");
                Translator._languageModeMap.Add("Latvian", "lv");
                Translator._languageModeMap.Add("Lithuanian", "lt");
                Translator._languageModeMap.Add("Macedonian", "mk");
                Translator._languageModeMap.Add("Malay", "ms");
                Translator._languageModeMap.Add("Maltese", "mt");
                Translator._languageModeMap.Add("Norwegian", "no");
                Translator._languageModeMap.Add("Persian", "fa");
                Translator._languageModeMap.Add("Polish", "pl");
                Translator._languageModeMap.Add("Portuguese", "pt");
                Translator._languageModeMap.Add("Romanian", "ro");
                Translator._languageModeMap.Add("Russian", "ru");
                Translator._languageModeMap.Add("Serbian", "sr");
                Translator._languageModeMap.Add("Slovak", "sk");
                Translator._languageModeMap.Add("Slovenian", "sl");
                Translator._languageModeMap.Add("Spanish", "es");
                Translator._languageModeMap.Add("Swahili", "sw");
                Translator._languageModeMap.Add("Swedish", "sv");
                Translator._languageModeMap.Add("Tamil", "ta");
                Translator._languageModeMap.Add("Telugu", "te");
                Translator._languageModeMap.Add("Thai", "th");
                Translator._languageModeMap.Add("Turkish", "tr");
                Translator._languageModeMap.Add("Ukrainian", "uk");
                Translator._languageModeMap.Add("Urdu", "ur");
                Translator._languageModeMap.Add("Vietnamese", "vi");
                Translator._languageModeMap.Add("Welsh", "cy");
                Translator._languageModeMap.Add("Yiddish", "yi");
            }
        }

        #endregion

        #region Fields

        /// <summary>
        /// The language to translation mode map.
        /// </summary>
        private static Dictionary<string, string> _languageModeMap;

        #endregion
    }
}
