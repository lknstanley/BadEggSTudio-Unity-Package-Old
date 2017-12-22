using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using BadEggStudio.Localization;

[RequireComponent (typeof (Text))]
public class AutoLocalizeText : BaseLocalizeComponent {

	Text text;

	public override void Awake () {
		base.Awake ();
		text = GetComponent<Text> ();
	}

	// Use this for initialization
	public override void Start () {
		base.Start ();
		string newText = uEasyLocalizer.Instance.GetString (localizeKey);
		if (!string.IsNullOrEmpty (newText)) {
			text.text = uEasyLocalizer.Instance.GetString (localizeKey);
			text.font = uEasyLocalizer.Instance.GetFont ();
		} else {
			text.text = "{MISSING LOCALIZED TEXT}";
		}
	}

	// ==============================================
	// |			Change Content Setter			|
	// ==============================================
	#region Change Content Setter
	public void SetKey (string newKey) {
		localizeKey = newKey;
		OnLangChanged ();
	}
	#endregion

	// ==================================================
	// |			On Language Change Event			|
	// ==================================================
	#region On Lang Change Event
	public override void OnLangChanged () {
		base.OnLangChanged ();
		string newText = uEasyLocalizer.Instance.GetString (localizeKey);
		if (!string.IsNullOrEmpty (newText)) {
			text.text = uEasyLocalizer.Instance.GetString (localizeKey);	
		} else {
			text.text = "{MISSING LOCALIZED TEXT}";
		}

		text.font = uEasyLocalizer.Instance.GetFont ();
	}
	#endregion
}