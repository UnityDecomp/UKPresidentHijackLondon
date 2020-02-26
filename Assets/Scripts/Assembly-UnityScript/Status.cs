using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000090 RID: 144
[Serializable]
public class Status : MonoBehaviour
{
	// Token: 0x060001F4 RID: 500 RVA: 0x00019E3C File Offset: 0x0001803C
	public Status()
	{
		this.characterName = string.Empty;
		this.level = 1;
		this.maxExp = 100;
		this.maxHealth = 100;
		this.health = 100;
		this.maxMana = 100;
		this.mana = 100;
		this.spawnPointName = string.Empty;
		this.elementEffective = new elem[5];
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x00019EA0 File Offset: 0x000180A0
	public virtual string OnDamage(int amount, int element)
	{
		string result;
		if (this.dead)
		{
			result = null;
		}
		else if (this.dodge)
		{
			result = "Evaded";
		}
		else
		{
			amount -= this.def;
			amount -= this.addDef;
			amount -= this.buffDef;
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
				this.enabled = false;
				this.dead = true;
				this.Death();
			}
			result = amount.ToString();
		}
		return result;
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x00019F6C File Offset: 0x0001816C
	public virtual string OnMagicDamage(int amount, int element)
	{
		string result;
		if (this.dead)
		{
			result = null;
		}
		else if (this.dodge)
		{
			result = "Evaded";
		}
		else
		{
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
				this.enabled = false;
				this.dead = true;
				this.Death();
			}
			result = amount.ToString();
		}
		return result;
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x0001A038 File Offset: 0x00018238
	public virtual void Heal(int hp, int mp)
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

	// Token: 0x060001F8 RID: 504 RVA: 0x0001A09C File Offset: 0x0001829C
	public virtual void Death()
	{
		if (this.gameObject.tag == "Player")
		{
			this.SaveData();
		}
		UnityEngine.Object.Destroy(this.gameObject);
		if (this.deathBody)
		{
			UnityEngine.Object.Instantiate<Transform>(this.deathBody, this.transform.position, this.transform.rotation);
		}
		else
		{
			MonoBehaviour.print("This Object didn't assign the Death Body");
		}
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x0001A118 File Offset: 0x00018318
	public virtual void gainEXP(int gain)
	{
		this.exp += gain;
		if (this.exp >= this.maxExp)
		{
			int remainingEXP = this.exp - this.maxExp;
			this.LevelUp(remainingEXP);
		}
	}

	// Token: 0x060001FA RID: 506 RVA: 0x0001A15C File Offset: 0x0001835C
	public virtual void LevelUp(int remainingEXP)
	{
		this.exp = 0;
		this.exp += remainingEXP;
		this.level++;
		this.statusPoint += 5;
		this.maxExp = (int)(1.25f * (float)this.maxExp);
		this.maxHealth += 20;
		this.maxMana += 10;
		this.health = this.maxHealth;
		this.mana = this.maxMana;
		this.gainEXP(0);
		if ((SkillWindow)this.GetComponent(typeof(SkillWindow)))
		{
			((SkillWindow)this.GetComponent(typeof(SkillWindow))).LearnSkillByLevel(this.level);
		}
	}

	// Token: 0x060001FB RID: 507 RVA: 0x0001A22C File Offset: 0x0001842C
	public virtual void SaveData()
	{
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
		PlayerPrefs.SetInt("TempCash", ((Inventory)this.GetComponent(typeof(Inventory))).cash);
		int num = Extensions.get_length(((Inventory)this.GetComponent(typeof(Inventory))).itemSlot);
		int i = 0;
		if (num > 0)
		{
			while (i < num)
			{
				PlayerPrefs.SetInt("TempItem" + i.ToString(), ((Inventory)this.GetComponent(typeof(Inventory))).itemSlot[i]);
				PlayerPrefs.SetInt("TempItemQty" + i.ToString(), ((Inventory)this.GetComponent(typeof(Inventory))).itemQuantity[i]);
				i++;
			}
		}
		int num2 = Extensions.get_length(((Inventory)this.GetComponent(typeof(Inventory))).equipment);
		i = 0;
		if (num2 > 0)
		{
			while (i < num2)
			{
				PlayerPrefs.SetInt("TempEquipm" + i.ToString(), ((Inventory)this.GetComponent(typeof(Inventory))).equipment[i]);
				i++;
			}
		}
		PlayerPrefs.SetInt("TempWeaEquip", ((Inventory)this.GetComponent(typeof(Inventory))).weaponEquip);
		PlayerPrefs.SetInt("TempArmoEquip", ((Inventory)this.GetComponent(typeof(Inventory))).armorEquip);
		int num3 = Extensions.get_length(((QuestStat)this.GetComponent(typeof(QuestStat))).questProgress);
		PlayerPrefs.SetInt("TempQuestSize", num3);
		i = 0;
		if (num3 > 0)
		{
			while (i < num3)
			{
				PlayerPrefs.SetInt("TempQuestp" + i.ToString(), ((QuestStat)this.GetComponent(typeof(QuestStat))).questProgress[i]);
				i++;
			}
		}
		int num4 = Extensions.get_length(((QuestStat)this.GetComponent(typeof(QuestStat))).questSlot);
		PlayerPrefs.SetInt("TempQuestSlotSize", num4);
		i = 0;
		if (num4 > 0)
		{
			while (i < num4)
			{
				PlayerPrefs.SetInt("TempQuestslot" + i.ToString(), ((QuestStat)this.GetComponent(typeof(QuestStat))).questSlot[i]);
				i++;
			}
		}
		for (i = 0; i <= 2; i++)
		{
			PlayerPrefs.SetInt("TempSkill" + i.ToString(), ((SkillWindow)this.GetComponent(typeof(SkillWindow))).skill[i]);
		}
		for (i = 0; i < Extensions.get_length(((SkillWindow)this.GetComponent(typeof(SkillWindow))).skillListSlot); i++)
		{
			PlayerPrefs.SetInt("TempSkillList" + i.ToString(), ((SkillWindow)this.GetComponent(typeof(SkillWindow))).skillListSlot[i]);
		}
		MonoBehaviour.print("Saved");
	}

	// Token: 0x060001FC RID: 508 RVA: 0x0001A610 File Offset: 0x00018810
	public virtual void CalculateStatus()
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

	// Token: 0x060001FD RID: 509 RVA: 0x0001A6E8 File Offset: 0x000188E8
	public virtual IEnumerator OnPoison(int hurtTime)
	{
		return new Status.$OnPoison$222(hurtTime, this).GetEnumerator();
	}

	// Token: 0x060001FE RID: 510 RVA: 0x0001A6F8 File Offset: 0x000188F8
	public virtual IEnumerator OnSilence(float dur)
	{
		return new Status.$OnSilence$231(dur, this).GetEnumerator();
	}

	// Token: 0x060001FF RID: 511 RVA: 0x0001A708 File Offset: 0x00018908
	public virtual IEnumerator OnWebbedUp(float dur)
	{
		return new Status.$OnWebbedUp$239(dur, this).GetEnumerator();
	}

	// Token: 0x06000200 RID: 512 RVA: 0x0001A718 File Offset: 0x00018918
	public virtual IEnumerator OnStun(float dur)
	{
		return new Status.$OnStun$247(dur, this).GetEnumerator();
	}

	// Token: 0x06000201 RID: 513 RVA: 0x0001A728 File Offset: 0x00018928
	public virtual void ApplyAbnormalStat(int statId, float dur)
	{
		if (statId == 0)
		{
			this.StartCoroutine(this.OnPoison(Mathf.FloorToInt(dur)));
		}
		if (statId == 1)
		{
			this.StartCoroutine(this.OnSilence(dur));
		}
		if (statId == 2)
		{
			this.StartCoroutine(this.OnStun(dur));
		}
		if (statId == 3)
		{
			this.StartCoroutine(this.OnWebbedUp(dur));
		}
	}

	// Token: 0x06000202 RID: 514 RVA: 0x0001A790 File Offset: 0x00018990
	public virtual IEnumerator OnBarrier(float amount, float dur)
	{
		return new Status.$OnBarrier$255(amount, dur, this).GetEnumerator();
	}

	// Token: 0x06000203 RID: 515 RVA: 0x0001A7A0 File Offset: 0x000189A0
	public virtual IEnumerator OnMagicBarrier(float amount, float dur)
	{
		return new Status.$OnMagicBarrier$262(amount, dur, this).GetEnumerator();
	}

	// Token: 0x06000204 RID: 516 RVA: 0x0001A7B0 File Offset: 0x000189B0
	public virtual IEnumerator OnBrave(float amount, float dur)
	{
		return new Status.$OnBrave$269(amount, dur, this).GetEnumerator();
	}

	// Token: 0x06000205 RID: 517 RVA: 0x0001A7C0 File Offset: 0x000189C0
	public virtual IEnumerator OnFaith(float amount, float dur)
	{
		return new Status.$OnFaith$276(amount, dur, this).GetEnumerator();
	}

	// Token: 0x06000206 RID: 518 RVA: 0x0001A7D0 File Offset: 0x000189D0
	public virtual void ApplyBuff(int statId, float dur, int amount)
	{
		if (statId == 1)
		{
			this.StartCoroutine(this.OnBarrier((float)amount, dur));
		}
		if (statId == 2)
		{
			this.StartCoroutine(this.OnMagicBarrier((float)amount, dur));
		}
		if (statId == 3)
		{
			this.StartCoroutine(this.OnBrave((float)amount, dur));
		}
		if (statId == 4)
		{
			this.StartCoroutine(this.OnFaith((float)amount, dur));
		}
	}

	// Token: 0x06000207 RID: 519 RVA: 0x0001A83C File Offset: 0x00018A3C
	public virtual void Main()
	{
	}

	// Token: 0x04000336 RID: 822
	public string characterName;

	// Token: 0x04000337 RID: 823
	public int characterId;

	// Token: 0x04000338 RID: 824
	public int level;

	// Token: 0x04000339 RID: 825
	public int atk;

	// Token: 0x0400033A RID: 826
	public int def;

	// Token: 0x0400033B RID: 827
	public int matk;

	// Token: 0x0400033C RID: 828
	public int mdef;

	// Token: 0x0400033D RID: 829
	public int exp;

	// Token: 0x0400033E RID: 830
	public int maxExp;

	// Token: 0x0400033F RID: 831
	public int maxHealth;

	// Token: 0x04000340 RID: 832
	public int health;

	// Token: 0x04000341 RID: 833
	public int maxMana;

	// Token: 0x04000342 RID: 834
	public int mana;

	// Token: 0x04000343 RID: 835
	public int statusPoint;

	// Token: 0x04000344 RID: 836
	private bool dead;

	// Token: 0x04000345 RID: 837
	[HideInInspector]
	public GameObject mainModel;

	// Token: 0x04000346 RID: 838
	[HideInInspector]
	public int addAtk;

	// Token: 0x04000347 RID: 839
	[HideInInspector]
	public int addDef;

	// Token: 0x04000348 RID: 840
	[HideInInspector]
	public int addMatk;

	// Token: 0x04000349 RID: 841
	[HideInInspector]
	public int addMdef;

	// Token: 0x0400034A RID: 842
	[HideInInspector]
	public int addHPpercent;

	// Token: 0x0400034B RID: 843
	[HideInInspector]
	public int addMPpercent;

	// Token: 0x0400034C RID: 844
	public Transform deathBody;

	// Token: 0x0400034D RID: 845
	[HideInInspector]
	public string spawnPointName;

	// Token: 0x0400034E RID: 846
	[HideInInspector]
	public int buffAtk;

	// Token: 0x0400034F RID: 847
	[HideInInspector]
	public int buffDef;

	// Token: 0x04000350 RID: 848
	[HideInInspector]
	public int buffMatk;

	// Token: 0x04000351 RID: 849
	[HideInInspector]
	public int buffMdef;

	// Token: 0x04000352 RID: 850
	[HideInInspector]
	public int weaponAtk;

	// Token: 0x04000353 RID: 851
	[HideInInspector]
	public int weaponMatk;

	// Token: 0x04000354 RID: 852
	[HideInInspector]
	public bool poison;

	// Token: 0x04000355 RID: 853
	[HideInInspector]
	public bool silence;

	// Token: 0x04000356 RID: 854
	[HideInInspector]
	public bool web;

	// Token: 0x04000357 RID: 855
	[HideInInspector]
	public bool stun;

	// Token: 0x04000358 RID: 856
	[HideInInspector]
	public bool freeze;

	// Token: 0x04000359 RID: 857
	[HideInInspector]
	public bool dodge;

	// Token: 0x0400035A RID: 858
	[HideInInspector]
	public bool brave;

	// Token: 0x0400035B RID: 859
	[HideInInspector]
	public bool barrier;

	// Token: 0x0400035C RID: 860
	[HideInInspector]
	public bool mbarrier;

	// Token: 0x0400035D RID: 861
	[HideInInspector]
	public bool faith;

	// Token: 0x0400035E RID: 862
	public GameObject poisonEffect;

	// Token: 0x0400035F RID: 863
	public GameObject silenceEffect;

	// Token: 0x04000360 RID: 864
	public GameObject stunEffect;

	// Token: 0x04000361 RID: 865
	public GameObject webbedUpEffect;

	// Token: 0x04000362 RID: 866
	public AnimationClip stunAnimation;

	// Token: 0x04000363 RID: 867
	public AnimationClip webbedUpAnimation;

	// Token: 0x04000364 RID: 868
	[HideInInspector]
	public bool useMecanim;

	// Token: 0x04000365 RID: 869
	public elem[] elementEffective;

	// Token: 0x04000366 RID: 870
	public resist statusResist;

	// Token: 0x02000091 RID: 145
	[CompilerGenerated]
	[Serializable]
	internal sealed class $OnPoison$222 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000208 RID: 520 RVA: 0x0001A840 File Offset: 0x00018A40
		public $OnPoison$222(int hurtTime, Status self_)
		{
			this.$hurtTime$229 = hurtTime;
			this.$self_$230 = self_;
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0001A858 File Offset: 0x00018A58
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new Status.$OnPoison$222.$(this.$hurtTime$229, this.$self_$230);
		}

		// Token: 0x04000367 RID: 871
		internal int $hurtTime$229;

		// Token: 0x04000368 RID: 872
		internal Status $self_$230;
	}

	// Token: 0x02000093 RID: 147
	[CompilerGenerated]
	[Serializable]
	internal sealed class $OnSilence$231 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x0600020C RID: 524 RVA: 0x0001AA70 File Offset: 0x00018C70
		public $OnSilence$231(float dur, Status self_)
		{
			this.$dur$237 = dur;
			this.$self_$238 = self_;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0001AA88 File Offset: 0x00018C88
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new Status.$OnSilence$231.$(this.$dur$237, this.$self_$238);
		}

		// Token: 0x0400036F RID: 879
		internal float $dur$237;

		// Token: 0x04000370 RID: 880
		internal Status $self_$238;
	}

