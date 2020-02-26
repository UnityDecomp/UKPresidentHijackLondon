using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000093 RID: 147
public class StatusC : MonoBehaviour
{
	// Token: 0x06000466 RID: 1126 RVA: 0x00021084 File Offset: 0x0001F484
	public string OnDamage(int amount, int element)
	{
		if (!this.dead)
		{
			if (this.dodge)
			{
				return "Evaded";
			}
			amount -= this.def;
			amount -= this.addDef;
			amount -= this.buffDef;
			amount *= this.elementEffective[element].effective;
			amount /= 100;
			if (base.gameObject.tag == "Player")
			{
				base.GetComponent<NewHealthBarC>().showHurtImage();
			}
			if (amount < 1)
			{
				amount = 1;
			}
			this.health -= amount;
			if (this.health <= 0)
			{
				this.health = 0;
				base.enabled = false;
				this.dead = true;
				this.Death();
			}
		}
		return amount.ToString();
	}

	// Token: 0x06000467 RID: 1127 RVA: 0x00021154 File Offset: 0x0001F554
	private void Start()
	{
		this.questM = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
		if (this.minimapMark)
		{
			this.minimapMark.gameObject.SetActive(true);
		}
		if (!this.minimapMark && base.transform.gameObject.tag == "Enemy")
		{
			this.assignMarks();
		}
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x000211D8 File Offset: 0x0001F5D8
	public string OnMagicDamage(int amount, int element)
	{
		if (!this.dead)
		{
			if (this.dodge)
			{
				return "Evaded";
			}
			amount -= this.mdef;
			amount -= this.addMdef;
			amount -= this.buffMdef;
			amount *= this.elementEffective[element].effective;
			amount /= 100;
			if (amount < 1)
			{
				amount = 1;
			}
			this.health -= amount;
			if (this.health <= 0)
			{
				this.health = 0;
				base.enabled = false;
				this.dead = true;
				this.Death();
			}
		}
		return amount.ToString();
	}

	// Token: 0x06000469 RID: 1129 RVA: 0x00021284 File Offset: 0x0001F684
	public void Heal(int hp, int mp)
	{
		this.health += hp;
		if (this.health >= this.maxHealth)
		{
			this.health = this.maxHealth;
		}
		this.mana += mp;
		if (this.mana >= this.maxMana)
		{
			this.mana = this.maxMana;
		}
	}

	// Token: 0x0600046A RID: 1130 RVA: 0x000212E7 File Offset: 0x0001F6E7
	public void FuriousKill(GameObject prey, GameObject deathModel)
	{
		this.questM = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
		this.questM.targetKilled(prey.name.ToLower());
		UnityEngine.Object.Destroy(prey);
	}

	// Token: 0x0600046B RID: 1131 RVA: 0x00021320 File Offset: 0x0001F720
	private void assignMarks()
	{
		string b = string.Empty;
		GameObject[] array = null;
		b = base.transform.gameObject.name + "Mark";
		try
		{
			array = GameObject.FindGameObjectsWithTag("Mark");
		}
		catch (UnityException message)
		{
			MonoBehaviour.print(message);
		}
		foreach (GameObject gameObject in array)
		{
			if (gameObject.name == b && gameObject.GetComponent<MinimapMark>().target == null)
			{
				gameObject.GetComponent<MinimapMark>().target = base.transform.gameObject;
			}
		}
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x000213DC File Offset: 0x0001F7DC
	public void Death()
	{
		if (base.gameObject.tag == "Player")
		{
			this.questM.GameOver();
		}
		if (base.gameObject.name != "Player")
		{
			this.questM = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
			this.questM.targetKilled(base.gameObject.name);
		}
		UnityEngine.Object.Destroy(base.gameObject);
		if (this.deathBody)
		{
			UnityEngine.Object.Instantiate<Transform>(this.deathBody, base.transform.position, base.transform.rotation);
		}
		else
		{
			MonoBehaviour.print("This Object didn't assign the Death Body");
		}
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x000214A4 File Offset: 0x0001F8A4
	public void Death(string deathReason)
	{
		if (base.gameObject.tag == "Player")
		{
			this.questM.GameOver(deathReason);
		}
		UnityEngine.Object.Destroy(base.gameObject);
		if (this.deathBody)
		{
			UnityEngine.Object.Instantiate<Transform>(this.deathBody, new Vector3(base.transform.position.x, base.transform.position.y + 0.7f, base.transform.position.z), base.transform.rotation);
		}
		else
		{
			MonoBehaviour.print("This Object didn't assign the Death Body");
		}
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x0002155C File Offset: 0x0001F95C
	public void gainEXP(int gain)
	{
		this.exp += gain;
		if (this.exp >= this.maxExp)
		{
			int remainingEXP = this.exp - this.maxExp;
			this.LevelUp(remainingEXP);
		}
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x000215A0 File Offset: 0x0001F9A0
	public void LevelUp(int remainingEXP)
	{
		this.exp = 0;
		this.exp += remainingEXP;
		this.level++;
		this.statusPoint += 5;
		this.maxExp = 125 * this.maxExp / 100;
		this.maxHealth += 20;
		this.maxMana += 10;
		this.health = this.maxHealth;
		this.mana = this.maxMana;
		this.gainEXP(0);
		if (base.GetComponent<SkillWindowC>())
		{
			base.GetComponent<SkillWindowC>().LearnSkillByLevel(this.level);
		}
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x00021650 File Offset: 0x0001FA50
	private void SaveData()
	{
		PlayerPrefs.SetInt("PreviousSave", 10);
		PlayerPrefs.SetInt("Quest", this.questM.getQuestID());
		PlayerPrefs.SetString("TempName", this.characterName);
		PlayerPrefs.SetInt("TempID", this.characterId);
		PlayerPrefs.SetInt("TempPlayerLevel", this.level);
		PlayerPrefs.SetInt("TempPlayerATK", this.atk);
		PlayerPrefs.SetInt("TempPlayerDEF", this.def);
		PlayerPrefs.SetInt("TempPlayerMATK", this.matk);
		PlayerPrefs.SetInt("TempPlayerMDEF", this.mdef);
		PlayerPrefs.SetInt("TempPlayerEXP", this.exp);
		PlayerPrefs.SetInt("TempPlayerMaxEXP", this.maxExp);
		PlayerPrefs.SetInt("TempPlayerMaxHP", this.maxHealth);
		PlayerPrefs.SetInt("TempPlayerMaxMP", this.maxMana);
		PlayerPrefs.SetInt("TempPlayerSTP", this.statusPoint);
		PlayerPrefs.SetInt("TempCash", base.GetComponent<InventoryC>().cash);
		int num = base.GetComponent<InventoryC>().itemSlot.Length;
		int i = 0;
		if (num > 0)
		{
			while (i < num)
			{
				PlayerPrefs.SetInt("TempItem" + i.ToString(), base.GetComponent<InventoryC>().itemSlot[i]);
				PlayerPrefs.SetInt("TempItemQty" + i.ToString(), base.GetComponent<InventoryC>().itemQuantity[i]);
				i++;
			}
		}
		int num2 = base.GetComponent<InventoryC>().equipment.Length;
		i = 0;
		if (num2 > 0)
		{
			while (i < num2)
			{
				PlayerPrefs.SetInt("TempEquipm" + i.ToString(), base.GetComponent<InventoryC>().equipment[i]);
				i++;
			}
		}
		PlayerPrefs.SetInt("TempWeaEquip", base.GetComponent<InventoryC>().weaponEquip);
		PlayerPrefs.SetInt("TempArmoEquip", base.GetComponent<InventoryC>().armorEquip);
		int num3 = base.GetComponent<QuestStatC>().questProgress.Length;
		PlayerPrefs.SetInt("TempQuestSize", num3);
		i = 0;
		if (num3 > 0)
		{
			while (i < num3)
			{
				PlayerPrefs.SetInt("TempQuestp" + i.ToString(), base.GetComponent<QuestStatC>().questProgress[i]);
				i++;
			}
		}
		int num4 = base.GetComponent<QuestStatC>().questSlot.Length;
		PlayerPrefs.SetInt("TempQuestSlotSize", num4);
		i = 0;
		if (num4 > 0)
		{
			while (i < num4)
			{
				PlayerPrefs.SetInt("TempQuestslot" + i.ToString(), base.GetComponent<QuestStatC>().questSlot[i]);
				i++;
			}
		}
		for (i = 0; i <= 2; i++)
		{
			PlayerPrefs.SetInt("TempSkill" + i.ToString(), base.GetComponent<SkillWindowC>().skill[i]);
		}
		for (i = 0; i < base.GetComponent<SkillWindowC>().skillListSlot.Length; i++)
		{
			PlayerPrefs.SetInt("TempSkillList" + i.ToString(), base.GetComponent<SkillWindowC>().skillListSlot[i]);
		}
		MonoBehaviour.print("Saved");
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x0002198C File Offset: 0x0001FD8C
	public void CalculateStatus()
	{
		this.addAtk = 0;
		this.addAtk += this.atk + this.buffAtk + this.weaponAtk;
		this.addMatk = 0;
		this.addMatk += this.matk + this.buffMatk + this.weaponMatk;
		int num = this.maxHealth * this.addHPpercent / 100;
		int num2 = this.maxMana * this.addMPpercent / 100;
		this.maxHealth += num;
		this.maxMana += num2;
		if (this.health >= this.maxHealth)
		{
			this.health = this.maxHealth;
		}
		if (this.mana >= this.maxMana)
		{
			this.mana = this.maxMana;
		}
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x00021A64 File Offset: 0x0001FE64
	public IEnumerator OnPoison(int hurtTime)
	{
		int amount = 0;
		GameObject eff = new GameObject();
		UnityEngine.Object.Destroy(eff.gameObject);
		if (!this.poison)
		{
			int chance = 100;
			chance -= this.statusResist.poisonResist;
			if (chance > 0)
			{
				int num = UnityEngine.Random.Range(0, 100);
				if (num <= chance)
				{
					this.poison = true;
					amount = this.maxHealth * 2 / 100;
				}
			}
			while (this.poison && hurtTime > 0)
			{
				if (this.poisonEffect)
				{
					eff = UnityEngine.Object.Instantiate<GameObject>(this.poisonEffect, base.transform.position, this.poisonEffect.transform.rotation);
					eff.transform.parent = base.transform;
				}
				yield return new WaitForSeconds(0.7f);
				this.health -= amount;
				if (this.health <= 1)
				{
					this.health = 1;
				}
				if (eff)
				{
					UnityEngine.Object.Destroy(eff.gameObject);
				}
				hurtTime--;
				if (hurtTime <= 0)
				{
					this.poison = false;
				}
			}
		}
		yield break;
	}

	// Token: 0x06000473 RID: 1139 RVA: 0x00021A88 File Offset: 0x0001FE88
	public IEnumerator OnSilence(float dur)
	{
		GameObject eff = new GameObject();
		UnityEngine.Object.Destroy(eff.gameObject);
		if (!this.silence)
		{
			int chance = 100;
			chance -= this.statusResist.silenceResist;
			if (chance > 0)
			{
				int per = UnityEngine.Random.Range(0, 100);
				if (per <= chance)
				{
					this.silence = true;
					if (this.silenceEffect)
					{
						eff = UnityEngine.Object.Instantiate<GameObject>(this.silenceEffect, base.transform.position, base.transform.rotation);
						eff.transform.parent = base.transform;
					}
					yield return new WaitForSeconds(dur);
					if (eff)
					{
						UnityEngine.Object.Destroy(eff.gameObject);
					}
					this.silence = false;
				}
			}
		}
		yield break;
	}

	// Token: 0x06000474 RID: 1140 RVA: 0x00021AAC File Offset: 0x0001FEAC
	public IEnumerator OnWebbedUp(float dur)
	{
		GameObject eff = new GameObject();
		UnityEngine.Object.Destroy(eff.gameObject);
		if (!this.web)
		{
			int chance = 100;
			chance -= this.statusResist.webResist;
			if (chance > 0)
			{
				int per = UnityEngine.Random.Range(0, 100);
				if (per <= chance)
				{
					this.web = true;
					this.freeze = true;
					if (this.webbedUpEffect)
					{
						eff = UnityEngine.Object.Instantiate<GameObject>(this.webbedUpEffect, base.transform.position, base.transform.rotation);
						eff.transform.parent = base.transform;
					}
					if (this.webbedUpAnimation)
					{
						if (this.useMecanim)
						{
							base.GetComponent<PlayerMecanimAnimationC>().PlayAnim(this.webbedUpAnimation.name);
						}
						else
						{
							this.mainModel.GetComponent<Animation>()[this.webbedUpAnimation.name].layer = 25;
							this.mainModel.GetComponent<Animation>().Play(this.webbedUpAnimation.name);
						}
					}
					yield return new WaitForSeconds(dur);
					if (eff)
					{
						UnityEngine.Object.Destroy(eff.gameObject);
					}
					if (this.webbedUpAnimation && !this.useMecanim)
					{
						this.mainModel.GetComponent<Animation>().Stop(this.webbedUpAnimation.name);
					}
					this.freeze = false;
					this.web = false;
				}
			}
		}
		yield break;
	}

	// Token: 0x06000475 RID: 1141 RVA: 0x00021AD0 File Offset: 0x0001FED0
	public IEnumerator OnStun(float dur)
	{
		GameObject eff = new GameObject();
		UnityEngine.Object.Destroy(eff.gameObject);
		if (!this.stun)
		{
			int chance = 100;
			chance -= this.statusResist.stunResist;
			if (chance > 0)
			{
				int per = UnityEngine.Random.Range(0, 100);
				if (per <= chance)
				{
					this.stun = true;
					this.freeze = true;
					if (this.stunEffect)
					{
						eff = UnityEngine.Object.Instantiate<GameObject>(this.stunEffect, base.transform.position, this.stunEffect.transform.rotation);
						eff.transform.parent = base.transform;
					}
					if (this.stunAnimation)
					{
						if (this.useMecanim)
						{
							base.GetComponent<PlayerMecanimAnimationC>().PlayAnim(this.stunAnimation.name);
						}
						else
						{
							this.mainModel.GetComponent<Animation>()[this.stunAnimation.name].layer = 25;
							this.mainModel.GetComponent<Animation>().Play(this.stunAnimation.name);
						}
					}
					yield return new WaitForSeconds(dur);
					if (eff)
					{
						UnityEngine.Object.Destroy(eff.gameObject);
					}
					if (this.stunAnimation && !this.useMecanim)
					{
						this.mainModel.GetComponent<Animation>().Stop(this.stunAnimation.name);
					}
					this.freeze = false;
					this.stun = false;
				}
			}
		}
		yield break;
	}

	// Token: 0x06000476 RID: 1142 RVA: 0x00021AF4 File Offset: 0x0001FEF4
	public void ApplyAbnormalStat(int statId, float dur)
	{
		if (statId == 0)
		{
			this.OnPoison(Mathf.FloorToInt(dur));
			base.StartCoroutine(this.OnPoison(Mathf.FloorToInt(dur)));
		}
		if (statId == 1)
		{
			base.StartCoroutine(this.OnSilence(dur));
		}
		if (statId == 2)
		{
			base.StartCoroutine(this.OnStun(dur));
		}
		if (statId == 3)
		{
			base.StartCoroutine(this.OnWebbedUp(dur));
		}
	}

	// Token: 0x06000477 RID: 1143 RVA: 0x00021B68 File Offset: 0x0001FF68
	public IEnumerator OnBarrier(int amount, float dur)
	{
		if (!this.barrier)
		{
			this.barrier = true;
			this.buffDef = 0;
			this.buffDef += amount;
			this.CalculateStatus();
			yield return new WaitForSeconds(dur);
			this.buffDef = 0;
			this.barrier = false;
			this.CalculateStatus();
		}
		yield break;
	}

	// Token: 0x06000478 RID: 1144 RVA: 0x00021B94 File Offset: 0x0001FF94
	public IEnumerator OnMagicBarrier(int amount, float dur)
	{
		if (!this.mbarrier)
		{
			this.mbarrier = true;
			this.buffMdef = 0;
			this.buffMdef += amount;
			this.CalculateStatus();
			yield return new WaitForSeconds(dur);
			this.buffMdef = 0;
			this.mbarrier = false;
			this.CalculateStatus();
		}
		yield break;
	}

	// Token: 0x06000479 RID: 1145 RVA: 0x00021BC0 File Offset: 0x0001FFC0
	public IEnumerator OnBrave(int amount, float dur)
	{
		if (!this.brave)
		{
			this.brave = true;
			this.buffAtk = 0;
			this.buffAtk += amount;
			this.CalculateStatus();
			yield return new WaitForSeconds(dur);
			this.buffAtk = 0;
			this.brave = false;
			this.CalculateStatus();
		}
		yield break;
	}

	// Token: 0x0600047A RID: 1146 RVA: 0x00021BEC File Offset: 0x0001FFEC
	public IEnumerator OnFaith(int amount, float dur)
	{
		if (!this.faith)
		{
			this.faith = true;
			this.buffMatk = 0;
			this.buffMatk += amount;
			this.CalculateStatus();
			yield return new WaitForSeconds(dur);
			this.buffMatk = 0;
			this.faith = false;
			this.CalculateStatus();
		}
		yield break;
	}

	// Token: 0x0600047B RID: 1147 RVA: 0x00021C18 File Offset: 0x00020018
	public void ApplyBuff(int statId, float dur, int amount)
	{
		if (statId == 1)
		{
			base.StartCoroutine(this.OnBarrier(amount, dur));
		}
		if (statId == 2)
		{
			base.StartCoroutine(this.OnMagicBarrier(amount, dur));
		}
		if (statId == 3)
		{
			base.StartCoroutine(this.OnBrave(amount, dur));
		}
		if (statId == 4)
		{
			base.StartCoroutine(this.OnFaith(amount, dur));
		}
	}

	// Token: 0x04000447 RID: 1095
	public string characterName = string.Empty;

	// Token: 0x04000448 RID: 1096
	[HideInInspector]
	public GameObject questProgress;

	// Token: 0x04000449 RID: 1097
	public int characterId;

	// Token: 0x0400044A RID: 1098
	public int level = 1;

	// Token: 0x0400044B RID: 1099
	public int atk;

	// Token: 0x0400044C RID: 1100
	public int def;

	// Token: 0x0400044D RID: 1101
	public int matk;

	// Token: 0x0400044E RID: 1102
	public int mdef;

	// Token: 0x0400044F RID: 1103
	public int exp;

	// Token: 0x04000450 RID: 1104
	public int maxExp = 100;

	// Token: 0x04000451 RID: 1105
	public int maxHealth = 100;

	// Token: 0x04000452 RID: 1106
	public int health = 100;

	// Token: 0x04000453 RID: 1107
	public int maxMana = 100;

	// Token: 0x04000454 RID: 1108
	public int mana = 100;

	// Token: 0x04000455 RID: 1109
	public int statusPoint;

	// Token: 0x04000456 RID: 1110
	public GameObject minimapMark;

	// Token: 0x04000457 RID: 1111
	private bool dead;

	// Token: 0x04000458 RID: 1112
	[HideInInspector]
	public GameObject mainModel;

	// Token: 0x04000459 RID: 1113
	[HideInInspector]
	public int addAtk;

	// Token: 0x0400045A RID: 1114
	[HideInInspector]
	public int addDef;

	// Token: 0x0400045B RID: 1115
	[HideInInspector]
	public int addMatk;

	// Token: 0x0400045C RID: 1116
	[HideInInspector]
	public int addMdef;

	// Token: 0x0400045D RID: 1117
	[HideInInspector]
	public int addHPpercent;

	// Token: 0x0400045E RID: 1118
	[HideInInspector]
	public int addMPpercent;

	// Token: 0x0400045F RID: 1119
	public Transform deathBody;

	// Token: 0x04000460 RID: 1120
	[HideInInspector]
	public QuestManager questM;

	// Token: 0x04000461 RID: 1121
	[HideInInspector]
	public string spawnPointName = "PlayerRespawn";

	// Token: 0x04000462 RID: 1122
	[HideInInspector]
	public int buffAtk;

	// Token: 0x04000463 RID: 1123
	[HideInInspector]
	public int buffDef;

	// Token: 0x04000464 RID: 1124
	[HideInInspector]
	public int buffMatk;

	// Token: 0x04000465 RID: 1125
	[HideInInspector]
	public int buffMdef;

	// Token: 0x04000466 RID: 1126
	[HideInInspector]
	public int weaponAtk;

	// Token: 0x04000467 RID: 1127
	[HideInInspector]
	public int weaponMatk;

	// Token: 0x04000468 RID: 1128
	[HideInInspector]
	public bool poison;

	// Token: 0x04000469 RID: 1129
	[HideInInspector]
	public bool silence;

	// Token: 0x0400046A RID: 1130
	[HideInInspector]
	public bool web;

	// Token: 0x0400046B RID: 1131
	[HideInInspector]
	public bool stun;

	// Token: 0x0400046C RID: 1132
	[HideInInspector]
	public bool freeze;

	// Token: 0x0400046D RID: 1133
	[HideInInspector]
	public bool dodge;

	// Token: 0x0400046E RID: 1134
	[HideInInspector]
	public bool brave;

	// Token: 0x0400046F RID: 1135
	[HideInInspector]
	public bool barrier;

	// Token: 0x04000470 RID: 1136
	[HideInInspector]
	public bool mbarrier;

	// Token: 0x04000471 RID: 1137
	[HideInInspector]
	public bool faith;

	// Token: 0x04000472 RID: 1138
	public GameObject poisonEffect;

	// Token: 0x04000473 RID: 1139
	public GameObject silenceEffect;

	// Token: 0x04000474 RID: 1140
	public GameObject stunEffect;

	// Token: 0x04000475 RID: 1141
	public GameObject webbedUpEffect;

	// Token: 0x04000476 RID: 1142
	public AnimationClip stunAnimation;

	// Token: 0x04000477 RID: 1143
	public AnimationClip webbedUpAnimation;

	// Token: 0x04000478 RID: 1144
	public StatusC.elem[] elementEffective = new StatusC.elem[5];

	// Token: 0x04000479 RID: 1145
	public StatusC.resist statusResist;

	// Token: 0x0400047A RID: 1146
	[HideInInspector]
	public bool useMecanim;

	// Token: 0x02000094 RID: 148
	[Serializable]
	public class elem
	{
		// Token: 0x0400047B RID: 1147
		public string elementName = string.Empty;

		// Token: 0x0400047C RID: 1148
		public int effective = 100;
	}

	// Token: 0x02000095 RID: 149
	[Serializable]
	public class resist
	{
		// Token: 0x0400047D RID: 1149
		public int poisonResist;

		// Token: 0x0400047E RID: 1150
		public int silenceResist;

		// Token: 0x0400047F RID: 1151
		public int webResist;

		// Token: 0x04000480 RID: 1152
		public int stunResist;
	}
}
