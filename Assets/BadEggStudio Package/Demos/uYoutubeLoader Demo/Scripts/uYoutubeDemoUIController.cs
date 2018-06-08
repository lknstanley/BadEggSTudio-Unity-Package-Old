using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BadEggStudio.Utils.uYoutubeLoader;
using UnityEngine.Video;

public class uYoutubeDemoUIController : MonoBehaviour {

	[Header ("UI References")]
	public Text getVideoInfoContent;
	public InputField youtubeId;
	public Toggle videoModeToggle;

	[Header ("Audio Player Reference")]
	public VideoPlayer videoPlayer;

	// Use this for initialization
	void Start () {
		
	}

	#region UI Callbacks
	public void OnGetVideoClicked () {
		uYoutubeLoader.Instance.GetVideoLinks (youtubeId.text, OnGotVideoLinks, videoModeToggle.isOn);
	}
	#endregion

	#region uYoutubeCallback
	public void OnGotVideoLinks () {
		videoPlayer.url = uYoutubeLoader.Instance.GetLinks ("18");
		videoPlayer.Play ();
	}
	#endregion
}
