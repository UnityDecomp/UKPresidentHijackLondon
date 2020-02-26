

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(CharacterMotor))]
[AddComponentMenu("Action-RPG Kit/Create Enemy")]
[RequireComponent(typeof(Status))]
public class AIset : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024KnockBack_0024127 : GenericGenerator<WaitForSeconds>
	{
		internal AIset _0024self__0024129;

		public _0024KnockBack_0024127(AIset self_)
		{
			_0024self__0024129 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024KnockBack_0024127(_0024self__0024129).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Attack_0024130 : GenericGenerator<WaitForSeconds>
	{
		internal AIset _0024self__0024133;

		public _0024Attack_0024130(AIset self_)
		{
			_0024self__0024133 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024Attack_0024130(_0024self__0024133).GetEnumerator();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024UseSkill_0024134 : GenericGenerator<WaitForSeconds>
	{
		internal Transform _0024skill_0024142;

		internal float _0024castTime_0024143;

		internal float _0024delay_0024144;

		internal string _0024anim_0024145;

		internal float _0024dist_0024146;

		internal AIset _0024self__0024147;

		public _0024UseSkill_0024134(Transform skill, float castTime, float delay, string anim, float dist, AIset self_)
		{
			_0024skill_0024142 = skill;
			_0024castTime_0024143 = castTime;
			_0024delay_0024144 = delay;
			_0024anim_0024145 = anim;
			_0024dist_0024146 = dist;
			_0024self__0024147 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024UseSkill_0024134(_0024skill_0024142, _0024castTime_0024143, _0024delay_0024144, _0024anim_0024145, _0024dist_0024146, _0024self__0024147).GetEnumerator();
		}
	}

	public GameObject mainModel;

	public Transform followTarget;

	public float approachDistance;

	public float detectRange;

	public float lostSight;

	public float speed;

	public bool useMecanim;

	public Animator animator;

	public AnimationClip movingAnimation;

	public AnimationClip idleAnimation;

	public AnimationClip attackAnimation;

	public AnimationClip hurtAnimation;

	[HideInInspector]
	public bool flinch;

	public bool stability;

	public bool freeze;

	public Transform bulletPrefab;

	public Transform attackPoint;

	public float attackCast;

	public float attackDelay;

	[HideInInspector]
	public AIState followState;

	private float distance;

	private int atk;

	private int matk;

	private Vector3 knock;

	[HideInInspector]
	public bool cancelAttack;

	private bool attacking;

	private bool castSkill;

	private bool angry;

	private GameObject[] gos;

	public AudioClip attackVoice;

	public AudioClip hurtVoice;

	public AIset()
	{
		approachDistance = 2f;
		detectRange = 15f;
		lostSight = 100f;
		speed = 4f;
		attackCast = 0.3f;
		attackDelay = 0.5f;
		knock = Vector3.zero;
	}

	public void Start()
	{
		gameObject.tag = "Enemy";
		if (!attackPoint)
		{
			attackPoint = transform;
		}
		if (!mainModel)
		{
			mainModel = gameObject;
		}
		((Status)GetComponent(typeof(Status))).useMecanim = useMecanim;
		((Status)GetComponent(typeof(Status))).mainModel = mainModel;
		atk = ((Status)GetComponent(typeof(Status))).atk;
		matk = ((Status)GetComponent(typeof(Status))).matk;
		followState = AIState.Idle;
		if (!useMecanim)
		{
			mainModel.GetComponent<Animation>().Play(idleAnimation.name);
			mainModel.GetComponent<Animation>()[hurtAnimation.name].layer = 10;
		}
		else if (!animator)
		{
			animator = (Animator)mainModel.GetComponent(typeof(Animator));
		}
	}

	public Vector3 GetDestination()
	{
		Vector3 position = followTarget.position;
		Vector3 position2 = transform.position;
		position.y = position2.y;
		return position;
	}

	public void Update()
	{
		Status status = (Status)GetComponent(typeof(Status));
		CharacterController characterController = (CharacterController)GetComponent(typeof(CharacterController));
		FindClosest();
		if (useMecanim)
		{
			animator.SetBool("hurt", flinch);
		}
		if (flinch)
		{
			characterController.Move(knock * 6f * Time.deltaTime);
		}
		else
		{
			if (freeze || status.freeze || !followTarget)
			{
				return;
			}
			if (followState == AIState.Moving)
			{
				if (!((followTarget.position - transform.position).magnitude > approachDistance))
				{
					followState = AIState.Pausing;
					if (!useMecanim)
					{
						mainModel.GetComponent<Animation>().CrossFade(idleAnimation.name, 0.2f);
					}
					else
					{
						animator.SetBool("run", value: false);
					}
					StartCoroutine(Attack());
				}
				else if (!((followTarget.position - transform.position).magnitude < lostSight))
				{
					angry = false;
					((Status)GetComponent(typeof(Status))).health = ((Status)GetComponent(typeof(Status))).maxHealth;
					followState = AIState.Idle;
					if (!useMecanim)
					{
						mainModel.GetComponent<Animation>().CrossFade(idleAnimation.name, 0.2f);
					}
					else
					{
						animator.SetBool("run", value: false);
					}
				}
				else
				{
					Vector3 a = transform.TransformDirection(Vector3.forward);
					characterController.Move(a * speed * Time.deltaTime);
					Vector3 position = followTarget.position;
					Vector3 position2 = transform.position;
					position.y = position2.y;
					transform.LookAt(position);
				}
			}
			else if (followState == AIState.Pausing)
			{
				Vector3 position3 = followTarget.position;
				Vector3 position4 = transform.position;
				position3.y = position4.y;
				transform.LookAt(position3);
				distance = (transform.position - GetDestination()).magnitude;
				if (!(distance <= approachDistance))
				{
					followState = AIState.Moving;
					if (!useMecanim)
					{
						mainModel.GetComponent<Animation>().CrossFade(movingAnimation.name, 0.2f);
					}
					else
					{
						animator.SetBool("run", value: true);
					}
				}
			}
			else
			{
				if (followState != AIState.Idle)
				{
					return;
				}
				Vector3 position5 = followTarget.position;
				Vector3 position6 = transform.position;
				position5.y = position6.y - position5.y;
				int num = ((Status)GetComponent(typeof(Status))).maxHealth - ((Status)GetComponent(typeof(Status))).health;
				distance = (transform.position - GetDestination()).magnitude;
				if ((!(distance >= detectRange) && Mathf.Abs(position5.y) <= 4f) || num > 0)
				{
					followState = AIState.Moving;
					if (!useMecanim)
					{
						mainModel.GetComponent<Animation>().CrossFade(movingAnimation.name, 0.2f);
					}
					else
					{
						animator.SetBool("run", value: true);
					}
				}
			}
		}
	}

	public void Flinch(Vector3 dir)
	{
		if (!stability)
		{
			if ((bool)hurtVoice && ((Status)GetComponent(typeof(Status))).health >= 1)
			{
				GetComponent<AudioSource>().clip = hurtVoice;
				GetComponent<AudioSource>().Play();
			}
			cancelAttack = true;
			if ((bool)followTarget)
			{
				Vector3 position = followTarget.position;
				Vector3 position2 = transform.position;
				position.y = position2.y;
				transform.LookAt(position);
			}
			knock = transform.TransformDirection(Vector3.back);
			StartCoroutine(KnockBack());
			if (!useMecanim)
			{
				mainModel.GetComponent<Animation>().PlayQueued(hurtAnimation.name, QueueMode.PlayNow);
				mainModel.GetComponent<Animation>().CrossFade(movingAnimation.name, 0.2f);
			}
			followState = AIState.Moving;
		}
	}

	public IEnumerator KnockBack()
	{
		return new _0024KnockBack_0024127(this).GetEnumerator();
	}

	public IEnumerator Attack()
	{
		return new _0024Attack_0024130(this).GetEnumerator();
	}

	public void CheckDistance()
	{
		if (!followTarget)
		{
			if (!useMecanim)
			{
				mainModel.GetComponent<Animation>().CrossFade(idleAnimation.name, 0.2f);
			}
			else
			{
				animator.SetBool("run", value: false);
			}
			followState = AIState.Idle;
			return;
		}
		float magnitude = (followTarget.position - transform.position).magnitude;
		if (!(magnitude > approachDistance))
		{
			Vector3 position = followTarget.position;
			Vector3 position2 = transform.position;
			position.y = position2.y;
			transform.LookAt(position);
			StartCoroutine(Attack());
		}
		else
		{
			followState = AIState.Moving;
			if (!useMecanim)
			{
				mainModel.GetComponent<Animation>().CrossFade(movingAnimation.name, 0.2f);
			}
			else
			{
				animator.SetBool("run", value: true);
			}
		}
	}

	public void FindClosest()
	{
		gos = GameObject.FindGameObjectsWithTag("Player");
		gos = (GameObject[])RuntimeServices.AddArrays(typeof(GameObject), gos, GameObject.FindGameObjectsWithTag("Ally"));
		if (gos.Length <= 0)
		{
			return;
		}
		angry = true;
		GameObject gameObject = null;
		float num = float.PositiveInfinity;
		Vector3 position = transform.position;
		int i = 0;
		GameObject[] array = gos;
		for (int length = array.Length; i < length; i++)
		{
			float sqrMagnitude = (array[i].transform.position - position).sqrMagnitude;
			if (!(sqrMagnitude >= num))
			{
				followTarget = array[i].transform;
				num = sqrMagnitude;
			}
		}
	}

	public void FindClosestEnemy()
	{
		float num = float.PositiveInfinity;
		float radius = detectRange;
		Collider[] array = Physics.OverlapSphere(transform.position, radius);
		int i = 0;
		Collider[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			if (array2[i].CompareTag("Player") || array2[i].CompareTag("Ally"))
			{
				float sqrMagnitude = (array2[i].transform.position - transform.position).sqrMagnitude;
				if (!(sqrMagnitude >= num))
				{
					followTarget = array2[i].transform;
					num = sqrMagnitude;
				}
			}
		}
	}

	public IEnumerator UseSkill(Transform skill, float castTime, float delay, string anim, float dist)
	{
		return new _0024UseSkill_0024134(skill, castTime, delay, anim, dist, this).GetEnumerator();
	}

	public void Main()
	{
	}
}
