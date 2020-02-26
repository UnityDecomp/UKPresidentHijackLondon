using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200008A RID: 138
public class SaveLoadC : MonoBehaviour
{
	// Token: 0x06000436 RID: 1078 RVA: 0x0001BED4 File Offset: 0x0001A2D4
	private void Start()
	{
		if (!this.player)
		{
			this.player = GameObject.FindWithTag("Player");
		}
		this.questM = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
		this.saveSlot = PlayerPrefs.GetInt("SaveSlot");
		if (PlayerPrefs.GetInt("Loadgame") == 10 || this.autoLoad)
		{
			this.LoadGame();
			if (!this.autoLoad)
			{
				PlayerPrefs.SetInt("Loadgame", 0);
			}
		}
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x0001BF63 File Offset: 0x0001A363
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			this.OnOffMenu();
		}
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x0001BF78 File Offset: 0x0001A378
	private void OnOffMenu()
	{
		if (!this.showWindow && Time.timeScale != 0f)
		{
			Time.timeScale = 0f;
			this.showWindow = true;
			Screen.lockCursor = false;
			this.questM.pause = true;
			this.pauseWindow.gameObject.SetActive(true);
		}
		else
		{
			this.showWindow = false;
			Time.timeScale = 1f;
			Screen.lockCursor = true;
			this.questM.pause = false;
			this.pauseWindow.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x0001C00C File Offset: 0x0001A40C
	public void Resume()
	{
		this.showWindow = false;
		Time.timeScale = 1f;
		Screen.lockCursor = true;
		this.questM.pause = false;
		this.pauseWindow.gameObject.SetActive(false);
	}

	// Token: 0x0600043A RID: 1082 RVA: 0x0001C042 File Offset: 0x0001A442
	public void Restart()
	{
		UnityEngine.Object.Destroy(this.player);
		Application.LoadLevel("TRexMainScene");
	}

	// Token: 0x0600043B RID: 1083 RVA: 0x0001C059 File Offset: 0x0001A459
	public void Exit()
	{
		PlayerPrefs.SetInt("Quest", this.questM.getQuestID());
		Application.LoadLevel("MainMenu");
	}

	// Token: 0x0600043C RID: 1084 RVA: 0x0001C07C File Offset: 0x0001A47C
	private void OnGUI()
	{
		if (this.menu)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 110), 230f, 220f, 200f), "Menu");
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 45), 285f, 90f, 40f), "Save Game"))
			{
				this.SaveData();
				this.OnOffMenu();
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 45), 365f, 90f, 40f), "Load Game"))
			{
				this.LoadData();
				this.OnOffMenu();
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 55), 235f, 30f, 30f), "X"))
			{
				this.OnOffMenu();
			}
		}
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x0001C168 File Offset: 0x0001A568
	private void SaveData()
	{
		PlayerPrefs.SetInt("PreviousSave" + this.saveSlot.ToString(), 10);
		PlayerPrefs.SetString("Name" + this.saveSlot.ToString(), this.player.GetComponent<StatusC>().characterName);
		PlayerPrefs.SetFloat("PlayerX", this.player.transform.position.x);
		PlayerPrefs.SetFloat("PlayerY", this.player.transform.position.y);
		PlayerPrefs.SetFloat("PlayerZ", this.player.transform.position.z);
		PlayerPrefs.SetInt("PlayerID" + this.saveSlot.ToString(), this.player.GetComponent<StatusC>().characterId);
		PlayerPrefs.SetInt("PlayerLevel" + this.saveSlot.ToString(), this.player.GetComponent<StatusC>().level);
		PlayerPrefs.SetInt("PlayerATK" + this.saveSlot.ToString(), this.player.GetComponent<StatusC>().atk);
		PlayerPrefs.SetInt("PlayerDEF" + this.saveSlot.ToString(), this.player.GetComponent<StatusC>().def);
		PlayerPrefs.SetInt("PlayerMATK" + this.saveSlot.ToString(), this.player.GetComponent<StatusC>().matk);
		PlayerPrefs.SetInt("PlayerMDEF" + this.saveSlot.ToString(), this.player.GetComponent<StatusC>().mdef);
		PlayerPrefs.SetInt("PlayerEXP" + this.saveSlot.ToString(), this.player.GetComponent<StatusC>().exp);
		PlayerPrefs.SetInt("PlayerMaxEXP" + this.saveSlot.ToString(), this.player.GetComponent<StatusC>().maxExp);
		PlayerPrefs.SetInt("PlayerMaxHP" + this.saveSlot.ToString(), this.player.GetComponent<StatusC>().maxHealth);
		PlayerPrefs.SetInt("PlayerHP" + this.saveSlot.ToString(), this.player.GetComponent<StatusC>().health);
		PlayerPrefs.SetInt("PlayerMaxMP" + this.saveSlot.ToString(), this.player.GetComponent<StatusC>().maxMana);
		PlayerPrefs.SetInt("PlayerSTP" + this.saveSlot.ToString(), this.player.GetComponent<StatusC>().statusPoint);
		PlayerPrefs.SetInt("Cash" + this.saveSlot.ToString(), this.player.GetComponent<InventoryC>().cash);
		int num = this.player.GetComponent<InventoryC>().itemSlot.Length;
		int i = 0;
		if (num > 0)
		{
			while (i < num)
			{
				PlayerPrefs.SetInt("Item" + i.ToString() + this.saveSlot.ToString(), this.player.GetComponent<InventoryC>().itemSlot[i]);
				PlayerPrefs.SetInt("ItemQty" + i.ToString() + this.saveSlot.ToString(), this.player.GetComponent<InventoryC>().itemQuantity[i]);
				i++;
			}
		}
		int num2 = this.player.GetComponent<InventoryC>().equipment.Length;
		i = 0;
		if (num2 > 0)
		{
			while (i < num2)
			{
				PlayerPrefs.SetInt("Equipm" + i.ToString() + this.saveSlot.ToString(), this.player.GetComponent<InventoryC>().equipment[i]);
				i++;
			}
		}
		PlayerPrefs.SetInt("WeaEquip" + this.saveSlot.ToString(), this.player.GetComponent<InventoryC>().weaponEquip);
		PlayerPrefs.SetInt("ArmoEquip" + this.saveSlot.ToString(), this.player.GetComponent<InventoryC>().armorEquip);
		int num3 = this.player.GetComponent<QuestStatC>().questProgress.Length;
		PlayerPrefs.SetInt("QuestSize" + this.saveSlot.ToString(), num3);
		i = 0;
		if (num3 > 0)
		{
			while (i < num3)
			{
				PlayerPrefs.SetInt("Questp" + i.ToString() + this.saveSlot.ToString(), this.player.GetComponent<QuestStatC>().questProgress[i]);
				i++;
			}
		}
		int num4 = this.player.GetComponent<QuestStatC>().questSlot.Length;
		PlayerPrefs.SetInt("QuestSlotSize" + this.saveSlot.ToString(), num4);
		i = 0;
		if (num4 > 0)
		{
			while (i < num4)
			{
				PlayerPrefs.SetInt("Questslot" + i.ToString() + this.saveSlot.ToString(), this.player.GetComponent<QuestStatC>().questSlot[i]);
				i++;
			}
		}
		for (i = 0; i <= 2; i++)
		{
			PlayerPrefs.SetInt("Skill" + i.ToString() + this.saveSlot.ToString(), this.player.GetComponent<SkillWindowC>().skill[i]);
		}
		for (i = 0; i < this.player.GetComponent<SkillWindowC>().skillListSlot.Length; i++)
		{
			PlayerPrefs.SetInt("SkillList" + i.ToString() + this.saveSlot.ToString(), this.player.GetComponent<SkillWindowC>().skillListSlot[i]);
		}
		MonoBehaviour.print("Saved");
	}

	// Token: 0x0600043E RID: 1086 RVA: 0x0001C814 File Offset: 0x0001AC14
	private void LoadData()
	{
		GameObject gameObject = GameObject.FindWithTag("Player");
		this.lastPosition.x = PlayerPrefs.GetFloat("PlayerX");
		this.lastPosition.y = PlayerPrefs.GetFloat("PlayerY");
		this.lastPosition.z = PlayerPrefs.GetFloat("PlayerZ");
		gameObject.transform.position = this.lastPosition;
		gameObject.GetComponent<StatusC>().level = PlayerPrefs.GetInt("PlayerLevel" + this.saveSlot.ToString());
		gameObject.GetComponent<StatusC>().atk = PlayerPrefs.GetInt("PlayerATK" + this.saveSlot.ToString());
		gameObject.GetComponent<StatusC>().def = PlayerPrefs.GetInt("PlayerDEF" + this.saveSlot.ToString());
		gameObject.GetComponent<StatusC>().matk = PlayerPrefs.GetInt("PlayerMATK" + this.saveSlot.ToString());
		gameObject.GetComponent<StatusC>().mdef = PlayerPrefs.GetInt("PlayerMDEF" + this.saveSlot.ToString());
		gameObject.GetComponent<StatusC>().mdef = PlayerPrefs.GetInt("PlayerMDEF" + this.saveSlot.ToString());
		gameObject.GetComponent<StatusC>().exp = PlayerPrefs.GetInt("PlayerEXP" + this.saveSlot.ToString());
		gameObject.GetComponent<StatusC>().maxExp = PlayerPrefs.GetInt("PlayerMaxEXP" + this.saveSlot.ToString());
		gameObject.GetComponent<StatusC>().maxHealth = PlayerPrefs.GetInt("PlayerMaxHP" + this.saveSlot.ToString());
		gameObject.GetComponent<StatusC>().health = PlayerPrefs.GetInt("PlayerHP" + this.saveSlot.ToString());
		gameObject.GetComponent<StatusC>().maxMana = PlayerPrefs.GetInt("PlayerMaxMP" + this.saveSlot.ToString());
		gameObject.GetComponent<StatusC>().mana = PlayerPrefs.GetInt("PlayerMaxMP" + this.saveSlot.ToString());
		gameObject.GetComponent<StatusC>().statusPoint = PlayerPrefs.GetInt("PlayerSTP" + this.saveSlot.ToString());
		this.mainCam = GameObject.FindWithTag("MainCamera").transform;
		gameObject.GetComponent<InventoryC>().cash = PlayerPrefs.GetInt("Cash" + this.saveSlot.ToString());
		int num = this.player.GetComponent<InventoryC>().itemSlot.Length;
		int i = 0;
		if (num > 0)
		{
			while (i < num)
			{
				gameObject.GetComponent<InventoryC>().itemSlot[i] = PlayerPrefs.GetInt("Item" + i.ToString() + this.saveSlot.ToString());
				gameObject.GetComponent<InventoryC>().itemQuantity[i] = PlayerPrefs.GetInt("ItemQty" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		int num2 = this.player.GetComponent<InventoryC>().equipment.Length;
		i = 0;
		if (num2 > 0)
		{
			while (i < num2)
			{
				gameObject.GetComponent<InventoryC>().equipment[i] = PlayerPrefs.GetInt("Equipm" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		gameObject.GetComponent<InventoryC>().weaponEquip = 0;
		gameObject.GetComponent<InventoryC>().armorEquip = PlayerPrefs.GetInt("ArmoEquip" + this.saveSlot.ToString());
		if (PlayerPrefs.GetInt("WeaEquip" + this.saveSlot.ToString()) == 0)
		{
			gameObject.GetComponent<InventoryC>().RemoveWeaponMesh();
		}
		else
		{
			gameObject.GetComponent<InventoryC>().EquipItem(PlayerPrefs.GetInt("WeaEquip" + this.saveSlot.ToString()), gameObject.GetComponent<InventoryC>().equipment.Length + 5);
		}
		Screen.lockCursor = true;
		GameObject[] array = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject gameObject2 in array)
		{
			if (gameObject2)
			{
				gameObject2.GetComponent<AIsetC>().followTarget = gameObject.transform;
			}
		}
		gameObject.GetComponent<QuestStatC>().questProgress = new int[PlayerPrefs.GetInt("QuestSize" + this.saveSlot.ToString())];
		int num3 = gameObject.GetComponent<QuestStatC>().questProgress.Length;
		i = 0;
		if (num3 > 0)
		{
			while (i < num3)
			{
				gameObject.GetComponent<QuestStatC>().questProgress[i] = PlayerPrefs.GetInt("Questp" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		gameObject.GetComponent<QuestStatC>().questSlot = new int[PlayerPrefs.GetInt("QuestSlotSize" + this.saveSlot.ToString())];
		int num4 = gameObject.GetComponent<QuestStatC>().questSlot.Length;
		i = 0;
		if (num4 > 0)
		{
			while (i < num4)
			{
				gameObject.GetComponent<QuestStatC>().questSlot[i] = PlayerPrefs.GetInt("Questslot" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		for (i = 0; i <= 2; i++)
		{
			gameObject.GetComponent<SkillWindowC>().skill[i] = PlayerPrefs.GetInt("Skill" + i.ToString() + this.saveSlot.ToString());
		}
		for (i = 0; i < this.player.GetComponent<SkillWindowC>().skillListSlot.Length; i++)
		{
			this.player.GetComponent<SkillWindowC>().skillListSlot[i] = PlayerPrefs.GetInt("SkillList" + i.ToString() + this.saveSlot.ToString());
		}
		gameObject.GetComponent<SkillWindowC>().AssignAllSkill();
		GameObject gameObject3 = GameObject.FindWithTag("Minimap");
		if (gameObject3)
		{
			GameObject minimapCam = gameObject3.GetComponent<MinimapOnOffC>().minimapCam;
			minimapCam.GetComponent<MinimapCameraC>().target = gameObject.transform;
		}
		this.player = GameObject.FindWithTag("Player");
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x0001CF14 File Offset: 0x0001B314
	private void LoadGame()
	{
		this.player.GetComponent<StatusC>().level = PlayerPrefs.GetInt("PlayerLevel" + this.saveSlot.ToString());
		this.player.GetComponent<StatusC>().atk = PlayerPrefs.GetInt("PlayerATK" + this.saveSlot.ToString());
		this.player.GetComponent<StatusC>().def = PlayerPrefs.GetInt("PlayerDEF" + this.saveSlot.ToString());
		this.player.GetComponent<StatusC>().matk = PlayerPrefs.GetInt("PlayerMATK" + this.saveSlot.ToString());
		this.player.GetComponent<StatusC>().mdef = PlayerPrefs.GetInt("PlayerMDEF" + this.saveSlot.ToString());
		this.player.GetComponent<StatusC>().mdef = PlayerPrefs.GetInt("PlayerMDEF" + this.saveSlot.ToString());
		this.player.GetComponent<StatusC>().exp = PlayerPrefs.GetInt("PlayerEXP" + this.saveSlot.ToString());
		this.player.GetComponent<StatusC>().maxExp = PlayerPrefs.GetInt("PlayerMaxEXP" + this.saveSlot.ToString());
		this.player.GetComponent<StatusC>().maxHealth = PlayerPrefs.GetInt("PlayerMaxHP" + this.saveSlot.ToString());
		this.player.GetComponent<StatusC>().health = PlayerPrefs.GetInt("PlayerMaxHP" + this.saveSlot.ToString());
		this.player.GetComponent<StatusC>().maxMana = PlayerPrefs.GetInt("PlayerMaxMP" + this.saveSlot.ToString());
		this.player.GetComponent<StatusC>().mana = PlayerPrefs.GetInt("PlayerMaxMP" + this.saveSlot.ToString());
		this.player.GetComponent<StatusC>().statusPoint = PlayerPrefs.GetInt("PlayerSTP" + this.saveSlot.ToString());
		this.player.GetComponent<InventoryC>().cash = PlayerPrefs.GetInt("Cash" + this.saveSlot.ToString());
		int num = this.player.GetComponent<InventoryC>().itemSlot.Length;
		int i = 0;
		if (num > 0)
		{
			while (i < num)
			{
				this.player.GetComponent<InventoryC>().itemSlot[i] = PlayerPrefs.GetInt("Item" + i.ToString() + this.saveSlot.ToString());
				this.player.GetComponent<InventoryC>().itemQuantity[i] = PlayerPrefs.GetInt("ItemQty" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		int num2 = this.player.GetComponent<InventoryC>().equipment.Length;
		i = 0;
		if (num2 > 0)
		{
			while (i < num2)
			{
				this.player.GetComponent<InventoryC>().equipment[i] = PlayerPrefs.GetInt("Equipm" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		this.player.GetComponent<InventoryC>().weaponEquip = 0;
		this.player.GetComponent<InventoryC>().armorEquip = PlayerPrefs.GetInt("ArmoEquip" + this.saveSlot.ToString());
		if (PlayerPrefs.GetInt("WeaEquip" + this.saveSlot.ToString()) == 0)
		{
			this.player.GetComponent<InventoryC>().RemoveWeaponMesh();
		}
		else
		{
			this.player.GetComponent<InventoryC>().EquipItem(PlayerPrefs.GetInt("WeaEquip" + this.saveSlot.ToString()), this.player.GetComponent<InventoryC>().equipment.Length + 5);
		}
		Screen.lockCursor = true;
		GameObject[] array = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject gameObject in array)
		{
			if (gameObject)
			{
				gameObject.GetComponent<AIsetC>().followTarget = this.player.transform;
			}
		}
		this.player.GetComponent<QuestStatC>().questProgress = new int[PlayerPrefs.GetInt("QuestSize" + this.saveSlot.ToString())];
		int num3 = this.player.GetComponent<QuestStatC>().questProgress.Length;
		i = 0;
		if (num3 > 0)
		{
			while (i < num3)
			{
				this.player.GetComponent<QuestStatC>().questProgress[i] = PlayerPrefs.GetInt("Questp" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		this.player.GetComponent<QuestStatC>().questSlot = new int[PlayerPrefs.GetInt("QuestSlotSize" + this.saveSlot.ToString())];
		int num4 = this.player.GetComponent<QuestStatC>().questSlot.Length;
		i = 0;
		if (num4 > 0)
		{
			while (i < num4)
			{
				this.player.GetComponent<QuestStatC>().questSlot[i] = PlayerPrefs.GetInt("Questslot" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		for (i = 0; i <= 2; i++)
		{
			this.player.GetComponent<SkillWindowC>().skill[i] = PlayerPrefs.GetInt("Skill" + i.ToString() + this.saveSlot.ToString());
		}
		for (i = 0; i < this.player.GetComponent<SkillWindowC>().skillListSlot.Length; i++)
		{
			this.player.GetComponent<SkillWindowC>().skillListSlot[i] = PlayerPrefs.GetInt("SkillList" + i.ToString() + this.saveSlot.ToString());
		}
		this.player.GetComponent<SkillWindowC>().AssignAllSkill();
		MonoBehaviour.print("Loaded");
	}

	// Token: 0x040003F7 RID: 1015
	public bool autoLoad;

	// Token: 0x040003F8 RID: 1016
	public Image pauseWindow;

	// Token: 0x040003F9 RID: 1017
	private bool showWindow;

	// Token: 0x040003FA RID: 1018
	public GameObject player;

	// Token: 0x040003FB RID: 1019
	private bool menu;

	// Token: 0x040003FC RID: 1020
	private Vector3 lastPosition;

	// Token: 0x040003FD RID: 1021
	private Transform mainCam;

	// Token: 0x040003FE RID: 1022
	public GameObject oldPlayer;

	// Token: 0x040003FF RID: 1023
	[HideInInspector]
	public QuestManager questM;

	// Token: 0x04000400 RID: 1024
	private int saveSlot;
}
