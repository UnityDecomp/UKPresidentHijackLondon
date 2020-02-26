
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


[Serializable]
public class GameOver : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Start_0024182
	{
		internal GameOver _0024self__0024184;

		public _0024Start_0024182(GameOver self_)
		{
			_0024self__0024184 = self_;
		}

		public IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024184);
		}
	}

	public float delay;

	public GameObject player;

	private bool menu;

	private Vector3 lastPosition;

	private Transform mainCam;

	private GameObject oldPlayer;

	public GameOver()
	{
		delay = 3f;
	}

	public IEnumerator Start()
	{
		return new _0024Start_0024182(this).GetEnumerator();
	}

	public void OnGUI()
	{
		if (menu)
		{
			GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 120, 200f, 160f), "Game Over");
			if (GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 80, 160f, 40f), "Retry"))
			{
				LoadData();
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height / 2 - 20, 160f, 40f), "Quit Game"))
			{
				mainCam = GameObject.FindWithTag("MainCamera").transform;
				UnityEngine.Object.Destroy(mainCam.gameObject);
				Application.LoadLevel("Title");
			}
		}
	}

	public void LoadData()
	{
		oldPlayer = GameObject.FindWithTag("Player");
		if ((bool)oldPlayer)
		{
			UnityEngine.Object.Destroy(this.gameObject);
			return;
		}
		lastPosition.x = PlayerPrefs.GetFloat("PlayerX");
		lastPosition.y = PlayerPrefs.GetFloat("PlayerY") + 0.2f;
		lastPosition.z = PlayerPrefs.GetFloat("PlayerZ");
		GameObject gameObject = UnityEngine.Object.Instantiate(player, lastPosition, transform.rotation);
		((Status)gameObject.GetComponent(typeof(Status))).level = PlayerPrefs.GetInt("TempPlayerLevel");
		((Status)gameObject.GetComponent(typeof(Status))).characterId = PlayerPrefs.GetInt("TempID");
		((Status)gameObject.GetComponent(typeof(Status))).characterName = PlayerPrefs.GetString("TempName");
		((Status)gameObject.GetComponent(typeof(Status))).atk = PlayerPrefs.GetInt("TempPlayerATK");
		((Status)gameObject.GetComponent(typeof(Status))).def = PlayerPrefs.GetInt("TempPlayerDEF");
		((Status)gameObject.GetComponent(typeof(Status))).matk = PlayerPrefs.GetInt("TempPlayerMATK");
		((Status)gameObject.GetComponent(typeof(Status))).mdef = PlayerPrefs.GetInt("TempPlayerMDEF");
		((Status)gameObject.GetComponent(typeof(Status))).mdef = PlayerPrefs.GetInt("TempPlayerMDEF");
		((Status)gameObject.GetComponent(typeof(Status))).exp = PlayerPrefs.GetInt("TempPlayerEXP");
		((Status)gameObject.GetComponent(typeof(Status))).maxExp = PlayerPrefs.GetInt("TempPlayerMaxEXP");
		((Status)gameObject.GetComponent(typeof(Status))).maxHealth = PlayerPrefs.GetInt("TempPlayerMaxHP");
		((Status)gameObject.GetComponent(typeof(Status))).health = PlayerPrefs.GetInt("TempPlayerMaxHP");
		((Status)gameObject.GetComponent(typeof(Status))).maxMana = PlayerPrefs.GetInt("TempPlayerMaxMP");
		((Status)gameObject.GetComponent(typeof(Status))).mana = PlayerPrefs.GetInt("TempPlayerMaxMP");
		((Status)gameObject.GetComponent(typeof(Status))).statusPoint = PlayerPrefs.GetInt("TempPlayerSTP");
		mainCam = GameObject.FindWithTag("MainCamera").transform;
		((ARPGcamera)mainCam.GetComponent(typeof(ARPGcamera))).target = gameObject.transform;
		((Inventory)gameObject.GetComponent(typeof(Inventory))).cash = PlayerPrefs.GetInt("TempCash");
		int num = Extensions.get_length((System.Array)((Inventory)player.GetComponent(typeof(Inventory))).itemSlot);
		int i = 0;
		if (num > 0)
		{
			for (; i < num; i++)
			{
				((Inventory)gameObject.GetComponent(typeof(Inventory))).itemSlot[i] = PlayerPrefs.GetInt("TempItem" + i.ToString());
				((Inventory)gameObject.GetComponent(typeof(Inventory))).itemQuantity[i] = PlayerPrefs.GetInt("TempItemQty" + i.ToString());
			}
		}
		int num2 = Extensions.get_length((System.Array)((Inventory)player.GetComponent(typeof(Inventory))).equipment);
		i = 0;
		if (num2 > 0)
		{
			for (; i < num2; i++)
			{
				((Inventory)gameObject.GetComponent(typeof(Inventory))).equipment[i] = PlayerPrefs.GetInt("TempEquipm" + i.ToString());
			}
		}
		((Inventory)gameObject.GetComponent(typeof(Inventory))).weaponEquip = 0;
		((Inventory)gameObject.GetComponent(typeof(Inventory))).armorEquip = PlayerPrefs.GetInt("TempArmoEquip");
		if (PlayerPrefs.GetInt("TempWeaEquip") == 0)
		{
			((Inventory)gameObject.GetComponent(typeof(Inventory))).RemoveWeaponMesh();
		}
		else
		{
			((Inventory)gameObject.GetComponent(typeof(Inventory))).EquipItem(PlayerPrefs.GetInt("TempWeaEquip"), ((Inventory)gameObject.GetComponent(typeof(Inventory))).equipment.Length + 5);
		}
		Screen.lockCursor = true;
		GameObject[] array = null;
		array = GameObject.FindGameObjectsWithTag("Enemy");
		int j = 0;
		GameObject[] array2 = array;
		for (int length = array2.Length; j < length; j++)
		{
			if ((bool)array2[j])
			{
				((AIset)array2[j].GetComponent(typeof(AIset))).followTarget = gameObject.transform;
			}
		}
		GameObject gameObject2 = GameObject.FindWithTag("Minimap");
		if ((bool)gameObject2)
		{
			GameObject minimapCam = ((MinimapOnOff)gameObject2.GetComponent(typeof(MinimapOnOff))).minimapCam;
			((MinimapCamera)minimapCam.GetComponent(typeof(MinimapCamera))).target = gameObject.transform;
		}
		((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questProgress = new int[PlayerPrefs.GetInt("TempQuestSize")];
		int num3 = Extensions.get_length((System.Array)((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questProgress);
		i = 0;
		if (num3 > 0)
		{
			for (; i < num3; i++)
			{
				((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questProgress[i] = PlayerPrefs.GetInt("TempQuestp" + i.ToString());
			}
		}
		((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questSlot = new int[PlayerPrefs.GetInt("TempQuestSlotSize")];
		int num4 = Extensions.get_length((System.Array)((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questSlot);
		i = 0;
		if (num4 > 0)
		{
			for (; i < num4; i++)
			{
				((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questSlot[i] = PlayerPrefs.GetInt("TempQuestslot" + i.ToString());
			}
		}
		for (i = 0; i <= 2; i++)
		{
			((SkillWindow)gameObject.GetComponent(typeof(SkillWindow))).skill[i] = PlayerPrefs.GetInt("TempSkill" + i.ToString());
		}
		for (i = 0; i < Extensions.get_length((System.Array)((SkillWindow)gameObject.GetComponent(typeof(SkillWindow))).skillListSlot); i++)
		{
			((SkillWindow)gameObject.GetComponent(typeof(SkillWindow))).skillListSlot[i] = PlayerPrefs.GetInt("TempSkillList" + i.ToString());
		}
		((SkillWindow)gameObject.GetComponent(typeof(SkillWindow))).AssignAllSkill();
		UnityEngine.Object.Destroy(this.gameObject);
	}

	public void Main()
	{
	}
}
