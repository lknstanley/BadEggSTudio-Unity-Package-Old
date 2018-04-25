using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BadEggStudio.Utils.uYoutubeLoader {
	public enum uYoutubeFormat {
	}

	public class uYoutubeLoader : Singleton<uYoutubeLoader> {
		bool isVideoMode = true;
		private Dictionary<string, string> _videoInfoDict;
		private string[] encodedSourceArray;
		private Dictionary<string, Dictionary<string, string>> _sourceDict;
		private Action _onGotVideoLinks;
		private string fullDecodedStream;
		private bool _isInit = false;

		/// <summary>
		/// Awake is called when the script instance is being loaded.
		/// </summary>
		void Awake () {
			_videoInfoDict = new Dictionary<string, string> ();
			_sourceDict = new Dictionary<string, Dictionary<string, string>> ();
		}

		#region Get Video Info Content From Youtube
		/// <summary>
		/// Using '/get_video_info' to download/get the video info file
		/// </summary>
		/// <param name="videoId">A Youtube video ID that you can to use.</param>
		/// <param name="onGotVideoLinks">A callbacks function which to use to notice when all the operation are completed.</param>
		public void GetVideoLinks (string videoId, Action onGotVideoLinks, bool isVideoMode = true) {
			_isInit = false;

			// switch mode
			isVideoMode = isVideoMode;

			// assign callbacks
			_onGotVideoLinks = onGotVideoLinks;

			// build youtube url to get video info file
			string newUrl = "http://www.youtube.com/get_video_info?eurl=http%3A%2F%2Fkej.tw%2F&sts=17638&video_id=" + videoId;
			StartCoroutine (AsyncGetVideoInfo (newUrl));
		}

		private IEnumerator AsyncGetVideoInfo (string videoUrl) {
			using (WWW www = new WWW (videoUrl)) {
				yield return www;

				// print video info content
				// Debug.Log ("========== Video Info Content ==========");
				// Debug.Log (www.text);
				// Debug.Log ("========== End of Video Info Content ==========");
				
				FirstSplit (www.text);
			}
		}
		#endregion

		#region First Split
		// Split to get url sources in string array
		/// <summary>
		/// To split the video content from youtube.
		/// </summary>
		/// <param name="videoContent">Video content which can be get from calling GetVideoInfo (string, Action) method.</param>
		/// <param name="onVideoSourceResponse">Callback for getting back the sources in string array.</param>
		private void FirstSplit (string videoContent) {				
			// update tmp video info dictionary
			_videoInfoDict.Clear ();
			_videoInfoDict = videoContent.Split ('&') // doing first split
										 .Select (part => part.Split ('=')) // select all items and split those record by '=' char
										 .ToDictionary (splitted => splitted[0], splitted => splitted [1]); // mapping to a dictionary

			// print formatted data
			// Debug.Log ("========== First Splitted Content ==========");
			// foreach (KeyValuePair<string, string> kvp in _videoInfoDict) {
			// 	Debug.Log (kvp.Key + "=" + kvp.Value);
			// }
			// Debug.Log ("========== End of First Splitted Content ==========");

			// decode fmt stream
			DecodeEncodedFMTStream (_videoInfoDict["url_encoded_fmt_stream_map"], _videoInfoDict["adaptive_fmts"]);


		}
		#endregion

		#region Analytics Encoded FMT stream (audio & video)
		/// <summary>
		/// Decode encoded video FMT streams
		/// </summary>
		/// <param name="fullEncodedStream">Full string of the encoded video fmts string.</param>
		private void DecodeEncodedFMTStream (string videoEncodedStream, string audioEncodedStream) {
			SecondSplite (Uri.UnescapeDataString (videoEncodedStream), Uri.UnescapeDataString (audioEncodedStream));
		}
		#endregion

		#region Second Split
		private void SecondSplite (string videoDecodedStream, string audioDecodedStream) {
			string[] tmpArr = videoDecodedStream.Split (',');
			string[] tmp2Arr = audioDecodedStream.Split (',');
			encodedSourceArray = new string [tmpArr.Length + tmp2Arr.Length];
			tmpArr.CopyTo (encodedSourceArray, 0);
			tmp2Arr.CopyTo (encodedSourceArray, tmpArr.Length);

			// print data
			// Debug.Log ("========== Second Split ==========");
			// foreach (string str in encodedSourceArray) {
			// 	Debug.Log (str);
			// }
			// Debug.Log ("========== End of Second Split ==========");

			BuildSourceDictionary (encodedSourceArray);
		}
		#endregion

		#region Build source dictionary
		private void BuildSourceDictionary (string[] encodedSourceArray) {

			// clear source dictionary
			_sourceDict.Clear ();

			// create tempoary dictioanry
			Dictionary<string, string> tmpDict;

			// data formatting
			for (int i = 0; i < encodedSourceArray.Length; i++) {
				tmpDict = encodedSourceArray[i].Split ('&')
											   .Select (part => part.Split ('='))
											   .ToDictionary (splitted => splitted[0], splitted => Uri.UnescapeDataString (splitted[1]));

				string iTagKey = tmpDict["itag"];
				if (_sourceDict.ContainsKey (iTagKey)) {
					_sourceDict[iTagKey] = tmpDict;
				} else {
					_sourceDict.Add (iTagKey, tmpDict);
				}
			}
			
			// print data
			// Debug.Log ("========== Build Source Dictionary ==========");
			// foreach (KeyValuePair<string, Dictionary<string, string>> kvp in _sourceDict) {
			// 	Debug.Log (">> ========== iTag: " + kvp.Key + "==========");
			// 	foreach (KeyValuePair<string, string> kvp2 in kvp.Value) {
			// 		Debug.Log ("|  " +kvp2.Key + "=" + kvp2.Value);
			// 	}
			// 	Debug.Log (">> ========== End of iTag: " + kvp.Key + "==========");
			// }
			// Debug.Log ("========== End of Build Source Dictionary ==========");

			_onGotVideoLinks ();

			_isInit = true;
		}
		#endregion

		#region uYoutube Controller Methods
		public string GetLinks (string iTag) {
			return _sourceDict[iTag]["url"];
		}
		#endregion
	}
}
