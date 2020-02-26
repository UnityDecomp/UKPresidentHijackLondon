using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001EA RID: 490
public class HomePopUp : MonoBehaviour
{
	// Token: 0x06000CAE RID: 3246 RVA: 0x00050086 File Offset: 0x0004E486
	private void Start()
	{
		this.aifriend = (UnityEngine.Object.FindObjectOfType(typeof(AIfriendC)) as AIfriendC);
	}

	// Token: 0x06000CAF RID: 3247 RVA: 0x000500A2 File Offset: 0x0004E4A2
	public void SleepWakeUp()
	{
		this.player.GetComponent<PlayerInputControllerC>().Sleep();
	}

	// Token: 0x06000CB0 RID: 3248 RVA: 0x000500B4 File Offset: 0x0004E4B4
	public void LeaveCallMate()
	{
		if (this.Mate && this.Child)
		{
			if (!this.Mate.GetComponent<AIfriendC>().allowFollowing && !this.Child.GetComponent<AIfriendC>().allowFollowing)
			{
				this.Mate.GetComponent<AIfriendC>().allowFollowing = true;
				this.Child.GetComponent<AIfriendC>().allowFollowing = true;
				this.leaveCallButton.GetComponentInChildren<Text>().text = "Leave";
			}
			else
			{
				this.Mate.GetComponent<AIfriendC>().allowFollowing = false;
				this.Child.GetComponent<AIfriendC>().allowFollowing = false;
				this.leaveCallButton.GetComponentInChildren<Text>().text = "Call";
			}
		}
		else
		{
			MonoBehaviour.print("Please assign mate and child object in HomePopUp script");
		}
	}

	// Token: 0x06000CB1 RID: 3249 RVA: 0x00050190 File Offset: 0x0004E590
	private void Update()
	{
		if (this.startFlow)
		{
			for (int i = 0; i < 3; i++)
			{
				if (this.playerList[i].gameObject.activeSelf)
				{
					this.player = this.playerList[i];
				}
			}
			this.startFlow = false;
		}
	}

	// Token: 0x04000D26 RID: 3366
	private AIfriendC aifriend;

	// Token: 0x04000D27 RID: 3367
	public GameObject[] playerList = new GameObject[3];

	// Token: 0x04000D28 RID: 3368
	public GameObject Mate;

	// Token: 0x04000D29 RID: 3369
	public GameObject Child;

	// Token: 0x04000D2A RID: 3370
	[HideInInspector]
	private GameObject player;

	// Token: 0x04000D2B RID: 3371
	private bool startFlow = true;

	// Token: 0x04000D2C RID: 3372
	public Button leaveCallButton;

	// Token: 0x04000D2D RID: 3373
	public Button sleepWakeUpButton;

	// Token: 0x04000D2E RID: 3374
	private bool sleep;
}
