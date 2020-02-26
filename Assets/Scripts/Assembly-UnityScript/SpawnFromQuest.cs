using System;
using UnityEngine;

// Token: 0x0200007B RID: 123
[Serializable]
public class SpawnFromQuest : MonoBehaviour
{
	// Token: 0x0600019E RID: 414 RVA: 0x0001308C File Offset: 0x0001128C
	public SpawnFromQuest()
	{
		this.questId = 1;
		this.progressBelow = 9999;
		this.by = SpawmQType.Instantiate;
	}

	// Token: 0x0600019F RID: 415 RVA: 0x000130B0 File Offset: 0x000112B0
	public virtual void Start()
	{
		this.CheckCondition();
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x000130B8 File Offset: 0x000112B8
	public virtual void CheckCondition()
	{
		if (this.by == SpawmQType.Instantiate)
		{
			this.Spawn();
		}
		if (this.by == SpawmQType.Active)
		{
			this.Activate();
		}
		if (this.by == SpawmQType.Deactivate)
		{
			this.Deactivate();
		}
		if (this.by == SpawmQType.Destroy)
		{
			this.DeleteObj();
		}
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x00013110 File Offset: 0x00011310
	public virtual void Spawn()
	{
		this.player = GameObject.FindWithTag("Player");
		if (this.player)
		{
			QuestStat exists = (QuestStat)this.player.GetComponent(typeof(QuestStat));
			if (exists)
			{
				bool flag = ((QuestStat)this.player.GetComponent(typeof(QuestStat))).CheckQuestSlot(this.questId);
				int num = ((QuestStat)this.player.GetComponent(typeof(QuestStat))).CheckQuestProgress(this.questId);
				if (flag && num >= this.progressAbove && num < this.progressBelow)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.spawnObject, this.transform.position, this.transform.rotation);
					gameObject.name = this.spawnObject.name;
				}
			}
		}
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x00013200 File Offset: 0x00011400
	public virtual void Activate()
	{
		this.player = GameObject.FindWithTag("Player");
		if (this.player)
		{
			QuestStat exists = (QuestStat)this.player.GetComponent(typeof(QuestStat));
			if (exists)
			{
				bool flag = ((QuestStat)this.player.GetComponent(typeof(QuestStat))).CheckQuestSlot(this.questId);
				int num = ((QuestStat)this.player.GetComponent(typeof(QuestStat))).CheckQuestProgress(this.questId);
				if (flag && num >= this.progressAbove && num < this.progressBelow)
				{
					this.spawnObject.SetActive(true);
				}
			}
		}
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x000132CC File Offset: 0x000114CC
	public virtual void Deactivate()
	{
		this.player = GameObject.FindWithTag("Player");
		if (this.player)
		{
			QuestStat exists = (QuestStat)this.player.GetComponent(typeof(QuestStat));
			if (exists)
			{
				bool flag = ((QuestStat)this.player.GetComponent(typeof(QuestStat))).CheckQuestSlot(this.questId);
				int num = ((QuestStat)this.player.GetComponent(typeof(QuestStat))).CheckQuestProgress(this.questId);
				if (flag && num >= this.progressAbove && num < this.progressBelow)
				{
					this.spawnObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x00013398 File Offset: 0x00011598
	public virtual void DeleteObj()
	{
		this.player = GameObject.FindWithTag("Player");
		if (this.player)
		{
			QuestStat exists = (QuestStat)this.player.GetComponent(typeof(QuestStat));
			if (exists)
			{
				bool flag = ((QuestStat)this.player.GetComponent(typeof(QuestStat))).CheckQuestSlot(this.questId);
				int num = ((QuestStat)this.player.GetComponent(typeof(QuestStat))).CheckQuestProgress(this.questId);
				if (flag && num >= this.progressAbove && num < this.progressBelow)
				{
					UnityEngine.Object.Destroy(this.spawnObject);
				}
			}
		}
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x00013460 File Offset: 0x00011660
	public virtual void Main()
	{
	}

	// Token: 0x040002C2 RID: 706
	public int questId;

	// Token: 0x040002C3 RID: 707
	public GameObject spawnObject;

	// Token: 0x040002C4 RID: 708
	public int progressAbove;

	// Token: 0x040002C5 RID: 709
	public int progressBelow;

	// Token: 0x040002C6 RID: 710
	private GameObject player;

	// Token: 0x040002C7 RID: 711
	public SpawmQType by;
}
