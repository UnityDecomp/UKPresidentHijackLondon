using System;
using DG.Tweening;
using SWS;
using UnityEngine;

// Token: 0x020000F5 RID: 245
public class CameraInputDemo : MonoBehaviour
{
	// Token: 0x060006E3 RID: 1763 RVA: 0x0002D430 File Offset: 0x0002B830
	private void Start()
	{
		this.myMove = base.gameObject.GetComponent<splineMove>();
		this.myMove.StartMove();
		this.myMove.Pause(0f);
	}

	// Token: 0x060006E4 RID: 1764 RVA: 0x0002D460 File Offset: 0x0002B860
	private void Update()
	{
		if (this.myMove.tween == null || this.myMove.tween.IsPlaying())
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			this.myMove.Resume();
		}
	}

	// Token: 0x060006E5 RID: 1765 RVA: 0x0002D4B0 File Offset: 0x0002B8B0
	private void OnGUI()
	{
		if (this.myMove.tween != null && this.myMove.tween.IsPlaying())
		{
			return;
		}
		GUI.Box(new Rect((float)(Screen.width - 150), (float)(Screen.height / 2), 150f, 100f), string.Empty);
		Rect position = new Rect((float)(Screen.width - 130), (float)(Screen.height / 2 + 10), 110f, 90f);
		GUI.Label(position, this.infoText);
	}

	// Token: 0x060006E6 RID: 1766 RVA: 0x0002D544 File Offset: 0x0002B944
	public void ShowInformation(string text)
	{
		this.infoText = text;
	}

	// Token: 0x040005E9 RID: 1513
	public string infoText = "Welcome to this customized input example";

	// Token: 0x040005EA RID: 1514
	private splineMove myMove;
}
