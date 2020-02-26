using System;
using System.Collections;
using UnityEngine;

// Token: 0x020001FC RID: 508
public class PointsAndDestinations : MonoBehaviour
{
	// Token: 0x06000CF9 RID: 3321 RVA: 0x0005169C File Offset: 0x0004FA9C
	private void Start()
	{
		this.questM = base.GetComponent<QuestManager>();
	}

	// Token: 0x06000CFA RID: 3322 RVA: 0x000516AA File Offset: 0x0004FAAA
	private void Update()
	{
	}

	// Token: 0x06000CFB RID: 3323 RVA: 0x000516AC File Offset: 0x0004FAAC
	public void showAction()
	{
	}

	// Token: 0x06000CFC RID: 3324 RVA: 0x000516AE File Offset: 0x0004FAAE
	public void Action()
	{
		this.questId = base.GetComponent<QuestManager>().getQuestID();
		this.player = base.GetComponent<QuestManager>().players[gameplay.count];
		base.StartCoroutine(this.doAction());
	}

	// Token: 0x06000CFD RID: 3325 RVA: 0x000516E8 File Offset: 0x0004FAE8
	private IEnumerator doAction()
	{
		yield return new WaitForSeconds(1f);
		UnityEngine.Object.Destroy(this.player);
		if (this.questId == 12)
		{
			PlayerPrefs.SetInt("Quest", 13);
			PlayerPrefs.SetString("Scene", "CutScene");
			Application.LoadLevel("Loading");
		}
		yield break;
	}

	// Token: 0x06000CFE RID: 3326 RVA: 0x00051703 File Offset: 0x0004FB03
	public void reachedDestination()
	{
	}

	// Token: 0x06000CFF RID: 3327 RVA: 0x00051708 File Offset: 0x0004FB08
	public void showNext(GameObject triggerer)
	{
		if (triggerer.name == "Careless_guard")
		{
			this.questM.consumed(triggerer.name);
			this.objects[0].SetActive(true);
		}
		if (triggerer.name == "Jailor")
		{
			this.questM.consumed(triggerer.name);
			this.objects[2].SetActive(true);
		}
		if (triggerer.name == "Jail")
		{
			this.objects[1].SetActive(true);
			this.triggeredObjects[0].GetComponent<SimpleRotation>().openDoor();
			this.questM.consumed("Jail");
			base.GetComponent<QuestManager>().mate.GetComponent<AIfriendC>().allowFollowing = true;
		}
		if (triggerer.name == "Jail2")
		{
			base.GetComponent<QuestManager>().mate2.GetComponent<AIfriendC>().allowFollowing = true;
			this.triggeredObjects[1].GetComponent<SimpleRotation>().openDoor();
			this.questM.consumed("Jail");
		}
		if (triggerer.name == "Jail3")
		{
			this.triggeredObjects[2].GetComponent<SimpleRotation>().openDoor();
			this.questM.consumed("Jail");
		}
		if (triggerer.name == "Jail4")
		{
			this.triggeredObjects[3].GetComponent<SimpleRotation>().openDoor();
			this.questM.consumed("Jail");
		}
		if (triggerer.name == "Jail5")
		{
			this.triggeredObjects[4].GetComponent<SimpleRotation>().openDoor();
			base.Invoke("apesStartRunning", 2f);
		}
	}

	// Token: 0x06000D00 RID: 3328 RVA: 0x000518CA File Offset: 0x0004FCCA
	private void apesStartRunning()
	{
		RunAtPoint.startRun = true;
		this.questM.consumed("Jail");
	}

	// Token: 0x04000D82 RID: 3458
	private int questId;

	// Token: 0x04000D83 RID: 3459
	private GameObject player;

	// Token: 0x04000D84 RID: 3460
	public GameObject[] objects;

	// Token: 0x04000D85 RID: 3461
	public GameObject[] triggeredObjects;

	// Token: 0x04000D86 RID: 3462
	private QuestManager questM;
}
