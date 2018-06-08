using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using BadEggStudio.Core.Exception;
using System.Net;

namespace BadEggStudio.Core {
	public class Http {
		#region Http Request Handling
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

