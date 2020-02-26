using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000160 RID: 352
	[ExecuteInEditMode]
	public class MobileControlRig : MonoBehaviour
	{
		// Token: 0x06000AAA RID: 2730 RVA: 0x0003F5D9 File Offset: 0x0003D9D9
		private void OnEnable()
		{
			this.CheckEnableControlRig();
		}

		// Token: 0x06000AAB RID: 2731 RVA: 0x0003F5E4 File Offset: 0x0003D9E4
		private void Start()
		{
			EventSystem x = UnityEngine.Object.FindObjectOfType<EventSystem>();
			if (x == null)
			{
				GameObject gameObject = new GameObject("EventSystem");
				gameObject.AddComponent<EventSystem>();
				gameObject.AddComponent<StandaloneInputModule>();
			}
		}

		// Token: 0x06000AAC RID: 2732 RVA: 0x0003F61C File Offset: 0x0003DA1C
		private void CheckEnableControlRig()
		{
			this.EnableControlRig(true);
		}

		// Token: 0x06000AAD RID: 2733 RVA: 0x0003F628 File Offset: 0x0003DA28
		private void EnableControlRig(bool enabled)
		{
			IEnumerator enumerator = base.transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					transform.gameObject.SetActive(enabled);
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}
	}
}
