using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace Dashboard.MVC
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        private readonly JsonSerializer _Serializer = new JsonSerializer();

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var ActualValue = this[name];
                return !ActualValue.ResourceNotFound
                    ? new LocalizedString(name, string.Format(ActualValue.Value, arguments)) : ActualValue;
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var filePath = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";
            using (var Stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var StreamReader = new StreamReader(Stream))
            using (var Reader = new JsonTextReader(StreamReader))

                while (Reader.Read())
                {
                    if (Reader.TokenType != JsonToken.PropertyName) continue;
                    var key = Reader.Value as string;
                    Reader.Read();
                    var value = _Serializer.Deserialize<string>(Reader);
                    yield return new LocalizedString(key!, value!);
                }
        }

        private string GetString(string key)
        {
            var filePath = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";
            var FullFilePath = Path.GetFullPath(filePath);

            if (File.Exists(FullFilePath))
            {
                var result = GetValueFromJson(key, FullFilePath);
                return result;
            }
            return string.Empty;
        }

        private string GetValueFromJson(string propertyName, string FilePath)
        {
            if (string.IsNullOrEmpty(FilePath) || string.IsNullOrEmpty(FilePath)) return string.Empty;
            using (var Stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var StreamReader = new StreamReader(Stream))
            using (var Reader = new JsonTextReader(StreamReader))

                while (Reader.Read())
                {
                    if (Reader.TokenType == JsonToken.PropertyName && Reader.Value as string == propertyName)
                    {
                        Reader.Read();
                        return _Serializer.Deserialize<string>(Reader)!;
                    }
                }
            return string.Empty;
        }
    }
}