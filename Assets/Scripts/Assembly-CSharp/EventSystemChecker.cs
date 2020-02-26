using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001BB RID: 443
public class EventSystemChecker : MonoBehaviour
{
	// Token: 0x06000BDC RID: 3036 RVA: 0x0004ADA0 File Offset: 0x000491A0
	private void Awake()
	{
		if (!UnityEngine.Object.FindObjectOfType<EventSystem>())
		{
			GameObject gameObject = new GameObject("EventSystem");
			gameObject.AddComponent<EventSystem>();
			gameObject.AddComponent<StandaloneInputModule>().forceModuleActive = true;
		}
	}
}
