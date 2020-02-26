using System;
using UnityEngine;

// Token: 0x0200020B RID: 523
public class sharetext : MonoBehaviour
{
	// Token: 0x06000D8C RID: 3468 RVA: 0x000569FC File Offset: 0x00054DFC
	public void shareText()
	{
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.content.Intent");
		AndroidJavaObject androidJavaObject = new AndroidJavaObject("android.content.Intent", new object[0]);
		androidJavaObject.Call<AndroidJavaObject>("setAction", new object[]
		{
			androidJavaClass.GetStatic<string>("ACTION_SEND")
		});
		androidJavaObject.Call<AndroidJavaObject>("setType", new object[]
		{
			"text/plain"
		});
		androidJavaObject.Call<AndroidJavaObject>("putExtra", new object[]
		{
			androidJavaClass.GetStatic<string>("EXTRA_SUBJECT"),
			this.subject
		});
		androidJavaObject.Call<AndroidJavaObject>("putExtra", new object[]
		{
			androidJavaClass.GetStatic<string>("EXTRA_TEXT"),
			this.body
		});
		AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject @static = androidJavaClass2.GetStatic<AndroidJavaObject>("currentActivity");
		@static.Call("startActivity", new object[]
		{
			androidJavaObject
		});
	}

	// Token: 0x04000E44 RID: 3652
	private string subject = Adpack.GAME_FULLNAME;

	// Token: 0x04000E45 RID: 3653
	private string body = "PLAY THIS AWESOME GAME. GET IT ON THE PLAYSTORE AT LINK https://play.google.com/store/apps/details?id=" + Adpack.PACKAGE_NAME;
}
