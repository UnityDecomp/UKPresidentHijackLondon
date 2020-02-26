using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Events;

namespace SWS
{
	// Token: 0x0200010C RID: 268
	[AddComponentMenu("Simple Waypoint System/splineMove")]
	public class splineMove : MonoBehaviour
	{
		// Token: 0x06000746 RID: 1862 RVA: 0x000305AC File Offset: 0x0002E9AC
		private void Start()
		{
			if (this.onStart)
			{
				this.StartMove();
			}
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x000305C0 File Offset: 0x0002E9C0
		public void StartMove()
		{
			if (this.pathContainer == null)
			{
				Debug.LogWarning(base.gameObject.name + " has no path! Please set Path Container.");
				return;
			}
			this.waypoints = this.pathContainer.GetPathPoints(this.local);
			this.originSpeed = this.speed;
			this.startPoint = Mathf.Clamp(this.startPoint, 0, this.waypoints.Length - 1);
			int num = this.startPoint;
			if (this.reverse)
			{
				Array.Reverse(this.waypoints);
				num = this.waypoints.Length - 1 - num;
			}
			this.Initialize(num);
			this.Stop();
			this.CreateTween();
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x00030678 File Offset: 0x0002EA78
		private void Initialize(int startAt = 0)
		{
			if (!this.moveToPath)
			{
				startAt = 0;
			}
			this.wpPos = new Vector3[this.waypoints.Length - startAt];
			for (int i = 0; i < this.wpPos.Length; i++)
			{
				this.wpPos[i] = this.waypoints[i + startAt] + new Vector3(0f, this.sizeToAdd, 0f);
			}
			for (int j = this.events.Count; j <= this.pathContainer.GetEventsCount() - 1; j++)
			{
				this.events.Add(new UnityEvent());
			}
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x00030738 File Offset: 0x0002EB38
		private void CreateTween()
		{
			TweenParams tweenParams = new TweenParams();
			if (this.timeValue == splineMove.TimeValue.speed)
			{
				tweenParams.SetSpeedBased(true);
			}
			if (this.loopType == splineMove.LoopType.yoyo)
			{
				tweenParams.SetLoops(-1, new DG.Tweening.LoopType?(DG.Tweening.LoopType.Yoyo));
			}
			if (this.easeType == Ease.INTERNAL_Custom)
			{
				tweenParams.SetEase(this.animEaseType);
			}
			else
			{
				tweenParams.SetEase(this.easeType, null, null);
			}
			if (this.moveToPath)
			{
				tweenParams.OnWaypointChange(new TweenCallback<int>(this.OnWaypointReached));
			}
			else
			{
				if (this.loopType == splineMove.LoopType.random)
				{
					this.RandomizeWaypoints();
				}
				else if (this.loopType == splineMove.LoopType.yoyo)
				{
					tweenParams.OnStepComplete(new TweenCallback(this.ReachedEnd));
				}
				Vector3 position = this.wpPos[0];
				if (this.local)
				{
					position = this.pathContainer.transform.TransformPoint(position);
				}
				base.transform.position = position;
				tweenParams.OnWaypointChange(new TweenCallback<int>(this.OnWaypointChange));
				tweenParams.OnComplete(new TweenCallback(this.ReachedEnd));
			}
			if (this.local)
			{
				this.tween = base.transform.DOLocalPath(this.wpPos, this.originSpeed, this.pathType, this.pathMode, 10, null).SetAs(tweenParams).SetOptions(this.closeLoop, this.lockPosition, this.lockRotation).SetLookAt(this.lookAhead, null, null);
			}
			else
			{
				this.tween = base.transform.DOPath(this.wpPos, this.originSpeed, this.pathType, this.pathMode, 10, null).SetAs(tweenParams).SetOptions(this.closeLoop, this.lockPosition, this.lockRotation).SetLookAt(this.lookAhead, null, null);
			}
			if (!this.moveToPath && this.startPoint > 0)
			{
				this.GoToWaypoint(this.startPoint);
				this.startPoint = 0;
			}
			if (this.originSpeed != this.speed)
			{
				this.ChangeSpeed(this.speed);
			}
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x000309A8 File Offset: 0x0002EDA8
		private void OnWaypointReached(int index)
		{
			if (index <= 0)
			{
				return;
			}
			this.Stop();
			this.moveToPath = false;
			this.Initialize(0);
			this.CreateTween();
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x000309CC File Offset: 0x0002EDCC
		private void OnWaypointChange(int index)
		{
			index = this.pathContainer.GetWaypointIndex(index);
			if (index == -1)
			{
				return;
			}
			if (this.loopType != splineMove.LoopType.yoyo && this.reverse)
			{
				index = this.waypoints.Length - 1 - index;
			}
			if (this.loopType == splineMove.LoopType.random)
			{
				index = this.rndArray[index];
			}
			this.currentPoint = index;
			if (this.events == null || this.events.Count - 1 < index || this.events[index] == null || (this.loopType == splineMove.LoopType.random && index == this.rndArray[this.rndArray.Length - 1]))
			{
				return;
			}
			this.events[index].Invoke();
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x00030A98 File Offset: 0x0002EE98
		private void ReachedEnd()
		{
			switch (this.loopType)
			{
			case splineMove.LoopType.none:
				return;
			case splineMove.LoopType.loop:
				this.currentPoint = 0;
				this.CreateTween();
				break;
			case splineMove.LoopType.pingPong:
				this.reverse = !this.reverse;
				Array.Reverse(this.waypoints);
				this.Initialize(0);
				this.CreateTween();
				break;
			case splineMove.LoopType.random:
				this.RandomizeWaypoints();
				this.CreateTween();
				break;
			case splineMove.LoopType.yoyo:
				this.reverse = !this.reverse;
				break;
			}
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x00030B30 File Offset: 0x0002EF30
		private void RandomizeWaypoints()
		{
			this.Initialize(0);
			this.rndArray = new int[this.wpPos.Length];
			for (int i = 0; i < this.rndArray.Length; i++)
			{
				this.rndArray[i] = i;
			}
			int j = this.wpPos.Length;
			while (j > 1)
			{
				int num = this.rand.Next(j--);
				Vector3 vector = this.wpPos[j];
				this.wpPos[j] = this.wpPos[num];
				this.wpPos[num] = vector;
				int num2 = this.rndArray[j];
				this.rndArray[j] = this.rndArray[num];
				this.rndArray[num] = num2;
			}
			Vector3 vector2 = this.wpPos[0];
			int num3 = this.rndArray[0];
			for (int k = 0; k < this.wpPos.Length; k++)
			{
				if (this.rndArray[k] == this.currentPoint)
				{
					this.rndArray[k] = num3;
					this.wpPos[0] = this.wpPos[k];
					this.wpPos[k] = vector2;
				}
			}
			this.rndArray[0] = this.currentPoint;
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x00030CA7 File Offset: 0x0002F0A7
		public void GoToWaypoint(int index)
		{
			if (this.tween == null)
			{
				return;
			}
			if (this.reverse)
			{
				index = this.waypoints.Length - 1 - index;
			}
			this.tween.ForceInit();
			this.tween.GotoWaypoint(index, true);
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x00030CE8 File Offset: 0x0002F0E8
		public void Pause(float seconds = 0f)
		{
			base.StopCoroutine(this.Wait(0f));
			if (this.tween != null)
			{
				this.tween.Pause<Tweener>();
			}
			if (seconds > 0f)
			{
				base.StartCoroutine(this.Wait(seconds));
			}
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x00030D38 File Offset: 0x0002F138
		private IEnumerator Wait(float secs = 0f)
		{
			yield return new WaitForSeconds(secs);
			this.Resume();
			yield break;
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x00030D5A File Offset: 0x0002F15A
		public void Resume()
		{
			base.StopCoroutine(this.Wait(0f));
			if (this.tween != null)
			{
				this.tween.Play<Tweener>();
			}
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x00030D84 File Offset: 0x0002F184
		public void SetPath(PathManager newPath)
		{
			this.Stop();
			this.pathContainer = newPath;
			this.StartMove();
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x00030D99 File Offset: 0x0002F199
		public void Stop()
		{
			base.StopAllCoroutines();
			if (this.tween != null)
			{
				this.tween.Kill(false);
			}
			this.tween = null;
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x00030DC0 File Offset: 0x0002F1C0
		public void ResetToStart()
		{
			this.Stop();
			this.currentPoint = 0;
			if (this.pathContainer)
			{
				base.transform.position = this.pathContainer.waypoints[this.currentPoint].position + new Vector3(0f, this.sizeToAdd, 0f);
			}
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x00030E28 File Offset: 0x0002F228
		public void ChangeSpeed(float value)
		{
			float timeScale;
			if (this.timeValue == splineMove.TimeValue.speed)
			{
				timeScale = value / this.originSpeed;
			}
			else
			{
				timeScale = this.originSpeed / value;
			}
			this.speed = value;
			if (this.tween != null)
			{
				this.tween.timeScale = timeScale;
			}
		}

		// Token: 0x04000646 RID: 1606
		public PathManager pathContainer;

		// Token: 0x04000647 RID: 1607
		public bool onStart;

		// Token: 0x04000648 RID: 1608
		public bool moveToPath;

		// Token: 0x04000649 RID: 1609
		public bool reverse;

		// Token: 0x0400064A RID: 1610
		public int startPoint;

		// Token: 0x0400064B RID: 1611
		[HideInInspector]
		public int currentPoint;

		// Token: 0x0400064C RID: 1612
		public bool closeLoop;

		// Token: 0x0400064D RID: 1613
		public bool local;

		// Token: 0x0400064E RID: 1614
		public float lookAhead;

		// Token: 0x0400064F RID: 1615
		public float sizeToAdd;

		// Token: 0x04000650 RID: 1616
		public splineMove.TimeValue timeValue = splineMove.TimeValue.speed;

		// Token: 0x04000651 RID: 1617
		public float speed = 5f;

		// Token: 0x04000652 RID: 1618
		private float originSpeed;

		// Token: 0x04000653 RID: 1619
		public AnimationCurve animEaseType;

		// Token: 0x04000654 RID: 1620
		public splineMove.LoopType loopType;

		// Token: 0x04000655 RID: 1621
		[HideInInspector]
		public Vector3[] waypoints;

		// Token: 0x04000656 RID: 1622
		private Vector3[] wpPos;

		// Token: 0x04000657 RID: 1623
		[HideInInspector]
		public List<UnityEvent> events = new List<UnityEvent>();

		// Token: 0x04000658 RID: 1624
		public PathType pathType = PathType.CatmullRom;

		// Token: 0x04000659 RID: 1625
		public PathMode pathMode = PathMode.Full3D;

		// Token: 0x0400065A RID: 1626
		public Ease easeType = Ease.Linear;

		// Token: 0x0400065B RID: 1627
		public AxisConstraint lockPosition;

		// Token: 0x0400065C RID: 1628
		public AxisConstraint lockRotation;

		// Token: 0x0400065D RID: 1629
		[HideInInspector]
		public Tweener tween;

		// Token: 0x0400065E RID: 1630
		private System.Random rand = new System.Random();

		// Token: 0x0400065F RID: 1631
		private int[] rndArray;

		// Token: 0x0200010D RID: 269
		public enum TimeValue
		{
			// Token: 0x04000661 RID: 1633
			time,
			// Token: 0x04000662 RID: 1634
			speed
		}

		// Token: 0x0200010E RID: 270
		public enum LoopType
		{
			// Token: 0x04000664 RID: 1636
			none,
			// Token: 0x04000665 RID: 1637
			loop,
			// Token: 0x04000666 RID: 1638
			pingPong,
			// Token: 0x04000667 RID: 1639
			random,
			// Token: 0x04000668 RID: 1640
			yoyo
		}
	}
}
