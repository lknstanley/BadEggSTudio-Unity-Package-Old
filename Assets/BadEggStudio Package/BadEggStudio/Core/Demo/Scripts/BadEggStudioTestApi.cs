using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BadEggStudio.Core;
using BadEggStudio.Core.Exception;

namespace BadEggStudio.Core {
	public class BadEggStudioTestApi : MonoBehaviour {

		Api api;

		public Text responseText;

		// Use this for initialization
		void Start () {
			api = new Api ("https://dev.juicyapphk.com/first_ferry_web/api");
		}

		#region UI Callbacks
		public void OnGetContactUsClicked () {
			try {
				StartCoroutine (api.GetContactUs (OnGetContactResponse));
			} catch (HttpException httpException) {
				Debug.Log (httpException.Message);
			} catch (NetworkException networkException) {
				Debug.Log (networkException.Message);
			}
		}
		#endregion

		void OnGetContactResponse (string content) {
			TestContactUsModel contactObject = JsonUtility.FromJson<TestContactUsModel> (content);
			Debug.Log (contactObject.content_cn);
			Debug.Log (contactObject.content_en);
			Debug.Log (contactObject.content_zh);
			Debug.Log (contactObject.updated_at);
			responseText.text = content;
		}
	}
}
