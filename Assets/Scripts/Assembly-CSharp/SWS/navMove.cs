using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace SWS
{
	// Token: 0x0200010A RID: 266
	[RequireComponent(typeof(NavMeshAgent))]
	[AddComponentMenu("Simple Waypoint System/navMove")]
	public class navMove : MonoBehaviour
	{
		// Token: 0x06000735 RID: 1845 RVA: 0x0002F8C5 File Offset: 0x0002DCC5
		private void Start()
		{
			this.agent = base.GetComponent<NavMeshAgent>();
			if (this.onStart)
			{
				this.StartMove();
			}
		}

		// Token: 0x06000736 RID: 1846 RVA: 0x0002F8E4 File Offset: 0x0002DCE4
		public void StartMove()
		{
			if (this.pathContainer == null)
			{
				Debug.LogWarning(base.gameObject.name + " has no path! Please set Path Container.");
				return;
			}
			this.waypoints = new Transform[this.pathContainer.waypoints.Length];
			Array.Copy(this.pathContainer.waypoints, this.waypoints, this.pathContainer.waypoints.Length);
			this.startPoint = Mathf.Clamp(this.startPoint, 0, this.waypoints.Length - 1);
			int num = this.startPoint;
			if (this.reverse)
			{
				Array.Reverse(this.waypoints);
				num = this.waypoints.Length - 1 - num;
			}
			this.currentPoint = num;
			for (int i = this.events.Count; i <= this.waypoints.Length - 1; i++)
			{
				this.events.Add(new UnityEvent());
			}
			this.Stop();
			base.StartCoroutine(this.Move());
		}

		// Token: 0x06000737 RID: 1847 RVA: 0x0002F9F0 File Offset: 0x0002DDF0
		private IEnumerator Move()
		{
			this.agent.Resume();
			this.agent.updateRotation = this.updateRotation;
			if (this.moveToPath)
			{
				this.agent.SetDestination(this.waypoints[this.currentPoint].position);
				yield return base.StartCoroutine(this.WaitForDestination());
			}
			if (this.loopType == navMove.LoopType.random)
			{
				base.StartCoroutine(this.ReachedEnd());
				yield break;
			}
			if (this.moveToPath)
			{
				base.StartCoroutine(this.NextWaypoint());
			}
			else
			{
				this.GoToWaypoint(this.startPoint);
			}
			this.moveToPath = false;
			yield break;
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x0002FA0C File Offset: 0x0002DE0C
		private IEnumerator NextWaypoint()
		{
			this.OnWaypointChange(this.currentPoint);
			yield return new WaitForEndOfFrame();
			while (this.waiting)
			{
				yield return null;
			}
			Transform next = null;
			if (this.loopType == navMove.LoopType.pingPong && this.repeat)
			{
				this.currentPoint--;
			}
			else if (this.loopType == navMove.LoopType.random)
			{
				this.rndIndex++;
				this.currentPoint = int.Parse(this.waypoints[this.rndIndex].name.Replace("Waypoint ", string.Empty));
				next = this.waypoints[this.rndIndex];
			}
			else
			{
				this.currentPoint++;
			}
			this.currentPoint = Mathf.Clamp(this.currentPoint, 0, this.waypoints.Length - 1);
			if (next == null)
			{
				next = this.waypoints[this.currentPoint];
			}
			this.agent.SetDestination(next.position);
			yield return base.StartCoroutine(this.WaitForDestination());
			if ((this.loopType != navMove.LoopType.random && this.currentPoint == this.waypoints.Length - 1) || this.rndIndex == this.waypoints.Length - 1 || (this.repeat && this.currentPoint == 0))
			{
				base.StartCoroutine(this.ReachedEnd());
			}
			else
			{
				base.StartCoroutine(this.NextWaypoint());
			}
			yield break;
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x0002FA28 File Offset: 0x0002DE28
		private IEnumerator WaitForDestination()
		{
			yield return new WaitForEndOfFrame();
			while (this.agent.pathPending)
			{
				yield return null;
			}
			yield return new WaitForEndOfFrame();
			float remain = this.agent.remainingDistance;
			while (remain == float.PositiveInfinity || remain - this.agent.stoppingDistance > 1.401298E-45f || this.agent.pathStatus != NavMeshPathStatus.PathComplete)
			{
				remain = this.agent.remainingDistance;
				yield return null;
			}
			yield break;
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x0002FA44 File Offset: 0x0002DE44
		private void OnWaypointChange(int index)
		{
			if (this.reverse)
			{
				index = this.waypoints.Length - 1 - index;
			}
			if (this.events == null || this.events.Count - 1 < index || this.events[index] == null)
			{
				return;
			}
			this.events[index].Invoke();
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x0002FAAC File Offset: 0x0002DEAC
		private IEnumerator ReachedEnd()
		{
			switch (this.loopType)
			{
			case navMove.LoopType.none:
				this.OnWaypointChange(this.waypoints.Length - 1);
				yield break;
			case navMove.LoopType.loop:
				this.OnWaypointChange(this.waypoints.Length - 1);
				if (this.closeLoop)
				{
					this.agent.SetDestination(this.waypoints[0].position);
					yield return base.StartCoroutine(this.WaitForDestination());
				}
				else
				{
					this.agent.Warp(this.waypoints[0].position);
				}
				this.currentPoint = 0;
				break;
			case navMove.LoopType.pingPong:
				this.repeat = !this.repeat;
				break;
			case navMove.LoopType.random:
				this.RandomizeWaypoints();
				break;
			}
			base.StartCoroutine(this.NextWaypoint());
			yield break;
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x0002FAC8 File Offset: 0x0002DEC8
		private void RandomizeWaypoints()
		{
			Array.Copy(this.pathContainer.waypoints, this.waypoints, this.pathContainer.waypoints.Length);
			int i = this.waypoints.Length;
			while (i > 1)
			{
				int num = this.rand.Next(i--);
				Transform transform = this.waypoints[i];
				this.waypoints[i] = this.waypoints[num];
				this.waypoints[num] = transform;
			}
			Transform y = this.pathContainer.waypoints[this.currentPoint];
			for (int j = 0; j < this.waypoints.Length; j++)
			{
				if (this.waypoints[j] == y)
				{
					Transform transform2 = this.waypoints[0];
					this.waypoints[0] = this.waypoints[j];
					this.waypoints[j] = transform2;
					break;
				}
			}
			this.rndIndex = 0;
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x0002FBB8 File Offset: 0x0002DFB8
		public void GoToWaypoint(int index)
		{
			if (this.reverse)
			{
				index = this.waypoints.Length - 1 - index;
			}
			this.Stop();
			this.currentPoint = index;
			this.agent.Warp(this.waypoints[index].position);
			base.StartCoroutine(this.NextWaypoint());
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x0002FC11 File Offset: 0x0002E011
		public void Pause(float seconds = 0f)
		{
			base.StopCoroutine(this.Wait(0f));
			this.waiting = true;
			this.agent.Stop();
			if (seconds > 0f)
			{
				base.StartCoroutine(this.Wait(seconds));
			}
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x0002FC50 File Offset: 0x0002E050
		private IEnumerator Wait(float secs = 0f)
		{
			yield return new WaitForSeconds(secs);
			this.Resume();
			yield break;
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0002FC72 File Offset: 0x0002E072
		public void Resume()
		{
			base.StopCoroutine(this.Wait(0f));
			this.waiting = false;
			this.agent.Resume();
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x0002FC97 File Offset: 0x0002E097
		public void SetPath(PathManager newPath)
		{
			this.Stop();
			this.pathContainer = newPath;
			this.StartMove();
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x0002FCAC File Offset: 0x0002E0AC
		public void Stop()
		{
			base.StopAllCoroutines();
			if (this.agent.enabled)
			{
				this.agent.Stop();
			}
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x0002FCD0 File Offset: 0x0002E0D0
		public void ResetToStart()
		{
			this.Stop();
			this.currentPoint = 0;
			if (this.pathContainer)
			{
				this.agent.Warp(this.pathContainer.waypoints[this.currentPoint].position);
			}
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x0002FD1D File Offset: 0x0002E11D
		public void ChangeSpeed(float value)
		{
			this.agent.speed = value;
		}

		// Token: 0x04000631 RID: 1585
		public PathManager pathContainer;

		// Token: 0x04000632 RID: 1586
		public bool onStart;

		// Token: 0x04000633 RID: 1587
		public bool moveToPath;

		// Token: 0x04000634 RID: 1588
		public bool reverse;

		// Token: 0x04000635 RID: 1589
		public int startPoint;

		// Token: 0x04000636 RID: 1590
		[HideInInspector]
		public int currentPoint;

		// Token: 0x04000637 RID: 1591
		public bool closeLoop;

		// Token: 0x04000638 RID: 1592
		public bool updateRotation = true;

		// Token: 0x04000639 RID: 1593
		[HideInInspector]
		public List<UnityEvent> events = new List<UnityEvent>();

		// Token: 0x0400063A RID: 1594
		public navMove.LoopType loopType;

		// Token: 0x0400063B RID: 1595
		[HideInInspector]
		public Transform[] waypoints;

		// Token: 0x0400063C RID: 1596
		private bool repeat;

		// Token: 0x0400063D RID: 1597
		private NavMeshAgent agent;

		// Token: 0x0400063E RID: 1598
		private System.Random rand = new System.Random();

		// Token: 0x0400063F RID: 1599
		private int rndIndex;

		// Token: 0x04000640 RID: 1600
		private bool waiting;

		// Token: 0x0200010B RID: 267
		public enum LoopType
		{
			// Token: 0x04000642 RID: 1602
			none,
			// Token: 0x04000643 RID: 1603
			loop,
			// Token: 0x04000644 RID: 1604
			pingPong,
			// Token: 0x04000645 RID: 1605
			random
		}
	}
}
