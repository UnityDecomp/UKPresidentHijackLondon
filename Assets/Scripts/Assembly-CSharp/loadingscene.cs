using System;
using System.Collections;
using UnityEngine;

// Token: 0x020001EB RID: 491
public class loadingscene : MonoBehaviour
{
	// Token: 0x06000CB3 RID: 3251 RVA: 0x000501FC File Offset: 0x0004E5FC
	private IEnumerator Start()
	{
		AsyncOperation async = Application.LoadLevelAdditiveAsync(this.levelName);
		yield return async;
		Debug.Log("Loading complete");
		this.loadobj.SetActive(false);
		yield break;
	}

	// Token: 0x06000CB4 RID: 3252 RVA: 0x00050217 File Offset: 0x0004E617
	private void Update()
	{
	}

	// Token: 0x04000D2F RID: 3375
	public GameObject loadobj;

	// Token: 0x04000D30 RID: 3376
	public string levelName = "Enter Scene Name";
}
