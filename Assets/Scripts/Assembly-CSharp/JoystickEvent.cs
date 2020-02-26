using System;
using UnityEngine;

// Token: 0x020000A2 RID: 162
public class JoystickEvent : MonoBehaviour
{
	// Token: 0x060004B1 RID: 1201 RVA: 0x00025284 File Offset: 0x00023684
	private void Start()
	{
		this.footprint = (UnityEngine.Object.FindObjectOfType(typeof(FootprintSystem)) as FootprintSystem);
		this.underSwim = (UnityEngine.Object.FindObjectOfType(typeof(UnderWaterSystem)) as UnderWaterSystem);
		this.questM = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
	}

	// Token: 0x060004B2 RID: 1202 RVA: 0x000252DF File Offset: 0x000236DF
	private void OnEnable()
	{
		EasyJoystick.On_JoystickMove += this.On_JoystickMove;
		EasyJoystick.On_JoystickMoveEnd += this.On_JoystickMoveEnd;
	}

	// Token: 0x060004B3 RID: 1203 RVA: 0x00025303 File Offset: 0x00023703
	private void OnDisable()
	{
		EasyJoystick.On_JoystickMove -= this.On_JoystickMove;
		EasyJoystick.On_JoystickMoveEnd -= this.On_JoystickMoveEnd;
	}

	// Token: 0x060004B4 RID: 1204 RVA: 0x00025327 File Offset: 0x00023727
	private void OnDestroy()
	{
		EasyJoystick.On_JoystickMove -= this.On_JoystickMove;
		EasyJoystick.On_JoystickMoveEnd -= this.On_JoystickMoveEnd;
	}

	// Token: 0x060004B5 RID: 1205 RVA: 0x0002534C File Offset: 0x0002374C
	private void On_JoystickMoveEnd(MovingJoystick move)
	{
		if (move.joystickName == "Move_Turn_Joystick1")
		{
			base.GetComponent<Animator>().SetFloat("vertical", 0f);
			base.GetComponent<Animator>().SetBool("back", false);
		}
		if (move.joystickName == "Move_Turn_Joystick2")
		{
			base.GetComponent<Animator>().SetBool("run", false);
			base.GetComponent<Animator>().SetBool("walk", false);
		}
		if (move.joystickName == "Move_Turn_Joystick3")
		{
			base.GetComponent<Animation>().CrossFade("Idle");
		}
	}

	// Token: 0x060004B6 RID: 1206 RVA: 0x000253F0 File Offset: 0x000237F0
	private void On_JoystickMove(MovingJoystick move)
	{
		this.isJumping = this.questM.players[gameplay.count].GetComponent<PlayerInputControllerC>().alwJump;
		if (!this.isJumping)
		{
			if (move.joystickName == "Move_Turn_Joystick1")
			{
				if (Mathf.Abs(move.joystickAxis.y) > 0f && (double)Mathf.Abs(move.joystickAxis.y) < 0.5)
				{
					if (move.joystickValue.y < 0f)
					{
						base.GetComponent<Animator>().SetBool("back", true);
						return;
					}
					base.GetComponent<Animator>().SetBool("back", false);
					base.GetComponent<Animator>().SetFloat("vertical", 1.5f);
				}
				else if ((double)Mathf.Abs(move.joystickAxis.y) >= 0.5)
				{
					if (move.joystickValue.y < 0f)
					{
						base.GetComponent<Animator>().SetBool("back", true);
						return;
					}
					base.GetComponent<Animator>().SetBool("back", false);
					base.GetComponent<Animator>().SetFloat("vertical", 2.5f);
				}
			}
			if (move.joystickName == "Move_Turn_Joystick2")
			{
				if (Mathf.Abs(move.joystickAxis.y) > 0f && (double)Mathf.Abs(move.joystickAxis.y) < 0.5)
				{
					base.GetComponent<Animator>().SetBool("idle", false);
					base.GetComponent<Animator>().SetBool("run", true);
				}
				else if ((double)Mathf.Abs(move.joystickAxis.y) >= 0.5)
				{
					base.GetComponent<Animator>().SetBool("walk", false);
					base.GetComponent<Animator>().SetBool("run", true);
				}
			}
			if (move.joystickName == "Move_Turn_Joystick3")
			{
				if (Mathf.Abs(move.joystickAxis.y) > 0f && (double)Mathf.Abs(move.joystickAxis.y) < 0.5)
				{
					base.GetComponent<Animation>().CrossFade("Walk");
				}
				else if ((double)Mathf.Abs(move.joystickAxis.y) >= 0.5)
				{
					base.GetComponent<Animation>().CrossFade("Runing Fast");
				}
			}
		}
	}

	// Token: 0x040004D2 RID: 1234
	private FootprintSystem footprint;

	// Token: 0x040004D3 RID: 1235
	private QuestManager questM;

	// Token: 0x040004D4 RID: 1236
	private UnderWaterSystem underSwim;

	// Token: 0x040004D5 RID: 1237
	private bool isJumping;
}
