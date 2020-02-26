using System;
using UnityEngine;

// Token: 0x02000066 RID: 102
[RequireComponent(typeof(CharacterMotor))]
[Serializable]
public class NpcPatrolling : MonoBehaviour
{
	// Token: 0x0600013E RID: 318 RVA: 0x0000F9C4 File Offset: 0x0000DBC4
	public NpcPatrolling()
	{
		this.waypoints = new Transform[3];
		this.speed = 4f;
		this.idleDuration = 2f;
		this.moveDuration = 3f;
	}

	// Token: 0x0600013F RID: 319 RVA: 0x0000F9FC File Offset: 0x0000DBFC
	public virtual void Start()
	{
		if (this.waypoints.Length > 1)
		{
			int i = 0;
			Transform[] array = this.waypoints;
			int length = array.Length;
			while (i < length)
			{
				array[i].parent = null;
				i++;
			}
		}
		if (!this.mainModel)
		{
			this.mainModel = this.gameObject;
		}
		if (this.useMecanim && !this.animator)
		{
			this.animator = (Animator)this.mainModel.GetComponent(typeof(Animator));
		}
	}

	// Token: 0x06000140 RID: 320 RVA: 0x0000FA9C File Offset: 0x0000DC9C
	public virtual void Update()
	{
		if (!this.freeze)
		{
			if (this.state >= 1)
			{
				CharacterController characterController = (CharacterController)this.GetComponent(typeof(CharacterController));
				Vector3 a = this.transform.TransformDirection(Vector3.forward);
				characterController.Move(a * this.speed * Time.deltaTime);
			}
			if (this.wait >= this.idleDuration && this.state == 0)
			{
				if (this.waypoints.Length > 1)
				{
					this.RandomWaypoint();
				}
				else
				{
					this.RandomTurning();
				}
			}
			if (this.wait >= this.moveDuration && this.state == 1)
			{
				if (this.idleAnimation && !this.useMecanim)
				{
					this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
				}
				else if (this.useMecanim)
				{
					this.animator.SetBool("run", false);
				}
				this.wait = (float)0;
				this.state = 0;
			}
			if (this.state == 2)
			{
				Vector3 position = this.headToPoint.position;
				position.y = this.transform.position.y;
				this.transform.LookAt(position);
				this.distance = (this.transform.position - this.GetDestination()).magnitude;
				if (this.distance <= 0.2f)
				{
					if (this.idleAnimation && !this.useMecanim)
					{
						this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
					}
					else if (this.useMecanim)
					{
						this.animator.SetBool("run", false);
					}
					this.wait = (float)0;
					this.state = 0;
				}
			}
			this.wait += Time.deltaTime;
		}
	}

	// Token: 0x06000141 RID: 321 RVA: 0x0000FCC0 File Offset: 0x0000DEC0
	public virtual void RandomTurning()
	{
		float num = (float)UnityEngine.Random.Range(0, 360);
		float y = num;
		Vector3 eulerAngles = this.transform.eulerAngles;
		float num2 = eulerAngles.y = y;
		Vector3 vector = this.transform.eulerAngles = eulerAngles;
		if (this.movingAnimation && !this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
		}
		else if (this.useMecanim)
		{
			this.animator.SetBool("run", true);
		}
		this.wait = (float)0;
		this.state = 1;
	}

	// Token: 0x06000142 RID: 322 RVA: 0x0000FD78 File Offset: 0x0000DF78
	public virtual void RandomWaypoint()
	{
		this.headToPoint = this.waypoints[UnityEngine.Random.Range(0, this.waypoints.Length)];
		if (this.movingAnimation && !this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
		}
		else if (this.useMecanim)
		{
			this.animator.SetBool("run", true);
		}
		this.wait = (float)0;
		this.state = 2;
	}

	// Token: 0x06000143 RID: 323 RVA: 0x0000FE10 File Offset: 0x0000E010
	public virtual Vector3 GetDestination()
	{
		Vector3 position = this.headToPoint.position;
		position.y = this.transform.position.y;
		return position;
	}

	// Token: 0x06000144 RID: 324 RVA: 0x0000FE44 File Offset: 0x0000E044
	public virtual void Main()
	{
	}

	// Token: 0x04000227 RID: 551
	public Transform[] waypoints;

	// Token: 0x04000228 RID: 552
	public float speed;

	// Token: 0x04000229 RID: 553
	private int state;

	// Token: 0x0400022A RID: 554
	public AnimationClip movingAnimation;

	// Token: 0x0400022B RID: 555
	public AnimationClip idleAnimation;

	// Token: 0x0400022C RID: 556
	public GameObject mainModel;

	// Token: 0x0400022D RID: 557
	public float idleDuration;

	// Token: 0x0400022E RID: 558
	public float moveDuration;

	// Token: 0x0400022F RID: 559
	private float wait;

	// Token: 0x04000230 RID: 560
	public bool useMecanim;

	// Token: 0x04000231 RID: 561
	private Animator animator;

	// Token: 0x04000232 RID: 562
	public bool freeze;

	// Token: 0x04000233 RID: 563
	private Transform headToPoint;

	// Token: 0x04000234 RID: 564
	private float distance;
}
