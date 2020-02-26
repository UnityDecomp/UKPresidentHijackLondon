using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x0200001D RID: 29
[RequireComponent(typeof(QuestStat))]
[RequireComponent(typeof(SkillWindow))]
[RequireComponent(typeof(DontDestroyOnload))]
[RequireComponent(typeof(Status))]
[RequireComponent(typeof(StatusWindow))]
[RequireComponent(typeof(HealthBar))]
[RequireComponent(typeof(PlayerInputController))]
[RequireComponent(typeof(CharacterMotor))]
[RequireComponent(typeof(Inventory))]
[Serializable]
public class AttackTrigger : MonoBehaviour
{
	// Token: 0x0600004B RID: 75 RVA: 0x00004F74 File Offset: 0x00003174
	public AttackTrigger()
	{
		this.whileAttack = whileAtk.MeleeFwd;
		this.aimingType = AimType.Normal;
		this.skillPrefab = new Transform[3];
		this.skillIcon = new Texture2D[3];
		this.skillIconSize = 80;
		this.attackSpeed = 0.15f;
		this.atkDelay1 = 0.1f;
		this.skillDelay = 0.3f;
		this.attackCombo = new AnimationClip[3];
		this.attackAnimationSpeed = 1f;
		this.skillAnimation = new AnimationClip[3];
		this.skillAnimationSpeed = 1f;
		this.manaCost = new int[3];
		this.aimIconSize = 40;
		this.knock = Vector3.zero;
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00005024 File Offset: 0x00003224
	public virtual void Awake()
	{
		this.gameObject.tag = "Player";
		if (!this.Maincam)
		{
			GameObject gameObject = GameObject.FindWithTag("MainCamera");
			if (!gameObject)
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.MaincamPrefab, this.transform.position, this.transform.rotation);
			}
			this.Maincam = gameObject.transform;
		}
		if (!this.mainModel)
		{
			this.mainModel = this.gameObject;
		}
		((Status)this.GetComponent(typeof(Status))).mainModel = this.mainModel;
		((Status)this.GetComponent(typeof(Status))).useMecanim = this.useMecanim;
		if (this.Maincam)
		{
			ARPGcamera exists = (ARPGcamera)this.Maincam.GetComponent(typeof(ARPGcamera));
			if (!exists)
			{
				UnityEngine.Object.Destroy(this.Maincam.gameObject);
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.MaincamPrefab, this.transform.position, this.transform.rotation);
				this.Maincam = gameObject.transform;
			}
		}
		else
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.MaincamPrefab, this.transform.position, this.transform.rotation);
			this.Maincam = gameObject.transform;
		}
		if (!this.cameraZoomPoint || this.aimingType == AimType.Normal)
		{
			((ARPGcamera)this.Maincam.GetComponent(typeof(ARPGcamera))).target = this.transform;
		}
		else
		{
			((ARPGcamera)this.Maincam.GetComponent(typeof(ARPGcamera))).target = this.cameraZoomPoint;
		}
		((ARPGcamera)this.Maincam.GetComponent(typeof(ARPGcamera))).targetBody = this.transform;
		this.str = ((Status)this.GetComponent(typeof(Status))).addAtk;
		this.matk = ((Status)this.GetComponent(typeof(Status))).addMatk;
		int num = Extensions.get_length(this.attackCombo);
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
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.attackPointPrefab, this.transform.position, this.transform.rotation);
			gameObject2.transform.parent = this.transform;
			this.attackPoint = gameObject2.transform;
		}
		if (!this.useMecanim)
		{
			this.hurt = ((PlayerAnimation)this.GetComponent(typeof(PlayerAnimation))).hurt;
		}
		if (this.aimingType == AimType.Raycast)
		{
			((ARPGcamera)this.Maincam.GetComponent(typeof(ARPGcamera))).lockOn = true;
		}
	}

	// Token: 0x0600004D RID: 77 RVA: 0x000053A0 File Offset: 0x000035A0
	public virtual void Update()
	{
		Status status = (Status)this.GetComponent(typeof(Status));
		if (!this.freeze && !this.atkDelay && Time.timeScale != (float)0 && !status.freeze)
		{
			CharacterController characterController = (CharacterController)this.GetComponent(typeof(CharacterController));
			if (this.flinch)
			{
				characterController.Move(this.knock * (float)6 * Time.deltaTime);
			}
			else
			{
				if (this.meleefwd)
				{
					Vector3 a = this.transform.TransformDirection(Vector3.forward);
					characterController.Move(a * (float)5 * Time.deltaTime);
				}
				if (this.aimingType == AimType.Raycast)
				{
					this.Aiming();
				}
				else
				{
					this.attackPoint.transform.rotation = ((ARPGcamera)this.Maincam.GetComponent(typeof(ARPGcamera))).aim;
				}
				if (Input.GetButton("Fire1") && Time.time > this.nextFire && !this.isCasting)
				{
					if (Time.time > this.nextFire + 0.5f)
					{
						this.c = 0;
					}
					if (this.attackCombo.Length >= 1)
					{
						this.conCombo++;
						this.StartCoroutine(this.AttackCombo());
					}
				}
				if (Input.GetButtonDown("Fire2") && Time.time > this.nextFire && !this.isCasting && this.skillPrefab[this.skillEquip] && !status.silence)
				{
					this.StartCoroutine(this.MagicSkill(this.skillEquip));
				}
				if (Input.GetKeyDown("1") && !this.isCasting && this.skillPrefab[0])
				{
					this.skillEquip = 0;
				}
				if (Input.GetKeyDown("2") && !this.isCasting && this.skillPrefab[1])
				{
					this.skillEquip = 1;
				}
				if (Input.GetKeyDown("3") && !this.isCasting && this.skillPrefab[2])
				{
					this.skillEquip = 2;
				}
			}
		}
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00005624 File Offset: 0x00003824
	public virtual void OnGUI()
	{
		if (this.aimingType == AimType.Normal)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 16), (float)(Screen.height / 2 - 90), (float)this.aimIconSize, (float)this.aimIconSize), this.aimIcon);
		}
		if (this.aimingType == AimType.Raycast)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 20), (float)(Screen.height / 2 - 20), (float)40, (float)40), this.aimIcon);
		}
		if (this.skillPrefab[this.skillEquip] && this.skillIcon[this.skillEquip])
		{
			GUI.DrawTexture(new Rect((float)(Screen.width - this.skillIconSize - 28), (float)(Screen.height - this.skillIconSize - 20), (float)this.skillIconSize, (float)this.skillIconSize), this.skillIcon[this.skillEquip]);
		}
		if (this.skillPrefab[0] && this.skillIcon[0])
		{
			GUI.DrawTexture(new Rect((float)(Screen.width - this.skillIconSize - 50), (float)(Screen.height - this.skillIconSize - 50), (float)(this.skillIconSize / 2), (float)(this.skillIconSize / 2)), this.skillIcon[0]);
		}
		if (this.skillPrefab[1] && this.skillIcon[1])
		{
			GUI.DrawTexture(new Rect((float)(Screen.width - this.skillIconSize - 10), (float)(Screen.height - this.skillIconSize - 60), (float)(this.skillIconSize / 2), (float)(this.skillIconSize / 2)), this.skillIcon[1]);
		}
		if (this.skillPrefab[2] && this.skillIcon[2])
		{
			GUI.DrawTexture(new Rect((float)(Screen.width - this.skillIconSize + 30), (float)(Screen.height - this.skillIconSize - 50), (float)(this.skillIconSize / 2), (float)(this.skillIconSize / 2)), this.skillIcon[2]);
		}
	}

	// Token: 0x0600004F RID: 79 RVA: 0x00005854 File Offset: 0x00003A54
	public virtual IEnumerator AttackCombo()
	{
		return new AttackTrigger.$AttackCombo$148(this).GetEnumerator();
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00005864 File Offset: 0x00003A64
	public virtual IEnumerator MeleeDash()
	{
		return new AttackTrigger.$MeleeDash$154(this).GetEnumerator();
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00005874 File Offset: 0x00003A74
	public virtual IEnumerator MagicSkill(int skillID)
	{
		return new AttackTrigger.$MagicSkill$157(skillID, this).GetEnumerator();
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00005884 File Offset: 0x00003A84
	public virtual void Flinch(Vector3 dir)
	{
		this.knock = dir;
		if (this.sound.hurtVoice && ((Status)this.GetComponent(typeof(Status))).health >= 1)
		{
			this.GetComponent<AudioSource>().clip = this.sound.hurtVoice;
			this.GetComponent<AudioSource>().Play();
		}
		((CharacterMotor)this.GetComponent(typeof(CharacterMotor))).canControl = false;
		this.StartCoroutine(this.KnockBack());
		if (!this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().PlayQueued(this.hurt.name, QueueMode.PlayNow);
		}
		((CharacterMotor)this.GetComponent(typeof(CharacterMotor))).canControl = true;
	}

	// Token: 0x06000053 RID: 83 RVA: 0x0000595C File Offset: 0x00003B5C
	public virtual IEnumerator KnockBack()
	{
		return new AttackTrigger.$KnockBack$165(this).GetEnumerator();
	}

	// Token: 0x06000054 RID: 84 RVA: 0x0000596C File Offset: 0x00003B6C
	public virtual void Aiming()
	{
		Ray ray = this.Maincam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, (float)0));
		RaycastHit raycastHit = default(RaycastHit);
		if (Physics.Raycast(ray, out raycastHit))
		{
			this.attackPoint.transform.LookAt(raycastHit.point);
		}
		else
		{
			this.attackPoint.transform.rotation = this.Maincam.transform.rotation;
		}
	}

	// Token: 0x06000055 RID: 85 RVA: 0x000059EC File Offset: 0x00003BEC
	public virtual void Main()
	{
	}

	// Token: 0x0400009F RID: 159
	public GameObject mainModel;

	// Token: 0x040000A0 RID: 160
	public Transform attackPoint;

	// Token: 0x040000A1 RID: 161
	public Transform cameraZoomPoint;

	// Token: 0x040000A2 RID: 162
	public Transform attackPrefab;

	// Token: 0x040000A3 RID: 163
	public bool useMecanim;

	// Token: 0x040000A4 RID: 164
	public whileAtk whileAttack;

	// Token: 0x040000A5 RID: 165
	public AimType aimingType;

	// Token: 0x040000A6 RID: 166
	public Transform[] skillPrefab;

	// Token: 0x040000A7 RID: 167
	private bool atkDelay;

	// Token: 0x040000A8 RID: 168
	public bool freeze;

	// Token: 0x040000A9 RID: 169
	public Texture2D[] skillIcon;

	// Token: 0x040000AA RID: 170
	public int skillIconSize;

	// Token: 0x040000AB RID: 171
	public float attackSpeed;

	// Token: 0x040000AC RID: 172
	private float nextFire;

	// Token: 0x040000AD RID: 173
	public float atkDelay1;

	// Token: 0x040000AE RID: 174
	public float skillDelay;

	// Token: 0x040000AF RID: 175
	public AnimationClip[] attackCombo;

	// Token: 0x040000B0 RID: 176
	public float attackAnimationSpeed;

	// Token: 0x040000B1 RID: 177
	public AnimationClip[] skillAnimation;

	// Token: 0x040000B2 RID: 178
	public float skillAnimationSpeed;

	// Token: 0x040000B3 RID: 179
	public int[] manaCost;

	// Token: 0x040000B4 RID: 180
	private AnimationClip hurt;

	// Token: 0x040000B5 RID: 181
	private bool meleefwd;

	// Token: 0x040000B6 RID: 182
	[HideInInspector]
	public bool isCasting;

	// Token: 0x040000B7 RID: 183
	private int c;

	// Token: 0x040000B8 RID: 184
	private int conCombo;

	// Token: 0x040000B9 RID: 185
	public Transform Maincam;

	// Token: 0x040000BA RID: 186
	public GameObject MaincamPrefab;

	// Token: 0x040000BB RID: 187
	public GameObject attackPointPrefab;

	// Token: 0x040000BC RID: 188
	private int str;

	// Token: 0x040000BD RID: 189
	private int matk;

	// Token: 0x040000BE RID: 190
	public Texture2D aimIcon;

	// Token: 0x040000BF RID: 191
	public int aimIconSize;

	// Token: 0x040000C0 RID: 192
	[HideInInspector]
	public bool flinch;

	// Token: 0x040000C1 RID: 193
	private int skillEquip;

	// Token: 0x040000C2 RID: 194
	private Vector3 knock;

	// Token: 0x040000C3 RID: 195
	public AtkSound sound;

	// Token: 0x040000C4 RID: 196
	[HideInInspector]
	public GameObject pet;

	// Token: 0x0200001E RID: 30
	[CompilerGenerated]
	[Serializable]
	internal sealed class $AttackCombo$148 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000056 RID: 86 RVA: 0x000059F0 File Offset: 0x00003BF0
		public $AttackCombo$148(AttackTrigger self_)
		{
			this.$self_$153 = self_;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00005A00 File Offset: 0x00003C00
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new AttackTrigger.$AttackCombo$148.$(this.$self_$153);
		}

		// Token: 0x040000C5 RID: 197
		internal AttackTrigger $self_$153;
	}

	// Token: 0x02000020 RID: 32
	[CompilerGenerated]
	[Serializable]
	internal sealed class $MeleeDash$154 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x0600005A RID: 90 RVA: 0x00005F0C File Offset: 0x0000410C
		public $MeleeDash$154(AttackTrigger self_)
		{
			this.$self_$156 = self_;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00005F1C File Offset: 0x0000411C
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new AttackTrigger.$MeleeDash$154.$(this.$self_$156);
		}

		// Token: 0x040000CA RID: 202
		internal AttackTrigger $self_$156;
	}

	// Token: 0x02000022 RID: 34
	[CompilerGenerated]
	[Serializable]
	internal sealed class $MagicSkill$157 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x0600005E RID: 94 RVA: 0x00005F98 File Offset: 0x00004198
		public $MagicSkill$157(int skillID, AttackTrigger self_)
		{
			this.$skillID$163 = skillID;
			this.$self_$164 = self_;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00005FB0 File Offset: 0x000041B0
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new AttackTrigger.$MagicSkill$157.$(this.$skillID$163, this.$self_$164);
		}

		// Token: 0x040000CC RID: 204
		internal int $skillID$163;

		// Token: 0x040000CD RID: 205
		internal AttackTrigger $self_$164;
	}

	// Token: 0x02000024 RID: 36
	[CompilerGenerated]
	[Serializable]
	internal sealed class $KnockBack$165 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000062 RID: 98 RVA: 0x00006484 File Offset: 0x00004684
		public $KnockBack$165(AttackTrigger self_)
		{
			this.$self_$167 = self_;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00006494 File Offset: 0x00004694
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new AttackTrigger.$KnockBack$165.$(this.$self_$167);
		}

		// Token: 0x040000D3 RID: 211
		internal AttackTrigger $self_$167;
	}
}
