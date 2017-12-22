using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadEggStudio.Localization {
	[System.Serializable]
	public enum uEasyLang {
			ZH_TW = 0,
			ZH_CN,
			EN_GB,
			EN_US,
	}

	[System.Serializable]
	public class StringKeyDB : SerializableDictionary<uEasyLang, string> {	}
}

