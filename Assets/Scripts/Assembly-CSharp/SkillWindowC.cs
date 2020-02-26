using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200008F RID: 143
public class SkillWindowC : MonoBehaviour
{
	// Token: 0x06000454 RID: 1108 RVA: 0x0001FD3C File Offset: 0x0001E13C
	private void Start()
	{
		if (!this.player)
		{
			this.player = base.gameObject;
		}
		this.originalRect = this.windowRect;
		if (this.autoAssignSkill)
		{
			this.AssignAllSkill();
		}
	}

	// Token: 0x06000455 RID: 1109 RVA: 0x0001FD77 File Offset: 0x0001E177
	private void Update()
	{
		if (Input.GetKeyDown("k"))
		{
			this.OnOffMenu();
		}
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x0001FD90 File Offset: 0x0001E190
	private void OnOffMenu()
	{
		if (!this.menu && Time.timeScale != 0f)
		{
			this.menu = true;
			this.skillListPage = false;
			this.shortcutPage = true;
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

	// Token: 0x06000457 RID: 1111 RVA: 0x0001FE04 File Offset: 0x0001E204
	private void OnGUI()
	{
		if (this.showSkillLearned)
		{
			GUI.Label(new Rect((float)(Screen.width / 2 - 50), 85f, 400f, 50f), "You Learned  " + this.showSkillName, this.textStyle2);
		}
		if (this.menu && this.shortcutPage)
		{
			this.windowRect = GUI.Window(3, this.windowRect, new GUI.WindowFunction(this.SkillShortcut), "Skill");
		}
		if (this.menu && this.skillListPage)
		{
			this.windowRect = GUI.Window(3, this.windowRect, new GUI.WindowFunction(this.AllSkill), "Skill");
		}
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x0001FEC8 File Offset: 0x0001E2C8
	private void SkillShortcut(int windowID)
	{
		SkillDataC component = this.database.GetComponent<SkillDataC>();
		this.windowRect.width = 360f;
		this.windowRect.height = 185f;
		if (GUI.Button(new Rect(310f, 2f, 30f, 30f), "X"))
		{
			this.OnOffMenu();
		}
		if (GUI.Button(new Rect(30f, 45f, 80f, 80f), component.skill[this.skill[0]].icon))
		{
			this.skillSelect = 0;
			this.skillListPage = true;
			this.shortcutPage = false;
		}
		GUI.Label(new Rect(70f, 145f, 20f, 20f), "1");
		if (GUI.Button(new Rect(130f, 45f, 80f, 80f), component.skill[this.skill[1]].icon))
		{
			this.skillSelect = 1;
			this.skillListPage = true;
			this.shortcutPage = false;
		}
		GUI.Label(new Rect(170f, 145f, 20f, 20f), "2");
		if (GUI.Button(new Rect(230f, 45f, 80f, 80f), component.skill[this.skill[2]].icon))
		{
			this.skillSelect = 2;
			this.skillListPage = true;
			this.shortcutPage = false;
		}
		GUI.Label(new Rect(270f, 145f, 20f, 20f), "3");
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
	}

	// Token: 0x06000459 RID: 1113 RVA: 0x0002009C File Offset: 0x0001E49C
	private void AllSkill(int windowID)
	{
		SkillDataC component = this.database.GetComponent<SkillDataC>();
		this.windowRect.width = 300f;
		this.windowRect.height = 555f;
		if (GUI.Button(new Rect(260f, 2f, 30f, 30f), "X"))
		{
			this.OnOffMenu();
		}
		if (GUI.Button(new Rect(30f, 60f, 50f, 50f), new GUIContent(component.skill[this.skillListSlot[this.page]].icon, component.skill[this.skillListSlot[this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect(95f, 75f, 140f, 40f), component.skill[this.skillListSlot[this.page]].skillName, this.textStyle);
		GUI.Label(new Rect(220f, 75f, 140f, 40f), "MP : " + component.skill[this.skillListSlot[this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect(30f, 120f, 50f, 50f), new GUIContent(component.skill[this.skillListSlot[1 + this.page]].icon, component.skill[this.skillListSlot[1 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 1 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect(95f, 135f, 140f, 40f), component.skill[this.skillListSlot[1 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect(220f, 135f, 140f, 40f), "MP : " + component.skill[this.skillListSlot[1 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect(30f, 180f, 50f, 50f), new GUIContent(component.skill[this.skillListSlot[2 + this.page]].icon, component.skill[this.skillListSlot[2 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 2 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect(95f, 195f, 140f, 40f), component.skill[this.skillListSlot[2 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect(220f, 195f, 140f, 40f), "MP : " + component.skill[this.skillListSlot[2 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect(30f, 240f, 50f, 50f), new GUIContent(component.skill[this.skillListSlot[3 + this.page]].icon, component.skill[this.skillListSlot[3 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 3 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect(95f, 255f, 140f, 40f), component.skill[this.skillListSlot[3 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect(220f, 255f, 140f, 40f), "MP : " + component.skill[this.skillListSlot[3 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect(30f, 300f, 50f, 50f), new GUIContent(component.skill[this.skillListSlot[4 + this.page]].icon, component.skill[this.skillListSlot[4 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 4 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect(95f, 315f, 140f, 40f), component.skill[this.skillListSlot[4 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect(220f, 315f, 140f, 40f), "MP : " + component.skill[this.skillListSlot[4 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect(30f, 360f, 50f, 50f), new GUIContent(component.skill[this.skillListSlot[5 + this.page]].icon, component.skill[this.skillListSlot[5 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 5 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect(95f, 375f, 140f, 40f), component.skill[this.skillListSlot[5 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect(220f, 375f, 140f, 40f), "MP : " + component.skill[this.skillListSlot[5 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect(30f, 420f, 50f, 50f), new GUIContent(component.skill[this.skillListSlot[6 + this.page]].icon, component.skill[this.skillListSlot[6 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 6 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect(95f, 435f, 140f, 40f), component.skill[this.skillListSlot[6 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect(220f, 435f, 140f, 40f), "MP : " + component.skill[this.skillListSlot[6 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect(30f, 480f, 50f, 50f), new GUIContent(component.skill[this.skillListSlot[7 + this.page]].icon, component.skill[this.skillListSlot[7 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 7 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect(95f, 495f, 140f, 40f), component.skill[this.skillListSlot[7 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect(220f, 495f, 140f, 40f), "MP : " + component.skill[this.skillListSlot[7 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect(220f, 514f, 25f, 30f), "1"))
		{
			this.page = 0;
		}
		if (GUI.Button(new Rect(250f, 514f, 25f, 30f), "2"))
		{
			this.page = this.pageMultiply;
		}
		GUI.Box(new Rect(20f, 20f, 240f, 26f), GUI.tooltip);
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
	}

	// Token: 0x0600045A RID: 1114 RVA: 0x00020A08 File Offset: 0x0001EE08
	public void AssignSkill(int id, int sk)
	{
		SkillDataC component = this.database.GetComponent<SkillDataC>();
		this.player.GetComponent<AttackTriggerC>().manaCost[id] = component.skill[this.skillListSlot[sk]].manaCost;
		this.player.GetComponent<AttackTriggerC>().skillPrefab[id] = component.skill[this.skillListSlot[sk]].skillPrefab;
		this.player.GetComponent<AttackTriggerC>().skillAnimation[id] = component.skill[this.skillListSlot[sk]].skillAnimation;
		this.player.GetComponent<AttackTriggerC>().skillIcon[id] = component.skill[this.skillListSlot[sk]].icon;
		this.skill[id] = this.skillListSlot[sk];
		MonoBehaviour.print(sk);
	}

	// Token: 0x0600045B RID: 1115 RVA: 0x00020AD4 File Offset: 0x0001EED4
	public void AssignAllSkill()
	{
		if (!this.player)
		{
			this.player = base.gameObject;
		}
		int i = 0;
		SkillDataC component = this.database.GetComponent<SkillDataC>();
		while (i <= 2)
		{
			this.player.GetComponent<AttackTriggerC>().manaCost[i] = component.skill[this.skill[i]].manaCost;
			this.player.GetComponent<AttackTriggerC>().skillPrefab[i] = component.skill[this.skill[i]].skillPrefab;
			this.player.GetComponent<AttackTriggerC>().skillAnimation[i] = component.skill[this.skill[i]].skillAnimation;
			this.player.GetComponent<AttackTriggerC>().skillIcon[i] = component.skill[this.skill[i]].icon;
			i++;
		}
	}

	// Token: 0x0600045C RID: 1116 RVA: 0x00020BB4 File Offset: 0x0001EFB4
	public void LearnSkillByLevel(int lv)
	{
		for (int i = 0; i < this.learnSkill.Length; i++)
		{
			if (lv >= this.learnSkill[i].level)
			{
				this.AddSkill(this.learnSkill[i].skillId);
			}
		}
	}

	// Token: 0x0600045D RID: 1117 RVA: 0x00020C00 File Offset: 0x0001F000
	private void AddSkill(int id)
	{
		bool flag = false;
		int num = 0;
		while (num < this.skillListSlot.Length && !flag)
		{
			if (this.skillListSlot[num] == id)
			{
				flag = true;
			}
			else if (this.skillListSlot[num] == 0)
			{
				this.skillListSlot[num] = id;
				base.StartCoroutine(this.ShowLearnedSkill(id));
				flag = true;
			}
			else
			{
				num++;
			}
		}
	}

	// Token: 0x0600045E RID: 1118 RVA: 0x00020C70 File Offset: 0x0001F070
	private IEnumerator ShowLearnedSkill(int id)
	{
		SkillDataC dataSkill = this.database.GetComponent<SkillDataC>();
		this.showSkillLearned = true;
		this.showSkillName = dataSkill.skill[id].skillName;
		yield return new WaitForSeconds(10.5f);
		this.showSkillLearned = false;
		yield break;
	}

	// Token: 0x0600045F RID: 1119 RVA: 0x00020C94 File Offset: 0x0001F094
	private void ResetPosition()
	{
		if (this.windowRect.x >= (float)(Screen.width - 30) || this.windowRect.y >= (float)(Screen.height - 30) || this.windowRect.x <= -70f || this.windowRect.y <= -70f)
		{
			this.windowRect = this.originalRect;
		}
	}

	// Token: 0x0400042E RID: 1070
	public GameObject player;

	// Token: 0x0400042F RID: 1071
	public GameObject database;

	// Token: 0x04000430 RID: 1072
	public int[] skill = new int[3];

	// Token: 0x04000431 RID: 1073
	public int[] skillListSlot = new int[9];

	// Token: 0x04000432 RID: 1074
	public SkillWindowC.LearnSkillLV[] learnSkill = new SkillWindowC.LearnSkillLV[2];

	// Token: 0x04000433 RID: 1075
	private bool menu;

	// Token: 0x04000434 RID: 1076
	private bool shortcutPage = true;

	// Token: 0x04000435 RID: 1077
	private bool skillListPage;

	// Token: 0x04000436 RID: 1078
	private int skillSelect;

	// Token: 0x04000437 RID: 1079
	public GUISkin skin1;

	// Token: 0x04000438 RID: 1080
	public Rect windowRect = new Rect(360f, 80f, 360f, 185f);

	// Token: 0x04000439 RID: 1081
	private Rect originalRect;

	// Token: 0x0400043A RID: 1082
	public GUIStyle textStyle;

	// Token: 0x0400043B RID: 1083
	public GUIStyle textStyle2;

	// Token: 0x0400043C RID: 1084
	private bool showSkillLearned;

	// Token: 0x0400043D RID: 1085
	private string showSkillName = string.Empty;

	// Token: 0x0400043E RID: 1086
	public int pageMultiply = 8;

	// Token: 0x0400043F RID: 1087
	private int page;

	// Token: 0x04000440 RID: 1088
	public bool autoAssignSkill;

	// Token: 0x02000090 RID: 144
	[Serializable]
	public class LearnSkillLV
	{
		// Token: 0x04000441 RID: 1089
		public int level = 1;

		// Token: 0x04000442 RID: 1090
		public int skillId = 1;
	}
}
