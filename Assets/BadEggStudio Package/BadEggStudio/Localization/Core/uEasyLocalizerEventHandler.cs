using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadEggStudio.Localization {
	public class uEasyLocalizerEventHandler : MonoBehaviour {

		// ======================================
		// |			Event Handler			|
		// ======================================
		#region Event handler
		public delegate void OnLangChangedDelegate ();
		public static event OnLangChangedDelegate onLangChanged;
		#endregion

		public static void OnLanguageChanged () {
			if (onLangChanged != null) {
				onLangChanged ();
			}
		}
	}
}

