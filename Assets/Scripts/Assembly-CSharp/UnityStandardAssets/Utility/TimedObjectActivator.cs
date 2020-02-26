using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001C8 RID: 456
	public class TimedObjectActivator : MonoBehaviour
	{
		// Token: 0x06000C02 RID: 3074 RVA: 0x0004BF88 File Offset: 0x0004A388
		private void Awake()
		{
			foreach (TimedObjectActivator.Entry entry in this.entries.entries)
			{
				switch (entry.action)
				{
				case TimedObjectActivator.Action.Activate:
					base.StartCoroutine(this.Activate(entry));
					break;
				case TimedObjectActivator.Action.Deactivate:
					base.StartCoroutine(this.Deactivate(entry));
					break;
				case TimedObjectActivator.Action.Destroy:
					UnityEngine.Object.Destroy(entry.target, entry.delay);
					break;
				case TimedObjectActivator.Action.ReloadLevel:
					base.StartCoroutine(this.ReloadLevel(entry));
					break;
				}
			}
		}

		// Token: 0x06000C03 RID: 3075 RVA: 0x0004C02C File Offset: 0x0004A42C
		private IEnumerator Activate(TimedObjectActivator.Entry entry)
		{
			yield return new WaitForSeconds(entry.delay);
			entry.target.SetActive(true);
			yield break;
		}

		// Token: 0x06000C04 RID: 3076 RVA: 0x0004C048 File Offset: 0x0004A448
		private IEnumerator Deactivate(TimedObjectActivator.Entry entry)
		{
			yield return new WaitForSeconds(entry.delay);
			entry.target.SetActive(false);
			yield break;
		}

		// Token: 0x06000C05 RID: 3077 RVA: 0x0004C064 File Offset: 0x0004A464
		private IEnumerator ReloadLevel(TimedObjectActivator.Entry entry)
		{
			yield return new WaitForSeconds(entry.delay);
			SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
			yield break;
		}

		// Token: 0x04000C56 RID: 3158
		public TimedObjectActivator.Entries entries = new TimedObjectActivator.Entries();

		// Token: 0x020001C9 RID: 457
		public enum Action
		{
			// Token: 0x04000C58 RID: 3160
			Activate,
			// Token: 0x04000C59 RID: 3161
			Deactivate,
			// Token: 0x04000C5A RID: 3162
			Destroy,
			// Token: 0x04000C5B RID: 3163
			ReloadLevel,
			// Token: 0x04000C5C RID: 3164
			Call
		}

		// Token: 0x020001CA RID: 458
		[Serializable]
		public class Entry
		{
			// Token: 0x04000C5D RID: 3165
			public GameObject target;

			// Token: 0x04000C5E RID: 3166
			public TimedObjectActivator.Action action;

			// Token: 0x04000C5F RID: 3167
			public float delay;
		}

		// Token: 0x020001CB RID: 459
		[Serializable]
		public class Entries
		{
			// Token: 0x04000C60 RID: 3168
			public TimedObjectActivator.Entry[] entries;
		}
	}
}
