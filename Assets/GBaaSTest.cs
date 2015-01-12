using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GBaaS.io;
using GBaaS.io.Objects;

public class GBaaSTest : MonoBehaviour {
	class MyGBaaSAsyncHandler : GBaaSApiHandler {
		GBaaSTest _outerClass;
		
		public void SetOuterClass(GBaaSTest outerClass) {
			_outerClass = outerClass;
		}
		
		public override void OnGetAchievement(List<GBAchievementObject> result) {
			Debug.Log ("GBaaSAsyncHandler OnGetAchievement count = " + result.Count.ToString());
		}
		
		public override void OnLogin(GBResult result) {
			Debug.Log("MyGBaaSAsyncHandler OnLogin : " + result.isSuccess);
		}
		
		public override void OnLoginWithFaceBook(GBResult result) {
			OnLogin(result);
		}
		
		public override void OnLoginWithoutID(GBResult result) {
			OnLogin(result);
		}
		
		public override void OnIsRegisteredDevice(bool result) {
			Debug.Log ("GBaaSAsyncHandler OnIsRegisteredDevice " + result.ToString());
		}
		
		public override void OnFileUpload(bool result) {
			Debug.Log ("GBaaSAsyncHandler OnFileUpload " + result.ToString());
		}
		
		public override void OnFileDownload(bool result) {
			Debug.Log ("GBaaSAsyncHandler OnFileDownload " + result.ToString());
		}
		
		public override void OnGetFileList(List<GBAsset> result) {
			Debug.Log ("GBaaSAsyncHandler OnGetFileList " + result.Count.ToString());
		}
	}

	Rect rectangle_0 = new Rect(0,0,100,50);
	//사각형 객체를 생성.(x축,y축,넓이,높이)

	MyGBaaSAsyncHandler myGBaaSAsyncHandler = new MyGBaaSAsyncHandler();

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {	
	}
	
	void OnGUI(){
		if(GUI.Button(rectangle_0, "GBaaS Login")) {
			GBaaSObject.Instance.Init(myGBaaSAsyncHandler);
			GBaaSObject.Instance.API.LoginWithoutID("ABCDEFG1234567");
		}
	}
}
