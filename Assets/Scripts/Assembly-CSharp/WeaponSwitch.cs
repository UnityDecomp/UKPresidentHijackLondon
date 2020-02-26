using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000221 RID: 545
[RequireComponent(typeof(AttackTriggerC))]
public class WeaponSwitch : MonoBehaviour
{
	// Token: 0x06000DED RID: 3565 RVA: 0x0005923C File Offset: 0x0005763C
	private void Start()
	{
		this.attackTrigger = base.GetComponent<AttackTriggerC>();
		if (!this.mainModel)
		{
			MonoBehaviour.print("<color=red> No Model assigned to Weapon Switch. Assign it from dogsactive script </color>");
			return;
		}
		this.manager = base.GetComponent<Manager>().questManager;
		this.anim = this.attackTrigger.mainModel.GetComponent<Animator>();
		this.inventory = this.mainModel.GetComponent<PlayerInventory>();
		this.controls = this.manager.CFPP;
		if (this.inventory)
		{
			this.SettingHandWeapons();
			this.SettingHolsterWeapons();
		}
	}

	// Token: 0x06000DEE RID: 3566 RVA: 0x000592D8 File Offset: 0x000576D8
	private void SettingHandWeapons()
	{
		this.weaponsOnHand = new GameObject[this.inventory.weapons.Length];
		for (int i = 0; i < this.inventory.weapons.Length; i++)
		{
			this.weaponsOnHand[i] = this.inventory.weapons[i];
		}
		this.activeWeapon = this.weaponsOnHand[0];
		this.SetWeaponProperties();
		this.SettingAttackTrigger();
	}

	// Token: 0x06000DEF RID: 3567 RVA: 0x0005934C File Offset: 0x0005774C
	private void SettingHolsterWeapons()
	{
		this.holsterWeapons = new GameObject[this.inventory.holster.Length];
		for (int i = 0; i < this.inventory.holster.Length; i++)
		{
			this.holsterWeapons[i] = this.inventory.holster[i];
		}
	}

	// Token: 0x06000DF0 RID: 3568 RVA: 0x000593A4 File Offset: 0x000577A4
	public void melee()
	{
	}

	// Token: 0x06000DF1 RID: 3569 RVA: 0x000593A6 File Offset: 0x000577A6
	public void bowArrow()
	{
	}

	// Token: 0x06000DF2 RID: 3570 RVA: 0x000593A8 File Offset: 0x000577A8
	public void activateEquipmentForTime(int equipID, float time, bool disableActiveWeapon)
	{
	}

	// Token: 0x06000DF3 RID: 3571 RVA: 0x000593AC File Offset: 0x000577AC
	public void nextWeapon()
	{
		this.anim.Play(this.equipAnim.name);
		MonoBehaviour.print("switch animation ah" + this.equipAnim.name);
		if (this.counter == 0)
		{
			this.weaponsOnHand[0].SetActive(false);
			this.holsterWeapons[0].SetActive(true);
			this.weaponsOnHand[1].SetActive(true);
			this.activeWeapon = this.weaponsOnHand[1];
			this.holsterWeapons[1].SetActive(false);
		}
		if (this.counter == 1)
		{
			this.weaponsOnHand[1].SetActive(false);
			this.holsterWeapons[1].SetActive(true);
			this.weaponsOnHand[0].SetActive(true);
			this.activeWeapon = this.weaponsOnHand[0];
			this.holsterWeapons[0].SetActive(false);
			this.counter = -1;
		}
		this.counter++;
		base.StartCoroutine(this.nextWeaponDelay());
		this.attackProperties();
		this.SetWeaponProperties();
		this.SettingAttackTrigger();
	}

	// Token: 0x06000DF4 RID: 3572 RVA: 0x000594C0 File Offset: 0x000578C0
	private IEnumerator nextWeaponDelay()
	{
		this.controls.GetComponent<TouchController>().touchZones[0].Disable(true);
		this.controls.GetComponent<TouchController>().touchZones[1].Disable(true);
		yield return new WaitForSeconds(1f);
		this.controls.GetComponent<TouchController>().touchZones[0].Enable(true);
		this.controls.GetComponent<TouchController>().touchZones[1].Enable(true);
		yield break;
	}

	// Token: 0x06000DF5 RID: 3573 RVA: 0x000594DC File Offset: 0x000578DC
	private void SetWeaponProperties()
	{
		this.currentWeaponProperties.attackPoint = this.activeWeapon.GetComponent<WeaponManager>().attackPoint;
		if (this.activeWeapon.GetComponent<WeaponManager>().fireType == WeaponManager.FireType.Burst)
		{
			this.currentWeaponProperties.fireType = WeaponSwitch.WeaponProperties.FireType.Burst;
		}
		else
		{
			this.currentWeaponProperties.fireType = WeaponSwitch.WeaponProperties.FireType.SingleShot;
		}
		this.currentWeaponProperties.damage = this.activeWeapon.GetComponent<WeaponManager>().damage;
		if (this.activeWeapon.GetComponent<WeaponManager>().shotSound)
		{
			this.currentWeaponProperties.shotSound = this.activeWeapon.GetComponent<WeaponManager>().shotSound;
		}
		if (this.activeWeapon.GetComponent<WeaponManager>().shotAnimation)
		{
			this.currentWeaponProperties.shotAnimation = this.activeWeapon.GetComponent<WeaponManager>().shotAnimation;
		}
	}

