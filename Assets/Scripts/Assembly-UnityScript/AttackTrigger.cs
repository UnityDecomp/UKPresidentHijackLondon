
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


[Serializable]
[RequireComponent(typeof(QuestStat))]
[RequireComponent(typeof(SkillWindow))]
[RequireComponent(typeof(DontDestroyOnload))]
[RequireComponent(typeof(Status))]
[RequireComponent(typeof(StatusWindow))]
[RequireComponent(typeof(HealthBar))]
[RequireComponent(typeof(PlayerInputController))]
[RequireComponent(typeof(CharacterMotor))]
[RequireComponent(typeof(Inventory))]
public class AttackTrigger : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024AttackCombo_0024148
	{
		internal AttackTrigger _0024self__0024153;

		public _0024AttackCombo_0024148(AttackTrigger self_)
		{
			_0024self__0024153 = self_;
		}

		public  IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024153);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MeleeDash_0024154
	{
		internal AttackTrigger _0024self__0024156;

		public _0024MeleeDash_0024154(AttackTrigger self_)
		{
			_0024self__0024156 = self_;
		}

		public  IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024156);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MagicSkill_0024157
	{
		internal int _0024skillID_0024163;

		internal AttackTrigger _0024self__0024164;

		public _0024MagicSkill_0024157(int skillID, AttackTrigger self_)
		{
			_0024skillID_0024163 = skillID;
			_0024self__0024164 = self_;
		}

		public  IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024skillID_0024163, _0024self__0024164);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024KnockBack_0024165
	{
		internal AttackTrigger _0024self__0024167;

		public _0024KnockBack_0024165(AttackTrigger self_)
		{
			_0024self__0024167 = self_;
		}

		public  IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024167);
		}
	}

	public GameObject mainModel;

	public Transform attackPoint;

	public Transform cameraZoomPoint;

	public Transform attackPrefab;

	public bool useMecanim;

	public whileAtk whileAttack;

	public AimType aimingType;

	public Transform[] skillPrefab;

	private bool atkDelay;

	public bool freeze;

	public Texture2D[] skillIcon;

	public int skillIconSize;

	public float attackSpeed;

	private float nextFire;

	public float atkDelay1;

	public float skillDelay;

	public AnimationClip[] attackCombo;

	public float attackAnimationSpeed;

	public AnimationClip[] skillAnimation;

	public float skillAnimationSpeed;

	public int[] manaCost;

	private AnimationClip hurt;

	private bool meleefwd;

	[HideInInspector]
	public bool isCasting;

	private int c;

	private int conCombo;

	public Transform Maincam;

	public GameObject MaincamPrefab;

	public GameObject attackPointPrefab;

	private int str;

	private int matk;

	public Texture2D aimIcon;

	public int aimIconSize;

	[HideInInspector]
	public bool flinch;

	private int skillEquip;

	private Vector3 knock;

	public AtkSound sound;

	[HideInInspector]
	public GameObject pet;

	public AttackTrigger()
	{
		whileAttack = whileAtk.MeleeFwd;
		aimingType = AimType.Normal;
		skillPrefab = new Transform[3];
		skillIcon = new Texture2D[3];
		skillIconSize = 80;
		attackSpeed = 0.15f;
		atkDelay1 = 0.1f;
		skillDelay = 0.3f;
		attackCombo = new AnimationClip[3];
		attackAnimationSpeed = 1f;
		skillAnimation = new AnimationClip[3];
		skillAnimationSpeed = 1f;
		manaCost = new int[3];
		aimIconSize = 40;
		knock = Vector3.zero;
	}

	public  void Awake()
	{
		this.gameObject.tag = "Player";
		if (!Maincam)
		{
			GameObject gameObject = GameObject.FindWithTag("MainCamera");
			if (!gameObject)
			{
				gameObject = UnityEngine.Object.Instantiate(MaincamPrefab, transform.position, transform.rotation);
			}
			Maincam = gameObject.transform;
		}
		if (!mainModel)
		{
			mainModel = this.gameObject;
		}
		((Status)GetComponent(typeof(Status))).mainModel = mainModel;
		((Status)GetComponent(typeof(Status))).useMecanim = useMecanim;
		if ((bool)Maincam)
		{
			ARPGcamera exists = (ARPGcamera)Maincam.GetComponent(typeof(ARPGcamera));
			if (!exists)
			{
				UnityEngine.Object.Destroy(Maincam.gameObject);
				GameObject gameObject = UnityEngine.Object.Instantiate(MaincamPrefab, transform.position, transform.rotation);
				Maincam = gameObject.transform;
			}
		}
		else
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(MaincamPrefab, transform.position, transform.rotation);
			Maincam = gameObject.transform;
		}
		if (!cameraZoomPoint || aimingType == AimType.Normal)
		{
			((ARPGcamera)Maincam.GetComponent(typeof(ARPGcamera))).target = transform;
		}
		else
		{
			((ARPGcamera)Maincam.GetComponent(typeof(ARPGcamera))).target = cameraZoomPoint;
		}
		((ARPGcamera)Maincam.GetComponent(typeof(ARPGcamera))).targetBody = transform;
		str = ((Status)GetComponent(typeof(Status))).addAtk;
		matk = ((Status)GetComponent(typeof(Status))).addMatk;
		int num = Extensions.get_length((System.Array)attackCombo);
		int i = 0;
		if (num > 0 && !useMecanim)
		{
			for (; i < num && (bool)attackCombo[i]; i++)
			{
				mainModel.GetComponent<Animation>()[attackCombo[i].name].layer = 15;
			}
		}
		if (!attackPoint)
		{
			if (!attackPointPrefab)
			{
				MonoBehaviour.print("Please assign Attack Point");
				freeze = true;
				return;
			}
			GameObject gameObject2 = UnityEngine.Object.Instantiate(attackPointPrefab, transform.position, transform.rotation);
			gameObject2.transform.parent = transform;
			attackPoint = gameObject2.transform;
		}
		if (!useMecanim)
		{
			hurt = ((PlayerAnimation)GetComponent(typeof(PlayerAnimation))).hurt;
		}
		if (aimingType == AimType.Raycast)
		{
			((ARPGcamera)Maincam.GetComponent(typeof(ARPGcamera))).lockOn = true;
		}
	}

	public  void Update()
	{
		Status status = (Status)GetComponent(typeof(Status));
		if (freeze || atkDelay || Time.timeScale == 0f || status.freeze)
		{
			return;
		}
		CharacterController characterController = (CharacterController)GetComponent(typeof(CharacterController));
		if (flinch)
		{
			characterController.Move(knock * 6f * Time.deltaTime);
			return;
		}
		if (meleefwd)
		{
			Vector3 a = this.transform.TransformDirection(Vector3.forward);
			characterController.Move(a * 5f * Time.deltaTime);
		}
		if (aimingType == AimType.Raycast)
		{
			Aiming();
		}
		else
		{
			attackPoint.transform.rotation = ((ARPGcamera)Maincam.GetComponent(typeof(ARPGcamera))).aim;
		}
		Transform transform = null;
		if (Input.GetButton("Fire1") && !(Time.time <= nextFire) && !isCasting)
		{
			if (!(Time.time <= nextFire + 0.5f))
			{
				c = 0;
			}
			if (attackCombo.Length >= 1)
			{
				conCombo++;
				StartCoroutine(AttackCombo());
			}
		}
		if (Input.GetButtonDown("Fire2") && !(Time.time <= nextFire) && !isCasting && (bool)skillPrefab[skillEquip] && !status.silence)
		{
			StartCoroutine(MagicSkill(skillEquip));
		}
		if (Input.GetKeyDown("1") && !isCasting && (bool)skillPrefab[0])
		{
			skillEquip = 0;
		}
		if (Input.GetKeyDown("2") && !isCasting && (bool)skillPrefab[1])
		{
			skillEquip = 1;
		}
		if (Input.GetKeyDown("3") && !isCasting && (bool)skillPrefab[2])
		{
			skillEquip = 2;
		}
	}

	public  void OnGUI()
	{
		if (aimingType == AimType.Normal)
		{
			GUI.DrawTexture(new Rect(Screen.width / 2 - 16, Screen.height / 2 - 90, aimIconSize, aimIconSize), aimIcon);
		}
		if (aimingType == AimType.Raycast)
		{
			GUI.DrawTexture(new Rect(Screen.width / 2 - 20, Screen.height / 2 - 20, 40f, 40f), aimIcon);
		}
		if ((bool)skillPrefab[skillEquip] && (bool)skillIcon[skillEquip])
		{
			GUI.DrawTexture(new Rect(Screen.width - skillIconSize - 28, Screen.height - skillIconSize - 20, skillIconSize, skillIconSize), skillIcon[skillEquip]);
		}
		if ((bool)skillPrefab[0] && (bool)skillIcon[0])
		{
			GUI.DrawTexture(new Rect(Screen.width - skillIconSize - 50, Screen.height - skillIconSize - 50, skillIconSize / 2, skillIconSize / 2), skillIcon[0]);
		}
		if ((bool)skillPrefab[1] && (bool)skillIcon[1])
		{
			GUI.DrawTexture(new Rect(Screen.width - skillIconSize - 10, Screen.height - skillIconSize - 60, skillIconSize / 2, skillIconSize / 2), skillIcon[1]);
		}
		if ((bool)skillPrefab[2] && (bool)skillIcon[2])
		{
			GUI.DrawTexture(new Rect(Screen.width - skillIconSize + 30, Screen.height - skillIconSize - 50, skillIconSize / 2, skillIconSize / 2), skillIcon[2]);
		}
	}

	public  IEnumerator AttackCombo()
	{
		return new _0024AttackCombo_0024148(this).GetEnumerator();
	}

	public  IEnumerator MeleeDash()
	{
		return new _0024MeleeDash_0024154(this).GetEnumerator();
	}

	public  IEnumerator MagicSkill(int skillID)
	{
		return new _0024MagicSkill_0024157(skillID, this).GetEnumerator();
	}

	public  void Flinch(Vector3 dir)
	{
		knock = dir;
		if ((bool)sound.hurtVoice && ((Status)GetComponent(typeof(Status))).health >= 1)
		{
			GetComponent<AudioSource>().clip = sound.hurtVoice;
			GetComponent<AudioSource>().Play();
		}
		((CharacterMotor)GetComponent(typeof(CharacterMotor))).canControl = false;
		StartCoroutine(KnockBack());
		if (!useMecanim)
		{
			mainModel.GetComponent<Animation>().PlayQueued(hurt.name, QueueMode.PlayNow);
		}
		((CharacterMotor)GetComponent(typeof(CharacterMotor))).canControl = true;
	}

	public  IEnumerator KnockBack()
	{
		return new _0024KnockBack_0024165(this).GetEnumerator();
	}

	public  void Aiming()
	{
		Ray ray = Maincam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		RaycastHit hitInfo = default(RaycastHit);
		if (Physics.Raycast(ray, out hitInfo))
		{
			attackPoint.transform.LookAt(hitInfo.point);
		}
		else
		{
			attackPoint.transform.rotation = Maincam.transform.rotation;
		}
	}

	public  void Main()
	{
	}
}
