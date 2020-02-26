
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class QuestClient : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024AcceptQuest_0024205 : GenericGenerator<WaitForSeconds>
	{
		internal QuestClient _0024self__0024208;

		public _0024AcceptQuest_0024205(QuestClient self_)
		{
			_0024self__0024208 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024AcceptQuest_0024205(_0024self__0024208);
		}
	}

	public int questId;

	public GameObject questData;

	private int finishProgress;

	public Texture2D button;

	public Texture2D textWindow;

	[HideInInspector]
	public bool enter;

	private bool showGui;

	private bool showError;

	[HideInInspector]
	public int s;

	private GameObject player;

	public string[] talkText;

	public string[] ongoingQuestText;

	public string[] finishQuestText;

	public string[] alreadyFinishText;

	private string errorLog;

	public GUIStyle textStyle;

	private bool acceptQuest;

	public bool trigger;

	private bool activateQuest;

	private int textLength;

	public string showText;

	private bool thisActive;

	private bool questFinish;

	public string sendMsgWhenTakeQuest;

	public QuestClient()
	{
		questId = 1;
		talkText = new string[3];
		ongoingQuestText = new string[1];
		finishQuestText = new string[1];
		alreadyFinishText = new string[1];
		errorLog = "Quest Full...";
		trigger = true;
		showText = string.Empty;
		sendMsgWhenTakeQuest = string.Empty;
	}

	public void Update()
	{
		if (Input.GetKeyDown("e") && enter && thisActive && !showError)
		{
			NextPage();
		}
	}

	public void NextPage()
	{
		int num = ((QuestStat)player.GetComponent(typeof(QuestStat))).CheckQuestProgress(questId);
		int num2 = ((QuestData)questData.GetComponent(typeof(QuestData))).questData[questId].finishProgress;
		int num3 = ((QuestStat)player.GetComponent(typeof(QuestStat))).questProgress[questId];
		if (num3 >= num2 + 9)
		{
			textLength = alreadyFinishText.Length;
			if (s < textLength)
			{
				showText = alreadyFinishText[s];
			}
			s++;
			TalkOnly();
			MonoBehaviour.print("Already Clear");
		}
		else if (acceptQuest)
		{
			if (num >= num2)
			{
				textLength = finishQuestText.Length;
				if (s < textLength)
				{
					showText = finishQuestText[s];
				}
				s++;
				FinishQuest();
			}
			else
			{
				textLength = ongoingQuestText.Length;
				if (s < textLength)
				{
					showText = ongoingQuestText[s];
				}
				s++;
				TalkOnly();
			}
		}
		else
		{
			textLength = talkText.Length;
			if (s < textLength)
			{
				showText = talkText[s];
			}
			s++;
			TakeQuest();
		}
	}

	public void TakeQuest()
	{
		if (s > textLength)
		{
			showGui = false;
			StartCoroutine(AcceptQuest());
			CloseTalk();
		}
		else
		{
			Talking();
		}
	}

	public void TalkOnly()
	{
		if (s > textLength)
		{
			showGui = false;
			CloseTalk();
		}
		else
		{
			Talking();
		}
	}

	public void FinishQuest()
	{
		if (s > textLength)
		{
			showGui = false;
			((QuestData)questData.GetComponent(typeof(QuestData))).QuestClear(questId, player);
			((QuestStat)player.GetComponent(typeof(QuestStat))).Clear(questId);
			MonoBehaviour.print("Clear");
			questFinish = true;
			CloseTalk();
		}
		else
		{
			Talking();
		}
	}

	public IEnumerator AcceptQuest()
	{
		return new _0024AcceptQuest_0024205(this).GetEnumerator();
	}

	public void CheckQuestCondition()
	{
		QuestData questData = (QuestData)this.questData.GetComponent(typeof(QuestData));
		int num = ((QuestStat)player.GetComponent(typeof(QuestStat))).CheckQuestProgress(questId);
		if (num >= questData.questData[questId].finishProgress)
		{
			questData.QuestClear(questId, player);
		}
	}

	public void OnGUI()
	{
		if (!player)
		{
			return;
		}
		if (enter && !showGui && !showError)
		{
			GUI.DrawTexture(new Rect(Screen.width / 2 - 130, Screen.height - 120, 260f, 80f), button);
		}
		if (showError)
		{
			GUI.DrawTexture(new Rect(80f, Screen.height - 255, 615f, 220f), textWindow);
			GUI.Label(new Rect(125f, Screen.height - 220, 500f, 200f), errorLog, textStyle);
			if (GUI.Button(new Rect(590f, Screen.height - 100, 80f, 30f), "OK"))
			{
				showError = false;
			}
		}
		if (showGui && !showError && s <= textLength)
		{
			GUI.DrawTexture(new Rect(80f, Screen.height - 255, 615f, 220f), textWindow);
			GUI.Label(new Rect(125f, Screen.height - 220, 500f, 200f), showText, textStyle);
			if (GUI.Button(new Rect(590f, Screen.height - 100, 80f, 30f), "Next"))
			{
				NextPage();
			}
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (trigger && other.tag == "Player")
		{
			s = 0;
			player = other.gameObject;
			acceptQuest = ((QuestStat)player.GetComponent(typeof(QuestStat))).CheckQuestSlot(questId);
			enter = true;
			thisActive = true;
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (trigger)
		{
			if (other.tag == "Player")
			{
				s = 0;
				enter = false;
				CloseTalk();
			}
			thisActive = false;
			showError = false;
		}
	}

	public void Talking()
	{
		if (enter)
		{
			Time.timeScale = 0f;
			Screen.lockCursor = false;
			showGui = true;
		}
	}

	public void CloseTalk()
	{
		showGui = false;
		Time.timeScale = 1f;
		Screen.lockCursor = true;
		s = 0;
	}

	public bool ActivateQuest(GameObject p)
	{
		player = p;
		acceptQuest = ((QuestStat)player.GetComponent(typeof(QuestStat))).CheckQuestSlot(questId);
		thisActive = false;
		trigger = false;
		NextPage();
		return questFinish;
	}

	public void Main()
	{
	}
}
