using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x0200008D RID: 141
[Serializable]
public class StageStart : MonoBehaviour
{
	// Token: 0x060001EC RID: 492 RVA: 0x00019208 File Offset: 0x00017408
	public StageStart()
	{
		this.duration = 8f;
	}

	// Token: 0x060001ED RID: 493 RVA: 0x0001921C File Offset: 0x0001741C
	public virtual void Start()
	{
		if (!this.player)
		{
			this.player = GameObject.FindWithTag("Player");
		}
		if (PlayerPrefs.GetInt("Loadgame") == 10)
		{
			this.LoadGame();
		}
		else
		{
			this.SaveData();
		}
		this.show = true;
	}

	// Token: 0x060001EE RID: 494 RVA: 0x00019274 File Offset: 0x00017474
	public virtual void SaveData()
	{
		PlayerPrefs.SetFloat("PlayerX", this.player.transform.position.x);
		PlayerPrefs.SetFloat("PlayerY", this.player.transform.position.y);
		PlayerPrefs.SetFloat("PlayerZ", this.player.transform.position.z);
		PlayerPrefs.SetInt("PlayerLevel", ((Status)this.player.GetComponent(typeof(Status))).level);
		PlayerPrefs.SetInt("PlayerATK", ((Status)this.player.GetComponent(typeof(Status))).atk);
		PlayerPrefs.SetInt("PlayerDEF", ((Status)this.player.GetComponent(typeof(Status))).def);
		PlayerPrefs.SetInt("PlayerMATK", ((Status)this.player.GetComponent(typeof(Status))).matk);
		PlayerPrefs.SetInt("PlayerMDEF", ((Status)this.player.GetComponent(typeof(Status))).mdef);
		PlayerPrefs.SetInt("PlayerEXP", ((Status)this.player.GetComponent(typeof(Status))).exp);
		PlayerPrefs.SetInt("PlayerMaxEXP", ((Status)this.player.GetComponent(typeof(Status))).maxExp);
		PlayerPrefs.SetInt("PlayerMaxHP", ((Status)this.player.GetComponent(typeof(Status))).maxHealth);
		PlayerPrefs.SetInt("PlayerMaxMP", ((Status)this.player.GetComponent(typeof(Status))).maxMana);
		PlayerPrefs.SetInt("PlayerSTP", ((Status)this.player.GetComponent(typeof(Status))).statusPoint);
		PlayerPrefs.SetInt("Cash", ((Inventory)this.player.GetComponent(typeof(Inventory))).cash);
		int num = Extensions.get_length(((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot);
		int i = 0;
		if (num > 0)
		{
			while (i < num)
			{
				PlayerPrefs.SetInt("Item" + i.ToString(), ((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot[i]);
				PlayerPrefs.SetInt("ItemQty" + i.ToString(), ((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[i]);
				i++;
			}
		}
		int num2 = Extensions.get_length(((Inventory)this.player.GetComponent(typeof(Inventory))).equipment);
		i = 0;
		if (num2 > 0)
		{
			while (i < num2)
			{
				PlayerPrefs.SetInt("Equipm" + i.ToString(), ((Inventory)this.player.GetComponent(typeof(Inventory))).equipment[i]);
				i++;
			}
		}
		PlayerPrefs.SetInt("WeaEquip", ((Inventory)this.player.GetComponent(typeof(Inventory))).weaponEquip);
		PlayerPrefs.SetInt("ArmoEquip", ((Inventory)this.player.GetComponent(typeof(Inventory))).armorEquip);
		int num3 = Extensions.get_length(((QuestStat)this.player.GetComponent(typeof(QuestStat))).questProgress);
		PlayerPrefs.SetInt("QuestSize", num3);
		i = 0;
		if (num3 > 0)
		{
			while (i < num3)
			{
				PlayerPrefs.SetInt("Questp" + i.ToString(), ((QuestStat)this.player.GetComponent(typeof(QuestStat))).questProgress[i]);
				i++;
			}
		}
		int num4 = Extensions.get_length(((QuestStat)this.player.GetComponent(typeof(QuestStat))).questSlot);
		PlayerPrefs.SetInt("QuestSlotSize", num4);
		i = 0;
		if (num4 > 0)
		{
			while (i < num4)
			{
				PlayerPrefs.SetInt("Questslot" + i.ToString(), ((QuestStat)this.player.GetComponent(typeof(QuestStat))).questSlot[i]);
				i++;
			}
		}
		for (i = 0; i <= 2; i++)
		{
			PlayerPrefs.SetInt("Skill" + i.ToString(), ((SkillWindow)this.player.GetComponent(typeof(SkillWindow))).skill[i]);
		}
		MonoBehaviour.print("Saved");
	}

	// Token: 0x060001EF RID: 495 RVA: 0x00019778 File Offset: 0x00017978
	public virtual void OnGUI()
	{
		if (this.show)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width - 320), (float)5, (float)300, (float)204), this.tip);
		}
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x000197B0 File Offset: 0x000179B0
	public virtual void LoadGame()
	{
		((Status)this.player.GetComponent(typeof(Status))).level = PlayerPrefs.GetInt("PlayerLevel");
		((Status)this.player.GetComponent(typeof(Status))).atk = PlayerPrefs.GetInt("PlayerATK");
		((Status)this.player.GetComponent(typeof(Status))).def = PlayerPrefs.GetInt("PlayerDEF");
		((Status)this.player.GetComponent(typeof(Status))).matk = PlayerPrefs.GetInt("PlayerMATK");
		((Status)this.player.GetComponent(typeof(Status))).mdef = PlayerPrefs.GetInt("PlayerMDEF");
		((Status)this.player.GetComponent(typeof(Status))).mdef = PlayerPrefs.GetInt("PlayerMDEF");
		((Status)this.player.GetComponent(typeof(Status))).exp = PlayerPrefs.GetInt("PlayerEXP");
		((Status)this.player.GetComponent(typeof(Status))).maxExp = PlayerPrefs.GetInt("PlayerMaxEXP");
		((Status)this.player.GetComponent(typeof(Status))).maxHealth = PlayerPrefs.GetInt("PlayerMaxHP");
		((Status)this.player.GetComponent(typeof(Status))).health = PlayerPrefs.GetInt("PlayerMaxHP");
		((Status)this.player.GetComponent(typeof(Status))).maxMana = PlayerPrefs.GetInt("PlayerMaxMP");
		((Status)this.player.GetComponent(typeof(Status))).mana = PlayerPrefs.GetInt("PlayerMaxMP");
		((Status)this.player.GetComponent(typeof(Status))).statusPoint = PlayerPrefs.GetInt("PlayerSTP");
		((Inventory)this.player.GetComponent(typeof(Inventory))).cash = PlayerPrefs.GetInt("Cash");
		int num = Extensions.get_length(((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot);
		int i = 0;
		if (num > 0)
		{
			while (i < num)
			{
				((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot[i] = PlayerPrefs.GetInt("Item" + i.ToString());
				((Inventory)this.player.GetComponent(typeof(Inventory))).itemQuantity[i] = PlayerPrefs.GetInt("ItemQty" + i.ToString());
				i++;
			}
		}
		int num2 = Extensions.get_length(((Inventory)this.player.GetComponent(typeof(Inventory))).equipment);
		i = 0;
		if (num2 > 0)
		{
			while (i < num2)
			{
				((Inventory)this.player.GetComponent(typeof(Inventory))).equipment[i] = PlayerPrefs.GetInt("Equipm" + i.ToString());
				i++;
			}
		}
		((Inventory)this.player.GetComponent(typeof(Inventory))).weaponEquip = 0;
		((Inventory)this.player.GetComponent(typeof(Inventory))).armorEquip = PlayerPrefs.GetInt("ArmoEquip");
		if (PlayerPrefs.GetInt("WeaEquip") == 0)
		{
			((Inventory)this.player.GetComponent(typeof(Inventory))).RemoveWeaponMesh();
		}
		else
		{
			((Inventory)this.player.GetComponent(typeof(Inventory))).EquipItem(PlayerPrefs.GetInt("WeaEquip"), ((Inventory)this.player.GetComponent(typeof(Inventory))).equipment.Length + 5);
		}
		Screen.lockCursor = true;
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
		((QuestStat)this.player.GetComponent(typeof(QuestStat))).questProgress = new int[PlayerPrefs.GetInt("QuestSize")];
		int num3 = Extensions.get_length(((QuestStat)this.player.GetComponent(typeof(QuestStat))).questProgress);
		i = 0;
		if (num3 > 0)
		{
			while (i < num3)
			{
				((QuestStat)this.player.GetComponent(typeof(QuestStat))).questProgress[i] = PlayerPrefs.GetInt("Questp" + i.ToString());
				i++;
			}
		}
		((QuestStat)this.player.GetComponent(typeof(QuestStat))).questSlot = new int[PlayerPrefs.GetInt("QuestSlotSize")];
		int num4 = Extensions.get_length(((QuestStat)this.player.GetComponent(typeof(QuestStat))).questSlot);
		i = 0;
		if (num4 > 0)
		{
			while (i < num4)
			{
				((QuestStat)this.player.GetComponent(typeof(QuestStat))).questSlot[i] = PlayerPrefs.GetInt("Questslot" + i.ToString());
				i++;
			}
		}
		for (i = 0; i <= 2; i++)
		{
			((SkillWindow)this.player.GetComponent(typeof(SkillWindow))).skill[i] = PlayerPrefs.GetInt("Skill" + i.ToString());
		}
		((SkillWindow)this.player.GetComponent(typeof(SkillWindow))).AssignAllSkill();
		MonoBehaviour.print("Loaded");
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x00019E14 File Offset: 0x00018014
	public virtual void Main()
	{
	}

	// Token: 0x0400032C RID: 812
	private GameObject player;

	// Token: 0x0400032D RID: 813
	public Texture2D tip;

	// Token: 0x0400032E RID: 814
	public float duration;

	// Token: 0x0400032F RID: 815
	private bool show;
}
