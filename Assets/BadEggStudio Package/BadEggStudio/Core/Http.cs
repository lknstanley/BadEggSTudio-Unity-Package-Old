using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using BadEggStudio.Core.Exception;
using System.Net;

namespace BadEggStudio.Core {
	public class Http {

		#region Contructor
		/// <summary>
		/// Contructor for Http Object. It is used to do http request and handling the response from server.
		/// </summary>
		public Http () {}
		#endregion

		#region Http Request Handling
		/// <summary>
		/// An async HTTP Get Request.
		/// </summary>
		/// <param name="url">The full path of the url to the endpoint.</param>
		/// <param name="OnGetResponse">A response method to handle the response from server.</param>
		/// <returns></returns>
		public IEnumerator Get (string url, Action<string> OnGetResponse) {
			Debug.Log ("[Http Request]: GET " + url);
			UnityWebRequest www = UnityWebRequest.Get (url);
			yield return www.SendWebRequest ();
			
			if (www.isNetworkError) {
				throw new NetworkException (www.error);
			} else if (www.isHttpError) {
				throw new HttpException (www.error);
			} else {
				Debug.Log ("[Http Response]: " + www.downloadHandler.text);
				OnGetResponse (www.downloadHandler.text);
				www.Dispose ();
			}
		}

		/// <summary>
		/// An async HTTP Post Request.
		/// </summary>
		/// <param name="url">The full path of the url to the endpoint.</param>
		/// <param name="jsonfiedString">A data that upload to the server and use it to do processing.</param>
		/// <param name="OnPostResponse">A response method to handle the response from server.</param>
		/// <returns></returns>
		public IEnumerator Post (string url, string jsonfiedString, Action<string> OnPostResponse) {
			Debug.Log ("[Http Request]: POST " + url);
			UnityWebRequest www = UnityWebRequest.Post (url, jsonfiedString);
			yield return www.SendWebRequest ();

			if (www.isNetworkError) {
				throw new NetworkException (www.error);
			} else if (www.isHttpError) {
				throw new HttpException (www.error);
			} else {
				Debug.Log ("[Http Response]: " + www.downloadHandler.text);
				OnPostResponse (www.downloadHandler.text);
				www.Dispose ();
			}
		}
		#endregion
	}
}

