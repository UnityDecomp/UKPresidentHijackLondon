using System;
using UnityEngine;

// Token: 0x02000078 RID: 120
[Serializable]
public class QuestStat : MonoBehaviour
{
	// Token: 0x0600018A RID: 394 RVA: 0x00012300 File Offset: 0x00010500
	public QuestStat()
	{
		this.questProgress = new int[20];
		this.questSlot = new int[5];
		this.hover = string.Empty;
	}

	// Token: 0x0600018B RID: 395 RVA: 0x00012338 File Offset: 0x00010538
	public virtual void Start()
	{
		QuestData questData = (QuestData)this.questDataBase.GetComponent(typeof(QuestData));
		if (this.questProgress.Length < questData.questData.Length)
		{
			this.questProgress = new int[questData.questData.Length];
		}
	}

	// Token: 0x0600018C RID: 396 RVA: 0x00012394 File Offset: 0x00010594
	public virtual void Update()
	{
		if (Input.GetKeyDown("q"))
		{
			this.OnOffMenu();
		}
	}

	// Token: 0x0600018D RID: 397 RVA: 0x000123AC File Offset: 0x000105AC
	public virtual bool AddQuest(int id)
	{
		bool result = false;
		bool flag = false;
		int num = 0;
		while (num < this.questSlot.Length && !flag)
		{
			if (this.questSlot[num] == id)
			{
				MonoBehaviour.print("You Already Accept this Quest");
				flag = true;
			}
			else if (this.questSlot[num] == 0)
			{
				this.questSlot[num] = id;
				flag = true;
			}
			else
			{
				num++;
				if (num >= this.questSlot.Length)
				{
					result = true;
					MonoBehaviour.print("Full");
				}
			}
		}
		return result;
	}

	// Token: 0x0600018E RID: 398 RVA: 0x0001243C File Offset: 0x0001063C
	public virtual void SortQuest()
	{
		int i = 0;
		bool flag = false;
		while (i < this.questSlot.Length)
		{
			if (this.questSlot[i] == 0)
			{
				int num = i + 1;
				while (num < this.questSlot.Length && !flag)
				{
					if (this.questSlot[num] > 0)
					{
						this.questSlot[i] = this.questSlot[num];
						this.questSlot[num] = 0;
						flag = true;
					}
					else
					{
						num++;
					}
				}
				flag = false;
				i++;
			}
			else
			{
				i++;
			}
		}
	}

	// Token: 0x0600018F RID: 399 RVA: 0x000124D4 File Offset: 0x000106D4
	public virtual void OnGUI()
	{
		QuestData questData = (QuestData)this.questDataBase.GetComponent(typeof(QuestData));
		if (this.menu)
		{
			GUI.Box(new Rect((float)260, (float)140, (float)280, (float)385), "Quest Log");
			if (GUI.Button(new Rect((float)490, (float)142, (float)30, (float)30), "X"))
			{
				this.OnOffMenu();
			}
			if (this.questSlot[0] > 0)
			{
				GUI.Label(new Rect((float)275, (float)185, (float)280, (float)40), questData.questData[this.questSlot[0]].questName);
				GUI.Label(new Rect((float)275, (float)210, (float)280, (float)40), questData.questData[this.questSlot[0]].description + " (" + this.questProgress[this.questSlot[0]].ToString() + " / " + questData.questData[this.questSlot[0]].finishProgress + ")");
				if (GUI.Button(new Rect((float)450, (float)195, (float)64, (float)32), "Cancel"))
				{
					this.questProgress[this.questSlot[0]] = 0;
					this.questSlot[0] = 0;
					this.SortQuest();
				}
			}
			if (this.questSlot[1] > 0)
			{
				GUI.Label(new Rect((float)275, (float)245, (float)280, (float)40), questData.questData[this.questSlot[1]].questName);
				GUI.Label(new Rect((float)275, (float)270, (float)280, (float)40), questData.questData[this.questSlot[1]].description + " (" + this.questProgress[this.questSlot[1]].ToString() + " / " + questData.questData[this.questSlot[1]].finishProgress + ")");
				if (GUI.Button(new Rect((float)450, (float)255, (float)64, (float)32), "Cancel"))
				{
					this.questProgress[this.questSlot[1]] = 0;
					this.questSlot[1] = 0;
					this.SortQuest();
				}
			}
			if (this.questSlot[2] > 0)
			{
				GUI.Label(new Rect((float)275, (float)305, (float)280, (float)40), questData.questData[this.questSlot[2]].questName);
				GUI.Label(new Rect((float)275, (float)330, (float)280, (float)40), questData.questData[this.questSlot[2]].description + " (" + this.questProgress[this.questSlot[2]].ToString() + " / " + questData.questData[this.questSlot[2]].finishProgress + ")");
				if (GUI.Button(new Rect((float)450, (float)315, (float)64, (float)32), "Cancel"))
				{
					this.questProgress[this.questSlot[2]] = 0;
					this.questSlot[2] = 0;
					this.SortQuest();
				}
			}
			if (this.questSlot[3] > 0)
			{
				GUI.Label(new Rect((float)275, (float)365, (float)280, (float)40), questData.questData[this.questSlot[3]].questName);
				GUI.Label(new Rect((float)275, (float)390, (float)280, (float)40), questData.questData[this.questSlot[3]].description + " (" + this.questProgress[this.questSlot[3]].ToString() + " / " + questData.questData[this.questSlot[3]].finishProgress + ")");
				if (GUI.Button(new Rect((float)450, (float)375, (float)64, (float)32), "Cancel"))
				{
					this.questProgress[this.questSlot[3]] = 0;
					this.questSlot[3] = 0;
					this.SortQuest();
				}
			}
			if (this.questSlot[4] > 0)
			{
				GUI.Label(new Rect((float)275, (float)425, (float)280, (float)40), questData.questData[this.questSlot[4]].questName);
				GUI.Label(new Rect((float)275, (float)450, (float)280, (float)40), questData.questData[this.questSlot[4]].description + " (" + this.questProgress[this.questSlot[4]].ToString() + " / " + questData.questData[this.questSlot[4]].finishProgress + ")");
				if (GUI.Button(new Rect((float)450, (float)435, (float)64, (float)32), "Cancel"))
				{
					this.questProgress[this.questSlot[4]] = 0;
					this.questSlot[4] = 0;
					this.SortQuest();
				}
			}
		}
	}

