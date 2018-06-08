using System;
using System.Runtime.Serialization;

namespace BadEggStudio.Core.Exception {
	[System.Serializable]
	public class NetworkException : System.Exception {
		public NetworkException () {

		}
		public NetworkException (string message) : base(message) {

		}
		public NetworkException (string message, System.Exception inner) : base (message, inner) {
			
		}
		protected NetworkException (SerializationInfo info, StreamingContext context) : base (info, context) {

		}
	}
}