	// Token: 0x02000095 RID: 149
	[CompilerGenerated]
	[Serializable]
	internal sealed class $OnWebbedUp$239 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000210 RID: 528 RVA: 0x0001AC10 File Offset: 0x00018E10
		public $OnWebbedUp$239(float dur, Status self_)
		{
			this.$dur$245 = dur;
			this.$self_$246 = self_;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0001AC28 File Offset: 0x00018E28
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new Status.$OnWebbedUp$239.$(this.$dur$245, this.$self_$246);
		}

		// Token: 0x04000376 RID: 886
		internal float $dur$245;

		// Token: 0x04000377 RID: 887
		internal Status $self_$246;
	}

	// Token: 0x02000097 RID: 151
	[CompilerGenerated]
	[Serializable]
	internal sealed class $OnStun$247 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000214 RID: 532 RVA: 0x0001AEBC File Offset: 0x000190BC
		public $OnStun$247(float dur, Status self_)
		{
			this.$dur$253 = dur;
			this.$self_$254 = self_;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0001AED4 File Offset: 0x000190D4
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new Status.$OnStun$247.$(this.$dur$253, this.$self_$254);
		}

		// Token: 0x0400037D RID: 893
		internal float $dur$253;

		// Token: 0x0400037E RID: 894
		internal Status $self_$254;
	}

	// Token: 0x02000099 RID: 153
	[CompilerGenerated]
	[Serializable]
	internal sealed class $OnBarrier$255 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000218 RID: 536 RVA: 0x0001B170 File Offset: 0x00019370
		public $OnBarrier$255(float amount, float dur, Status self_)
		{
			this.$amount$259 = amount;
			this.$dur$260 = dur;
			this.$self_$261 = self_;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0001B190 File Offset: 0x00019390
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new Status.$OnBarrier$255.$(this.$amount$259, this.$dur$260, this.$self_$261);
		}

		// Token: 0x04000384 RID: 900
		internal float $amount$259;

		// Token: 0x04000385 RID: 901
		internal float $dur$260;

		// Token: 0x04000386 RID: 902
		internal Status $self_$261;
	}

	// Token: 0x0200009B RID: 155
	[CompilerGenerated]
	[Serializable]
	internal sealed class $OnMagicBarrier$262 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x0600021C RID: 540 RVA: 0x0001B28C File Offset: 0x0001948C
		public $OnMagicBarrier$262(float amount, float dur, Status self_)
		{
			this.$amount$266 = amount;
			this.$dur$267 = dur;
			this.$self_$268 = self_;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0001B2AC File Offset: 0x000194AC
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new Status.$OnMagicBarrier$262.$(this.$amount$266, this.$dur$267, this.$self_$268);
		}

		// Token: 0x0400038A RID: 906
		internal float $amount$266;

		// Token: 0x0400038B RID: 907
		internal float $dur$267;

		// Token: 0x0400038C RID: 908
		internal Status $self_$268;
	}

	// Token: 0x0200009D RID: 157
	[CompilerGenerated]
	[Serializable]
	internal sealed class $OnBrave$269 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000220 RID: 544 RVA: 0x0001B3A8 File Offset: 0x000195A8
		public $OnBrave$269(float amount, float dur, Status self_)
		{
			this.$amount$273 = amount;
			this.$dur$274 = dur;
			this.$self_$275 = self_;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0001B3C8 File Offset: 0x000195C8
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new Status.$OnBrave$269.$(this.$amount$273, this.$dur$274, this.$self_$275);
		}

		// Token: 0x04000390 RID: 912
		internal float $amount$273;

		// Token: 0x04000391 RID: 913
		internal float $dur$274;

		// Token: 0x04000392 RID: 914
		internal Status $self_$275;
	}

	// Token: 0x0200009F RID: 159
	[CompilerGenerated]
	[Serializable]
	internal sealed class $OnFaith$276 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000224 RID: 548 RVA: 0x0001B4C4 File Offset: 0x000196C4
		public $OnFaith$276(float amount, float dur, Status self_)
		{
			this.$amount$280 = amount;
			this.$dur$281 = dur;
			this.$self_$282 = self_;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0001B4E4 File Offset: 0x000196E4
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new Status.$OnFaith$276.$(this.$amount$280, this.$dur$281, this.$self_$282);
		}

		// Token: 0x04000396 RID: 918
		internal float $amount$280;

		// Token: 0x04000397 RID: 919
		internal float $dur$281;

		// Token: 0x04000398 RID: 920
		internal Status $self_$282;
	}
}
