using System.Runtime.Serialization;

namespace PusherRESTDotNet.Authentication
{
    internal class AuthData
    {
        public string auth { get; set; }

        public string channel_data { get; set; }
    }
}