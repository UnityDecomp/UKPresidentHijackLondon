using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

// Token: 0x02000088 RID: 136
[Serializable]
public class SkillWindow : MonoBehaviour
{
	// Token: 0x060001D4 RID: 468 RVA: 0x00017D9C File Offset: 0x00015F9C
	public SkillWindow()
	{
		this.skill = new int[3];
		this.skillListSlot = new int[16];
		this.learnSkill = new LearnSkillLV[2];
		this.shortcutPage = true;
		this.windowRect = new Rect((float)360, (float)80, (float)360, (float)185);
		this.selectedPos = new Vector2((float)27, (float)97);
		this.showSkillName = string.Empty;
		this.pageMultiply = 8;
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x00017E20 File Offset: 0x00016020
	public virtual void Start()
	{
		if (!this.player)
		{
			this.player = this.gameObject;
		}
		this.originalRect = this.windowRect;
		if (this.autoAssignSkill)
		{
			this.AssignAllSkill();
		}
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x00017E5C File Offset: 0x0001605C
	public virtual void Update()
	{
		if (Input.GetKeyDown("k"))
		{
			this.OnOffMenu();
		}
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x00017E74 File Offset: 0x00016074
	public virtual void OnOffMenu()
	{
		if (!this.menu && Time.timeScale != (float)0)
		{
			this.menu = true;
			this.skillListPage = false;
			this.shortcutPage = true;
			Time.timeScale = (float)0;
			this.selectedPos = new Vector2((float)26, (float)56);
			this.ResetPosition();
			Screen.lockCursor = false;
		}
		else if (this.menu)
		{
			this.menu = false;
			Time.timeScale = 1f;
			Screen.lockCursor = true;
		}
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x00017EF8 File Offset: 0x000160F8
	public virtual void OnGUI()
	{
		SkillData skillData = (SkillData)this.database.GetComponent(typeof(SkillData));
		if (this.showSkillLearned)
		{
			GUI.Label(new Rect((float)(Screen.width / 2 - 50), (float)85, (float)400, (float)50), "You Learned  " + this.showSkillName, this.textStyle2);
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

	// Token: 0x060001D9 RID: 473 RVA: 0x00017FD8 File Offset: 0x000161D8
	public virtual void AssignSkill(int id, int sk)
	{
		SkillData skillData = (SkillData)this.database.GetComponent(typeof(SkillData));
		((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).manaCost[id] = skillData.skill[this.skillListSlot[sk]].manaCost;
		((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).skillPrefab[id] = skillData.skill[this.skillListSlot[sk]].skillPrefab;
		((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).skillAnimation[id] = skillData.skill[this.skillListSlot[sk]].skillAnimation;
		((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).skillIcon[id] = skillData.skill[this.skillListSlot[sk]].icon;
		this.skill[id] = this.skillListSlot[sk];
		MonoBehaviour.print(sk);
	}

	// Token: 0x060001DA RID: 474 RVA: 0x000180F0 File Offset: 0x000162F0
	public virtual void AssignAllSkill()
	{
		if (!this.player)
		{
			this.player = this.gameObject;
		}
		int i = 0;
		SkillData skillData = (SkillData)this.database.GetComponent(typeof(SkillData));
		while (i <= 2)
		{
			((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).manaCost[i] = skillData.skill[this.skill[i]].manaCost;
			((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).skillPrefab[i] = skillData.skill[this.skill[i]].skillPrefab;
			((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).skillAnimation[i] = skillData.skill[this.skill[i]].skillAnimation;
			((AttackTrigger)this.player.GetComponent(typeof(AttackTrigger))).skillIcon[i] = skillData.skill[this.skill[i]].icon;
			i++;
		}
	}

	// Token: 0x060001DB RID: 475 RVA: 0x0001821C File Offset: 0x0001641C
	public virtual void SkillShortcut(int windowID)
	{
		SkillData skillData = (SkillData)this.database.GetComponent(typeof(SkillData));
		this.windowRect.width = (float)360;
		this.windowRect.height = (float)185;
		if (GUI.Button(new Rect((float)310, (float)2, (float)30, (float)30), "X"))
		{
			this.OnOffMenu();
		}
		if (GUI.Button(new Rect((float)30, (float)45, (float)80, (float)80), skillData.skill[this.skill[0]].icon))
		{
			this.skillSelect = 0;
			this.skillListPage = true;
			this.shortcutPage = false;
		}
		GUI.Label(new Rect((float)70, (float)145, (float)20, (float)20), "1");
		if (GUI.Button(new Rect((float)130, (float)45, (float)80, (float)80), skillData.skill[this.skill[1]].icon))
		{
			this.skillSelect = 1;
			this.skillListPage = true;
			this.shortcutPage = false;
		}
		GUI.Label(new Rect((float)170, (float)145, (float)20, (float)20), "2");
		if (GUI.Button(new Rect((float)230, (float)45, (float)80, (float)80), skillData.skill[this.skill[2]].icon))
		{
			this.skillSelect = 2;
			this.skillListPage = true;
			this.shortcutPage = false;
		}
		GUI.Label(new Rect((float)270, (float)145, (float)20, (float)20), "3");
		GUI.DragWindow(new Rect((float)0, (float)0, (float)10000, (float)10000));
	}

	// Token: 0x060001DC RID: 476 RVA: 0x000183DC File Offset: 0x000165DC
	public virtual void AllSkill(int windowID)
	{
		SkillData skillData = (SkillData)this.database.GetComponent(typeof(SkillData));
		this.windowRect.width = (float)300;
		this.windowRect.height = (float)555;
		if (GUI.Button(new Rect((float)260, (float)2, (float)30, (float)30), "X"))
		{
			this.OnOffMenu();
		}
		if (GUI.Button(new Rect((float)30, (float)60, (float)50, (float)50), new GUIContent(skillData.skill[this.skillListSlot[0 + this.page]].icon, skillData.skill[this.skillListSlot[0 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 0 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect((float)95, (float)75, (float)140, (float)40), skillData.skill[this.skillListSlot[0 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect((float)220, (float)75, (float)140, (float)40), "MP : " + skillData.skill[this.skillListSlot[0 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect((float)30, (float)120, (float)50, (float)50), new GUIContent(skillData.skill[this.skillListSlot[1 + this.page]].icon, skillData.skill[this.skillListSlot[1 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 1 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect((float)95, (float)135, (float)140, (float)40), skillData.skill[this.skillListSlot[1 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect((float)220, (float)135, (float)140, (float)40), "MP : " + skillData.skill[this.skillListSlot[1 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect((float)30, (float)180, (float)50, (float)50), new GUIContent(skillData.skill[this.skillListSlot[2 + this.page]].icon, skillData.skill[this.skillListSlot[2 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 2 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect((float)95, (float)195, (float)140, (float)40), skillData.skill[this.skillListSlot[2 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect((float)220, (float)195, (float)140, (float)40), "MP : " + skillData.skill[this.skillListSlot[2 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect((float)30, (float)240, (float)50, (float)50), new GUIContent(skillData.skill[this.skillListSlot[3 + this.page]].icon, skillData.skill[this.skillListSlot[3 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 3 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect((float)95, (float)255, (float)140, (float)40), skillData.skill[this.skillListSlot[3 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect((float)220, (float)255, (float)140, (float)40), "MP : " + skillData.skill[this.skillListSlot[3 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect((float)30, (float)300, (float)50, (float)50), new GUIContent(skillData.skill[this.skillListSlot[4 + this.page]].icon, skillData.skill[this.skillListSlot[4 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 4 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect((float)95, (float)315, (float)140, (float)40), skillData.skill[this.skillListSlot[4 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect((float)220, (float)315, (float)140, (float)40), "MP : " + skillData.skill[this.skillListSlot[4 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect((float)30, (float)360, (float)50, (float)50), new GUIContent(skillData.skill[this.skillListSlot[5 + this.page]].icon, skillData.skill[this.skillListSlot[5 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 5 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect((float)95, (float)375, (float)140, (float)40), skillData.skill[this.skillListSlot[5 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect((float)220, (float)375, (float)140, (float)40), "MP : " + skillData.skill[this.skillListSlot[5 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect((float)30, (float)420, (float)50, (float)50), new GUIContent(skillData.skill[this.skillListSlot[6 + this.page]].icon, skillData.skill[this.skillListSlot[6 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 6 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect((float)95, (float)435, (float)140, (float)40), skillData.skill[this.skillListSlot[6 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect((float)220, (float)435, (float)140, (float)40), "MP : " + skillData.skill[this.skillListSlot[6 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect((float)30, (float)480, (float)50, (float)50), new GUIContent(skillData.skill[this.skillListSlot[7 + this.page]].icon, skillData.skill[this.skillListSlot[7 + this.page]].description)))
		{
			this.AssignSkill(this.skillSelect, 7 + this.page);
			this.shortcutPage = true;
			this.skillListPage = false;
		}
		GUI.Label(new Rect((float)95, (float)495, (float)140, (float)40), skillData.skill[this.skillListSlot[7 + this.page]].skillName, this.textStyle);
		GUI.Label(new Rect((float)220, (float)495, (float)140, (float)40), "MP : " + skillData.skill[this.skillListSlot[7 + this.page]].manaCost, this.textStyle);
		if (GUI.Button(new Rect((float)220, (float)514, (float)25, (float)30), "1"))
		{
			this.page = 0;
		}
		if (GUI.Button(new Rect((float)250, (float)514, (float)25, (float)30), "2"))
		{
			this.page = this.pageMultiply;
		}
		GUI.Box(new Rect((float)20, (float)20, (float)240, (float)26), GUI.tooltip);
		GUI.DragWindow(new Rect((float)0, (float)0, (float)10000, (float)10000));
	}

	// Token: 0x060001DD RID: 477 RVA: 0x00018D14 File Offset: 0x00016F14
	public virtual void AddSkill(int id)
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
				this.StartCoroutine(this.ShowLearnedSkill(id));
				flag = true;
			}
			else
			{
				num++;
			}
		}
	}

	// Token: 0x060001DE RID: 478 RVA: 0x00018D88 File Offset: 0x00016F88
	public virtual IEnumerator ShowLearnedSkill(int id)
	{
		return new SkillWindow.$ShowLearnedSkill$216(id, this).GetEnumerator();
	}

	// Token: 0x060001DF RID: 479 RVA: 0x00018D98 File Offset: 0x00016F98
	public virtual void ResetPosition()
	{
		if (this.windowRect.x >= (float)(Screen.width - 30) || this.windowRect.y >= (float)(Screen.height - 30) || this.windowRect.x <= (float)-70 || this.windowRect.y <= (float)-70)
		{
			this.windowRect = this.originalRect;
		}
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x00018E0C File Offset: 0x0001700C
	public virtual void LearnSkillByLevel(int lv)
	{
		for (int i = 0; i < this.learnSkill.Length; i++)
		{
			if (lv >= this.learnSkill[i].level)
			{
				this.AddSkill(this.learnSkill[i].skillId);
			}
		}
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x00018E5C File Offset: 0x0001705C
	public virtual void Main()
	{
	}

	// Token: 0x0400030F RID: 783
	public GameObject player;

	// Token: 0x04000310 RID: 784
	public GameObject database;

	// Token: 0x04000311 RID: 785
	public int[] skill;

	// Token: 0x04000312 RID: 786
	public int[] skillListSlot;

	// Token: 0x04000313 RID: 787
	public LearnSkillLV[] learnSkill;

	// Token: 0x04000314 RID: 788
	private bool menu;

	// Token: 0x04000315 RID: 789
	private bool shortcutPage;

	// Token: 0x04000316 RID: 790
	private bool skillListPage;

	// Token: 0x04000317 RID: 791
	private int skillSelect;

	// Token: 0x04000318 RID: 792
	public GUISkin skin1;

	// Token: 0x04000319 RID: 793
	public Rect windowRect;

	// Token: 0x0400031A RID: 794
	private Rect originalRect;

	// Token: 0x0400031B RID: 795
	private Vector2 selectedPos;

	// Token: 0x0400031C RID: 796
	public GUIStyle textStyle;

	// Token: 0x0400031D RID: 797
	public GUIStyle textStyle2;

	// Token: 0x0400031E RID: 798
	private bool showSkillLearned;

	// Token: 0x0400031F RID: 799
	private string showSkillName;

	// Token: 0x04000320 RID: 800
	public int pageMultiply;

	// Token: 0x04000321 RID: 801
	private int page;

	// Token: 0x04000322 RID: 802
	public bool autoAssignSkill;

	// Token: 0x02000089 RID: 137
	[CompilerGenerated]
	[Serializable]
	internal sealed class $ShowLearnedSkill$216 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x060001E2 RID: 482 RVA: 0x00018E60 File Offset: 0x00017060
		public $ShowLearnedSkill$216(int id, SkillWindow self_)
		{
			this.$id$220 = id;
			this.$self_$221 = self_;
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00018E78 File Offset: 0x00017078
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new SkillWindow.$ShowLearnedSkill$216.$(this.$id$220, this.$self_$221);
		}

		// Token: 0x04000323 RID: 803
		internal int $id$220;

		// Token: 0x04000324 RID: 804
		internal SkillWindow $self_$221;
	}
}
