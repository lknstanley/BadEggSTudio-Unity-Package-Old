using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace BadEggStudio.Utils {
	public class SaveHelper : Singleton<SaveHelper> {
		private static string saveKey = "BADEGGSTUDIO_DEFAULT_SAVE_KEY";
		private static Record record;

		// ===============================================
		// |			 Save / Load Methods			 |
		// ===============================================
		#region Save/Load Methods
		/// <summary>
		/// Save the specified data to PlayerPrefs by passing key and value.
		/// </summary>
		/// <param name="key">PlayerPrefs key</param>
		/// <param name="value">Data which are going to store in PlayerPrefs.</param>
		public static void Save (string key, string value) {
			CommonHelper.Log ("Saving to PlayerPref: Key = " + key + "; New Value = " + value);

			// Encrypt string
			string encryptStr = AESHelper.Encrypt (value);

			// Set value to PlayerPref
			PlayerPrefs.SetString (key, encryptStr);

			// Save PlayerPref
			PlayerPrefs.Save ();
		}

		/// <summary>
		/// Load the specified data by passing key.
		/// </summary>
		/// <param name="key">PlayerPrefs key</param>
		public static string Load (string key) {
			CommonHelper.Log ("Loading from PlayerPref: key = " + key);

			if (PlayerPrefs.HasKey (key)) {
				string encryptedStr = PlayerPrefs.GetString (key);
				return AESHelper.Decrypt (encryptedStr);
			} else {
				return null;
			}

		}
		#endregion

		#region Helper Methods
		// ==========================================================
		// |			 PlayerPref Loader / Saver					|
		// ==========================================================
		private static void SaveToPlayerPref (string value) {
			if (PlayerPrefs.HasKey (saveKey)) {
				PlayerPrefs.SetString (saveKey, value);
			} else {
				PlayerPrefs.SetString (saveKey, value);
				Debug.Log ("Created new key for storing item: " + saveKey);
			}
		}

		private static string LoadFromPlayerPref (string key) {
			if (PlayerPrefs.HasKey (key)) {
				return PlayerPrefs.GetString (key);
			} else {
				return null;
			}
		}
		#endregion

		// ======================================
		// |			Editor Usage			|
		// ======================================
		#if UNITY_EDITOR
		[UnityEditor.MenuItem ("BadEggStudio/Clean All Player Prefs")]
		static void OnEditorSelectedRemoveAllSave () {
			PlayerPrefs.DeleteAll ();
		}
		#endif
	}
}

