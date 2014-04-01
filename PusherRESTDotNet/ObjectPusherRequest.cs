using Newtonsoft.Json;

namespace PusherRESTDotNet
{
	/// <summary>
	/// Provides a simple <see cref="PusherRequest"/> wrapper that provides JsonData by serializing an object using a <see cref="System.Web.Script.Serialization.JavaScriptSerializer" />
	/// </summary>
	public class ObjectPusherRequest : PusherRequest
	{
		private readonly string _serializedData;

		public ObjectPusherRequest(string channelName, string eventName, object data)
			: base(channelName, eventName)
		{
			_serializedData = JsonConvert.SerializeObject(data);
		}

		public override string JsonData
		{
			get { return _serializedData; }
		}
	}
}