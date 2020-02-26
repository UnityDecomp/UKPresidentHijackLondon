
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(Status))]
[RequireComponent(typeof(CharacterMotor))]
[AddComponentMenu("Action-RPG Kit/Create Ally")]
public class AIfriend : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Attack_0024114
	{
		internal AIfriend _0024self__0024120;

		public _0024Attack_0024114(AIfriend self_)
		{
			_0024self__0024120 = self_;
		}

		public  IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024120);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024MeleeDash_0024121
	{
		internal AIfriend _0024self__0024123;

		public _0024MeleeDash_0024121(AIfriend self_)
		{
			_0024self__0024123 = self_;
		}

		public  IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024123);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024KnockBack_0024124
	{
		internal AIfriend _0024self__0024126;

		public _0024KnockBack_0024124(AIfriend self_)
		{
			_0024self__0024126 = self_;
		}

		public  IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024126);
		}
	}

	public Transform master;

	public GameObject mainModel;

	public bool useMecanim;

	public Animator animator;

	public Transform followTarget;

	public float approachDistance;

	public float detectRange;

	public float lostSight;

	public float speed;

	public AnimationClip movingAnimation;

	public AnimationClip idleAnimation;

	public AnimationClip[] attackAnimation;

	public AnimationClip hurtAnimation;

	private bool flinch;

	public bool stability;

	public bool freeze;

	public Transform attackPrefab;

	public Transform attackPoint;

	public float attackCast;

	public float attackDelay;

	private int continueAttack;

	public float continueAttackDelay;

	private AIStatef followState;

	private float distance;

	private float masterDistance;

	private int atk;

	private int mag;

	private bool cancelAttack;

	private bool meleefwd;

	public AIatkType attackType;

	public AudioClip[] attackVoice;

	public AudioClip hurtVoice;

	public AIfriend()
	{
		approachDistance = 3f;
		detectRange = 15f;
		lostSight = 100f;
		speed = 4f;
		attackAnimation = new AnimationClip[1];
		attackCast = 0.5f;
		attackDelay = 1f;
		continueAttack = 1;
		continueAttackDelay = 0.8f;
		attackType = AIatkType.Immobile;
		attackVoice = new AudioClip[3];
	}

	public  void Start()
	{
		gameObject.tag = "Ally";
		if (!mainModel)
		{
			mainModel = gameObject;
		}
		((Status)GetComponent(typeof(Status))).mainModel = mainModel;
		if (!master)
		{
			MonoBehaviour.print("Please Assign It's Master first");
		}
		if (!attackPoint)
		{
			attackPoint = transform;
		}
		((Status)GetComponent(typeof(Status))).useMecanim = useMecanim;
		continueAttack = attackAnimation.Length;
		atk = ((Status)GetComponent(typeof(Status))).atk;
		mag = ((Status)GetComponent(typeof(Status))).matk;
		followState = AIStatef.FollowMaster;
		if (!useMecanim)
		{
			mainModel.GetComponent<Animation>().Play(movingAnimation.name);
			if ((bool)hurtAnimation)
			{
				mainModel.GetComponent<Animation>()[hurtAnimation.name].layer = 10;
			}
		}
		else
		{
			if (!animator)
			{
				animator = (Animator)mainModel.GetComponent(typeof(Animator));
			}
			animator.SetBool("run", value: true);
		}
		if ((bool)master)
		{
			Physics.IgnoreCollision(GetComponent<Collider>(), master.GetComponent<Collider>());
		}
	}

	public  Vector3 GetDestination()
	{
		Vector3 position = followTarget.position;
		Vector3 position2 = transform.position;
		position.y = position2.y;
		return position;
	}

	public  Vector3 GetMasterPosition()
	{
		Vector3 result;
		if ((bool)master)
		{
			Vector3 position = master.position;
			Vector3 position2 = transform.position;
			position.y = position2.y;
			result = position;
		}
		else
		{
			Vector3 vector = default(Vector3);
			result = vector;
		}
		return result;
	}

	public  void Update()
	{
		CharacterController characterController = (CharacterController)GetComponent(typeof(CharacterController));
		Status status = (Status)GetComponent(typeof(Status));
		if (!master)
		{
			status.Death();
		}
		else if (meleefwd && !status.freeze)
		{
			Vector3 a = transform.TransformDirection(Vector3.forward);
			characterController.Move(a * 5f * Time.deltaTime);
		}
		else
		{
			if (freeze || status.freeze)
			{
				return;
			}
			if (useMecanim)
			{
				animator.SetBool("hurt", flinch);
			}
			if (flinch)
			{
				cancelAttack = true;
				Vector3 a = transform.TransformDirection(Vector3.back);
				characterController.SimpleMove(a * 5f);
				return;
			}
			if (!((master.position - transform.position).magnitude <= 30f))
			{
				Vector3 position = master.position;
				position.y += 1.7f;
				transform.position = position;
			}
			FindClosest();
			if (followState == AIStatef.FollowMaster)
			{
				if (!((master.position - transform.position).magnitude > 3f))
				{
					followState = AIStatef.Idle;
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
					Vector3 a2 = transform.TransformDirection(Vector3.forward);
					characterController.Move(a2 * speed * Time.deltaTime);
					Vector3 position2 = master.position;
					Vector3 position3 = transform.position;
					position2.y = position3.y;
					transform.LookAt(position2);
				}
			}
			else if (followState == AIStatef.Moving)
			{
				masterDistance = (transform.position - GetMasterPosition()).magnitude;
				if (!(masterDistance <= detectRange + 5f))
				{
					followState = AIStatef.FollowMaster;
					if (!useMecanim)
					{
						mainModel.GetComponent<Animation>().CrossFade(movingAnimation.name, 0.2f);
					}
					else
					{
						animator.SetBool("run", value: true);
					}
				}
				else if (!((followTarget.position - transform.position).magnitude > approachDistance))
				{
					followState = AIStatef.Pausing;
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
					((Status)GetComponent(typeof(Status))).health = ((Status)GetComponent(typeof(Status))).maxHealth;
					followState = AIStatef.Idle;
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
					Vector3 a2 = transform.TransformDirection(Vector3.forward);
					characterController.Move(a2 * speed * Time.deltaTime);
					Vector3 position4 = followTarget.position;
					Vector3 position5 = transform.position;
					position4.y = position5.y;
					transform.LookAt(position4);
				}
			}
			else if (followState == AIStatef.Pausing)
			{
				Vector3 position6 = followTarget.position;
				Vector3 position7 = transform.position;
				position6.y = position7.y;
				transform.LookAt(position6);
				distance = (transform.position - GetDestination()).magnitude;
				masterDistance = (transform.position - GetMasterPosition()).magnitude;
				if (!(masterDistance <= 12f))
				{
					followState = AIStatef.FollowMaster;
					if (!useMecanim)
					{
						mainModel.GetComponent<Animation>().CrossFade(movingAnimation.name, 0.2f);
					}
					else
					{
						animator.SetBool("run", value: true);
					}
				}
				else if (!(distance <= approachDistance))
				{
					followState = AIStatef.Moving;
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
				if (followState != AIStatef.Idle)
				{
					return;
				}
				Vector3 position8 = followTarget.position;
				Vector3 position9 = transform.position;
				position8.y = position9.y - position8.y;
				int num = ((Status)GetComponent(typeof(Status))).maxHealth - ((Status)GetComponent(typeof(Status))).health;
				distance = (transform.position - GetDestination()).magnitude;
				masterDistance = (transform.position - GetMasterPosition()).magnitude;
				if (!(distance >= detectRange) && !(Mathf.Abs(position8.y) > 4f) && (bool)followTarget)
				{
					followState = AIStatef.Moving;
					if (!useMecanim)
					{
						mainModel.GetComponent<Animation>().CrossFade(movingAnimation.name, 0.2f);
					}
					else
					{
						animator.SetBool("run", value: true);
					}
				}
				else if (!(masterDistance <= 3f))
				{
					followState = AIStatef.FollowMaster;
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

	public  IEnumerator Attack()
	{
		return new _0024Attack_0024114(this).GetEnumerator();
	}

	public  void CheckDistance()
	{
		masterDistance = (transform.position - GetMasterPosition()).magnitude;
		if (!(masterDistance <= detectRange + 5f))
		{
			followState = AIStatef.FollowMaster;
			if (!useMecanim)
			{
				mainModel.GetComponent<Animation>().CrossFade(movingAnimation.name, 0.2f);
			}
			else
			{
				animator.SetBool("run", value: true);
			}
			return;
		}
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
			followState = AIStatef.Idle;
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
			followState = AIStatef.Moving;
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

	public  GameObject FindClosest()
	{
		GameObject[] array = null;
		array = GameObject.FindGameObjectsWithTag("Enemy");
		object result;
		if (array != null)
		{
			GameObject gameObject = null;
			float num = float.PositiveInfinity;
			Vector3 position = transform.position;
			int i = 0;
			GameObject[] array2 = array;
			for (int length = array2.Length; i < length; i++)
			{
				float sqrMagnitude = (array2[i].transform.position - position).sqrMagnitude;
				if (!(sqrMagnitude >= num))
				{
					gameObject = array2[i];
					num = sqrMagnitude;
				}
			}
			if ((bool)gameObject)
			{
				followTarget = gameObject.transform;
				result = gameObject;
				goto IL_00ef;
			}
			followTarget = null;
			followState = AIStatef.FollowMaster;
			if (!useMecanim)
			{
				mainModel.GetComponent<Animation>().CrossFade(movingAnimation.name, 0.2f);
			}
			else
			{
				animator.SetBool("run", value: true);
			}
		}
		result = null;
		goto IL_00ef;
		IL_00ef:
		return (GameObject)result;
	}

	public  IEnumerator MeleeDash()
	{
		return new _0024MeleeDash_0024121(this).GetEnumerator();
	}

	public  void Flinch(Vector3 dir)
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
			StartCoroutine(KnockBack());
			if (!useMecanim)
			{
				mainModel.GetComponent<Animation>().PlayQueued(hurtAnimation.name, QueueMode.PlayNow);
				mainModel.GetComponent<Animation>().CrossFade(movingAnimation.name, 0.2f);
			}
			followState = AIStatef.Moving;
		}
	}

	public  IEnumerator KnockBack()
	{
		return new _0024KnockBack_0024124(this).GetEnumerator();
	}

	public  void Main()
	{
	}
}
