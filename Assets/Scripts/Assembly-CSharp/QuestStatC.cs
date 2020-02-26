using System;
using UnityEngine;

// Token: 0x02000084 RID: 132
public class QuestStatC : MonoBehaviour
{
	// Token: 0x06000419 RID: 1049 RVA: 0x0001AD38 File Offset: 0x00019138
	private void Start()
	{
		QuestDataC component = this.questDataBase.GetComponent<QuestDataC>();
		if (this.questProgress.Length < component.questData.Length)
		{
			this.questProgress = new int[component.questData.Length];
		}
	}

	// Token: 0x0600041A RID: 1050 RVA: 0x0001AD79 File Offset: 0x00019179
	private void Update()
	{
		if (Input.GetKeyDown("q"))
		{
			this.OnOffMenu();
		}
	}

	// Token: 0x0600041B RID: 1051 RVA: 0x0001AD90 File Offset: 0x00019190
	public bool AddQuest(int id)
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

	// Token: 0x0600041C RID: 1052 RVA: 0x0001AE18 File Offset: 0x00019218
	public void SortQuest()
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

	// Token: 0x0600041D RID: 1053 RVA: 0x0001AEAC File Offset: 0x000192AC
	private void OnGUI()
	{
		QuestDataC component = this.questDataBase.GetComponent<QuestDataC>();
		if (this.menu)
		{
			GUI.Box(new Rect(260f, 140f, 280f, 385f), "Quest Log");
			if (GUI.Button(new Rect(490f, 142f, 30f, 30f), "X"))
			{
				this.OnOffMenu();
			}
			if (this.questSlot[0] > 0)
			{
				GUI.Label(new Rect(275f, 185f, 280f, 40f), component.questData[this.questSlot[0]].questName);
				GUI.Label(new Rect(275f, 210f, 280f, 40f), string.Concat(new object[]
				{
					component.questData[this.questSlot[0]].description,
					" (",
					this.questProgress[this.questSlot[0]].ToString(),
					" / ",
					component.questData[this.questSlot[0]].finishProgress,
					")"
				}));
				if (GUI.Button(new Rect(450f, 195f, 64f, 32f), "Cancel"))
				{
					this.questProgress[this.questSlot[0]] = 0;
					this.questSlot[0] = 0;
					this.SortQuest();
				}
			}
			if (this.questSlot[1] > 0)
			{
				GUI.Label(new Rect(275f, 245f, 280f, 40f), component.questData[this.questSlot[1]].questName);
				GUI.Label(new Rect(275f, 270f, 280f, 40f), string.Concat(new object[]
				{
					component.questData[this.questSlot[1]].description,
					" (",
					this.questProgress[this.questSlot[1]].ToString(),
					" / ",
					component.questData[this.questSlot[1]].finishProgress,
					")"
				}));
				if (GUI.Button(new Rect(450f, 255f, 64f, 32f), "Cancel"))
				{
					this.questProgress[this.questSlot[1]] = 0;
					this.questSlot[1] = 0;
					this.SortQuest();
				}
			}
			if (this.questSlot[2] > 0)
			{
				GUI.Label(new Rect(275f, 305f, 280f, 40f), component.questData[this.questSlot[2]].questName);
				GUI.Label(new Rect(275f, 330f, 280f, 40f), string.Concat(new object[]
				{
					component.questData[this.questSlot[2]].description,
					" (",
					this.questProgress[this.questSlot[2]].ToString(),
					" / ",
					component.questData[this.questSlot[2]].finishProgress,
					")"
				}));
				if (GUI.Button(new Rect(450f, 315f, 64f, 32f), "Cancel"))
				{
					this.questProgress[this.questSlot[2]] = 0;
					this.questSlot[2] = 0;
					this.SortQuest();
				}
			}
			if (this.questSlot[3] > 0)
			{
				GUI.Label(new Rect(275f, 365f, 280f, 40f), component.questData[this.questSlot[3]].questName);
				GUI.Label(new Rect(275f, 390f, 280f, 40f), string.Concat(new object[]
				{
					component.questData[this.questSlot[3]].description,
					" (",
					this.questProgress[this.questSlot[3]].ToString(),
					" / ",
					component.questData[this.questSlot[3]].finishProgress,
					")"
				}));
				if (GUI.Button(new Rect(450f, 375f, 64f, 32f), "Cancel"))
				{
					this.questProgress[this.questSlot[3]] = 0;
					this.questSlot[3] = 0;
					this.SortQuest();
				}
			}
			if (this.questSlot[4] > 0)
			{
				GUI.Label(new Rect(275f, 425f, 280f, 40f), component.questData[this.questSlot[4]].questName);
				GUI.Label(new Rect(275f, 450f, 280f, 40f), string.Concat(new object[]
				{
					component.questData[this.questSlot[4]].description,
					" (",
					this.questProgress[this.questSlot[4]].ToString(),
					" / ",
					component.questData[this.questSlot[4]].finishProgress,
					")"
				}));
				if (GUI.Button(new Rect(450f, 435f, 64f, 32f), "Cancel"))
				{
					this.questProgress[this.questSlot[4]] = 0;
					this.questSlot[4] = 0;
					this.SortQuest();
				}
			}
		}
	}

	// Token: 0x0600041E RID: 1054 RVA: 0x0001B4B0 File Offset: 0x000198B0
	private void OnOffMenu()
	{
		if (!this.menu && Time.timeScale != 0f)
		{
			this.menu = true;
			Time.timeScale = 0f;
			Screen.lockCursor = false;
		}
		else if (this.menu)
		{
			this.menu = false;
			Time.timeScale = 1f;
			Screen.lockCursor = true;
		}
	}

	// Token: 0x0600041F RID: 1055 RVA: 0x0001B518 File Offset: 0x00019918
	public bool Progress(int id)
	{
		bool result = false;
		for (int i = 0; i < this.questSlot.Length; i++)
		{
			if (this.questSlot[i] == id && id != 0)
			{
				QuestDataC component = this.questDataBase.GetComponent<QuestDataC>();
				if (this.questProgress[id] < component.questData[this.questSlot[i]].finishProgress)
				{
					this.questProgress[id]++;
					result = true;
				}
				MonoBehaviour.print("Quest Slot =" + i);
			}
		}
		return result;
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x0001B5AC File Offset: 0x000199AC
	public bool CheckQuestSlot(int id)
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

	// Token: 0x06000421 RID: 1057 RVA: 0x0001B5EC File Offset: 0x000199EC
	public int CheckQuestProgress(int id)
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

	// Token: 0x06000422 RID: 1058 RVA: 0x0001B634 File Offset: 0x00019A34
	public void Clear(int id)
	{
		for (int i = 0; i < this.questSlot.Length; i++)
		{
			if (this.questSlot[i] == id && id != 0)
			{
				this.questProgress[id] += 10;
				this.questSlot[i] = 0;
				this.SortQuest();
				MonoBehaviour.print("Quest Slot =" + i);
			}
		}
	}

	// Token: 0x040003DB RID: 987
	public GameObject questDataBase;

	// Token: 0x040003DC RID: 988
	public int[] questProgress = new int[20];

	// Token: 0x040003DD RID: 989
	public int[] questSlot = new int[5];

	// Token: 0x040003DE RID: 990
	private bool menu;
}
