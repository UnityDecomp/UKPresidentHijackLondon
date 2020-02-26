using System;
using UnityEngine;

// Token: 0x020001F9 RID: 505
public class PlayerCollision : MonoBehaviour
{
	// Token: 0x06000CED RID: 3309 RVA: 0x0005155D File Offset: 0x0004F95D
	private void Start()
	{
		this.canvasScript = (UnityEngine.Object.FindObjectOfType(typeof(CanvasScript)) as CanvasScript);
		this.questM = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
	}

	// Token: 0x06000CEE RID: 3310 RVA: 0x00051593 File Offset: 0x0004F993
	private void Update()
	{
	}

	// Token: 0x06000CEF RID: 3311 RVA: 0x00051595 File Offset: 0x0004F995
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.canvasScript.showEat();
		}
	}

	// Token: 0x06000CF0 RID: 3312 RVA: 0x000515BC File Offset: 0x0004F9BC
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.canvasScript.hideEat();
		}
	}

	// Token: 0x04000D7A RID: 3450
	private CanvasScript canvasScript;

	// Token: 0x04000D7B RID: 3451
	private QuestManager questM;
}
