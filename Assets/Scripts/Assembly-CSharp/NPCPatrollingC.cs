using System;
using UnityEngine;

// Token: 0x02000078 RID: 120
[RequireComponent(typeof(CharacterMotorC))]
public class NPCPatrollingC : MonoBehaviour
{
	// Token: 0x060003C9 RID: 969 RVA: 0x00017484 File Offset: 0x00015884
	private void Start()
	{
		if (this.waypoints.Length > 1)
		{
			foreach (Transform transform in this.waypoints)
			{
				transform.parent = null;
			}
		}
		if (!this.mainModel)
		{
			this.mainModel = base.gameObject;
		}
		if (this.useMecanim && !this.animator)
		{
			this.animator = this.mainModel.GetComponent<Animator>();
		}
	}

	// Token: 0x060003CA RID: 970 RVA: 0x00017510 File Offset: 0x00015910
	private void Update()
	{
		if (this.freeze)
		{
			return;
		}
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
		}
		this.wait += Time.deltaTime;
	}

	// Token: 0x060003CB RID: 971 RVA: 0x00017740 File Offset: 0x00015B40
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

	// Token: 0x060003CC RID: 972 RVA: 0x00017800 File Offset: 0x00015C00
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

	// Token: 0x060003CD RID: 973 RVA: 0x00017898 File Offset: 0x00015C98
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

	// Token: 0x060003CE RID: 974 RVA: 0x00017958 File Offset: 0x00015D58
	private Vector3 GetDestination()
	{
		Vector3 position = this.headToPoint.position;
		position.y = base.transform.position.y;
		return position;
	}

	// Token: 0x04000331 RID: 817
	public Transform[] waypoints = new Transform[3];

	// Token: 0x04000332 RID: 818
	public bool randomWaypoints = true;

	// Token: 0x04000333 RID: 819
	public float speed = 4f;

	// Token: 0x04000334 RID: 820
	private int state;

	// Token: 0x04000335 RID: 821
	public AnimationClip movingAnimation;

	// Token: 0x04000336 RID: 822
	public AnimationClip idleAnimation;

	// Token: 0x04000337 RID: 823
	public GameObject mainModel;

	// Token: 0x04000338 RID: 824
	public float idleDuration = 2f;

	// Token: 0x04000339 RID: 825
	public float moveDuration = 3f;

	// Token: 0x0400033A RID: 826
	private float wait;

	// Token: 0x0400033B RID: 827
	public bool useMecanim;

	// Token: 0x0400033C RID: 828
	private int step;

	// Token: 0x0400033D RID: 829
	private Animator animator;

	// Token: 0x0400033E RID: 830
	public bool freeze;

	// Token: 0x0400033F RID: 831
	private Transform headToPoint;

	// Token: 0x04000340 RID: 832
	private float distance;
}
