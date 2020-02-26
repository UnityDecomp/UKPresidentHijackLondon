using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200007C RID: 124
[RequireComponent(typeof(CharacterMotorC))]
public class PlayerInputControllerC : MonoBehaviour
{
	// Token: 0x060003E1 RID: 993 RVA: 0x00018538 File Offset: 0x00016938
	private void Start()
	{
		this.stick = (UnityEngine.Object.FindObjectOfType(typeof(EasyJoystick)) as EasyJoystick);
		this.eats = false;
		this.runr = false;
		this.tutorial = false;
		if (this.home)
		{
			this.maleSleepPos = this.home.Find("MALE").transform;
			this.femaleSleepPos = this.home.Find("FEMALE").transform;
		}
		this.motor = base.GetComponent<CharacterMotorC>();
		this.controller = base.GetComponent<CharacterController>();
		this.stamina = this.maxStamina;
		if (!this.mainModel)
		{
			this.mainModel = base.GetComponent<StatusC>().mainModel;
		}
		this.useMecanim = base.GetComponent<AttackTriggerC>().useMecanim;
		this.guiFunc = (UnityEngine.Object.FindObjectOfType(typeof(GUIFunctions)) as GUIFunctions);
		this.daynight = (UnityEngine.Object.FindObjectOfType(typeof(DayNight)) as DayNight);
		this.questM = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
		this.freeQ = (UnityEngine.Object.FindObjectOfType(typeof(FreeQuests)) as FreeQuests);
		this.respawnScript = (UnityEngine.Object.FindObjectOfType(typeof(RespawnMonsterC)) as RespawnMonsterC);
		this.aifriend = (UnityEngine.Object.FindObjectOfType(typeof(AIfriendC)) as AIfriendC);
		this.colQuest = (UnityEngine.Object.FindObjectOfType(typeof(CollectionQuest)) as CollectionQuest);
		this.pointAndDest = (UnityEngine.Object.FindObjectOfType(typeof(PointsAndDestinations)) as PointsAndDestinations);
		this.underWater = (UnityEngine.Object.FindObjectOfType(typeof(UnderWaterSystem)) as UnderWaterSystem);
		this.HomePopUp.gameObject.SetActive(false);
		this.mate = this.questM.mate;
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x0001871C File Offset: 0x00016B1C
	public void Sleep()
	{
		this.showHomePopUp = false;
		base.StartCoroutine(this.SleepRoutine());
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x00018734 File Offset: 0x00016B34
	private IEnumerator SleepRoutineForChild1()
	{
		this.daynight.startNight();
		base.GetComponent<CharacterMotorC>().canControl = false;
		yield return new WaitForSeconds(5f);
		this.questM.counter = 1;
		this.daynight.startDay();
		this.questM.enableChild1();
		yield break;
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x00018750 File Offset: 0x00016B50
	private IEnumerator SleepRoutineForChild2()
	{
		this.daynight.startNight();
		base.GetComponent<CharacterMotorC>().canControl = false;
		yield return new WaitForSeconds(5f);
		this.questM.counter = 1;
		this.daynight.startDay();
		this.questM.enableChild2();
		yield break;
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x0001876C File Offset: 0x00016B6C
	private IEnumerator SleepRoutine()
	{
		this.moveSleep = true;
		yield return new WaitForSeconds(2f);
		this.moveSleep = false;
		base.GetComponent<PlayerMecanimAnimationC>().PlaySleepAnim();
		if (this.mate)
		{
			this.mate.GetComponent<AIfriendC>().mainModel.GetComponent<Animator>().Play("S_Going_asleep");
		}
		this.questM.hideGUI();
		base.GetComponent<NewHealthBarC>().allowHunger = false;
		yield return new WaitForSeconds(10f);
		base.GetComponent<PlayerMecanimAnimationC>().PlayWakeAnim();
		if (this.mate)
		{
			this.mate.GetComponent<AIfriendC>().mainModel.GetComponent<Animator>().Play("S_Waking_up");
		}
		yield return new WaitForSeconds(3f);
		base.GetComponent<NewHealthBarC>().allowHunger = true;
		this.questM.showGUI();
		yield break;
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x00018788 File Offset: 0x00016B88
	private void Update()
	{
		this.stick = (UnityEngine.Object.FindObjectOfType(typeof(EasyJoystick)) as EasyJoystick);
		if (CFInput.GetButton("Eat") && this.eats && this.questM.Eatbar())
		{
			if (base.GetComponent<AttackTriggerC>().useMecanim)
			{
				this.mainModel.GetComponent<Animator>().CrossFade(this.EatingAnim, 0.5f);
			}
			else
			{
				this.mainModel.GetComponent<Animation>()[this.EatingAnim].layer = 25;
				this.mainModel.GetComponent<Animation>().CrossFade(this.EatingAnim);
			}
		}
		if (this.moveSleep && this.maleSleepPos && this.femaleSleepPos)
		{
			this.mate.transform.position = Vector3.MoveTowards(this.mate.transform.position, this.femaleSleepPos.position, 0.1f);
			base.transform.position = Vector3.MoveTowards(base.transform.position, this.maleSleepPos.position, 0.1f);
		}
		if (this.rotating)
		{
			this._lookRotation = Quaternion.LookRotation(this._direction);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this._lookRotation, Time.deltaTime * this.RotationSpeed);
		}
		StatusC component = base.GetComponent<StatusC>();
		if (component.freeze)
		{
			this.motor.inputMoveDirection = new Vector3(0f, 0f, 0f);
			return;
		}
		if (Time.timeScale == 0f)
		{
			return;
		}
		if (this.dodging)
		{
			Vector3 a = base.transform.TransformDirection(this.dir);
			this.controller.Move(a * 8f * Time.deltaTime);
			return;
		}
		if (this.recover && !this.sprint && !this.dodging)
		{
			if (this.recoverStamina >= this.staminaRecover)
			{
				this.StaminaRecovery();
			}
			else
			{
				this.recoverStamina += Time.deltaTime;
			}
		}
		if (this.dodgeRollSetting.canDodgeRoll)
		{
			if (CFInput.GetButtonDown("Vertical") && CFInput.GetAxis("Vertical") > 0f && (this.controller.collisionFlags & CollisionFlags.Below) != CollisionFlags.None && CFInput.GetAxis("Horizontal") == 0f)
			{
				if (CFInput.GetButtonDown("Vertical") && Time.time - this.lastTime < 0.4f && CFInput.GetButtonDown("Vertical") && Time.time - this.lastTime > 0.1f && CFInput.GetAxis("Vertical") > 0.03f)
				{
					this.lastTime = Time.time;
					this.dir = Vector3.forward;
					base.StartCoroutine(this.DodgeRoll(this.dodgeRollSetting.dodgeForward));
				}
				else
				{
					this.lastTime = Time.time;
				}
			}
			if (CFInput.GetButtonDown("Vertical") && CFInput.GetAxis("Vertical") < 0f && (this.controller.collisionFlags & CollisionFlags.Below) != CollisionFlags.None && CFInput.GetAxis("Horizontal") == 0f)
			{
				if (CFInput.GetButtonDown("Vertical") && Time.time - this.lastTime < 0.4f && CFInput.GetButtonDown("Vertical") && Time.time - this.lastTime > 0.1f && CFInput.GetAxis("Vertical") < -0.03f)
				{
					this.lastTime = Time.time;
					this.dir = Vector3.back;
					base.StartCoroutine(this.DodgeRoll(this.dodgeRollSetting.dodgeBack));
				}
				else
				{
					this.lastTime = Time.time;
				}
			}
			if (CFInput.GetButtonDown("Horizontal") && CFInput.GetAxis("Horizontal") < 0f && (this.controller.collisionFlags & CollisionFlags.Below) != CollisionFlags.None && !CFInput.GetButton("Vertical"))
			{
				if (CFInput.GetButtonDown("Horizontal") && Time.time - this.lastTime < 0.3f && CFInput.GetButtonDown("Horizontal") && Time.time - this.lastTime > 0.15f && CFInput.GetAxis("Horizontal") < -0.03f)
				{
					this.lastTime = Time.time;
					this.dir = Vector3.left;
					base.StartCoroutine(this.DodgeRoll(this.dodgeRollSetting.dodgeLeft));
				}
				else
				{
					this.lastTime = Time.time;
				}
			}
			if (CFInput.GetButtonDown("Horizontal") && CFInput.GetAxis("Horizontal") > 0f && (this.controller.collisionFlags & CollisionFlags.Below) != CollisionFlags.None && !CFInput.GetButton("Vertical"))
			{
				if (CFInput.GetButtonDown("Horizontal") && Time.time - this.lastTime < 0.3f && CFInput.GetButtonDown("Horizontal") && Time.time - this.lastTime > 0.15f && CFInput.GetAxis("Horizontal") > 0.03f)
				{
					this.lastTime = Time.time;
					this.dir = Vector3.right;
					base.StartCoroutine(this.DodgeRoll(this.dodgeRollSetting.dodgeRight));
				}
				else
				{
					this.lastTime = Time.time;
				}
			}
		}
		if ((this.sprint && Input.GetAxis("Vertical") < 0.02f) || (this.sprint && this.stamina <= 0f) || (this.sprint && Input.GetButtonDown("Fire1")) || (this.sprint && Input.GetKeyUp(KeyCode.LeftShift)))
		{
			this.sprint = false;
			this.recover = true;
			this.motor.movement.maxForwardSpeed = this.walkSpeed;
			this.motor.movement.maxSidewaysSpeed = this.walkSpeed;
			this.recoverStamina = 0f;
		}
		Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		if (vector != Vector3.zero)
		{
			float num = vector.magnitude;
			vector /= num;
			num = Mathf.Min(1f, num);
			num *= num;
			vector *= num;
		}
		this.motor.inputMoveDirection = base.transform.rotation * vector;
		if (CFInput.GetButton("Jump") && !this.alwJump)
		{
			base.GetComponent<PlayerMecanimAnimationC>().PlayAnim("jump");
			base.GetComponent<PlayerMecanimAnimationC>().PlayAnim("Jump_place_All_short");
			base.StartCoroutine(this.jumping());
		}
		this.motor.inputJump = CFInput.GetButton("Jump");
		if (this.sprint)
		{
			this.motor.movement.maxForwardSpeed = this.sprintSpeed;
			this.motor.movement.maxSidewaysSpeed = this.sprintSpeed;
			return;
		}
		if (CFInput.GetButton("Sprint") && Input.GetAxis("Vertical") > 0f && (this.controller.collisionFlags & CollisionFlags.Below) != CollisionFlags.None && this.canSprint && this.stamina > 0f)
		{
			this.sprint = true;
			base.StartCoroutine(this.Dasher());
		}
		if (CFInput.GetButton("Sprint"))
		{
		}
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x00018FB0 File Offset: 0x000173B0
	private IEnumerator jumping()
	{
		this.alwJump = true;
		yield return new WaitForSeconds(0.5f);
		this.alwJump = false;
		yield break;
	}

	// Token: 0x060003E8 RID: 1000 RVA: 0x00018FCC File Offset: 0x000173CC
	private void OnGUI()
	{
		if (this.questM.getQuestID() > 2)
		{
			if (this.showHomePopUp)
			{
				this.HomePopUp.gameObject.SetActive(true);
			}
			else
			{
				this.HomePopUp.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x060003E9 RID: 1001 RVA: 0x0001901C File Offset: 0x0001741C
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.collider.tag == "Dragable")
		{
			hit.gameObject.GetComponent<Rigidbody>().AddForce(base.transform.forward * 20f);
		}
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x00019068 File Offset: 0x00017468
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "HomeCollider")
		{
			this.showHomePopUp = true;
		}
		if (other.gameObject.name == "Surface")
		{
			this.underWater.hideSwimPanel();
		}
		if (other.gameObject.name == "WaterCollide")
		{
			this.questM.players[gameplay.count].GetComponent<StatusC>().Death();
		}
		if (other.gameObject.tag == "Trigger")
		{
			if (other.gameObject.name == "CameraTrigger")
			{
				this.disableFpsCam();
			}
			if (other.gameObject.name == "Jail" || other.gameObject.name == "Jail2" || other.gameObject.name == "Jail3" || other.gameObject.name == "Jail4" || other.gameObject.name == "Jail5")
			{
				this.pointAndDest.showNext(other.gameObject);
			}
			other.gameObject.SetActive(false);
		}
		if (other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
			GameObject gameObject = other.gameObject;
			if (other.gameObject.name == "Rifle(Clone)")
			{
				this.questM.panelInteract.gameObject.SetActive(true);
				base.GetComponent<AttackTriggerC>().changeWeaponMode();
			}
			if (this.useMecanim)
			{
				base.GetComponent<PlayerMecanimAnimationC>().PlayPickUpAnim();
				this.questM.GetComponent<dogsactive>().getActiveJoystick().GetComponent<EasyJoystick>().speed.y = 0f;
				base.StartCoroutine(this.picked(gameObject));
			}
		}
		if (other.gameObject.name == "Destination")
		{
			this.questM.counter = 1;
			other.gameObject.SetActive(false);
			if (this.questM.getQuestID() == 3)
			{
				this.questM.zone4enemies.SetActive(false);
			}
		}
		if (other.gameObject.tag == "Food")
		{
			this.colQuest.gotOne(other.gameObject);
			this.questM.consumed(other.gameObject.tag);
			UnityEngine.Object.Destroy(other.gameObject);
		}
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x00019319 File Offset: 0x00017719
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "HomeCollider")
		{
			this.showHomePopUp = false;
		}
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x0001933C File Offset: 0x0001773C
	private IEnumerator picked(GameObject pickedObject)
	{
		yield return new WaitForSeconds(0.8f);
		if (pickedObject.GetComponent<PickUpItemType>().itemType == PickUpItemType.ItemType.Food)
		{
			if (this.useMecanim)
			{
				base.GetComponent<PlayerMecanimAnimationC>().PlayEatAnim();
			}
			base.GetComponent<WeaponSwitch>().activateEquipmentForTime(1, 2f, true);
			base.GetComponent<NewHealthBarC>().fillHunger(20f);
			this.checkIfFoodQuest();
			yield return new WaitForSeconds(2f);
		}
		if (pickedObject.GetComponent<PickUpItemType>().itemType == PickUpItemType.ItemType.Wood)
		{
			this.checkIfPickObjectQuest();
			yield return new WaitForSeconds(1f);
		}
		if (pickedObject.GetComponent<PickUpItemType>().itemType == PickUpItemType.ItemType.Ingredient)
		{
			yield return new WaitForSeconds(1f);
		}
		if (pickedObject.GetComponent<PickUpItemType>().itemType == PickUpItemType.ItemType.Weapon)
		{
			base.GetComponent<WeaponSwitch>().saveWeapon(pickedObject.GetComponent<PickUpItemType>().itemID);
			for (int i = 0; i < base.GetComponent<WeaponSwitch>().weaponsOnHand.Length; i++)
			{
				if (pickedObject.name == base.GetComponent<WeaponSwitch>().weaponsOnHand[i].name)
				{
					base.GetComponent<WeaponSwitch>().weaponsOnHand[i].SetActive(true);
				}
				else
				{
					base.GetComponent<WeaponSwitch>().weaponsOnHand[i].SetActive(false);
				}
			}
			yield return new WaitForSeconds(1f);
		}
		if (pickedObject.name == "Baton")
		{
			this.questM.CFPP.GetComponent<TouchController>().touchZones[0].Enable(true);
		}
		UnityEngine.Object.Destroy(pickedObject);
		this.questM.GetComponent<dogsactive>().getActiveJoystick().GetComponent<EasyJoystick>().speed.y = 8f;
		yield break;
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x00019360 File Offset: 0x00017760
	private IEnumerator Dasher()
	{
		while (this.sprint)
		{
			yield return new WaitForSeconds(this.useStamina);
			if (this.stamina > 0f)
			{
				this.stamina -= 1f;
			}
			else
			{
				this.stamina = 0f;
			}
		}
		yield break;
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x0001937B File Offset: 0x0001777B
	private void checkIfFoodQuest()
	{
		if (PlayerPrefs.GetInt("Quest") == 3 || PlayerPrefs.GetInt("Quest") == 12)
		{
			this.questM.consumed("Apple");
		}
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x000193AE File Offset: 0x000177AE
	private void checkIfPickObjectQuest()
	{
		if (PlayerPrefs.GetInt("Quest") == 4)
		{
			this.questM.consumed("Log");
		}
	}

	// Token: 0x060003F0 RID: 1008 RVA: 0x000193D0 File Offset: 0x000177D0
	private void StaminaRecovery()
	{
		this.stamina += 1f;
		if (this.stamina >= this.maxStamina)
		{
			this.stamina = this.maxStamina;
			this.recoverStamina = 0f;
			this.recover = false;
		}
		else
		{
			this.recoverStamina = this.staminaRecover - 0.02f;
		}
	}

	// Token: 0x060003F1 RID: 1009 RVA: 0x00019438 File Offset: 0x00017838
	private IEnumerator DodgeRoll(AnimationClip anim)
	{
		if (this.stamina < 25f || this.dodging)
		{
			yield return false;
		}
		if (!this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>()[anim.name].layer = 18;
			this.mainModel.GetComponent<Animation>().PlayQueued(anim.name, QueueMode.PlayNow);
		}
		else
		{
			base.GetComponent<PlayerMecanimAnimationC>().AttackAnimation(anim.name);
		}
		this.dodging = true;
		this.stamina -= (float)this.dodgeRollSetting.staminaUse;
		base.GetComponent<StatusC>().dodge = true;
		this.motor.canControl = false;
		yield return new WaitForSeconds(0.5f);
		base.GetComponent<StatusC>().dodge = false;
		this.recover = true;
		this.motor.canControl = true;
		this.dodging = false;
		this.recoverStamina = 0f;
		yield break;
	}

	// Token: 0x060003F2 RID: 1010 RVA: 0x0001945A File Offset: 0x0001785A
	public void rotateTowards(Transform direction)
	{
		this._direction = direction.position;
		base.StartCoroutine(this.rotateDelay());
	}

	// Token: 0x060003F3 RID: 1011 RVA: 0x00019475 File Offset: 0x00017875
	public void enableFpsCam()
	{
		base.GetComponent<AttackTriggerC>().playerCam.gameObject.SetActive(false);
		this.fpsCam.gameObject.SetActive(true);
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x0001949E File Offset: 0x0001789E
	public void disableFpsCam()
	{
		base.GetComponent<AttackTriggerC>().playerCam.gameObject.SetActive(true);
		this.fpsCam.gameObject.SetActive(false);
	}

	// Token: 0x060003F5 RID: 1013 RVA: 0x000194C8 File Offset: 0x000178C8
	private IEnumerator rotateDelay()
	{
		this.rotating = true;
		yield return new WaitForSeconds(2f);
		this.rotating = false;
		yield break;
	}

	// Token: 0x0400036A RID: 874
	[HideInInspector]
	public GameObject mainModel;

	// Token: 0x0400036B RID: 875
	public GameObject fpsCam;

	// Token: 0x0400036C RID: 876
	private bool showHomePopUp;

	// Token: 0x0400036D RID: 877
	public float walkSpeed = 6f;

	// Token: 0x0400036E RID: 878
	public float sprintSpeed = 12f;

	// Token: 0x0400036F RID: 879
	public bool canSprint = true;

	// Token: 0x04000370 RID: 880
	public bool sprint;

	// Token: 0x04000371 RID: 881
	private bool recover;

	// Token: 0x04000372 RID: 882
	private float staminaRecover = 1.4f;

	// Token: 0x04000373 RID: 883
	private float useStamina = 0.04f;

	// Token: 0x04000374 RID: 884
	public bool eats;

	// Token: 0x04000375 RID: 885
	public bool runr;

	// Token: 0x04000376 RID: 886
	private Vector3 _direction;

	// Token: 0x04000377 RID: 887
	private bool rotating;

	// Token: 0x04000378 RID: 888
	[HideInInspector]
	public bool dodging;

	// Token: 0x04000379 RID: 889
	private GameObject chosenFood;

	// Token: 0x0400037A RID: 890
	public bool alwJump;

	// Token: 0x0400037B RID: 891
	public Texture2D staminaGauge;

	// Token: 0x0400037C RID: 892
	public Texture2D staminaBorder;

	// Token: 0x0400037D RID: 893
	public Image HomePopUp;

	// Token: 0x0400037E RID: 894
	private QuestManager questM;

	// Token: 0x0400037F RID: 895
	private AIfriendC aifriend;

	// Token: 0x04000380 RID: 896
	private CollectionQuest colQuest;

	// Token: 0x04000381 RID: 897
	private FreeQuests freeQ;

	// Token: 0x04000382 RID: 898
	public EasyJoystick stick;

	// Token: 0x04000383 RID: 899
	private bool moveSleep;

	// Token: 0x04000384 RID: 900
	public Transform home;

	// Token: 0x04000385 RID: 901
	private Transform maleSleepPos;

	// Token: 0x04000386 RID: 902
	private Transform femaleSleepPos;

	// Token: 0x04000387 RID: 903
	private GameObject mate;

	// Token: 0x04000388 RID: 904
	public string EatingAnim = "Enter Anim Name";

	// Token: 0x04000389 RID: 905
	public float maxStamina = 1f;

	// Token: 0x0400038A RID: 906
	public float stamina = 1f;

	// Token: 0x0400038B RID: 907
	private float lastTime;

	// Token: 0x0400038C RID: 908
	private float recoverStamina;

	// Token: 0x0400038D RID: 909
	private Vector3 dir = Vector3.forward;

	// Token: 0x0400038E RID: 910
	private GUIFunctions guiFunc;

	// Token: 0x0400038F RID: 911
	private RespawnMonsterC respawnScript;

	// Token: 0x04000390 RID: 912
	private DayNight daynight;

	// Token: 0x04000391 RID: 913
	private PointsAndDestinations pointAndDest;

	// Token: 0x04000392 RID: 914
	private UnderWaterSystem underWater;

	// Token: 0x04000393 RID: 915
	private float RotationSpeed = 1f;

	// Token: 0x04000394 RID: 916
	private Quaternion _lookRotation;

	// Token: 0x04000395 RID: 917
	[HideInInspector]
	public bool tutorial = true;

	// Token: 0x04000396 RID: 918
	[HideInInspector]
	public int tutorialprogress;

	// Token: 0x04000397 RID: 919
	private bool useMecanim = true;

	// Token: 0x04000398 RID: 920
	public PlayerInputControllerC.DodgeSetting dodgeRollSetting;

	// Token: 0x04000399 RID: 921
	private static bool running;

	// Token: 0x0400039A RID: 922
	private CharacterMotorC motor;

	// Token: 0x0400039B RID: 923
	private CharacterController controller;

	// Token: 0x0400039C RID: 924
	private bool waiting;

	// Token: 0x0200007D RID: 125
	[Serializable]
	public class DodgeSetting
	{
		// Token: 0x0400039D RID: 925
		public bool canDodgeRoll;

		// Token: 0x0400039E RID: 926
		public int staminaUse = 25;

		// Token: 0x0400039F RID: 927
		public AnimationClip dodgeForward;

		// Token: 0x040003A0 RID: 928
		public AnimationClip dodgeLeft;

		// Token: 0x040003A1 RID: 929
		public AnimationClip dodgeRight;

		// Token: 0x040003A2 RID: 930
		public AnimationClip dodgeBack;
	}
}
