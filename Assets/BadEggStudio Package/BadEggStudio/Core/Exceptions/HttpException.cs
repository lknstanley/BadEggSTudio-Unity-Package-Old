using System;
using System.Runtime.Serialization;

namespace BadEggStudio.Core.Exception {
	[System.Serializable]
	public class HttpException : System.Exception {
		public HttpException () {

		}
		public HttpException (string message) : base(message) {

		}
		public HttpException (string message, System.Exception inner) : base (message, inner) {
			
		}
		protected HttpException (SerializationInfo info, StreamingContext context) : base (info, context) {

		}
	}
}
