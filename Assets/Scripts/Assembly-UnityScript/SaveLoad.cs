using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000080 RID: 128
[Serializable]
public class SaveLoad : MonoBehaviour
{
	// Token: 0x060001B1 RID: 433 RVA: 0x000136A0 File Offset: 0x000118A0
	public virtual void Start()
	{
		if (!this.player)
		{
			this.player = GameObject.FindWithTag("Player");
		}
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

	// Token: 0x060001B2 RID: 434 RVA: 0x00013718 File Offset: 0x00011918
	public virtual void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			this.OnOffMenu();
		}
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x0001372C File Offset: 0x0001192C
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

	// Token: 0x060001B4 RID: 436 RVA: 0x0001378C File Offset: 0x0001198C
	public virtual void OnGUI()
	{
		if (this.menu)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 110), (float)230, (float)220, (float)220), "Menu");
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 45), (float)285, (float)90, (float)40), "Save Game"))
			{
				this.SaveData();
				this.OnOffMenu();
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 45), (float)335, (float)90, (float)40), "Load Game"))
			{
				this.LoadData();
				this.OnOffMenu();
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 45), (float)385, (float)90, (float)40), "Quit Game"))
			{
				GameObject obj = GameObject.FindWithTag("MainCamera");
				UnityEngine.Object.Destroy(obj);
				UnityEngine.Object.Destroy(this.player);
				Time.timeScale = 1f;
				Application.LoadLevel("Title");
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 + 55), (float)235, (float)30, (float)30), "X"))
			{
				this.OnOffMenu();
			}
		}
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x000138CC File Offset: 0x00011ACC
	public virtual void SaveData()
	{
		PlayerPrefs.SetInt("PreviousSave" + this.saveSlot.ToString(), 10);
		PlayerPrefs.SetString("Name" + this.saveSlot.ToString(), ((Status)this.player.GetComponent(typeof(Status))).characterName);
		PlayerPrefs.SetFloat("PlayerX", this.player.transform.position.x);
		PlayerPrefs.SetFloat("PlayerY", this.player.transform.position.y);
		PlayerPrefs.SetFloat("PlayerZ", this.player.transform.position.z);
		PlayerPrefs.SetInt("PlayerID" + this.saveSlot.ToString(), ((Status)this.player.GetComponent(typeof(Status))).characterId);
		PlayerPrefs.SetInt("PlayerLevel" + this.saveSlot.ToString(), ((Status)this.player.GetComponent(typeof(Status))).level);
		PlayerPrefs.SetInt("PlayerATK" + this.saveSlot.ToString(), ((Status)this.player.GetComponent(typeof(Status))).atk);
		PlayerPrefs.SetInt("PlayerDEF" + this.saveSlot.ToString(), ((Status)this.player.GetComponent(typeof(Status))).def);
		PlayerPrefs.SetInt("PlayerMATK" + this.saveSlot.ToString(), ((Status)this.player.GetComponent(typeof(Status))).matk);
		PlayerPrefs.SetInt("PlayerMDEF" + this.saveSlot.ToString(), ((Status)this.player.GetComponent(typeof(Status))).mdef);
		PlayerPrefs.SetInt("PlayerEXP" + this.saveSlot.ToString(), ((Status)this.player.GetComponent(typeof(Status))).exp);
		PlayerPrefs.SetInt("PlayerMaxEXP" + this.saveSlot.ToString(), ((Status)this.player.GetComponent(typeof(Status))).maxExp);
		PlayerPrefs.SetInt("PlayerMaxHP" + this.saveSlot.ToString(), ((Status)this.player.GetComponent(typeof(Status))).maxHealth);
		PlayerPrefs.SetInt("PlayerHP" + this.saveSlot.ToString(), ((Status)this.player.GetComponent(typeof(Status))).health);
		PlayerPrefs.SetInt("PlayerMaxMP" + this.saveSlot.ToString(), ((Status)this.player.GetComponent(typeof(Status))).maxMana);
		PlayerPrefs.SetInt("PlayerSTP" + this.saveSlot.ToString(), ((Status)this.player.GetComponent(typeof(Status))).statusPoint);
		PlayerPrefs.SetInt("Cash" + this.saveSlot.ToString(), ((Inventory)this.player.GetComponent(typeof(Inventory))).cash);
		int num = Extensions.get_length(((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot);
		int i = 0;
		if (num > 0)
		{
			while (i < num)
			{
				PlayerPrefs.SetInt("Item" + i.ToString() + this.saveSlot.ToString(), ((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot[i]);
				PlayerPrefs.SetInt("ItemQty" + i.ToString() + this.saveSlot.ToString(), ((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[i]);
				i++;
			}
		}
		int num2 = Extensions.get_length(((Inventory)this.player.GetComponent(typeof(Inventory))).equipment);
		i = 0;
		if (num2 > 0)
		{
			while (i < num2)
			{
				PlayerPrefs.SetInt("Equipm" + i.ToString() + this.saveSlot.ToString(), ((Inventory)this.player.GetComponent(typeof(Inventory))).equipment[i]);
				i++;
			}
		}
		PlayerPrefs.SetInt("WeaEquip" + this.saveSlot.ToString(), ((Inventory)this.player.GetComponent(typeof(Inventory))).weaponEquip);
		PlayerPrefs.SetInt("ArmoEquip" + this.saveSlot.ToString(), ((Inventory)this.player.GetComponent(typeof(Inventory))).armorEquip);
		int num3 = Extensions.get_length(((QuestStat)this.player.GetComponent(typeof(QuestStat))).questProgress);
		PlayerPrefs.SetInt("QuestSize" + this.saveSlot.ToString(), num3);
		i = 0;
		if (num3 > 0)
		{
			while (i < num3)
			{
				PlayerPrefs.SetInt("Questp" + i.ToString() + this.saveSlot.ToString(), ((QuestStat)this.player.GetComponent(typeof(QuestStat))).questProgress[i]);
				i++;
			}
		}
		int num4 = Extensions.get_length(((QuestStat)this.player.GetComponent(typeof(QuestStat))).questSlot);
		PlayerPrefs.SetInt("QuestSlotSize" + this.saveSlot.ToString(), num4);
		i = 0;
		if (num4 > 0)
		{
			while (i < num4)
			{
				PlayerPrefs.SetInt("Questslot" + i.ToString() + this.saveSlot.ToString(), ((QuestStat)this.player.GetComponent(typeof(QuestStat))).questSlot[i]);
				i++;
			}
		}
		for (i = 0; i <= 2; i++)
		{
			PlayerPrefs.SetInt("Skill" + i.ToString() + this.saveSlot.ToString(), ((SkillWindow)this.player.GetComponent(typeof(SkillWindow))).skill[i]);
		}
		for (i = 0; i < Extensions.get_length(((SkillWindow)this.player.GetComponent(typeof(SkillWindow))).skillListSlot); i++)
		{
			PlayerPrefs.SetInt("SkillList" + i.ToString() + this.saveSlot.ToString(), ((SkillWindow)this.player.GetComponent(typeof(SkillWindow))).skillListSlot[i]);
		}
		MonoBehaviour.print("Saved");
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x00014064 File Offset: 0x00012264
	public virtual void LoadData()
	{
		GameObject gameObject = GameObject.FindWithTag("Player");
		((Status)gameObject.GetComponent(typeof(Status))).characterName = PlayerPrefs.GetString("Name" + this.saveSlot.ToString());
		this.lastPosition.x = PlayerPrefs.GetFloat("PlayerX");
		this.lastPosition.y = PlayerPrefs.GetFloat("PlayerY");
		this.lastPosition.z = PlayerPrefs.GetFloat("PlayerZ");
		gameObject.transform.position = this.lastPosition;
		((Status)gameObject.GetComponent(typeof(Status))).level = PlayerPrefs.GetInt("PlayerLevel" + this.saveSlot.ToString());
		((Status)gameObject.GetComponent(typeof(Status))).atk = PlayerPrefs.GetInt("PlayerATK" + this.saveSlot.ToString());
		((Status)gameObject.GetComponent(typeof(Status))).def = PlayerPrefs.GetInt("PlayerDEF" + this.saveSlot.ToString());
		((Status)gameObject.GetComponent(typeof(Status))).matk = PlayerPrefs.GetInt("PlayerMATK" + this.saveSlot.ToString());
		((Status)gameObject.GetComponent(typeof(Status))).mdef = PlayerPrefs.GetInt("PlayerMDEF" + this.saveSlot.ToString());
		((Status)gameObject.GetComponent(typeof(Status))).mdef = PlayerPrefs.GetInt("PlayerMDEF" + this.saveSlot.ToString());
		((Status)gameObject.GetComponent(typeof(Status))).exp = PlayerPrefs.GetInt("PlayerEXP" + this.saveSlot.ToString());
		((Status)gameObject.GetComponent(typeof(Status))).maxExp = PlayerPrefs.GetInt("PlayerMaxEXP" + this.saveSlot.ToString());
		((Status)gameObject.GetComponent(typeof(Status))).maxHealth = PlayerPrefs.GetInt("PlayerMaxHP" + this.saveSlot.ToString());
		((Status)gameObject.GetComponent(typeof(Status))).health = PlayerPrefs.GetInt("PlayerHP" + this.saveSlot.ToString());
		((Status)gameObject.GetComponent(typeof(Status))).maxMana = PlayerPrefs.GetInt("PlayerMaxMP" + this.saveSlot.ToString());
		((Status)gameObject.GetComponent(typeof(Status))).mana = PlayerPrefs.GetInt("PlayerMaxMP" + this.saveSlot.ToString());
		((Status)gameObject.GetComponent(typeof(Status))).statusPoint = PlayerPrefs.GetInt("PlayerSTP" + this.saveSlot.ToString());
		this.mainCam = GameObject.FindWithTag("MainCamera").transform;
		((Inventory)gameObject.GetComponent(typeof(Inventory))).cash = PlayerPrefs.GetInt("Cash" + this.saveSlot.ToString());
		int num = Extensions.get_length(((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot);
		int i = 0;
		if (num > 0)
		{
			while (i < num)
			{
				((Inventory)gameObject.GetComponent(typeof(Inventory))).itemSlot[i] = PlayerPrefs.GetInt("Item" + i.ToString() + this.saveSlot.ToString());
				((Inventory)gameObject.GetComponent(typeof(Inventory))).itemQuantity[i] = PlayerPrefs.GetInt("ItemQty" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		int num2 = Extensions.get_length(((Inventory)this.player.GetComponent(typeof(Inventory))).equipment);
		i = 0;
		if (num2 > 0)
		{
			while (i < num2)
			{
				((Inventory)gameObject.GetComponent(typeof(Inventory))).equipment[i] = PlayerPrefs.GetInt("Equipm" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		((Inventory)gameObject.GetComponent(typeof(Inventory))).weaponEquip = 0;
		((Inventory)gameObject.GetComponent(typeof(Inventory))).armorEquip = PlayerPrefs.GetInt("ArmoEquip" + this.saveSlot.ToString());
		if (PlayerPrefs.GetInt("WeaEquip" + this.saveSlot.ToString()) == 0)
		{
			((Inventory)gameObject.GetComponent(typeof(Inventory))).RemoveWeaponMesh();
		}
		else
		{
			((Inventory)gameObject.GetComponent(typeof(Inventory))).EquipItem(PlayerPrefs.GetInt("WeaEquip" + this.saveSlot.ToString()), ((Inventory)gameObject.GetComponent(typeof(Inventory))).equipment.Length + 5);
		}
		GameObject[] array = GameObject.FindGameObjectsWithTag("Enemy");
		int j = 0;
		GameObject[] array2 = array;
		int length = array2.Length;
		while (j < length)
		{
			if (array2[j])
			{
				((AIset)array2[j].GetComponent(typeof(AIset))).followTarget = gameObject.transform;
			}
			j++;
		}
		((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questProgress = new int[PlayerPrefs.GetInt("QuestSize" + this.saveSlot.ToString())];
		int num3 = Extensions.get_length(((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questProgress);
		i = 0;
		if (num3 > 0)
		{
			while (i < num3)
			{
				((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questProgress[i] = PlayerPrefs.GetInt("Questp" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questSlot = new int[PlayerPrefs.GetInt("QuestSlotSize" + this.saveSlot.ToString())];
		int num4 = Extensions.get_length(((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questSlot);
		i = 0;
		if (num4 > 0)
		{
			while (i < num4)
			{
				((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questSlot[i] = PlayerPrefs.GetInt("Questslot" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		for (i = 0; i <= 2; i++)
		{
			((SkillWindow)gameObject.GetComponent(typeof(SkillWindow))).skill[i] = PlayerPrefs.GetInt("Skill" + i.ToString() + this.saveSlot.ToString());
		}
		for (i = 0; i < Extensions.get_length(((SkillWindow)this.player.GetComponent(typeof(SkillWindow))).skillListSlot); i++)
		{
			((SkillWindow)this.player.GetComponent(typeof(SkillWindow))).skillListSlot[i] = PlayerPrefs.GetInt("SkillList" + i.ToString() + this.saveSlot.ToString());
		}
		((SkillWindow)gameObject.GetComponent(typeof(SkillWindow))).AssignAllSkill();
		GameObject gameObject2 = GameObject.FindWithTag("Minimap");
		if (gameObject2)
		{
			GameObject minimapCam = ((MinimapOnOff)gameObject2.GetComponent(typeof(MinimapOnOff))).minimapCam;
			((MinimapCamera)minimapCam.GetComponent(typeof(MinimapCamera))).target = gameObject.transform;
		}
		this.player = GameObject.FindWithTag("Player");
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00014938 File Offset: 0x00012B38
	public virtual void LoadGame()
	{
		((Status)this.player.GetComponent(typeof(Status))).characterName = PlayerPrefs.GetString("Name" + this.saveSlot.ToString());
		((Status)this.player.GetComponent(typeof(Status))).level = PlayerPrefs.GetInt("PlayerLevel" + this.saveSlot.ToString());
		((Status)this.player.GetComponent(typeof(Status))).atk = PlayerPrefs.GetInt("PlayerATK" + this.saveSlot.ToString());
		((Status)this.player.GetComponent(typeof(Status))).def = PlayerPrefs.GetInt("PlayerDEF" + this.saveSlot.ToString());
		((Status)this.player.GetComponent(typeof(Status))).matk = PlayerPrefs.GetInt("PlayerMATK" + this.saveSlot.ToString());
		((Status)this.player.GetComponent(typeof(Status))).mdef = PlayerPrefs.GetInt("PlayerMDEF" + this.saveSlot.ToString());
		((Status)this.player.GetComponent(typeof(Status))).mdef = PlayerPrefs.GetInt("PlayerMDEF" + this.saveSlot.ToString());
		((Status)this.player.GetComponent(typeof(Status))).exp = PlayerPrefs.GetInt("PlayerEXP" + this.saveSlot.ToString());
		((Status)this.player.GetComponent(typeof(Status))).maxExp = PlayerPrefs.GetInt("PlayerMaxEXP" + this.saveSlot.ToString());
		((Status)this.player.GetComponent(typeof(Status))).maxHealth = PlayerPrefs.GetInt("PlayerMaxHP" + this.saveSlot.ToString());
		((Status)this.player.GetComponent(typeof(Status))).health = PlayerPrefs.GetInt("PlayerMaxHP" + this.saveSlot.ToString());
		((Status)this.player.GetComponent(typeof(Status))).maxMana = PlayerPrefs.GetInt("PlayerMaxMP" + this.saveSlot.ToString());
		((Status)this.player.GetComponent(typeof(Status))).mana = PlayerPrefs.GetInt("PlayerMaxMP" + this.saveSlot.ToString());
		((Status)this.player.GetComponent(typeof(Status))).statusPoint = PlayerPrefs.GetInt("PlayerSTP" + this.saveSlot.ToString());
		((Inventory)this.player.GetComponent(typeof(Inventory))).cash = PlayerPrefs.GetInt("Cash" + this.saveSlot.ToString());
		int num = Extensions.get_length(((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot);
		int i = 0;
		if (num > 0)
		{
			while (i < num)
			{
				((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot[i] = PlayerPrefs.GetInt("Item" + i.ToString() + this.saveSlot.ToString());
				((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[i] = PlayerPrefs.GetInt("ItemQty" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		int num2 = Extensions.get_length(((Inventory)this.player.GetComponent(typeof(Inventory))).equipment);
		i = 0;
		if (num2 > 0)
		{
			while (i < num2)
			{
				((Inventory)this.player.GetComponent(typeof(Inventory))).equipment[i] = PlayerPrefs.GetInt("Equipm" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		((Inventory)this.player.GetComponent(typeof(Inventory))).weaponEquip = 0;
		((Inventory)this.player.GetComponent(typeof(Inventory))).armorEquip = PlayerPrefs.GetInt("ArmoEquip" + this.saveSlot.ToString());
		if (PlayerPrefs.GetInt("WeaEquip" + this.saveSlot.ToString()) == 0)
		{
			((Inventory)this.player.GetComponent(typeof(Inventory))).RemoveWeaponMesh();
		}
		else
		{
			((Inventory)this.player.GetComponent(typeof(Inventory))).EquipItem(PlayerPrefs.GetInt("WeaEquip" + this.saveSlot.ToString()), ((Inventory)this.player.GetComponent(typeof(Inventory))).equipment.Length + 5);
		}
		GameObject[] array = GameObject.FindGameObjectsWithTag("Enemy");
		int j = 0;
		GameObject[] array2 = array;
		int length = array2.Length;
		while (j < length)
		{
			if (array2[j])
			{
				((AIset)array2[j].GetComponent(typeof(AIset))).followTarget = this.player.transform;
			}
			j++;
		}
		((QuestStat)this.player.GetComponent(typeof(QuestStat))).questProgress = new int[PlayerPrefs.GetInt("QuestSize" + this.saveSlot.ToString())];
		int num3 = Extensions.get_length(((QuestStat)this.player.GetComponent(typeof(QuestStat))).questProgress);
		i = 0;
		if (num3 > 0)
		{
			while (i < num3)
			{
				((QuestStat)this.player.GetComponent(typeof(QuestStat))).questProgress[i] = PlayerPrefs.GetInt("Questp" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		((QuestStat)this.player.GetComponent(typeof(QuestStat))).questSlot = new int[PlayerPrefs.GetInt("QuestSlotSize" + this.saveSlot.ToString())];
		int num4 = Extensions.get_length(((QuestStat)this.player.GetComponent(typeof(QuestStat))).questSlot);
		i = 0;
		if (num4 > 0)
		{
			while (i < num4)
			{
				((QuestStat)this.player.GetComponent(typeof(QuestStat))).questSlot[i] = PlayerPrefs.GetInt("Questslot" + i.ToString() + this.saveSlot.ToString());
				i++;
			}
		}
		for (i = 0; i <= 2; i++)
		{
			((SkillWindow)this.player.GetComponent(typeof(SkillWindow))).skill[i] = PlayerPrefs.GetInt("Skill" + i.ToString() + this.saveSlot.ToString());
		}
		for (i = 0; i < Extensions.get_length(((SkillWindow)this.player.GetComponent(typeof(SkillWindow))).skillListSlot); i++)
		{
			((SkillWindow)this.player.GetComponent(typeof(SkillWindow))).skillListSlot[i] = PlayerPrefs.GetInt("SkillList" + i.ToString() + this.saveSlot.ToString());
		}
		((SkillWindow)this.player.GetComponent(typeof(SkillWindow))).AssignAllSkill();
		MonoBehaviour.print("Loaded");
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x000151DC File Offset: 0x000133DC
	public virtual void Main()
	{
	}

	// Token: 0x040002D5 RID: 725
	public bool autoLoad;

	// Token: 0x040002D6 RID: 726
	public GameObject player;

	// Token: 0x040002D7 RID: 727
	private bool menu;

	// Token: 0x040002D8 RID: 728
	private Vector3 lastPosition;

	// Token: 0x040002D9 RID: 729
	private Transform mainCam;

	// Token: 0x040002DA RID: 730
	public GameObject oldPlayer;

	// Token: 0x040002DB RID: 731
	private int saveSlot;
}
