using System;
using System.Runtime.Serialization;

namespace BadEggStudio.Core.Exception {
	[System.Serializable]
	public class NetworkException : System.Exception {
		/// <summary>
		/// A network exception for handling UnityWebRequest networking error.
		/// </summary>
		public NetworkException () {

		}

		/// <summary>
		/// A network exception for handling UnityWebRequest networking error.
		/// </summary>
		/// <param name="message">A error message</param>
		/// <returns></returns>
		public NetworkException (string message) : base(message) {

		}

		/// <summary>
		/// A network exception for handling UnityWebRequest networking error.
		/// </summary>
		/// <param name="message">A error message</param>
		/// <param name="inner">Inner</param>
		/// <returns></returns>
		public NetworkException (string message, System.Exception inner) : base (message, inner) {
			
		}

		/// <summary>
		/// A network exception for handling UnityWebRequest networking error.
		/// </summary>
		/// <param name="info">Info</param>
		/// <param name="context">Context</param>
		/// <returns></returns>
		protected NetworkException (SerializationInfo info, StreamingContext context) : base (info, context) {

		}
	}
}
