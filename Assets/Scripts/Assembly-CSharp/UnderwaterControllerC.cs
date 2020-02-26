using System;
using UnityEngine;

// Token: 0x0200009D RID: 157
[RequireComponent(typeof(PlayerInputControllerC))]
public class UnderwaterControllerC : MonoBehaviour
{
	// Token: 0x0600049C RID: 1180 RVA: 0x00024640 File Offset: 0x00022A40
	private void Start()
	{
		this.motor = base.GetComponent<CharacterMotorC>();
		this.useMecanim = base.GetComponent<AttackTriggerC>().useMecanim;
		this.mainModel = base.GetComponent<AttackTriggerC>().mainModel;
		if (!this.mainModel)
		{
			this.mainModel = base.gameObject;
		}
		this.mainCam = base.GetComponent<AttackTriggerC>().Maincam.gameObject;
		if (!this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>()[this.swimForward.name].speed = this.animationSpeed;
			this.mainModel.GetComponent<Animation>()[this.swimRight.name].speed = this.animationSpeed;
			this.mainModel.GetComponent<Animation>()[this.swimLeft.name].speed = this.animationSpeed;
			this.mainModel.GetComponent<Animation>()[this.swimBack.name].speed = this.animationSpeed;
		}
		else
		{
			this.animator = base.GetComponent<PlayerMecanimAnimationC>().animator;
			this.moveHorizontalState = base.GetComponent<PlayerMecanimAnimationC>().moveHorizontalState;
			this.moveVerticalState = base.GetComponent<PlayerMecanimAnimationC>().moveVerticalState;
			this.jumpState = base.GetComponent<PlayerMecanimAnimationC>().jumpState;
		}
	}

	// Token: 0x0600049D RID: 1181 RVA: 0x0002479C File Offset: 0x00022B9C
	private void Update()
	{
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
		CharacterController component2 = base.GetComponent<CharacterController>();
		float y;
		if (Input.GetButton("Jump"))
		{
			y = 2f;
		}
		else
		{
			y = 0f;
		}
		Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), y, Input.GetAxis("Vertical"));
		if (vector != Vector3.zero)
		{
			float num = vector.magnitude;
			vector /= num;
			num = Mathf.Min(1f, num);
			num *= num;
			vector *= num;
		}
		if ((Input.GetAxis("Vertical") != 0f && base.transform.position.y < this.surfaceExit) || (base.transform.position.y >= this.surfaceExit && Input.GetAxis("Vertical") > 0f && this.mainCam.transform.eulerAngles.x >= 25f && this.mainCam.transform.eulerAngles.x <= 180f))
		{
			base.transform.rotation = this.mainCam.transform.rotation;
		}
		component2.Move(base.transform.rotation * vector * this.swimSpeed * Time.deltaTime);
		if (!this.useMecanim)
		{
			if ((double)Input.GetAxis("Horizontal") > 0.1)
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.swimRight.name);
			}
			else if ((double)Input.GetAxis("Horizontal") < -0.1)
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.swimLeft.name);
			}
			else if ((double)Input.GetAxis("Vertical") > 0.1)
			{
				this.mainModel.GetComponent<Animation>().CrossFade(this.swimForward.name);
			}
			else if ((double)Input.GetAxis("Vertical") < -0.1)
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

	// Token: 0x0600049E RID: 1182 RVA: 0x00024AB0 File Offset: 0x00022EB0
	public void MecanimEnterWater()
	{
		this.useMecanim = base.GetComponent<AttackTriggerC>().useMecanim;
		this.animator = base.GetComponent<PlayerMecanimAnimationC>().animator;
		this.animator.SetBool(this.jumpState, false);
		this.animator.SetBool("swimming", true);
		this.animator.Play(this.swimIdle.name);
	}

	// Token: 0x0600049F RID: 1183 RVA: 0x00024B18 File Offset: 0x00022F18
	public void MecanimExitWater()
	{
		this.animator.SetBool("swimming", false);
		this.animator.SetBool(this.jumpState, true);
		this.animator.Play(this.jumpState);
	}

	// Token: 0x040004B7 RID: 1207
	private CharacterMotorC motor;

	// Token: 0x040004B8 RID: 1208
	public float swimSpeed = 5f;

	// Token: 0x040004B9 RID: 1209
	private GameObject mainModel;

	// Token: 0x040004BA RID: 1210
	private GameObject mainCam;

	// Token: 0x040004BB RID: 1211
	public AnimationClip swimIdle;

	// Token: 0x040004BC RID: 1212
	public AnimationClip swimForward;

	// Token: 0x040004BD RID: 1213
	public AnimationClip swimRight;

	// Token: 0x040004BE RID: 1214
	public AnimationClip swimLeft;

	// Token: 0x040004BF RID: 1215
	public AnimationClip swimBack;

	// Token: 0x040004C0 RID: 1216
	public float animationSpeed = 1f;

	// Token: 0x040004C1 RID: 1217
	[HideInInspector]
	public float surfaceExit;

	// Token: 0x040004C2 RID: 1218
	private bool useMecanim;

	// Token: 0x040004C3 RID: 1219
	private Animator animator;

	// Token: 0x040004C4 RID: 1220
	private string moveHorizontalState = "horizontal";

	// Token: 0x040004C5 RID: 1221
	private string moveVerticalState = "vertical";

	// Token: 0x040004C6 RID: 1222
	private string jumpState = "jump";
}
