using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

namespace SWS
{
	// Token: 0x02000103 RID: 259
	public class MoveAnimator : MonoBehaviour
	{
		// Token: 0x06000710 RID: 1808 RVA: 0x0002E800 File Offset: 0x0002CC00
		private void Start()
		{
			this.animator = base.GetComponentInChildren<Animator>();
			this.sMove = base.GetComponent<splineMove>();
			if (!this.sMove)
			{
				this.nAgent = base.GetComponent<NavMeshAgent>();
			}
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x0002E838 File Offset: 0x0002CC38
		private void OnAnimatorMove()
		{
			float value;
			float value2;
			if (this.sMove)
			{
				value = ((this.sMove.tween != null && this.sMove.tween.IsPlaying()) ? this.sMove.speed : 0f);
				value2 = (base.transform.eulerAngles.y - this.lastRotY) * 10f;
				this.lastRotY = base.transform.eulerAngles.y;
			}
			else
			{
				value = this.nAgent.velocity.magnitude;
				Vector3 vector = Quaternion.Inverse(base.transform.rotation) * this.nAgent.desiredVelocity;
				value2 = Mathf.Atan2(vector.x, vector.z) * 180f / 3.14159f;
			}
			this.animator.SetFloat("Speed", value);
			this.animator.SetFloat("Direction", value2, 0.15f, Time.deltaTime);
		}

		// Token: 0x04000613 RID: 1555
		private splineMove sMove;

		// Token: 0x04000614 RID: 1556
		private NavMeshAgent nAgent;

		// Token: 0x04000615 RID: 1557
		private Animator animator;

		// Token: 0x04000616 RID: 1558
		private float lastRotY;
	}
}
