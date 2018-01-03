using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadEggStudio.Utils {
	// public class CommonHelper : Singleton<CommonHelper> {
	public static class CommonHelper {
		
		// logger properties
		private static bool isDevMode = true;
		private static bool forceLogMode = false;

		// ==========================================
		// |			Customized Logger			|
		// ==========================================
		#region Customized Logger
		/// <summary>
		/// Log the specified message.
		/// </summary>
		/// <param name="msg">Message which you are going to log.</param>
		/// <param name="forceLog">If set to <c>true</c>, the log will be show even in publish mode.</param>
		public static void Log (string msg, bool forceLog = false) {
			if (isDevMode || forceLogMode || forceLog) {
				Debug.Log (msg);
			}
		}

		/// <summary>
		/// Log the specified message in error stylish.
		/// </summary>
		/// <param name="msg">Message which you are going to log.</param>
		/// <param name="forceLog">If set to <c>true</c>, the log will be show even in publish mode.</param>
		public static void LogError (string msg, bool forceLog = false) {
			if (isDevMode || forceLogMode || forceLog) {
				Debug.LogError (msg);
			}
		}
		#endregion

		// ======================================================
		// |		Local Transform Direct Edit Methods			|
		// ======================================================
		#region Local Transform Direct Edit Methods
		/// <summary>
		/// Change the transform local position X by passing value.
		/// </summary>
		/// <param name="trans">Transform where you are going to change.</param>
		/// <param name="val">New transform position local X</param>
		public static void ChangeLocalX (this Transform trans, float val) {
			Vector3 pos = trans.localPosition ;
			pos.x = val ;
			trans.localPosition = pos ;
		}

		/// <summary>
		/// Change the transform local position Y by passing value.
		/// </summary>
		/// <param name="trans">Transform where you are going to change.</param>
		/// <param name="val">New transform position local Y.</param>
		public static void ChangeLocalY (this Transform trans, float val) {
			Vector3 pos = trans.localPosition ;
			pos.y = val ;
			trans.localPosition = pos ;
		}

		/// <summary>
		/// Change the transform local position Z by passing value.
		/// </summary>
		/// <param name="trans">Transform where you are going to change.</param>
		/// <param name="val">New transform position local Z.</param>
		public static void ChangeLocalZ (this Transform trans, float val) {
			Vector3 pos = trans.localPosition ;
			pos.z = val ;
			trans.localPosition = pos ;
		}
		#endregion

		// ======================================================
		// |		Global Transform Direct Edit Methods		|
		// ======================================================
		/// <summary>
		/// Change the transform global position X by passing value.
		/// </summary>
		/// <param name="trans">Transform where you are going to change.</param>
		/// <param name="val">New transform position global X.</param>
		#region Global Transform Direct Edit Methods
		public static void ChangeGlobalX (this Transform trans, float val) {
			Vector3 pos = trans.position ;
			pos.x = val ;
			trans.position = pos ;
		}

		/// <summary>
		/// Change the transform global position Y by passing value.
		/// </summary>
		/// <param name="trans">Transform where you are going to change.</param>
		/// <param name="val">New transform position global Y.</param>
		public static void ChangeGlobalY (this Transform trans, float val) {
			Vector3 pos = trans.position ;
			pos.y = val ;
			trans.position = pos ;
		}

		/// <summary>
		/// Change the transform global position Z by passing value.
		/// </summary>
		/// <param name="trans">Transform where you are going to change.</param>
		/// <param name="val">New transform position global Z.</param>
		public static void ChangeGlobalZ (this Transform trans, float val) {
			Vector3 pos = trans.position ;
			pos.z = val ;
			trans.position = pos ;
		}
		#endregion

	}
}

