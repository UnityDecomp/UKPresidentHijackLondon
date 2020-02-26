
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(AIset))]
public class FlyingEnemy : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Landing_0024179 : GenericGenerator<WaitForSeconds>
	{
		internal FlyingEnemy _0024self__0024181;

		public _0024Landing_0024179(FlyingEnemy self_)
		{
			_0024self__0024181 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024Landing_0024179(_0024self__0024181).GetEnumerator();
		}
	}

	private int flying;

	private bool onGround;

	private Transform target;

	private float distance;

	public float flyDownRange;

	public float flyUpRange;

	public float flyingSpeed;

	public float flyUpHeight;

	public float landingDelay;

	private float currentHeight;

	public AnimationClip flyDownAnimation;

	public AnimationClip flyUpAnimation;

	public AnimationClip landingAnimation;

	private GameObject mainModel;

	private bool useMecanim;

	private Animator animator;

	private AIset ai;

	public FlyingEnemy()
	{
		flyDownRange = 5.5f;
		flyUpRange = 8.5f;
		flyingSpeed = 8f;
		flyUpHeight = 7f;
		landingDelay = 0.4f;
	}

	public void Start()
	{
		ai = (AIset)GetComponent(typeof(AIset));
		mainModel = ((AIset)GetComponent(typeof(AIset))).mainModel;
		((CharacterMotor)GetComponent(typeof(CharacterMotor))).enabled = false;
		useMecanim = ((AIset)GetComponent(typeof(AIset))).useMecanim;
		if (!mainModel)
		{
			mainModel = gameObject;
		}
		if (useMecanim)
		{
			animator = ai.animator;
			if (!animator)
			{
				animator = (Animator)mainModel.GetComponent(typeof(Animator));
			}
		}
	}

	public Vector3 GetDestination()
	{
		Vector3 position = target.position;
		Vector3 position2 = transform.position;
		position.y = position2.y;
		return position;
	}

	public void Update()
	{
		if (!target && (bool)((AIset)GetComponent(typeof(AIset))).followTarget)
		{
			target = ((AIset)GetComponent(typeof(AIset))).followTarget;
		}
		if (!target)
		{
			return;
		}
		CharacterController characterController = (CharacterController)GetComponent(typeof(CharacterController));
		if (flying == 1)
		{
			if (!useMecanim && (bool)flyDownAnimation)
			{
				mainModel.GetComponent<Animation>().CrossFade(flyDownAnimation.name, 0.2f);
			}
			else
			{
				animator.SetBool("flyDown", value: true);
			}
			Vector3 a = transform.TransformDirection(Vector3.down);
			characterController.Move(a * flyingSpeed * Time.deltaTime);
		}
		else if (flying == 2)
		{
			if (!useMecanim && (bool)flyUpAnimation)
			{
				mainModel.GetComponent<Animation>().CrossFade(flyUpAnimation.name, 0.2f);
			}
			else
			{
				animator.SetBool("flyUp", value: true);
			}
			Vector3 a = transform.TransformDirection(Vector3.up);
			characterController.Move(a * flyingSpeed * Time.deltaTime);
			Vector3 position = transform.position;
			if (!(position.y < currentHeight + flyUpHeight))
			{
				ai.freeze = false;
				flying = 0;
			}
		}
		else
		{
			distance = (transform.position - GetDestination()).magnitude;
			if (!(distance > flyDownRange) && !onGround)
			{
				FlyDown();
			}
			if (!(distance < flyUpRange) && onGround)
			{
				FlyUp();
			}
		}
	}

	public void FlyDown()
	{
		ai.freeze = true;
		flying = 1;
	}

	public void FlyUp()
	{
		onGround = false;
		((CharacterMotor)GetComponent(typeof(CharacterMotor))).enabled = false;
		Vector3 position = transform.position;
		currentHeight = position.y;
		ai.freeze = true;
		flying = 2;
	}

	public void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (flying == 1)
		{
			StartCoroutine(Landing());
		}
	}

	public IEnumerator Landing()
	{
		return new _0024Landing_0024179(this).GetEnumerator();
	}

	public void Main()
	{
	}
}
