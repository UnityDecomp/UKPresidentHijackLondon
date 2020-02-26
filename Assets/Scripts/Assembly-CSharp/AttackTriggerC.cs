using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000049 RID: 73
[RequireComponent(typeof(PlayerInputControllerC))]
[RequireComponent(typeof(CharacterMotorC))]
[RequireComponent(typeof(WeaponSwitch))]
public class AttackTriggerC : MonoBehaviour
{
	// Token: 0x0600032E RID: 814 RVA: 0x0000E3F0 File Offset: 0x0000C7F0
	private void Awake()
	{
		if (!this.mainModel)
		{
			this.mainModel = base.gameObject;
		}
		this.crosshair.gameObject.SetActive(false);
		base.GetComponent<StatusC>().mainModel = this.mainModel;
		base.GetComponent<StatusC>().useMecanim = this.useMecanim;
		base.gameObject.tag = "Player";
		this.str = base.GetComponent<StatusC>().addAtk;
		this.matk = base.GetComponent<StatusC>().addMatk;
		int num = this.attackCombo.Length;
		int num2 = 0;
		if (num > 0 && !this.useMecanim)
		{
			while (num2 < num && this.attackCombo[num2])
			{
				this.mainModel.GetComponent<Animation>()[this.attackCombo[num2].name].layer = 15;
				num2++;
			}
		}
		if (!this.attackPoint)
		{
			if (!this.attackPointPrefab)
			{
				MonoBehaviour.print("Please assign Attack Point");
				this.freeze = true;
				return;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.attackPointPrefab, base.transform.position, base.transform.rotation);
			gameObject.transform.parent = base.transform;
			this.attackPoint = gameObject.transform;
		}
		if (!this.useMecanim)
		{
			this.hurt = base.GetComponent<PlayerAnimationC>().hurt;
		}
		if (this.aimingType == AttackTriggerC.AimType.Raycast)
		{
		}
		GameObject gameObject2 = GameObject.FindWithTag("Minimap");
		if (gameObject2)
		{
			GameObject minimapCam = gameObject2.GetComponent<MinimapOnOffC>().minimapCam;
			minimapCam.GetComponent<MinimapCameraC>().target = base.transform;
		}
	}