	// Token: 0x06000190 RID: 400 RVA: 0x00012AB4 File Offset: 0x00010CB4
	public virtual void OnOffMenu()
	{
		if (!this.menu && Time.timeScale != (float)0)
		{
			this.menu = true;
			Time.timeScale = (float)0;
			Screen.lockCursor = false;
		}
		else if (this.menu)
		{
			this.menu = false;
			Time.timeScale = 1f;
			Screen.lockCursor = true;
		}
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00012B14 File Offset: 0x00010D14
	public virtual bool Progress(int id)
	{
		bool result = false;
		for (int i = 0; i < this.questSlot.Length; i++)
		{
			if (this.questSlot[i] == id && id != 0)
			{
				QuestData questData = (QuestData)this.questDataBase.GetComponent(typeof(QuestData));
				if (this.questProgress[id] < questData.questData[this.questSlot[i]].finishProgress)
				{
					this.questProgress[id] = this.questProgress[id] + 1;
					result = true;
				}
				MonoBehaviour.print("Quest Slot =" + i);
			}
		}
		return result;
	}

	// Token: 0x06000192 RID: 402 RVA: 0x00012BBC File Offset: 0x00010DBC
	public virtual bool CheckQuestSlot(int id)
	{
		bool result = false;
		for (int i = 0; i < this.questSlot.Length; i++)
		{
			if (this.questSlot[i] == id && id != 0)
			{
				result = true;
			}
		}
		return result;
	}

	// Token: 0x06000193 RID: 403 RVA: 0x00012C00 File Offset: 0x00010E00
	public virtual int CheckQuestProgress(int id)
	{
		int result = 0;
		for (int i = 0; i < this.questSlot.Length; i++)
		{
			if (this.questSlot[i] == id && id != 0)
			{
				result = this.questProgress[id];
			}
		}
		return result;
	}

	// Token: 0x06000194 RID: 404 RVA: 0x00012C4C File Offset: 0x00010E4C
	public virtual void Clear(int id)
	{
		for (int i = 0; i < this.questSlot.Length; i++)
		{
			if (this.questSlot[i] == id && id != 0)
			{
				QuestData questData = (QuestData)this.questDataBase.GetComponent(typeof(QuestData));
				this.questProgress[id] = this.questProgress[id] + 10;
				this.questSlot[i] = 0;
				this.SortQuest();
				MonoBehaviour.print("Quest Slot =" + i);
			}
		}
	}

	// Token: 0x06000195 RID: 405 RVA: 0x00012CDC File Offset: 0x00010EDC
	public virtual void Main()
	{
	}

	// Token: 0x040002B2 RID: 690
	public GameObject questDataBase;

	// Token: 0x040002B3 RID: 691
	public int[] questProgress;

	// Token: 0x040002B4 RID: 692
	public int[] questSlot;

	// Token: 0x040002B5 RID: 693
	private string hover;

	// Token: 0x040002B6 RID: 694
	private bool menu;
}
