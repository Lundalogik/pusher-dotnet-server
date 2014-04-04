using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace PusherRESTDotNet
{
    public class Authentication
    {
        private readonly string _applicationKey;
        private readonly string _applicationSecret;

        public Authentication(string applicationKey, string applicationSecret)
        {
            this._applicationKey = applicationKey;
            this._applicationSecret = applicationSecret;
        }

        public string CreateAuthenticatedString(string channelName, string socketId)
        {
            string auth = GetAuthString(socketId + ":" + channelName, _applicationSecret);

            var data = new AuthData {auth = _applicationKey + ":" + auth};

            return JsonConvert.SerializeObject(data);
        }

        public string CreateAuthenticatedString(string channelName, string socketId, PresenceChannelData channelData)
        {
            string channel = (channelData == null ? "" : JsonConvert.SerializeObject(channelData));
            string auth = GetAuthString(socketId + ":" + channelName + ":" + channel,
                _applicationSecret);

            var data = new AuthData {auth = _applicationKey + ":" + auth, channel_data = channel};

            return JsonConvert.SerializeObject(data);
        }

        public static string GetAuthString(string authData, string applicationSecretKey)
        {
            var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(applicationSecretKey));
            var hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(authData));

            return BytesToHex(hash);
        }

        public static string BytesToHex(IEnumerable<byte> byteArray)
        {
            return String.Concat(byteArray.Select(bytes => bytes.ToString("x2")).ToArray());
        }
    }
}