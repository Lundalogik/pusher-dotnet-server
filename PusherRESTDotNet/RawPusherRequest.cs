namespace PusherRESTDotNet
{
    public class RawPusherRequest : PusherRequest
    {
        private readonly string _jsonData;

        public RawPusherRequest(string channelName, string eventName, string jsonData)
            : base(channelName, eventName)
        {
            _jsonData = jsonData;
        }

        public override string JsonData
        {
            get { return _jsonData; }
        }
    }
}