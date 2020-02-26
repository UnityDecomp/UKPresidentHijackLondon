using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x0200004D RID: 77
[Serializable]
public class GameOver : MonoBehaviour
{
	// Token: 0x060000ED RID: 237 RVA: 0x0000ACC4 File Offset: 0x00008EC4
	public GameOver()
	{
		this.delay = 3f;
	}

	// Token: 0x060000EE RID: 238 RVA: 0x0000ACD8 File Offset: 0x00008ED8
	public virtual IEnumerator Start()
	{
		return new GameOver.$Start$182(this).GetEnumerator();
	}

	// Token: 0x060000EF RID: 239 RVA: 0x0000ACE8 File Offset: 0x00008EE8
	public virtual void OnGUI()
	{
		if (this.menu)
		{
			GUI.Box(new Rect((float)(Screen.width / 2 - 100), (float)(Screen.height / 2 - 120), (float)200, (float)160), "Game Over");
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 80), (float)(Screen.height / 2 - 80), (float)160, (float)40), "Retry"))
			{
				this.LoadData();
			}
			if (GUI.Button(new Rect((float)(Screen.width / 2 - 80), (float)(Screen.height / 2 - 20), (float)160, (float)40), "Quit Game"))
			{
				this.mainCam = GameObject.FindWithTag("MainCamera").transform;
				UnityEngine.Object.Destroy(this.mainCam.gameObject);
				Application.LoadLevel("Title");
			}
		}
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x0000ADCC File Offset: 0x00008FCC
	public virtual void LoadData()
	{
		this.oldPlayer = GameObject.FindWithTag("Player");
		if (this.oldPlayer)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
		else
		{
			this.lastPosition.x = PlayerPrefs.GetFloat("PlayerX");
			this.lastPosition.y = PlayerPrefs.GetFloat("PlayerY") + 0.2f;
			this.lastPosition.z = PlayerPrefs.GetFloat("PlayerZ");
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.player, this.lastPosition, this.transform.rotation);
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
			this.mainCam = GameObject.FindWithTag("MainCamera").transform;
			((ARPGcamera)this.mainCam.GetComponent(typeof(ARPGcamera))).target = gameObject.transform;
			((Inventory)gameObject.GetComponent(typeof(Inventory))).cash = PlayerPrefs.GetInt("TempCash");
			int num = Extensions.get_length(((Inventory)this.player.GetComponent(typeof(Inventory))).itemSlot);
			int i = 0;
			if (num > 0)
			{
				while (i < num)
				{
					((Inventory)gameObject.GetComponent(typeof(Inventory))).itemSlot[i] = PlayerPrefs.GetInt("TempItem" + i.ToString());
					((Inventory)gameObject.GetComponent(typeof(Inventory))).itemQuantity[i] = PlayerPrefs.GetInt("TempItemQty" + i.ToString());
					i++;
				}
			}
			int num2 = Extensions.get_length(((Inventory)this.player.GetComponent(typeof(Inventory))).equipment);
			i = 0;
			if (num2 > 0)
			{
				while (i < num2)
				{
					((Inventory)gameObject.GetComponent(typeof(Inventory))).equipment[i] = PlayerPrefs.GetInt("TempEquipm" + i.ToString());
					i++;
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
			GameObject gameObject2 = GameObject.FindWithTag("Minimap");
			if (gameObject2)
			{
				GameObject minimapCam = ((MinimapOnOff)gameObject2.GetComponent(typeof(MinimapOnOff))).minimapCam;
				((MinimapCamera)minimapCam.GetComponent(typeof(MinimapCamera))).target = gameObject.transform;
			}
			((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questProgress = new int[PlayerPrefs.GetInt("TempQuestSize")];
			int num3 = Extensions.get_length(((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questProgress);
			i = 0;
			if (num3 > 0)
			{
				while (i < num3)
				{
					((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questProgress[i] = PlayerPrefs.GetInt("TempQuestp" + i.ToString());
					i++;
				}
			}
			((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questSlot = new int[PlayerPrefs.GetInt("TempQuestSlotSize")];
			int num4 = Extensions.get_length(((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questSlot);
			i = 0;
			if (num4 > 0)
			{
				while (i < num4)
				{
					((QuestStat)gameObject.GetComponent(typeof(QuestStat))).questSlot[i] = PlayerPrefs.GetInt("TempQuestslot" + i.ToString());
					i++;
				}
			}
			for (i = 0; i <= 2; i++)
			{
				((SkillWindow)gameObject.GetComponent(typeof(SkillWindow))).skill[i] = PlayerPrefs.GetInt("TempSkill" + i.ToString());
			}
			for (i = 0; i < Extensions.get_length(((SkillWindow)gameObject.GetComponent(typeof(SkillWindow))).skillListSlot); i++)
			{
				((SkillWindow)gameObject.GetComponent(typeof(SkillWindow))).skillListSlot[i] = PlayerPrefs.GetInt("TempSkillList" + i.ToString());
			}
			((SkillWindow)gameObject.GetComponent(typeof(SkillWindow))).AssignAllSkill();
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x0000B564 File Offset: 0x00009764
	public virtual void Main()
	{
	}

	// Token: 0x040001A1 RID: 417
	public float delay;

	// Token: 0x040001A2 RID: 418
	public GameObject player;

	// Token: 0x040001A3 RID: 419
	private bool menu;

	// Token: 0x040001A4 RID: 420
	private Vector3 lastPosition;

	// Token: 0x040001A5 RID: 421
	private Transform mainCam;

	// Token: 0x040001A6 RID: 422
	private GameObject oldPlayer;

	// Token: 0x0200004E RID: 78
	[CompilerGenerated]
	[Serializable]
	internal sealed class $Start$182 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x060000F2 RID: 242 RVA: 0x0000B568 File Offset: 0x00009768
		public $Start$182(GameOver self_)
		{
			this.$self_$184 = self_;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000B578 File Offset: 0x00009778
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new GameOver.$Start$182.$(this.$self_$184);
		}

		// Token: 0x040001A7 RID: 423
		internal GameOver $self_$184;
	}
}
