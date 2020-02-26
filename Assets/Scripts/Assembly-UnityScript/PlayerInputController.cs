
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(CharacterMotor))]
public class PlayerInputController : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Dasher_0024197 : GenericGenerator<WaitForSeconds>
	{
		internal PlayerInputController _0024self__0024199;

		public _0024Dasher_0024197(PlayerInputController self_)
		{
			_0024self__0024199 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024Dasher_0024197(_0024self__0024199).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024DodgeRoll_0024200 : GenericGenerator<WaitForSeconds>
	{
		internal AnimationClip _0024anim_0024203;

		internal PlayerInputController _0024self__0024204;

		public _0024DodgeRoll_0024200(AnimationClip anim, PlayerInputController self_)
		{
			_0024anim_0024203 = anim;
			_0024self__0024204 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024DodgeRoll_0024200(_0024anim_0024203, _0024self__0024204).GetEnumerator();
		}
	}

	private GameObject mainModel;

	public float walkSpeed;

	public float sprintSpeed;

	public bool canSprint;

	private bool sprint;

	private bool recover;

	private float staminaRecover;

	private float useStamina;

	[HideInInspector]
	public bool dodging;

	public Texture2D staminaGauge;

	public Texture2D staminaBorder;

	public float maxStamina;

	public float stamina;

	private float lastTime;

	private float recoverStamina;

	private Vector3 dir;

	private bool useMecanim;

	public DodgeSetting dodgeRollSetting;

	private CharacterMotor motor;

	private CharacterController controller;

	public PlayerInputController()
	{
		walkSpeed = 6f;
		sprintSpeed = 12f;
		canSprint = true;
		staminaRecover = 1.4f;
		useStamina = 0.04f;
		maxStamina = 100f;
		stamina = 100f;
		dir = Vector3.forward;
		useMecanim = true;
	}

	public void Start()
	{
		motor = (CharacterMotor)GetComponent(typeof(CharacterMotor));
		controller = (CharacterController)GetComponent(typeof(CharacterController));
		stamina = maxStamina;
		if (!mainModel)
		{
			mainModel = ((Status)GetComponent(typeof(Status))).mainModel;
		}
		useMecanim = ((AttackTrigger)GetComponent(typeof(AttackTrigger))).useMecanim;
	}

	public void Update()
	{
		Status status = (Status)GetComponent(typeof(Status));
		if (status.freeze)
		{
			motor.inputMoveDirection = new Vector3(0f, 0f, 0f);
		}
		else
		{
			if (Time.timeScale == 0f)
			{
				return;
			}
			if (dodging)
			{
				Vector3 a = transform.TransformDirection(dir);
				controller.Move(a * 8f * Time.deltaTime);
				return;
			}
			if (recover && !sprint && !dodging)
			{
				if (!(recoverStamina < staminaRecover))
				{
					StaminaRecovery();
				}
				else
				{
					recoverStamina += Time.deltaTime;
				}
			}
			if (dodgeRollSetting.canDodgeRoll)
			{
				if (Input.GetButtonDown("Vertical") && !(Input.GetAxis("Vertical") <= 0f) && (controller.collisionFlags & CollisionFlags.Below) != 0 && Input.GetAxis("Horizontal") == 0f)
				{
					if (Input.GetButtonDown("Vertical") && !(Time.time - lastTime >= 0.4f) && Input.GetButtonDown("Vertical") && !(Time.time - lastTime <= 0.1f) && !(Input.GetAxis("Vertical") <= 0.03f))
					{
						lastTime = Time.time;
						dir = Vector3.forward;
						StartCoroutine(DodgeRoll(dodgeRollSetting.dodgeForward));
					}
					else
					{
						lastTime = Time.time;
					}
				}
				if (Input.GetButtonDown("Vertical") && !(Input.GetAxis("Vertical") >= 0f) && (controller.collisionFlags & CollisionFlags.Below) != 0 && Input.GetAxis("Horizontal") == 0f)
				{
					if (Input.GetButtonDown("Vertical") && !(Time.time - lastTime >= 0.4f) && Input.GetButtonDown("Vertical") && !(Time.time - lastTime <= 0.1f) && !(Input.GetAxis("Vertical") >= -0.03f))
					{
						lastTime = Time.time;
						dir = Vector3.back;
						StartCoroutine(DodgeRoll(dodgeRollSetting.dodgeBack));
					}
					else
					{
						lastTime = Time.time;
					}
				}
				if (Input.GetButtonDown("Horizontal") && !(Input.GetAxis("Horizontal") >= 0f) && (controller.collisionFlags & CollisionFlags.Below) != 0 && !Input.GetButton("Vertical"))
				{
					if (Input.GetButtonDown("Horizontal") && !(Time.time - lastTime >= 0.3f) && Input.GetButtonDown("Horizontal") && !(Time.time - lastTime <= 0.15f) && !(Input.GetAxis("Horizontal") >= -0.03f))
					{
						lastTime = Time.time;
						dir = Vector3.left;
						StartCoroutine(DodgeRoll(dodgeRollSetting.dodgeLeft));
					}
					else
					{
						lastTime = Time.time;
					}
				}
				if (Input.GetButtonDown("Horizontal") && !(Input.GetAxis("Horizontal") <= 0f) && (controller.collisionFlags & CollisionFlags.Below) != 0 && !Input.GetButton("Vertical"))
				{
					if (Input.GetButtonDown("Horizontal") && !(Time.time - lastTime >= 0.3f) && Input.GetButtonDown("Horizontal") && !(Time.time - lastTime <= 0.15f) && !(Input.GetAxis("Horizontal") <= 0.03f))
					{
						lastTime = Time.time;
						dir = Vector3.right;
						StartCoroutine(DodgeRoll(dodgeRollSetting.dodgeRight));
					}
					else
					{
						lastTime = Time.time;
					}
				}
			}
			if ((sprint && Input.GetAxis("Vertical") < 0.02f) || (sprint && stamina <= 0f) || (sprint && Input.GetButtonDown("Fire1")) || (sprint && Input.GetKeyUp(KeyCode.LeftShift)))
			{
				sprint = false;
				recover = true;
				motor.movement.maxForwardSpeed = walkSpeed;
				motor.movement.maxSidewaysSpeed = walkSpeed;
				recoverStamina = 0f;
			}
			Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
			if (vector != Vector3.zero)
			{
				float magnitude = vector.magnitude;
				vector /= magnitude;
				magnitude = Mathf.Min(1f, magnitude);
				magnitude *= magnitude;
				vector *= magnitude;
			}
			motor.inputMoveDirection = transform.rotation * vector;
			motor.inputJump = Input.GetButton("Jump");
			if (sprint)
			{
				motor.movement.maxForwardSpeed = sprintSpeed;
				motor.movement.maxSidewaysSpeed = sprintSpeed;
			}
			else if (Input.GetKey(KeyCode.LeftShift) && !(Input.GetAxis("Vertical") <= 0f) && (controller.collisionFlags & CollisionFlags.Below) != 0 && canSprint && !(stamina <= 0f))
			{
				sprint = true;
				StartCoroutine(Dasher());
			}
		}
	}

	public void OnGUI()
	{
		if (sprint || recover || dodging)
		{
			float width = stamina * 100f / maxStamina * 3f;
			GUI.DrawTexture(new Rect(Screen.width / 2 - 150, Screen.height - 120, width, 10f), staminaGauge);
			GUI.DrawTexture(new Rect(Screen.width / 2 - 153, Screen.height - 123, 306f, 16f), staminaBorder);
		}
	}

	public IEnumerator Dasher()
	{
		return new _0024Dasher_0024197(this).GetEnumerator();
	}

	public void StaminaRecovery()
	{
		stamina += 1f;
		if (!(stamina < maxStamina))
		{
			stamina = maxStamina;
			recoverStamina = 0f;
			recover = false;
		}
		else
		{
			recoverStamina = staminaRecover - 0.02f;
		}
	}

	public IEnumerator DodgeRoll(AnimationClip anim)
	{
		return new _0024DodgeRoll_0024200(anim, this).GetEnumerator();
	}

	public void Main()
	{
	}
}
