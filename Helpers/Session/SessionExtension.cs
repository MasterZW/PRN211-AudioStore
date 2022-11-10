using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AudioStore.Helpers.Session
{
    public static class SessionExtension
    {
        public static void SetObjects(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjects<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}