	// Token: 0x06000DF6 RID: 3574 RVA: 0x000595BC File Offset: 0x000579BC
	private void SettingAttackTrigger()
	{
		this.attackTrigger.attackPoint = this.currentWeaponProperties.attackPoint;
		if (this.currentWeaponProperties.fireType == WeaponSwitch.WeaponProperties.FireType.Burst)
		{
			this.attackTrigger.useBurst = true;
		}
		else
		{
			this.attackTrigger.useBurst = false;
		}
		this.attackTrigger.GetComponent<StatusC>().atk = this.currentWeaponProperties.damage;
		if (this.activeWeapon.GetComponent<WeaponManager>().shotSound)
		{
			this.attackTrigger.sound.attackComboVoice[0] = this.currentWeaponProperties.shotSound;
		}
		if (this.activeWeapon.GetComponent<WeaponManager>().shotAnimation)
		{
			this.attackTrigger.attackCombo[0] = this.currentWeaponProperties.shotAnimation;
		}
	}

	// Token: 0x06000DF7 RID: 3575 RVA: 0x00059691 File Offset: 0x00057A91
	public void saveWeapon(int id)
	{
		PlayerPrefs.SetInt("SavedWeapons", id);
	}

	// Token: 0x06000DF8 RID: 3576 RVA: 0x000596A0 File Offset: 0x00057AA0
	private void attackProperties()
	{
		int num = this.counter;
		if (num != 0)
		{
			if (num != 1)
			{
				if (num == 2)
				{
					base.GetComponent<StatusC>().atk = 14;
				}
			}
			else
			{
				base.GetComponent<StatusC>().atk = 10;
			}
		}
		else
		{
			base.GetComponent<StatusC>().atk = 6;
		}
	}

	// Token: 0x06000DF9 RID: 3577 RVA: 0x00059704 File Offset: 0x00057B04
	private IEnumerator delay()
	{
		this.allow = false;
		this.weapons[2].SetActive(true);
		base.GetComponent<AttackTriggerC>().showCross = true;
		yield return new WaitForSeconds(1f);
		base.GetComponent<AttackTriggerC>().showCross = false;
		this.weapons[2].SetActive(false);
		this.allow = true;
		yield break;
	}

	// Token: 0x06000DFA RID: 3578 RVA: 0x0005971F File Offset: 0x00057B1F
	public void meleeToRifle()
	{
		base.GetComponent<AttackTriggerC>().attackCombo[0] = this.weaponAnim;
		base.GetComponent<AttackTriggerC>().attackPrefab = this.attackPrefabs[1].transform;
	}

	// Token: 0x06000DFB RID: 3579 RVA: 0x0005974C File Offset: 0x00057B4C
	public void rifleToMelee()
	{
	}

	// Token: 0x06000DFC RID: 3580 RVA: 0x0005974E File Offset: 0x00057B4E
	public void emptyHandedPlayer()
	{
	}

	// Token: 0x04000ECD RID: 3789
	public WeaponSwitch.WeaponProperties currentWeaponProperties;

	// Token: 0x04000ECE RID: 3790
	public GameObject activeWeapon;

	// Token: 0x04000ECF RID: 3791
	public GameObject holsterWeapon;

	// Token: 0x04000ED0 RID: 3792
	public GameObject[] weaponsOnHand;

	// Token: 0x04000ED1 RID: 3793
	public GameObject[] holsterWeapons;

	// Token: 0x04000ED2 RID: 3794
	public GameObject[] attackPrefabs;

	// Token: 0x04000ED3 RID: 3795
	public AudioClip[] attackSounds;

	// Token: 0x04000ED4 RID: 3796
	public AnimationClip equipAnim;

	// Token: 0x04000ED5 RID: 3797
	public AnimationClip meleeAnim;

	// Token: 0x04000ED6 RID: 3798
	public AnimationClip weaponAnim;

	// Token: 0x04000ED7 RID: 3799
	[HideInInspector]
	public Transform mainModel;

	// Token: 0x04000ED8 RID: 3800
	private AttackTriggerC attackTrigger;

	// Token: 0x04000ED9 RID: 3801
	private PlayerInventory inventory;

	// Token: 0x04000EDA RID: 3802
	private Animator anim;

	// Token: 0x04000EDB RID: 3803
	private GameObject weaponActive;

	// Token: 0x04000EDC RID: 3804
	private int counter;

	// Token: 0x04000EDD RID: 3805
	private QuestManager manager;

	// Token: 0x04000EDE RID: 3806
	private GameObject controls;

	// Token: 0x04000EDF RID: 3807
	public GameObject[] weapons;

	// Token: 0x04000EE0 RID: 3808
	public GameObject[] equipments;

	// Token: 0x04000EE1 RID: 3809
	private bool allow = true;

	// Token: 0x02000222 RID: 546
	[Serializable]
	public class WeaponProperties
	{
		// Token: 0x04000EE2 RID: 3810
		public Transform attackPoint;

		// Token: 0x04000EE3 RID: 3811
		public WeaponSwitch.WeaponProperties.FireType fireType;

		// Token: 0x04000EE4 RID: 3812
		public int damage = 5;

		// Token: 0x04000EE5 RID: 3813
		public AudioClip shotSound;

		// Token: 0x04000EE6 RID: 3814
		public AnimationClip shotAnimation;

		// Token: 0x02000223 RID: 547
		public enum FireType
		{
			// Token: 0x04000EE8 RID: 3816
			SingleShot,
			// Token: 0x04000EE9 RID: 3817
			Burst
		}
	}
}
