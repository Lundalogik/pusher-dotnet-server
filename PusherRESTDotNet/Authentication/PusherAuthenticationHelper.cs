﻿using Newtonsoft.Json;

namespace PusherRESTDotNet.Authentication
{
    public class PusherAuthenticationHelper
    {
        private string applicationId;
        private string applicationKey;
        private string applicationSecret;

        public PusherAuthenticationHelper(string applicationId, string applicationKey, string applicationSecret)
        {
            this.applicationId = applicationId;
            this.applicationKey = applicationKey;
            this.applicationSecret = applicationSecret;
        }

        public string CreateAuthenticatedString(string socketId, string channelName)
        {
            string auth = AuthSignatureHelper.GetAuthString(socketId + ":" + channelName, applicationSecret);

            AuthData data = new AuthData();
            data.auth = applicationKey + ":" + auth;

            string json = JsonConvert.SerializeObject(data);
            return json;
        }

        public string CreateAuthenticatedString(string socketId, string channelName, PresenceChannelData channelData)
        {
            string channel = (channelData == null?"":JsonConvert.SerializeObject(channelData));
            string auth = AuthSignatureHelper.GetAuthString(socketId + ":" + channelName + ":" + channel, applicationSecret);

            AuthData data = new AuthData();
            data.auth = applicationKey + ":" + auth;
            data.channel_data = channel;

            string json = JsonConvert.SerializeObject(data);
            return json;
        }
    }
}
