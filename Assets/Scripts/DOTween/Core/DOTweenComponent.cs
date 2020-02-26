using System;
using System.Collections;
using UnityEngine;

namespace DG.Tweening.Core
{
	// Token: 0x02000048 RID: 72
	[AddComponentMenu("")]
	public class DOTweenComponent : MonoBehaviour, IDOTweenInit
	{
		// Token: 0x0600024C RID: 588 RVA: 0x0000D148 File Offset: 0x0000B348
		private void Awake()
		{
			this.inspectorUpdater = 0;
			this._unscaledTime = Time.realtimeSinceStartup;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000D15C File Offset: 0x0000B35C
		private void Start()
		{
			if (DOTween.instance != this)
			{
				this._duplicateToDestroy = true;
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000D180 File Offset: 0x0000B380
		private void Update()
		{
			this._unscaledDeltaTime = Time.realtimeSinceStartup - this._unscaledTime;
			if (TweenManager.hasActiveDefaultTweens)
			{
				TweenManager.Update(UpdateType.Normal, (DOTween.useSmoothDeltaTime ? Time.smoothDeltaTime : Time.deltaTime) * DOTween.timeScale, this._unscaledDeltaTime * DOTween.timeScale);
			}
			this._unscaledTime = Time.realtimeSinceStartup;
			if (DOTween.isUnityEditor)
			{
				this.inspectorUpdater++;
				if (DOTween.showUnityEditorReport && TweenManager.hasActiveTweens)
				{
					if (TweenManager.totActiveTweeners > DOTween.maxActiveTweenersReached)
					{
						DOTween.maxActiveTweenersReached = TweenManager.totActiveTweeners;
					}
					if (TweenManager.totActiveSequences > DOTween.maxActiveSequencesReached)
					{
						DOTween.maxActiveSequencesReached = TweenManager.totActiveSequences;
					}
				}
			}
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000D22B File Offset: 0x0000B42B
		private void LateUpdate()
		{
			if (TweenManager.hasActiveLateTweens)
			{
				TweenManager.Update(UpdateType.Late, (DOTween.useSmoothDeltaTime ? Time.smoothDeltaTime : Time.deltaTime) * DOTween.timeScale, this._unscaledDeltaTime * DOTween.timeScale);
			}
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000D260 File Offset: 0x0000B460
		private void FixedUpdate()
		{
			if (TweenManager.hasActiveFixedTweens && Time.timeScale > 0f)
			{
				TweenManager.Update(UpdateType.Fixed, (DOTween.useSmoothDeltaTime ? Time.smoothDeltaTime : Time.deltaTime) * DOTween.timeScale, (DOTween.useSmoothDeltaTime ? Time.smoothDeltaTime : Time.deltaTime) / Time.timeScale * DOTween.timeScale);
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000D2BE File Offset: 0x0000B4BE
		private void OnLevelWasLoaded()
		{
			if (DOTween.useSafeMode)
			{
				DOTween.Validate();
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000D2D0 File Offset: 0x0000B4D0
		private void OnDrawGizmos()
		{
			if (!DOTween.drawGizmos || !DOTween.isUnityEditor)
			{
				return;
			}
			int count = DOTween.GizmosDelegates.Count;
			if (count == 0)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				DOTween.GizmosDelegates[i]();
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000D318 File Offset: 0x0000B518
		private void OnDestroy()
		{
			if (this._duplicateToDestroy)
			{
				return;
			}
			if (DOTween.showUnityEditorReport)
			{
				Debugger.LogReport(string.Concat(new object[]
				{
					"REPORT > Max overall simultaneous active Tweeners/Sequences: ",
					DOTween.maxActiveTweenersReached,
					"/",
					DOTween.maxActiveSequencesReached
				}));
			}
			if (DOTween.instance == this)
			{
				DOTween.instance = null;
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000D382 File Offset: 0x0000B582
		private void OnApplicationQuit()
		{
			DOTween.isQuitting = true;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000D38A File Offset: 0x0000B58A
		public IDOTweenInit SetCapacity(int tweenersCapacity, int sequencesCapacity)
		{
			TweenManager.SetCapacities(tweenersCapacity, sequencesCapacity);
			return this;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000D394 File Offset: 0x0000B594
		internal IEnumerator WaitForCompletion(Tween t)
		{
			while (t.active && !t.isComplete)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000D3A3 File Offset: 0x0000B5A3
		internal IEnumerator WaitForRewind(Tween t)
		{
			while (t.active && (!t.playedOnce || t.position * (float)(t.completedLoops + 1) > 0f))
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000D3B2 File Offset: 0x0000B5B2
		internal IEnumerator WaitForKill(Tween t)
		{
			while (t.active)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000D3C1 File Offset: 0x0000B5C1
		internal IEnumerator WaitForElapsedLoops(Tween t, int elapsedLoops)
		{
			while (t.active && t.completedLoops < elapsedLoops)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000D3D7 File Offset: 0x0000B5D7
		internal IEnumerator WaitForPosition(Tween t, float position)
		{
			while (t.active && t.position * (float)(t.completedLoops + 1) < position)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000D3ED File Offset: 0x0000B5ED
		internal IEnumerator WaitForStart(Tween t)
		{
			while (t.active && !t.playedOnce)
			{
				yield return null;
			}
			yield break;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000D3FC File Offset: 0x0000B5FC
		internal static void Create()
		{
			if (DOTween.instance != null)
			{
				return;
			}
			GameObject gameObject = new GameObject("[DOTween]");
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
			DOTween.instance = gameObject.AddComponent<DOTweenComponent>();
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000D426 File Offset: 0x0000B626
		internal static void DestroyInstance()
		{
			if (DOTween.instance != null)
			{
				UnityEngine.Object.Destroy(DOTween.instance.gameObject);
			}
			DOTween.instance = null;
		}

		// Token: 0x04000118 RID: 280
		public int inspectorUpdater;

		// Token: 0x04000119 RID: 281
		private float _unscaledTime;

		// Token: 0x0400011A RID: 282
		private float _unscaledDeltaTime;

		// Token: 0x0400011B RID: 283
		private bool _duplicateToDestroy;
	}
}
