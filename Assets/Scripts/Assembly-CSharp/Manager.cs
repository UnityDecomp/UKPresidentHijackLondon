using System;
using UnityEngine;

// Token: 0x020001ED RID: 493
public class Manager : MonoBehaviour
{
	// Token: 0x06000CCA RID: 3274 RVA: 0x000507C6 File Offset: 0x0004EBC6
	private void OnEnable()
	{
		this.questManager = this.gameManager.GetComponent<QuestManager>();
	}

	// Token: 0x04000D37 RID: 3383
	public GameObject gameManager;

	// Token: 0x04000D38 RID: 3384
	[HideInInspector]
	public QuestManager questManager;
}
