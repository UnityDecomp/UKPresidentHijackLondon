using System;
using System.Collections;

namespace UnityEngine.Advertisements
{
	// Token: 0x02000027 RID: 39
	internal class AsyncExec
	{
		// Token: 0x0600012A RID: 298 RVA: 0x000040CC File Offset: 0x000022CC
		private static MonoBehaviour getImpl()
		{
			if (!AsyncExec.init)
			{
				AsyncExec.asyncImpl = new AsyncExec();
				AsyncExec.asyncExecGameObject = new GameObject("Unity Ads Coroutine Host")
				{
					hideFlags = HideFlags.HideAndDontSave
				};
				AsyncExec.coroutineHost = AsyncExec.asyncExecGameObject.AddComponent<MonoBehaviour>();
				Object.DontDestroyOnLoad(AsyncExec.asyncExecGameObject);
				AsyncExec.init = true;
			}
			return AsyncExec.coroutineHost;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0000412A File Offset: 0x0000232A
		private static AsyncExec getAsyncImpl()
		{
			if (!AsyncExec.init)
			{
				AsyncExec.getImpl();
			}
			return AsyncExec.asyncImpl;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00004141 File Offset: 0x00002341
		public static void runWithCallback<K, T>(Func<K, Action<T>, IEnumerator> asyncMethod, K arg0, Action<T> callback)
		{
			AsyncExec.getImpl().StartCoroutine(asyncMethod(arg0, callback));
		}

		// Token: 0x040000A0 RID: 160
		private static GameObject asyncExecGameObject;

		// Token: 0x040000A1 RID: 161
		private static MonoBehaviour coroutineHost;

		// Token: 0x040000A2 RID: 162
		private static AsyncExec asyncImpl;

		// Token: 0x040000A3 RID: 163
		private static bool init;
	}
}
