using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E5 RID: 485
public class FreeQuests : MonoBehaviour
{
	// Token: 0x06000C89 RID: 3209 RVA: 0x0004F2A0 File Offset: 0x0004D6A0
	private void Start()
	{
	}

	// Token: 0x06000C8A RID: 3210 RVA: 0x0004F2A2 File Offset: 0x0004D6A2
	private void Update()
	{
	}

	// Token: 0x06000C8B RID: 3211 RVA: 0x0004F2A4 File Offset: 0x0004D6A4
	public void StartFreeQuest(int quest)
	{
		if (quest == 4)
		{
			this.sideNotifier.GetComponentInChildren<Text>().text = "Go Sleep to get Baby Wolf";
		}
	}

	// Token: 0x04000CF0 RID: 3312
	public int[] FreeQuestVar = new int[4];

	// Token: 0x04000CF1 RID: 3313
	public GameObject mate;

	// Token: 0x04000CF2 RID: 3314
	public GameObject Child1;

	// Token: 0x04000CF3 RID: 3315
	public GameObject Player;

	// Token: 0x04000CF4 RID: 3316
	public Image sideNotifier;
}
