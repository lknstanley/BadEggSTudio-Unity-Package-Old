using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLocalizeComponent : MonoBehaviour {

	[Header ("Localize Settings")]
	[SerializeField] protected string localizeKey = "";

	public virtual void Awake() {
		RegisterEvent ();
	}

	// Use this for initialization
	public virtual void Start () {

	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}

	public virtual void OnDestroy() {
		RemoveEvent ();
	}

	// ==================================================
	// |			Event Register / Remover			|
	// ==================================================
	#region Event Register / Remover
	/// <summary>
	/// Use to add event delegate method to binding this class.
	/// </summary>
	void RegisterEvent () {
		BadEggStudio.Localization.uEasyLocalizerEventHandler.onLangChanged += OnLangChanged;
	}

	void RemoveEvent () {
		BadEggStudio.Localization.uEasyLocalizerEventHandler.onLangChanged -= OnLangChanged;
	}
	#endregion
	
	// ==================================================================
	// |				On Language Change Event Callbacks				|
	// ==================================================================
	#region On Language Change Event Callback
	public virtual void OnLangChanged () {
		
	}
	#endregion
}
