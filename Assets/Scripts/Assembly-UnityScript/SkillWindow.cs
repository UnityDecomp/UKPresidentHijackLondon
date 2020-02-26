
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class SkillWindow : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowLearnedSkill_0024216
	{
		internal int _0024id_0024220;

		internal SkillWindow _0024self__0024221;

		public _0024ShowLearnedSkill_0024216(int id, SkillWindow self_)
		{
			_0024id_0024220 = id;
			_0024self__0024221 = self_;
		}

		public IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024id_0024220, _0024self__0024221);
		}
	}

	public GameObject player;

	public GameObject database;

	public int[] skill;

	public int[] skillListSlot;

	public LearnSkillLV[] learnSkill;

	private bool menu;

	private bool shortcutPage;

	private bool skillListPage;

	private int skillSelect;

	public GUISkin skin1;

	public Rect windowRect;

	private Rect originalRect;

	private Vector2 selectedPos;

	public GUIStyle textStyle;

	public GUIStyle textStyle2;

	private bool showSkillLearned;

	private string showSkillName;

	public int pageMultiply;

	private int page;

	public bool autoAssignSkill;

	public SkillWindow()
	{
		skill = new int[3];
		skillListSlot = new int[16];
		learnSkill = new LearnSkillLV[2];
		shortcutPage = true;
		windowRect = new Rect(360f, 80f, 360f, 185f);
		selectedPos = new Vector2(27f, 97f);
		showSkillName = string.Empty;
		pageMultiply = 8;
	}

	public void Start()
	{
		if (!player)
		{
			player = gameObject;
		}
		originalRect = windowRect;
		if (autoAssignSkill)
		{
			AssignAllSkill();
		}
	}

	public void Update()
	{
		if (Input.GetKeyDown("k"))
		{
			OnOffMenu();
		}
	}

	public void OnOffMenu()
	{
		if (!menu && Time.timeScale != 0f)
		{
			menu = true;
			skillListPage = false;
			shortcutPage = true;
			Time.timeScale = 0f;
			selectedPos = new Vector2(26f, 56f);
			ResetPosition();
			Screen.lockCursor = false;
		}
		else if (menu)
		{
			menu = false;
			Time.timeScale = 1f;
			Screen.lockCursor = true;
		}
	}

	public void OnGUI()
	{
		SkillData skillData = (SkillData)database.GetComponent(typeof(SkillData));
		if (showSkillLearned)
		{
			GUI.Label(new Rect(Screen.width / 2 - 50, 85f, 400f, 50f), "You Learned  " + showSkillName, textStyle2);
		}
		if (menu && shortcutPage)
		{
			windowRect = GUI.Window(3, windowRect, SkillShortcut, "Skill");
		}
		if (menu && skillListPage)
		{
			windowRect = GUI.Window(3, windowRect, AllSkill, "Skill");
		}
	}

	public void AssignSkill(int id, int sk)
	{
		SkillData skillData = (SkillData)database.GetComponent(typeof(SkillData));
		((AttackTrigger)player.GetComponent(typeof(AttackTrigger))).manaCost[id] = skillData.skill[skillListSlot[sk]].manaCost;
		((AttackTrigger)player.GetComponent(typeof(AttackTrigger))).skillPrefab[id] = skillData.skill[skillListSlot[sk]].skillPrefab;
		((AttackTrigger)player.GetComponent(typeof(AttackTrigger))).skillAnimation[id] = skillData.skill[skillListSlot[sk]].skillAnimation;
		((AttackTrigger)player.GetComponent(typeof(AttackTrigger))).skillIcon[id] = skillData.skill[skillListSlot[sk]].icon;
		skill[id] = skillListSlot[sk];
		MonoBehaviour.print(sk);
	}

	public void AssignAllSkill()
	{
		if (!player)
		{
			player = gameObject;
		}
		int i = 0;
		SkillData skillData = (SkillData)database.GetComponent(typeof(SkillData));
		for (; i <= 2; i++)
		{
			((AttackTrigger)player.GetComponent(typeof(AttackTrigger))).manaCost[i] = skillData.skill[skill[i]].manaCost;
			((AttackTrigger)player.GetComponent(typeof(AttackTrigger))).skillPrefab[i] = skillData.skill[skill[i]].skillPrefab;
			((AttackTrigger)player.GetComponent(typeof(AttackTrigger))).skillAnimation[i] = skillData.skill[skill[i]].skillAnimation;
			((AttackTrigger)player.GetComponent(typeof(AttackTrigger))).skillIcon[i] = skillData.skill[skill[i]].icon;
		}
	}

	public void SkillShortcut(int windowID)
	{
		SkillData skillData = (SkillData)database.GetComponent(typeof(SkillData));
		windowRect.width = 360f;
		windowRect.height = 185f;
		if (GUI.Button(new Rect(310f, 2f, 30f, 30f), "X"))
		{
			OnOffMenu();
		}
		if (GUI.Button(new Rect(30f, 45f, 80f, 80f), skillData.skill[skill[0]].icon))
		{
			skillSelect = 0;
			skillListPage = true;
			shortcutPage = false;
		}
		GUI.Label(new Rect(70f, 145f, 20f, 20f), "1");
		if (GUI.Button(new Rect(130f, 45f, 80f, 80f), skillData.skill[skill[1]].icon))
		{
			skillSelect = 1;
			skillListPage = true;
			shortcutPage = false;
		}
		GUI.Label(new Rect(170f, 145f, 20f, 20f), "2");
		if (GUI.Button(new Rect(230f, 45f, 80f, 80f), skillData.skill[skill[2]].icon))
		{
			skillSelect = 2;
			skillListPage = true;
			shortcutPage = false;
		}
		GUI.Label(new Rect(270f, 145f, 20f, 20f), "3");
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
	}

	public void AllSkill(int windowID)
	{
		SkillData skillData = (SkillData)database.GetComponent(typeof(SkillData));
		windowRect.width = 300f;
		windowRect.height = 555f;
		if (GUI.Button(new Rect(260f, 2f, 30f, 30f), "X"))
		{
			OnOffMenu();
		}
		if (GUI.Button(new Rect(30f, 60f, 50f, 50f), new GUIContent(skillData.skill[skillListSlot[0 + page]].icon, skillData.skill[skillListSlot[0 + page]].description)))
		{
			AssignSkill(skillSelect, 0 + page);
			shortcutPage = true;
			skillListPage = false;
		}
		GUI.Label(new Rect(95f, 75f, 140f, 40f), skillData.skill[skillListSlot[0 + page]].skillName, textStyle);
		GUI.Label(new Rect(220f, 75f, 140f, 40f), "MP : " + skillData.skill[skillListSlot[0 + page]].manaCost, textStyle);
		if (GUI.Button(new Rect(30f, 120f, 50f, 50f), new GUIContent(skillData.skill[skillListSlot[1 + page]].icon, skillData.skill[skillListSlot[1 + page]].description)))
		{
			AssignSkill(skillSelect, 1 + page);
			shortcutPage = true;
			skillListPage = false;
		}
		GUI.Label(new Rect(95f, 135f, 140f, 40f), skillData.skill[skillListSlot[1 + page]].skillName, textStyle);
		GUI.Label(new Rect(220f, 135f, 140f, 40f), "MP : " + skillData.skill[skillListSlot[1 + page]].manaCost, textStyle);
		if (GUI.Button(new Rect(30f, 180f, 50f, 50f), new GUIContent(skillData.skill[skillListSlot[2 + page]].icon, skillData.skill[skillListSlot[2 + page]].description)))
		{
			AssignSkill(skillSelect, 2 + page);
			shortcutPage = true;
			skillListPage = false;
		}
		GUI.Label(new Rect(95f, 195f, 140f, 40f), skillData.skill[skillListSlot[2 + page]].skillName, textStyle);
		GUI.Label(new Rect(220f, 195f, 140f, 40f), "MP : " + skillData.skill[skillListSlot[2 + page]].manaCost, textStyle);
		if (GUI.Button(new Rect(30f, 240f, 50f, 50f), new GUIContent(skillData.skill[skillListSlot[3 + page]].icon, skillData.skill[skillListSlot[3 + page]].description)))
		{
			AssignSkill(skillSelect, 3 + page);
			shortcutPage = true;
			skillListPage = false;
		}
		GUI.Label(new Rect(95f, 255f, 140f, 40f), skillData.skill[skillListSlot[3 + page]].skillName, textStyle);
		GUI.Label(new Rect(220f, 255f, 140f, 40f), "MP : " + skillData.skill[skillListSlot[3 + page]].manaCost, textStyle);
		if (GUI.Button(new Rect(30f, 300f, 50f, 50f), new GUIContent(skillData.skill[skillListSlot[4 + page]].icon, skillData.skill[skillListSlot[4 + page]].description)))
		{
			AssignSkill(skillSelect, 4 + page);
			shortcutPage = true;
			skillListPage = false;
		}
		GUI.Label(new Rect(95f, 315f, 140f, 40f), skillData.skill[skillListSlot[4 + page]].skillName, textStyle);
		GUI.Label(new Rect(220f, 315f, 140f, 40f), "MP : " + skillData.skill[skillListSlot[4 + page]].manaCost, textStyle);
		if (GUI.Button(new Rect(30f, 360f, 50f, 50f), new GUIContent(skillData.skill[skillListSlot[5 + page]].icon, skillData.skill[skillListSlot[5 + page]].description)))
		{
			AssignSkill(skillSelect, 5 + page);
			shortcutPage = true;
			skillListPage = false;
		}
		GUI.Label(new Rect(95f, 375f, 140f, 40f), skillData.skill[skillListSlot[5 + page]].skillName, textStyle);
		GUI.Label(new Rect(220f, 375f, 140f, 40f), "MP : " + skillData.skill[skillListSlot[5 + page]].manaCost, textStyle);
		if (GUI.Button(new Rect(30f, 420f, 50f, 50f), new GUIContent(skillData.skill[skillListSlot[6 + page]].icon, skillData.skill[skillListSlot[6 + page]].description)))
		{
			AssignSkill(skillSelect, 6 + page);
			shortcutPage = true;
			skillListPage = false;
		}
		GUI.Label(new Rect(95f, 435f, 140f, 40f), skillData.skill[skillListSlot[6 + page]].skillName, textStyle);
		GUI.Label(new Rect(220f, 435f, 140f, 40f), "MP : " + skillData.skill[skillListSlot[6 + page]].manaCost, textStyle);
		if (GUI.Button(new Rect(30f, 480f, 50f, 50f), new GUIContent(skillData.skill[skillListSlot[7 + page]].icon, skillData.skill[skillListSlot[7 + page]].description)))
		{
			AssignSkill(skillSelect, 7 + page);
			shortcutPage = true;
			skillListPage = false;
		}
		GUI.Label(new Rect(95f, 495f, 140f, 40f), skillData.skill[skillListSlot[7 + page]].skillName, textStyle);
		GUI.Label(new Rect(220f, 495f, 140f, 40f), "MP : " + skillData.skill[skillListSlot[7 + page]].manaCost, textStyle);
		if (GUI.Button(new Rect(220f, 514f, 25f, 30f), "1"))
		{
			page = 0;
		}
		if (GUI.Button(new Rect(250f, 514f, 25f, 30f), "2"))
		{
			page = pageMultiply;
		}
		GUI.Box(new Rect(20f, 20f, 240f, 26f), GUI.tooltip);
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 10000f));
	}

	public void AddSkill(int id)
	{
		bool flag = false;
		int num = 0;
		while (num < skillListSlot.Length && !flag)
		{
			if (skillListSlot[num] == id)
			{
				flag = true;
			}
			else if (skillListSlot[num] == 0)
			{
				skillListSlot[num] = id;
				StartCoroutine(ShowLearnedSkill(id));
				flag = true;
			}
			else
			{
				num++;
			}
		}
	}

	public IEnumerator ShowLearnedSkill(int id)
	{
		return new _0024ShowLearnedSkill_0024216(id, this).GetEnumerator();
	}

	public void ResetPosition()
	{
		if (windowRect.x >= (float)(Screen.width - 30) || windowRect.y >= (float)(Screen.height - 30) || windowRect.x <= -70f || !(windowRect.y > -70f))
		{
			windowRect = originalRect;
		}
	}

	public void LearnSkillByLevel(int lv)
	{
		for (int i = 0; i < learnSkill.Length; i++)
		{
			if (lv >= learnSkill[i].level)
			{
				AddSkill(learnSkill[i].skillId);
			}
		}
	}

	public void Main()
	{
	}
}
