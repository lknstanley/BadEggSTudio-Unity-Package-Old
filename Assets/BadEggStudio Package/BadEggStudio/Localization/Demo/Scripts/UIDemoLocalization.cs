using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// using badeggstudio package here
using BadEggStudio.Localization;

public class UIDemoLocalization : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnChangeTradChineseButtonClicked () {
		uEasyLocalizer.Instance.ChangeLanguage (uEasyLang.ZH_TW);
	}

	public void OnChangeSimpleChineseButtonClicked () {
		uEasyLocalizer.Instance.ChangeLanguage (uEasyLang.ZH_CN);
	}

	public void OnChangeUSEnglishButtonClicked () {
		uEasyLocalizer.Instance.ChangeLanguage (uEasyLang.EN_US);
	}

	public void OnChangeGBEnglishButtonClicked () {
		uEasyLocalizer.Instance.ChangeLanguage (uEasyLang.EN_GB);
	}

}
