using System;
using UnityEngine;

// Token: 0x020000AC RID: 172
[RequireComponent(typeof(PlayerInputController))]
[Serializable]
public class UnderwaterController : MonoBehaviour
{
	// Token: 0x06000255 RID: 597 RVA: 0x0001D67C File Offset: 0x0001B87C
	public UnderwaterController()
	{
		this.swimSpeed = 5f;
		this.animationSpeed = 1f;
		this.moveHorizontalState = "horizontal";
		this.moveVerticalState = "vertical";
		this.jumpState = "jump";
	}

	// Token: 0x06000256 RID: 598 RVA: 0x0001D6BC File Offset: 0x0001B8BC
	public virtual void Start()
	{
		this.motor = (CharacterMotor)this.GetComponent(typeof(CharacterMotor));
		this.useMecanim = ((AttackTrigger)this.GetComponent(typeof(AttackTrigger))).useMecanim;
		this.mainModel = ((AttackTrigger)this.GetComponent(typeof(AttackTrigger))).mainModel;
		if (!this.mainModel)
		{
			this.mainModel = this.gameObject;
		}
		this.mainCam = ((AttackTrigger)this.GetComponent(typeof(AttackTrigger))).Maincam.gameObject;
		if (!this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>()[this.swimForward.name].speed = this.animationSpeed;
			this.mainModel.GetComponent<Animation>()[this.swimRight.name].speed = this.animationSpeed;
			this.mainModel.GetComponent<Animation>()[this.swimLeft.name].speed = this.animationSpeed;
			this.mainModel.GetComponent<Animation>()[this.swimBack.name].speed = this.animationSpeed;
		}
		else
		{
			this.animator = ((PlayerMecanimAnimation)this.GetComponent(typeof(PlayerMecanimAnimation))).animator;
			this.moveHorizontalState = ((PlayerMecanimAnimation)this.GetComponent(typeof(PlayerMecanimAnimation))).moveHorizontalState;
			this.moveVerticalState = ((PlayerMecanimAnimation)this.GetComponent(typeof(PlayerMecanimAnimation))).moveVerticalState;
			this.jumpState = ((PlayerMecanimAnimation)this.GetComponent(typeof(PlayerMecanimAnimation))).jumpState;
		}
	}

	// Token: 0x06000257 RID: 599 RVA: 0x0001D890 File Offset: 0x0001BA90
	public virtual void Update()
	{
		Status status = (Status)this.GetComponent(typeof(Status));
		if (status.freeze)
		{
			this.motor.inputMoveDirection = new Vector3((float)0, (float)0, (float)0);
		}
		else if (Time.timeScale != (float)0)
		{
			CharacterController characterController = (CharacterController)this.GetComponent(typeof(CharacterController));
			float y = 0f;
			if (Input.GetButton("Jump"))
			{
				y = 2f;
			}
			else
			{
				y = (float)0;
			}
			Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), y, Input.GetAxis("Vertical"));
			if (vector != Vector3.zero)
			{
				float num = vector.magnitude;
				vector /= num;
				num = Mathf.Min((float)1, num);
				num *= num;
				vector *= num;
			}
			if ((Input.GetAxis("Vertical") != (float)0 && this.transform.position.y < this.surfaceExit) || (this.transform.position.y >= this.surfaceExit && Input.GetAxis("Vertical") > (float)0 && this.mainCam.transform.eulerAngles.x >= (float)25 && this.mainCam.transform.eulerAngles.x <= (float)180))
			{
				this.transform.rotation = this.mainCam.transform.rotation;
			}
			characterController.Move(this.transform.rotation * vector * this.swimSpeed * Time.deltaTime);
			if (!this.useMecanim)
			{
				if (Input.GetAxis("Horizontal") > 0.1f)
				{
					this.mainModel.GetComponent<Animation>().CrossFade(this.swimRight.name);
				}
				else if (Input.GetAxis("Horizontal") < -0.1f)
				{
					this.mainModel.GetComponent<Animation>().CrossFade(this.swimLeft.name);
				}
				else if (Input.GetAxis("Vertical") > 0.1f)
				{
					this.mainModel.GetComponent<Animation>().CrossFade(this.swimForward.name);
				}
				else if (Input.GetAxis("Vertical") < -0.1f)
				{
					this.mainModel.GetComponent<Animation>().CrossFade(this.swimBack.name);
				}
				else
				{
					this.mainModel.GetComponent<Animation>().CrossFade(this.swimIdle.name);
				}
			}
			else
			{
				float axis = Input.GetAxis("Horizontal");
				float axis2 = Input.GetAxis("Vertical");
				this.animator.SetFloat(this.moveHorizontalState, axis);
				this.animator.SetFloat(this.moveVerticalState, axis2);
			}
		}
	}

	// Token: 0x06000258 RID: 600 RVA: 0x0001DBA4 File Offset: 0x0001BDA4
	public virtual void MecanimEnterWater()
	{
		this.useMecanim = ((AttackTrigger)this.GetComponent(typeof(AttackTrigger))).useMecanim;
		this.animator = ((PlayerMecanimAnimation)this.GetComponent(typeof(PlayerMecanimAnimation))).animator;
		this.animator.SetBool(this.jumpState, false);
		this.animator.SetBool("swimming", true);
		this.animator.Play(this.swimIdle.name);
	}

	// Token: 0x06000259 RID: 601 RVA: 0x0001DC2C File Offset: 0x0001BE2C
	public virtual void MecanimExitWater()
	{
		this.animator.SetBool("swimming", false);
		this.animator.SetBool(this.jumpState, true);
		this.animator.Play(this.jumpState);
	}

	// Token: 0x0600025A RID: 602 RVA: 0x0001DC70 File Offset: 0x0001BE70
	public virtual void Main()
	{
	}

	// Token: 0x040003D7 RID: 983
	private CharacterMotor motor;

	// Token: 0x040003D8 RID: 984
	public float swimSpeed;

	// Token: 0x040003D9 RID: 985
	private GameObject mainModel;

	// Token: 0x040003DA RID: 986
	private GameObject mainCam;

	// Token: 0x040003DB RID: 987
	public AnimationClip swimIdle;

	// Token: 0x040003DC RID: 988
	public AnimationClip swimForward;

	// Token: 0x040003DD RID: 989
	public AnimationClip swimRight;

	// Token: 0x040003DE RID: 990
	public AnimationClip swimLeft;

	// Token: 0x040003DF RID: 991
	public AnimationClip swimBack;

	// Token: 0x040003E0 RID: 992
	public float animationSpeed;

	// Token: 0x040003E1 RID: 993
	[HideInInspector]
	public float surfaceExit;

	// Token: 0x040003E2 RID: 994
	private bool useMecanim;

	// Token: 0x040003E3 RID: 995
	private Animator animator;

	// Token: 0x040003E4 RID: 996
	private string moveHorizontalState;

	// Token: 0x040003E5 RID: 997
	private string moveVerticalState;

	// Token: 0x040003E6 RID: 998
	private string jumpState;
}
