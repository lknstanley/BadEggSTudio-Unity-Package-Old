using System;
using System.Runtime.Serialization;

namespace BadEggStudio.Core.Exception {
	[System.Serializable]
	public class HttpException : System.Exception {
		/// <summary>
		/// A network exception for handling UnityWebRequest http request error.
		/// </summary>
		public HttpException () {

		}
		/// <summary>
		/// A network exception for handling UnityWebRequest http request error.
		/// </summary>
		/// <param name="message">A error message</param>
		/// <returns></returns>
		public HttpException (string message) : base(message) {

		}

		/// <summary>
		/// A network exception for handling UnityWebRequest http request error.
		/// </summary>
		/// <param name="message">A error message</param>
		/// <param name="inner">Inner</param>
		/// <returns></returns>
		public HttpException (string message, System.Exception inner) : base (message, inner) {
			
		}

		/// <summary>
		/// A network exception for handling UnityWebRequest http request error.
		/// </summary>
		/// <param name="info">Info</param>
		/// <param name="context">Context</param>
		/// <returns></returns>
		protected HttpException (SerializationInfo info, StreamingContext context) : base (info, context) {

		}
	}
}
