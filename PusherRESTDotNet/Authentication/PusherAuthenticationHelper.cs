using Newtonsoft.Json;

namespace PusherRESTDotNet.Authentication
{
    public class PusherAuthenticationHelper
    {
        private string applicationKey;
        private string applicationSecret;

        public PusherAuthenticationHelper(string applicationKey, string applicationSecret)
        {
            this.applicationKey = applicationKey;
            this.applicationSecret = applicationSecret;
        }

        public string CreateAuthenticatedString(string channelName, string socketId)
        {
            string auth = AuthSignatureHelper.GetAuthString(socketId + ":" + channelName, applicationSecret);

            AuthData data = new AuthData();
            data.auth = applicationKey + ":" + auth;

            string json = JsonConvert.SerializeObject(data);
            return json;
        }

        public string CreateAuthenticatedString(string channelName, string socketId, PresenceChannelData channelData)
        {
            string channel = (channelData == null ? "" : JsonConvert.SerializeObject(channelData));
            string auth = AuthSignatureHelper.GetAuthString(socketId + ":" + channelName + ":" + channel,
                applicationSecret);

            AuthData data = new AuthData();
            data.auth = applicationKey + ":" + auth;
            data.channel_data = channel;

            string json = JsonConvert.SerializeObject(data);
            return json;
        }
    }
}