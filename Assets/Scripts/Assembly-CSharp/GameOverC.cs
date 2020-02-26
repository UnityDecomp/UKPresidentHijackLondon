using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000069 RID: 105
public class GameOverC : MonoBehaviour
{
	// Token: 0x06000396 RID: 918 RVA: 0x000134A2 File Offset: 0x000118A2
	private void Start()
	{
		base.StartCoroutine(this.Delay());
	}

	// Token: 0x06000397 RID: 919 RVA: 0x000134B4 File Offset: 0x000118B4
	private IEnumerator Delay()
	{
		yield return new WaitForSeconds(this.delay);
		this.menu = true;
		Screen.lockCursor = false;
		yield break;
	}

	// Token: 0x06000398 RID: 920 RVA: 0x000134CF File Offset: 0x000118CF
	private void OnGUI()
	{
		if (this.menu)
		{
		}
	}

	// Token: 0x06000399 RID: 921 RVA: 0x000134DC File Offset: 0x000118DC
	private void LoadData()
	{
		this.oldPlayer = GameObject.FindWithTag("Player");
		if (this.oldPlayer)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			this.lastPosition.x = PlayerPrefs.GetFloat("PlayerX");
			this.lastPosition.y = PlayerPrefs.GetFloat("PlayerY") + 0.2f;
			this.lastPosition.z = PlayerPrefs.GetFloat("PlayerZ");
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.player, this.lastPosition, base.transform.rotation);
			gameObject.GetComponent<StatusC>().level = PlayerPrefs.GetInt("TempPlayerLevel");
			gameObject.GetComponent<StatusC>().characterId = PlayerPrefs.GetInt("TempID");
			gameObject.GetComponent<StatusC>().characterName = PlayerPrefs.GetString("TempName");
			gameObject.GetComponent<StatusC>().atk = PlayerPrefs.GetInt("TempPlayerATK");
			gameObject.GetComponent<StatusC>().def = PlayerPrefs.GetInt("TempPlayerDEF");
			gameObject.GetComponent<StatusC>().matk = PlayerPrefs.GetInt("TempPlayerMATK");
			gameObject.GetComponent<StatusC>().mdef = PlayerPrefs.GetInt("TempPlayerMDEF");
			gameObject.GetComponent<StatusC>().mdef = PlayerPrefs.GetInt("TempPlayerMDEF");
			gameObject.GetComponent<StatusC>().exp = PlayerPrefs.GetInt("TempPlayerEXP");
			gameObject.GetComponent<StatusC>().maxExp = PlayerPrefs.GetInt("TempPlayerMaxEXP");
			gameObject.GetComponent<StatusC>().maxHealth = PlayerPrefs.GetInt("TempPlayerMaxHP");
			gameObject.GetComponent<StatusC>().health = PlayerPrefs.GetInt("TempPlayerMaxHP");
			gameObject.GetComponent<StatusC>().maxMana = PlayerPrefs.GetInt("TempPlayerMaxMP");
			gameObject.GetComponent<StatusC>().mana = PlayerPrefs.GetInt("TempPlayerMaxMP");
			gameObject.GetComponent<StatusC>().statusPoint = PlayerPrefs.GetInt("TempPlayerSTP");
			this.mainCam = GameObject.FindWithTag("MainCamera").transform;
			gameObject.GetComponent<InventoryC>().cash = PlayerPrefs.GetInt("TempCash");
			int num = this.player.GetComponent<InventoryC>().itemSlot.Length;
			int i = 0;
			if (num > 0)
			{
				while (i < num)
				{
					gameObject.GetComponent<InventoryC>().itemSlot[i] = PlayerPrefs.GetInt("TempItem" + i.ToString());
					gameObject.GetComponent<InventoryC>().itemQuantity[i] = PlayerPrefs.GetInt("TempItemQty" + i.ToString());
					i++;
				}
			}
			int num2 = this.player.GetComponent<InventoryC>().equipment.Length;
			i = 0;
			if (num2 > 0)
			{
				while (i < num2)
				{
					gameObject.GetComponent<InventoryC>().equipment[i] = PlayerPrefs.GetInt("TempEquipm" + i.ToString());
					i++;
				}
			}
			gameObject.GetComponent<InventoryC>().weaponEquip = 0;
			gameObject.GetComponent<InventoryC>().armorEquip = PlayerPrefs.GetInt("TempArmoEquip");
			if (PlayerPrefs.GetInt("TempWeaEquip") == 0)
			{
				gameObject.GetComponent<InventoryC>().RemoveWeaponMesh();
			}
			else
			{
				gameObject.GetComponent<InventoryC>().EquipItem(PlayerPrefs.GetInt("TempWeaEquip"), gameObject.GetComponent<InventoryC>().equipment.Length + 5);
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
			GameObject gameObject3 = GameObject.FindWithTag("Minimap");
			if (gameObject3)
			{
				GameObject minimapCam = gameObject3.GetComponent<MinimapOnOffC>().minimapCam;
				minimapCam.GetComponent<MinimapCameraC>().target = gameObject.transform;
			}
			gameObject.GetComponent<QuestStatC>().questProgress = new int[PlayerPrefs.GetInt("TempQuestSize")];
			int num3 = gameObject.GetComponent<QuestStatC>().questProgress.Length;
			i = 0;
			if (num3 > 0)
			{
				while (i < num3)
				{
					gameObject.GetComponent<QuestStatC>().questProgress[i] = PlayerPrefs.GetInt("TempQuestp" + i.ToString());
					i++;
				}
			}
			gameObject.GetComponent<QuestStatC>().questSlot = new int[PlayerPrefs.GetInt("TempQuestSlotSize")];
			int num4 = gameObject.GetComponent<QuestStatC>().questSlot.Length;
			i = 0;
			if (num4 > 0)
			{
				while (i < num4)
				{
					gameObject.GetComponent<QuestStatC>().questSlot[i] = PlayerPrefs.GetInt("TempQuestslot" + i.ToString());
					i++;
				}
			}
			for (i = 0; i <= 2; i++)
			{
				gameObject.GetComponent<SkillWindowC>().skill[i] = PlayerPrefs.GetInt("TempSkill" + i.ToString());
			}
			for (i = 0; i < gameObject.GetComponent<SkillWindowC>().skillListSlot.Length; i++)
			{
				gameObject.GetComponent<SkillWindowC>().skillListSlot[i] = PlayerPrefs.GetInt("TempSkillList" + i.ToString());
			}
			gameObject.GetComponent<SkillWindowC>().AssignAllSkill();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040002BA RID: 698
	public float delay = 3f;

	// Token: 0x040002BB RID: 699
	public GameObject player;

	// Token: 0x040002BC RID: 700
	private bool menu;

	// Token: 0x040002BD RID: 701
	private Vector3 lastPosition;

	// Token: 0x040002BE RID: 702
	private Transform mainCam;

	// Token: 0x040002BF RID: 703
	private GameObject oldPlayer;
}
