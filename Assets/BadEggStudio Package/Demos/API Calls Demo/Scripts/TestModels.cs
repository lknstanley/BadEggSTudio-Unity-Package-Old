using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BadEggStudio.Core {
	[System.Serializable]
	public class TestPromotionModel {
		public string id;
		public string pos;
		public string image_url_zh;
		public string image_url_en;
		public string image_url_cn;
		public string content_zh;
		public string content_en;
		public string content_cn;
		public string status;
	}

	[System.Serializable]
	public class TestContactUsModel {
		public string content_zh;
		public string content_en;
		public string content_cn;
		public string updated_at;
	}
}

