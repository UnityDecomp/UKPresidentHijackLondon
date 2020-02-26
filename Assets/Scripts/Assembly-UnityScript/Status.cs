
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


[Serializable]
public class Status : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OnPoison_0024222 : GenericGenerator<WaitForSeconds>
	{
		internal int _0024hurtTime_0024229;

		internal Status _0024self__0024230;

		public _0024OnPoison_0024222(int hurtTime, Status self_)
		{
			_0024hurtTime_0024229 = hurtTime;
			_0024self__0024230 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024OnPoison_0024222(_0024hurtTime_0024229, _0024self__0024230);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OnSilence_0024231 : GenericGenerator<WaitForSeconds>
	{
		internal float _0024dur_0024237;

		internal Status _0024self__0024238;

		public _0024OnSilence_0024231(float dur, Status self_)
		{
			_0024dur_0024237 = dur;
			_0024self__0024238 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024OnSilence_0024231(_0024dur_0024237, _0024self__0024238);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OnWebbedUp_0024239 : GenericGenerator<WaitForSeconds>
	{
		internal float _0024dur_0024245;

		internal Status _0024self__0024246;

		public _0024OnWebbedUp_0024239(float dur, Status self_)
		{
			_0024dur_0024245 = dur;
			_0024self__0024246 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024OnWebbedUp_0024239(_0024dur_0024245, _0024self__0024246);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OnStun_0024247 : GenericGenerator<WaitForSeconds>
	{
		internal float _0024dur_0024253;

		internal Status _0024self__0024254;

		public _0024OnStun_0024247(float dur, Status self_)
		{
			_0024dur_0024253 = dur;
			_0024self__0024254 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024OnStun_0024247(_0024dur_0024253, _0024self__0024254);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OnBarrier_0024255 : GenericGenerator<WaitForSeconds>
	{
		internal float _0024amount_0024259;

		internal float _0024dur_0024260;

		internal Status _0024self__0024261;

		public _0024OnBarrier_0024255(float amount, float dur, Status self_)
		{
			_0024amount_0024259 = amount;
			_0024dur_0024260 = dur;
			_0024self__0024261 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024OnBarrier_0024255(_0024amount_0024259, _0024dur_0024260, _0024self__0024261);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OnMagicBarrier_0024262 : GenericGenerator<WaitForSeconds>
	{
		internal float _0024amount_0024266;

		internal float _0024dur_0024267;

		internal Status _0024self__0024268;

		public _0024OnMagicBarrier_0024262(float amount, float dur, Status self_)
		{
			_0024amount_0024266 = amount;
			_0024dur_0024267 = dur;
			_0024self__0024268 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024OnMagicBarrier_0024262(_0024amount_0024266, _0024dur_0024267, _0024self__0024268);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OnBrave_0024269 : GenericGenerator<WaitForSeconds>
	{
		internal float _0024amount_0024273;

		internal float _0024dur_0024274;

		internal Status _0024self__0024275;

		public _0024OnBrave_0024269(float amount, float dur, Status self_)
		{
			_0024amount_0024273 = amount;
			_0024dur_0024274 = dur;
			_0024self__0024275 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024OnBrave_0024269(_0024amount_0024273, _0024dur_0024274, _0024self__0024275);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OnFaith_0024276 : GenericGenerator<WaitForSeconds>
	{
		internal float _0024amount_0024280;

		internal float _0024dur_0024281;

		internal Status _0024self__0024282;

		public _0024OnFaith_0024276(float amount, float dur, Status self_)
		{
			_0024amount_0024280 = amount;
			_0024dur_0024281 = dur;
			_0024self__0024282 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024OnFaith_0024276(_0024amount_0024280, _0024dur_0024281, _0024self__0024282);
		}
	}

	public string characterName;

	public int characterId;

	public int level;

	public int atk;

	public int def;

	public int matk;

	public int mdef;

	public int exp;

	public int maxExp;

	public int maxHealth;

	public int health;

	public int maxMana;

	public int mana;

	public int statusPoint;

	private bool dead;

	[HideInInspector]
	public GameObject mainModel;

	[HideInInspector]
	public int addAtk;

	[HideInInspector]
	public int addDef;

	[HideInInspector]
	public int addMatk;

	[HideInInspector]
	public int addMdef;

	[HideInInspector]
	public int addHPpercent;

	[HideInInspector]
	public int addMPpercent;

	public Transform deathBody;

	[HideInInspector]
	public string spawnPointName;

	[HideInInspector]
	public int buffAtk;

	[HideInInspector]
	public int buffDef;

	[HideInInspector]
	public int buffMatk;

	[HideInInspector]
	public int buffMdef;

	[HideInInspector]
	public int weaponAtk;

	[HideInInspector]
	public int weaponMatk;

	[HideInInspector]
	public bool poison;

	[HideInInspector]
	public bool silence;

	[HideInInspector]
	public bool web;

	[HideInInspector]
	public bool stun;

	[HideInInspector]
	public bool freeze;

	[HideInInspector]
	public bool dodge;

	[HideInInspector]
	public bool brave;

	[HideInInspector]
	public bool barrier;

	[HideInInspector]
	public bool mbarrier;

	[HideInInspector]
	public bool faith;

	public GameObject poisonEffect;

	public GameObject silenceEffect;

	public GameObject stunEffect;

	public GameObject webbedUpEffect;

	public AnimationClip stunAnimation;

	public AnimationClip webbedUpAnimation;

	[HideInInspector]
	public bool useMecanim;

	public elem[] elementEffective;

	public resist statusResist;

	public Status()
	{
		characterName = string.Empty;
		level = 1;
		maxExp = 100;
		maxHealth = 100;
		health = 100;
		maxMana = 100;
		mana = 100;
		spawnPointName = string.Empty;
		elementEffective = new elem[5];
	}

	public string OnDamage(int amount, int element)
	{
		object result;
		if (!dead)
		{
			if (dodge)
			{
				result = "Evaded";
			}
			else
			{
				amount -= def;
				amount -= addDef;
				amount -= buffDef;
				amount *= elementEffective[element].effective;
				amount /= 100;
				if (amount < 1)
				{
					amount = 1;
				}
				health -= amount;
				if (health <= 0)
				{
					health = 0;
					enabled = false;
					dead = true;
					Death();
				}
				result = amount.ToString();
			}
		}
		else
		{
			result = null;
		}
		return (string)result;
	}

	public string OnMagicDamage(int amount, int element)
	{
		object result;
		if (!dead)
		{
			if (dodge)
			{
				result = "Evaded";
			}
			else
			{
				amount -= mdef;
				amount -= addMdef;
				amount -= buffMdef;
				amount *= elementEffective[element].effective;
				amount /= 100;
				if (amount < 1)
				{
					amount = 1;
				}
				health -= amount;
				if (health <= 0)
				{
					health = 0;
					enabled = false;
					dead = true;
					Death();
				}
				result = amount.ToString();
			}
		}
		else
		{
			result = null;
		}
		return (string)result;
	}

	public void Heal(int hp, int mp)
	{
		health += hp;
		if (health >= maxHealth)
		{
			health = maxHealth;
		}
		mana += mp;
		if (mana >= maxMana)
		{
			mana = maxMana;
		}
	}

	public void Death()
	{
		if (gameObject.tag == "Player")
		{
			SaveData();
		}
		UnityEngine.Object.Destroy(gameObject);
		if ((bool)deathBody)
		{
			UnityEngine.Object.Instantiate(deathBody, transform.position, transform.rotation);
		}
		else
		{
			MonoBehaviour.print("This Object didn't assign the Death Body");
		}
	}

	public void gainEXP(int gain)
	{
		exp += gain;
		if (exp >= maxExp)
		{
			int remainingEXP = exp - maxExp;
			LevelUp(remainingEXP);
		}
	}

	public void LevelUp(int remainingEXP)
	{
		exp = 0;
		exp += remainingEXP;
		level++;
		statusPoint += 5;
		maxExp = (int)(1.25f * (float)maxExp);
		maxHealth += 20;
		maxMana += 10;
		health = maxHealth;
		mana = maxMana;
		gainEXP(0);
		if ((bool)(SkillWindow)GetComponent(typeof(SkillWindow)))
		{
			((SkillWindow)GetComponent(typeof(SkillWindow))).LearnSkillByLevel(level);
		}
	}

	public void SaveData()
	{
		PlayerPrefs.SetString("TempName", characterName);
		PlayerPrefs.SetInt("TempID", characterId);
		PlayerPrefs.SetInt("TempPlayerLevel", level);
		PlayerPrefs.SetInt("TempPlayerATK", atk);
		PlayerPrefs.SetInt("TempPlayerDEF", def);
		PlayerPrefs.SetInt("TempPlayerMATK", matk);
		PlayerPrefs.SetInt("TempPlayerMDEF", mdef);
		PlayerPrefs.SetInt("TempPlayerEXP", exp);
		PlayerPrefs.SetInt("TempPlayerMaxEXP", maxExp);
		PlayerPrefs.SetInt("TempPlayerMaxHP", maxHealth);
		PlayerPrefs.SetInt("TempPlayerMaxMP", maxMana);
		PlayerPrefs.SetInt("TempPlayerSTP", statusPoint);
		PlayerPrefs.SetInt("TempCash", ((Inventory)GetComponent(typeof(Inventory))).cash);
		int num = Extensions.get_length((System.Array)((Inventory)GetComponent(typeof(Inventory))).itemSlot);
		int i = 0;
		if (num > 0)
		{
			for (; i < num; i++)
			{
				PlayerPrefs.SetInt("TempItem" + i.ToString(), ((Inventory)GetComponent(typeof(Inventory))).itemSlot[i]);
				PlayerPrefs.SetInt("TempItemQty" + i.ToString(), ((Inventory)GetComponent(typeof(Inventory))).itemQuantity[i]);
			}
		}
		int num2 = Extensions.get_length((System.Array)((Inventory)GetComponent(typeof(Inventory))).equipment);
		i = 0;
		if (num2 > 0)
		{
			for (; i < num2; i++)
			{
				PlayerPrefs.SetInt("TempEquipm" + i.ToString(), ((Inventory)GetComponent(typeof(Inventory))).equipment[i]);
			}
		}
		PlayerPrefs.SetInt("TempWeaEquip", ((Inventory)GetComponent(typeof(Inventory))).weaponEquip);
		PlayerPrefs.SetInt("TempArmoEquip", ((Inventory)GetComponent(typeof(Inventory))).armorEquip);
		int num3 = Extensions.get_length((System.Array)((QuestStat)GetComponent(typeof(QuestStat))).questProgress);
		PlayerPrefs.SetInt("TempQuestSize", num3);
		i = 0;
		if (num3 > 0)
		{
			for (; i < num3; i++)
			{
				PlayerPrefs.SetInt("TempQuestp" + i.ToString(), ((QuestStat)GetComponent(typeof(QuestStat))).questProgress[i]);
			}
		}
		int num4 = Extensions.get_length((System.Array)((QuestStat)GetComponent(typeof(QuestStat))).questSlot);
		PlayerPrefs.SetInt("TempQuestSlotSize", num4);
		i = 0;
		if (num4 > 0)
		{
			for (; i < num4; i++)
			{
				PlayerPrefs.SetInt("TempQuestslot" + i.ToString(), ((QuestStat)GetComponent(typeof(QuestStat))).questSlot[i]);
			}
		}
		for (i = 0; i <= 2; i++)
		{
			PlayerPrefs.SetInt("TempSkill" + i.ToString(), ((SkillWindow)GetComponent(typeof(SkillWindow))).skill[i]);
		}
		for (i = 0; i < Extensions.get_length((System.Array)((SkillWindow)GetComponent(typeof(SkillWindow))).skillListSlot); i++)
		{
			PlayerPrefs.SetInt("TempSkillList" + i.ToString(), ((SkillWindow)GetComponent(typeof(SkillWindow))).skillListSlot[i]);
		}
		MonoBehaviour.print("Saved");
	}

	public void CalculateStatus()
	{
		addAtk = 0;
		addAtk += atk + buffAtk + weaponAtk;
		addMatk = 0;
		addMatk += matk + buffMatk + weaponMatk;
		int num = maxHealth * addHPpercent / 100;
		int num2 = maxMana * addMPpercent / 100;
		maxHealth += num;
		maxMana += num2;
		if (health >= maxHealth)
		{
			health = maxHealth;
		}
		if (mana >= maxMana)
		{
			mana = maxMana;
		}
	}

	public IEnumerator OnPoison(int hurtTime)
	{
		return new _0024OnPoison_0024222(hurtTime, this).GetEnumerator();
	}

	public IEnumerator OnSilence(float dur)
	{
		return new _0024OnSilence_0024231(dur, this).GetEnumerator();
	}

	public IEnumerator OnWebbedUp(float dur)
	{
		return new _0024OnWebbedUp_0024239(dur, this).GetEnumerator();
	}

	public IEnumerator OnStun(float dur)
	{
		return new _0024OnStun_0024247(dur, this).GetEnumerator();
	}

	public void ApplyAbnormalStat(int statId, float dur)
	{
		if (statId == 0)
		{
			StartCoroutine(OnPoison(Mathf.FloorToInt(dur)));
		}
		if (statId == 1)
		{
			StartCoroutine(OnSilence(dur));
		}
		if (statId == 2)
		{
			StartCoroutine(OnStun(dur));
		}
		if (statId == 3)
		{
			StartCoroutine(OnWebbedUp(dur));
		}
	}

	public IEnumerator OnBarrier(float amount, float dur)
	{
		return new _0024OnBarrier_0024255(amount, dur, this).GetEnumerator();
	}

	public IEnumerator OnMagicBarrier(float amount, float dur)
	{
		return new _0024OnMagicBarrier_0024262(amount, dur, this).GetEnumerator();
	}

	public IEnumerator OnBrave(float amount, float dur)
	{
		return new _0024OnBrave_0024269(amount, dur, this).GetEnumerator();
	}

	public IEnumerator OnFaith(float amount, float dur)
	{
		return new _0024OnFaith_0024276(amount, dur, this).GetEnumerator();
	}

	public void ApplyBuff(int statId, float dur, int amount)
	{
		if (statId == 1)
		{
			StartCoroutine(OnBarrier(amount, dur));
		}
		if (statId == 2)
		{
			StartCoroutine(OnMagicBarrier(amount, dur));
		}
		if (statId == 3)
		{
			StartCoroutine(OnBrave(amount, dur));
		}
		if (statId == 4)
		{
			StartCoroutine(OnFaith(amount, dur));
		}
	}

	public void Main()
	{
	}
}
