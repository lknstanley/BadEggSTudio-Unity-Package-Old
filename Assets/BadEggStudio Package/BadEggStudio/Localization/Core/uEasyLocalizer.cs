using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadEggStudio.Localization {
	
	public class uEasyLocalizer : Singleton<uEasyLocalizer> {

		[Header ("Language Manager Settings")]
		public uEasyLang currentLang = uEasyLang.EN_US;
		public LocalizeDB localizeDB;

		[Header ("Font Settings")]
		public FontDB fontDB;

		// ======================================
		// |			Called Methods			|
		// ======================================
		#region Called Methods
		public string GetString (string key) {
			if (localizeDB.ContainsKey (key)) {
				if (localizeDB[key].ContainsKey (currentLang)) {
					return localizeDB[key][currentLang];
				} else {
					return null;
				}
			} else {
				return null;
			}
		}

		public Font GetFont () {
			if (fontDB [currentLang] != null) {
				// return pre-set font
				return fontDB [currentLang];	
			} else {
				// default Unity build in font
				return Resources.GetBuiltinResource<Font> ("Arial.ttf");
			}
		}

		public void ChangeLanguage (uEasyLang newLang) {
			this.currentLang = newLang;
			uEasyLocalizerEventHandler.OnLanguageChanged ();
		}
		#endregion
	}

}