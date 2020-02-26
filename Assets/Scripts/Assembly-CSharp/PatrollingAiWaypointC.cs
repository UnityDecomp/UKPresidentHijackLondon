using System;
using UnityEngine;

// Token: 0x0200007A RID: 122
[RequireComponent(typeof(AIsetC))]
public class PatrollingAiWaypointC : MonoBehaviour
{
	// Token: 0x060003D4 RID: 980 RVA: 0x00017C8C File Offset: 0x0001608C
	private void Start()
	{
		if (this.waypoints.Length > 1)
		{
			foreach (Transform transform in this.waypoints)
			{
				transform.parent = null;
			}
		}
		this.ai = base.GetComponent<AIsetC>();
		this.mainModel = base.GetComponent<AIsetC>().mainModel;
		this.useMecanim = base.GetComponent<AIsetC>().useMecanim;
		if (!this.mainModel)
		{
			this.mainModel = base.gameObject;
		}
		this.movingAnimation = this.ai.movingAnimation;
		this.idleAnimation = this.ai.idleAnimation;
		if (this.useMecanim)
		{
			this.animator = this.ai.animator;
			if (!this.animator)
			{
				this.animator = this.mainModel.GetComponent<Animator>();
			}
		}
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x00017D78 File Offset: 0x00016178
	private void Update()
	{
		if (this.ai.followState == AIsetC.AIState.Idle)
		{
			if (this.state >= 1)
			{
				CharacterController component = base.GetComponent<CharacterController>();
				Vector3 a = base.transform.TransformDirection(Vector3.forward);
				component.Move(a * this.speed * Time.deltaTime);
			}
			if (this.wait >= this.idleDuration && this.state == 0)
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
				this.wait = 0f;
				this.state = 0;
			}
			if (this.state == 2)
			{
				Vector3 position = this.headToPoint.position;
				position.y = base.transform.position.y;
				base.transform.LookAt(position);
				this.distance = (base.transform.position - this.GetDestination()).magnitude;
				if ((double)this.distance <= 0.2)
				{
					if (this.idleAnimation)
					{
						this.mainModel.GetComponent<Animation>().CrossFade(this.idleAnimation.name, 0.2f);
					}
					this.wait = 0f;
					this.state = 0;
				}
			}
			this.wait += Time.deltaTime;
		}
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x00017F80 File Offset: 0x00016380
	private void RandomTurning()
	{
		float y = (float)UnityEngine.Random.Range(0, 360);
		base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, y, base.transform.eulerAngles.z);
		if (this.movingAnimation && !this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
		}
		else if (this.useMecanim)
		{
			this.animator.SetBool("run", true);
		}
		this.wait = 0f;
		this.state = 1;
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x00018040 File Offset: 0x00016440
	private void RandomWaypoint()
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
		this.wait = 0f;
		this.state = 2;
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x000180D8 File Offset: 0x000164D8
	private void WaypointStep()
	{
		this.headToPoint = this.waypoints[this.step];
		if (this.movingAnimation && !this.useMecanim)
		{
			this.mainModel.GetComponent<Animation>().CrossFade(this.movingAnimation.name, 0.2f);
		}
		else if (this.useMecanim)
		{
			this.animator.SetBool("run", true);
		}
		this.wait = 0f;
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

	// Token: 0x060003D9 RID: 985 RVA: 0x00018198 File Offset: 0x00016598
	private Vector3 GetDestination()
	{
		Vector3 position = this.headToPoint.position;
		position.y = base.transform.position.y;
		return position;
	}

	// Token: 0x0400034C RID: 844
	public Transform[] waypoints = new Transform[3];

	// Token: 0x0400034D RID: 845
	public bool randomWaypoints = true;

	// Token: 0x0400034E RID: 846
	public float speed = 4f;

	// Token: 0x0400034F RID: 847
	private AIsetC ai;

	// Token: 0x04000350 RID: 848
	private int state;

	// Token: 0x04000351 RID: 849
	private AnimationClip movingAnimation;

	// Token: 0x04000352 RID: 850
	private AnimationClip idleAnimation;

	// Token: 0x04000353 RID: 851
	private GameObject mainModel;

	// Token: 0x04000354 RID: 852
	public float idleDuration = 2f;

	// Token: 0x04000355 RID: 853
	public float moveDuration = 3f;

	// Token: 0x04000356 RID: 854
	private Transform headToPoint;

	// Token: 0x04000357 RID: 855
	private float distance;

	// Token: 0x04000358 RID: 856
	private int step;

	// Token: 0x04000359 RID: 857
	private bool useMecanim;

	// Token: 0x0400035A RID: 858
	private Animator animator;

	// Token: 0x0400035B RID: 859
	private float wait;
}