	// Token: 0x0600032F RID: 815 RVA: 0x0000E5B0 File Offset: 0x0000C9B0
	private void Update()
	{
		StatusC component = base.GetComponent<StatusC>();
		if (this.freeze || this.atkDelay || Time.timeScale == 0f || component.freeze)
		{
			return;
		}
		CharacterController component2 = base.GetComponent<CharacterController>();
		if (this.flinch && this.allowFlinch)
		{
			component2.Move(this.knock * 6f * Time.deltaTime);
			return;
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
		}
		if (Input.GetKeyDown(KeyCode.P))
		{
		}
		if (this.meleefwd)
		{
			Vector3 a = base.transform.TransformDirection(Vector3.forward);
			component2.Move(a * 5f * Time.deltaTime);
		}
		if (this.aimingType == AttackTriggerC.AimType.Raycast || this.aimingType == AttackTriggerC.AimType.Normal)
		{
			this.Aiming();
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Time.timeScale == 1f)
			{
				Time.timeScale = 0f;
			}
			else
			{
				Time.timeScale = 1f;
			}
		}
		if ((CFInput.GetButton("Fire1") || Input.GetButton("Firing")) && Time.time > this.nextFire && !this.isCasting)
		{
			if (!this.useBurst)
			{
				if (Time.time > this.nextFire + 0.5f)
				{
					this.c = 0;
				}
				if (this.attackCombo.Length >= 1)
				{
					this.conCombo++;
					base.StartCoroutine(this.AttackCombo());
				}
			}
			else
			{
				this.nextFire = Time.time + 0.1f;
				Transform transform = UnityEngine.Object.Instantiate<Transform>(this.attackPrefab, this.attackPoint.transform.position, this.attackPoint.transform.rotation);
				transform.GetComponent<BulletStatusC>().Setting(this.str, this.matk, "Player", base.gameObject);
				base.GetComponent<AudioSource>().PlayOneShot(this.sound.attackComboVoice[0]);
				this.mainModel.GetComponent<Animator>().Play(this.attackCombo[0].name);
			}
			if (this.muzzleFlash)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.muzzleFlash, this.attackPoint.transform.position, this.attackPoint.transform.rotation);
				gameObject.transform.parent = this.attackPoint.transform;
			}
		}
		if (CFInput.GetButton("Fire3") && Time.time > this.nextFire && !this.isCasting && this.skillPrefab[this.skillEquip] && !component.silence)
		{
			base.GetComponent<WeaponSwitch>().bowArrow();
			base.StartCoroutine(this.MagicSkill(0));
		}
		if ((CFInput.GetButton("Attack") || Input.GetButton("Firing")) && Time.time > this.nextFire && !this.isCasting && !this.useBurst)
		{
			if (Time.time > this.nextFire + 0.5f)
			{
				this.c = 0;
			}
			if (this.attackCombo.Length >= 1)
			{
				this.conCombo++;
				base.StartCoroutine(this.AttackCombo());
			}
		}
	}

	// Token: 0x06000330 RID: 816 RVA: 0x0000E940 File Offset: 0x0000CD40
	private void OnGUI()
	{
	}

	// Token: 0x06000331 RID: 817 RVA: 0x0000E944 File Offset: 0x0000CD44
	private IEnumerator AttackCombo()
	{
		float wait = 0f;
		if (this.attackCombo[this.c])
		{
			this.str = base.GetComponent<StatusC>().addAtk;
			this.matk = base.GetComponent<StatusC>().addMatk;
			this.isCasting = true;
			if (this.whileAttack == AttackTriggerC.whileAtk.MeleeFwd)
			{
				base.GetComponent<CharacterMotorC>().canControl = false;
				base.StartCoroutine(this.MeleeDash());
			}
			if (this.whileAttack == AttackTriggerC.whileAtk.Immobile)
			{
				base.GetComponent<CharacterMotorC>().canControl = false;
			}
			if (this.sound.attackComboVoice.Length > this.c && this.sound.attackComboVoice[this.c])
			{
				base.GetComponent<AudioSource>().clip = this.sound.attackComboVoice[this.c];
				base.GetComponent<AudioSource>().Play();
			}
			while (this.conCombo > 0)
			{
				if (!this.useMecanim)
				{
					if (this.c >= 1)
					{
						this.mainModel.GetComponent<Animation>().PlayQueued(this.attackCombo[this.c].name, QueueMode.PlayNow).speed = this.attackAnimationSpeed;
					}
					else
					{
						this.mainModel.GetComponent<Animation>().PlayQueued(this.attackCombo[this.c].name, QueueMode.PlayNow).speed = this.attackAnimationSpeed;
					}
					wait = this.mainModel.GetComponent<Animation>()[this.attackCombo[this.c].name].length;
				}
				else
				{
					base.GetComponent<PlayerMecanimAnimationC>().AttackAnimation(this.attackCombo[this.c].name);
					float num = (float)base.GetComponent<PlayerMecanimAnimationC>().animator.GetCurrentAnimatorClipInfo(0).Length;
					wait = num - 0.3f;
				}
				yield return new WaitForSeconds(this.atkDelay1);
				this.c++;
				this.nextFire = Time.time + this.attackSpeed;
				Transform bulletShootout = UnityEngine.Object.Instantiate<Transform>(this.attackPrefab, this.attackPoint.transform.position, this.attackPoint.transform.rotation);
				bulletShootout.GetComponent<BulletStatusC>().Setting(this.str, this.matk, "Player", base.gameObject);
				this.conCombo--;
				if (this.c >= this.attackCombo.Length)
				{
					this.c = 0;
					this.atkDelay = true;
					yield return new WaitForSeconds(wait);
					this.atkDelay = false;
				}
				else
				{
					yield return new WaitForSeconds(this.attackSpeed);
				}
			}
			this.isCasting = false;
			base.GetComponent<CharacterMotorC>().canControl = true;
		}
		else
		{
			MonoBehaviour.print("Please assign attack animation in Attack Combo");
		}
		yield break;
	}

	// Token: 0x06000332 RID: 818 RVA: 0x0000E960 File Offset: 0x0000CD60
	private IEnumerator MeleeDash()
	{
		this.meleefwd = true;
		yield return new WaitForSeconds(0.2f);
		this.meleefwd = false;
		yield break;
	}

	// Token: 0x06000333 RID: 819 RVA: 0x0000E97C File Offset: 0x0000CD7C
	private IEnumerator MagicSkill(int skillID)
	{
		float wait = 0f;
		if (this.skillAnimation[skillID])
		{
			this.str = base.GetComponent<StatusC>().addAtk;
			this.matk = base.GetComponent<StatusC>().addMatk;
			if (base.GetComponent<StatusC>().mana > this.manaCost[skillID] && !base.GetComponent<StatusC>().silence)
			{
				if (this.sound.magicCastVoice)
				{
					base.GetComponent<AudioSource>().clip = this.sound.magicCastVoice;
					base.GetComponent<AudioSource>().Play();
				}
				this.isCasting = true;
				base.GetComponent<CharacterMotorC>().canControl = false;
				if (!this.useMecanim)
				{
					this.mainModel.GetComponent<Animation>()[this.skillAnimation[skillID].name].layer = 16;
					this.mainModel.GetComponent<Animation>()[this.skillAnimation[skillID].name].speed = this.skillAnimationSpeed;
					this.mainModel.GetComponent<Animation>().Play(this.skillAnimation[skillID].name);
					wait = this.mainModel.GetComponent<Animation>()[this.skillAnimation[skillID].name].length - 0.3f;
				}
				else
				{
					base.GetComponent<PlayerMecanimAnimationC>().AttackAnimation(this.skillAnimation[skillID].name);
					float num = (float)base.GetComponent<PlayerMecanimAnimationC>().animator.GetCurrentAnimatorClipInfo(0).Length;
					wait = num - 0.3f;
				}
				this.nextFire = Time.time + this.skillDelay;
				yield return new WaitForSeconds(wait);
				if (this.aimingType == AttackTriggerC.AimType.Normal)
				{
				}
				this.shoot = true;
				if (this.shoot)
				{
					Transform transform = UnityEngine.Object.Instantiate<Transform>(this.skillPrefab[skillID], this.attackPoint.transform.position, this.attackPoint.transform.rotation);
					transform.GetComponent<BulletStatusC>().Setting(this.str, this.matk, "Player", base.gameObject);
				}
				yield return new WaitForSeconds(this.skillDelay);
				this.isCasting = false;
				this.shoot = false;
				base.GetComponent<CharacterMotorC>().canControl = true;
			}
		}
		else
		{
			MonoBehaviour.print("Please assign skill animation in Skill Animation");
		}
		yield break;
	}

	// Token: 0x06000334 RID: 820 RVA: 0x0000E9A0 File Offset: 0x0000CDA0
	public void Flinch(Vector3 dir)
	{
		if (this.sound.hurtVoice && base.GetComponent<StatusC>().health >= 1)
		{
			base.GetComponent<AudioSource>().clip = this.sound.hurtVoice;
			base.GetComponent<AudioSource>().Play();
		}
		this.knock = dir;
		base.GetComponent<CharacterMotorC>().canControl = false;
		base.StartCoroutine(this.KnockBack());
		if (!this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().PlayQueued(this.hurt.name, QueueMode.PlayNow);
		}
		base.GetComponent<CharacterMotorC>().canControl = true;
	}

	// Token: 0x06000335 RID: 821 RVA: 0x0000EA48 File Offset: 0x0000CE48
	private IEnumerator KnockBack()
	{
		this.flinch = true;
		yield return new WaitForSeconds(0.2f);
		this.flinch = false;
		yield break;
	}

	// Token: 0x06000336 RID: 822 RVA: 0x0000EA63 File Offset: 0x0000CE63
	public void WhileAttackSet(int watk)
	{
		if (watk == 2)
		{
			this.whileAttack = AttackTriggerC.whileAtk.WalkFree;
		}
		else if (watk == 1)
		{
			this.whileAttack = AttackTriggerC.whileAtk.Immobile;
		}
		else
		{
			this.whileAttack = AttackTriggerC.whileAtk.MeleeFwd;
		}
	}

	// Token: 0x06000337 RID: 823 RVA: 0x0000EA94 File Offset: 0x0000CE94
	private void Aiming()
	{
		Ray ray = this.playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		RaycastHit raycastHit;
		if (Physics.Raycast(ray, out raycastHit))
		{
			this.attackPoint.transform.LookAt(raycastHit.point);
		}
		else
		{
			this.attackPoint.transform.rotation = this.playerCam.transform.rotation;
		}
	}

	// Token: 0x06000338 RID: 824 RVA: 0x0000EB10 File Offset: 0x0000CF10
	public void changeWeaponMode()
	{
		if (!this.zooming)
		{
			this.zooming = true;
			this.playerCam.transform.localPosition = this.cameraZoomPoint.transform.localPosition;
			this.playerCam.transform.localRotation = this.cameraZoomPoint.localRotation;
			this.playerCam.GetComponent<TPSCameraC>().shoot();
			base.GetComponent<WeaponSwitch>().meleeToRifle();
			this.crosshair.gameObject.SetActive(true);
		}
		else
		{
			this.zooming = false;
			this.playerCam.transform.localPosition = this.cameraNormalPoint.transform.localPosition;
			this.playerCam.transform.localRotation = this.cameraNormalPoint.localRotation;
			this.playerCam.GetComponent<TPSCameraC>().melee();
			base.GetComponent<WeaponSwitch>().rifleToMelee();
			this.crosshair.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000339 RID: 825 RVA: 0x0000EC0C File Offset: 0x0000D00C
	public void gunMode()
	{
		this.zooming = true;
		this.playerCam.transform.localPosition = this.cameraZoomPoint.transform.localPosition;
		this.playerCam.transform.localRotation = this.cameraZoomPoint.localRotation;
		this.playerCam.GetComponent<TPSCameraC>().shoot();
		base.GetComponent<WeaponSwitch>().meleeToRifle();
		this.crosshair.gameObject.SetActive(true);
	}

	// Token: 0x0600033A RID: 826 RVA: 0x0000EC88 File Offset: 0x0000D088
	public void meleeMode()
	{
		this.zooming = false;
		this.playerCam.transform.localPosition = this.cameraNormalPoint.transform.localPosition;
		this.playerCam.transform.localRotation = this.cameraNormalPoint.localRotation;
		this.playerCam.GetComponent<TPSCameraC>().melee();
		base.GetComponent<WeaponSwitch>().rifleToMelee();
		this.crosshair.gameObject.SetActive(false);
	}

	// Token: 0x040001D3 RID: 467
	public GameObject mainModel;

	// Token: 0x040001D4 RID: 468
	public Transform playerCam;

	// Token: 0x040001D5 RID: 469
	public Transform attackPoint;

	// Token: 0x040001D6 RID: 470
	public Transform cameraNormalPoint;

	// Token: 0x040001D7 RID: 471
	public Transform cameraZoomPoint;

	// Token: 0x040001D8 RID: 472
	public Transform attackPrefab;

	// Token: 0x040001D9 RID: 473
	public bool shoot;

	// Token: 0x040001DA RID: 474
	public bool useBurst;

	// Token: 0x040001DB RID: 475
	private bool zooming;

	// Token: 0x040001DC RID: 476
	public bool useMecanim;

	// Token: 0x040001DD RID: 477
	public AttackTriggerC.whileAtk whileAttack;

	// Token: 0x040001DE RID: 478
	public AttackTriggerC.AimType aimingType;

	// Token: 0x040001DF RID: 479
	public Transform[] skillPrefab = new Transform[3];

	// Token: 0x040001E0 RID: 480
	private bool atkDelay;

	// Token: 0x040001E1 RID: 481
	public bool freeze;

	// Token: 0x040001E2 RID: 482
	public Texture2D[] skillIcon = new Texture2D[3];

	// Token: 0x040001E3 RID: 483
	public int skillIconSize = 80;

	// Token: 0x040001E4 RID: 484
	public float attackSpeed = 0.15f;

	// Token: 0x040001E5 RID: 485
	private float nextFire;

	// Token: 0x040001E6 RID: 486
	public float atkDelay1 = 0.1f;

	// Token: 0x040001E7 RID: 487
	public float skillDelay = 0.3f;

	// Token: 0x040001E8 RID: 488
	public AnimationClip[] attackCombo = new AnimationClip[3];

	// Token: 0x040001E9 RID: 489
	public float attackAnimationSpeed = 1f;

	// Token: 0x040001EA RID: 490
	public AnimationClip[] skillAnimation = new AnimationClip[3];

	// Token: 0x040001EB RID: 491
	public float skillAnimationSpeed = 1f;

	// Token: 0x040001EC RID: 492
	public int[] manaCost = new int[3];

	// Token: 0x040001ED RID: 493
	private AnimationClip hurt;

	// Token: 0x040001EE RID: 494
	private bool meleefwd;

	// Token: 0x040001EF RID: 495
	[HideInInspector]
	public bool isCasting;

	// Token: 0x040001F0 RID: 496
	private int c;

	// Token: 0x040001F1 RID: 497
	private int conCombo;

	// Token: 0x040001F2 RID: 498
	[HideInInspector]
	public bool showCross;

	// Token: 0x040001F3 RID: 499
	public Transform Maincam;

	// Token: 0x040001F4 RID: 500
	public GameObject MaincamPrefab;

	// Token: 0x040001F5 RID: 501
	public GameObject attackPointPrefab;

	// Token: 0x040001F6 RID: 502
	private int str;

	// Token: 0x040001F7 RID: 503
	private int matk;

	// Token: 0x040001F8 RID: 504
	public Image crosshair;

	// Token: 0x040001F9 RID: 505
	public GameObject muzzleFlash;

	// Token: 0x040001FA RID: 506
	public Texture2D aimIcon;

	// Token: 0x040001FB RID: 507
	public int aimIconSize = 40;

	// Token: 0x040001FC RID: 508
	public bool allowFlinch = true;

	// Token: 0x040001FD RID: 509
	[HideInInspector]
	public bool flinch;

	// Token: 0x040001FE RID: 510
	private int skillEquip;

	// Token: 0x040001FF RID: 511
	private Vector3 knock = Vector3.zero;

	// Token: 0x04000200 RID: 512
	public AttackTriggerC.AtkSound sound;

	// Token: 0x04000201 RID: 513
	[HideInInspector]
	public GameObject pet;

	// Token: 0x0200004A RID: 74
	public enum whileAtk
	{
		// Token: 0x04000203 RID: 515
		MeleeFwd,
		// Token: 0x04000204 RID: 516
		Immobile,
		// Token: 0x04000205 RID: 517
		WalkFree
	}

	// Token: 0x0200004B RID: 75
	public enum AimType
	{
		// Token: 0x04000207 RID: 519
		Normal,
		// Token: 0x04000208 RID: 520
		Raycast
	}

	// Token: 0x0200004C RID: 76
	[Serializable]
	public class AtkSound
	{
		// Token: 0x04000209 RID: 521
		public AudioClip[] attackComboVoice = new AudioClip[3];

		// Token: 0x0400020A RID: 522
		public AudioClip magicCastVoice;

		// Token: 0x0400020B RID: 523
		public AudioClip hurtVoice;
	}
}
