using System;
using UnityEngine;

// Token: 0x02000201 RID: 513
public class Quests : MonoBehaviour
{
	// Token: 0x06000D63 RID: 3427 RVA: 0x00055D98 File Offset: 0x00054198
	public bool setQuest(int questId)
	{
		if (questId < this.allQuests.Length)
		{
			this.quest = string.Empty;
			this.quest += this.allQuests[questId].statement;
			this.targets = new string[this.allQuests[questId].targets.Length];
			this.Amount = new int[this.allQuests[questId].targets.Length];
			for (int i = 0; i < this.allQuests[questId].targets.Length; i++)
			{
				this.targets[i] = this.allQuests[questId].targets[i].target;
				this.Amount[i] = this.allQuests[questId].targets[i].amount;
			}
			return true;
		}
		Debug.Log("No further quests are added !");
		return false;
	}

	// Token: 0x06000D64 RID: 3428 RVA: 0x00055E75 File Offset: 0x00054275
	public string[] getQuestTarget()
	{
		return this.targets;
	}

	// Token: 0x06000D65 RID: 3429 RVA: 0x00055E7D File Offset: 0x0005427D
	public int[] getQuestTargetAmount()
	{
		return this.Amount;
	}

	// Token: 0x06000D66 RID: 3430 RVA: 0x00055E85 File Offset: 0x00054285
	public string getStatement()
	{
		return this.quest;
	}

	// Token: 0x04000E07 RID: 3591
	public Quests.AllQuests[] allQuests = new Quests.AllQuests[5];

	// Token: 0x04000E08 RID: 3592
	private string[] targets;

	// Token: 0x04000E09 RID: 3593
	private int[] Amount;

	// Token: 0x04000E0A RID: 3594
	private string quest = string.Empty;

	// Token: 0x04000E0B RID: 3595
	private string action = string.Empty;

	// Token: 0x02000202 RID: 514
	[Serializable]
	public class AllQuests
	{
		// Token: 0x04000E0C RID: 3596
		public string name = "Quest";

		// Token: 0x04000E0D RID: 3597
		public string statement;

		// Token: 0x04000E0E RID: 3598
		public bool kill;

		// Token: 0x04000E0F RID: 3599
		public bool reach;

		// Token: 0x04000E10 RID: 3600
		public bool eat;

		// Token: 0x04000E11 RID: 3601
		public Quests.Kill[] targets = new Quests.Kill[5];
	}

	// Token: 0x02000203 RID: 515
	[Serializable]
	public class Kill
	{
		// Token: 0x04000E12 RID: 3602
		public string name = "Target Info";

		// Token: 0x04000E13 RID: 3603
		public string target;

		// Token: 0x04000E14 RID: 3604
		public int amount;
	}
}
