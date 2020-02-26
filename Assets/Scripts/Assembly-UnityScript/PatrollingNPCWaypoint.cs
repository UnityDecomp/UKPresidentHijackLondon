using System;
using UnityEngine;

// Token: 0x02000068 RID: 104
[RequireComponent(typeof(CharacterMotor))]
[Serializable]
public class PatrollingNPCWaypoint : MonoBehaviour
{
	// Token: 0x0600014A RID: 330 RVA: 0x00010150 File Offset: 0x0000E350
	public PatrollingNPCWaypoint()
	{
		this.waypoints = new Transform[3];
		this.speed = 4f;
		this.idleDuration = new Vector2(1.5f, 2.5f);
		this.moveDuration = new Vector2(1f, 2f);
		this.waitDuration = 3f;
		this.randomWaypoints = true;
	}

	// Token: 0x0600014B RID: 331 RVA: 0x000101B8 File Offset: 0x0000E3B8
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
	}

	// Token: 0x0600014C RID: 332 RVA: 0x0001021C File Offset: 0x0000E41C
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
			if (this.wait >= this.waitDuration && this.state == 0)
			{
				if (this.waypoints.Length > 1)
				{
					if (this.randomWaypoints)
					{
						this.RandomWaypoint();
					}
					else
					{
						this.WaypointStep();
					}
				}
				else
				{
					this.RandomTurning();
				}
			}
			if (this.wait >= this.waitDuration && this.state == 1)
			{
				if (this.idleAnimation)
				{
					this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
				}
				this.wait = (float)0;
				this.waitDuration = UnityEngine.Random.Range(this.idleDuration.x, this.idleDuration.y);
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
					if (this.idleAnimation)
					{
						this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
					}
					this.wait = (float)0;
					this.waitDuration = UnityEngine.Random.Range(this.idleDuration.x, this.idleDuration.y);
					this.state = 0;
				}
			}
			this.wait += Time.deltaTime;
		}
	}

	// Token: 0x0600014D RID: 333 RVA: 0x00010440 File Offset: 0x0000E640
	public virtual void RandomTurning()
	{
		float num = (float)UnityEngine.Random.Range(0, 360);
		float y = num;
		Vector3 eulerAngles = this.transform.eulerAngles;
		float num2 = eulerAngles.y = y;
		Vector3 vector = this.transform.eulerAngles = eulerAngles;
		if (this.movingAnimation)
		{
			this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
		}
		this.wait = (float)0;
		this.waitDuration = UnityEngine.Random.Range(this.moveDuration.x, this.moveDuration.y);
		this.state = 1;
	}

	// Token: 0x0600014E RID: 334 RVA: 0x000104EC File Offset: 0x0000E6EC
	public virtual void RandomWaypoint()
	{
		this.headToPoint = this.waypoints[UnityEngine.Random.Range(0, this.waypoints.Length)];
		if (this.movingAnimation)
		{
			this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
		}
		this.wait = (float)0;
		this.state = 2;
	}

	// Token: 0x0600014F RID: 335 RVA: 0x00010558 File Offset: 0x0000E758
	public virtual void WaypointStep()
	{
		this.headToPoint = this.waypoints[this.step];
		if (this.movingAnimation)
		{
			this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
		}
		this.wait = (float)0;
		this.state = 2;
		if (this.step >= this.waypoints.Length - 1)
		{
			this.step = 0;
		}
		else
		{
			this.step++;
		}
	}

	// Token: 0x06000150 RID: 336 RVA: 0x000105EC File Offset: 0x0000E7EC
	public virtual Vector3 GetDestination()
	{
		Vector3 position = this.headToPoint.position;
		position.y = this.transform.position.y;
		return position;
	}

	// Token: 0x06000151 RID: 337 RVA: 0x00010620 File Offset: 0x0000E820
	public virtual void Main()
	{
	}

	// Token: 0x04000240 RID: 576
	public Transform[] waypoints;

	// Token: 0x04000241 RID: 577
	public float speed;

	// Token: 0x04000242 RID: 578
	private int state;

	// Token: 0x04000243 RID: 579
	public AnimationClip movingAnimation;

	// Token: 0x04000244 RID: 580
	public AnimationClip idleAnimation;

	// Token: 0x04000245 RID: 581
	public GameObject mainModel;

	// Token: 0x04000246 RID: 582
	public Vector2 idleDuration;

	// Token: 0x04000247 RID: 583
	public Vector2 moveDuration;

	// Token: 0x04000248 RID: 584
	private float waitDuration;

	// Token: 0x04000249 RID: 585
	private float wait;

	// Token: 0x0400024A RID: 586
	public bool freeze;

	// Token: 0x0400024B RID: 587
	private Transform headToPoint;

	// Token: 0x0400024C RID: 588
	private float distance;

	// Token: 0x0400024D RID: 589
	public bool randomWaypoints;

	// Token: 0x0400024E RID: 590
	private int step;
}
