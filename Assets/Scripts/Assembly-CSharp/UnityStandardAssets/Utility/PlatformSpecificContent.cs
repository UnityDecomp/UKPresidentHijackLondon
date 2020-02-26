using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001C3 RID: 451
	public class PlatformSpecificContent : MonoBehaviour
	{
		// Token: 0x06000BF5 RID: 3061 RVA: 0x0004B846 File Offset: 0x00049C46
		private void OnEnable()
		{
			this.CheckEnableContent();
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x0004B84E File Offset: 0x00049C4E
		private void CheckEnableContent()
		{
			if (this.m_BuildTargetGroup == PlatformSpecificContent.BuildTargetGroup.Mobile)
			{
				this.EnableContent(true);
			}
			else
			{
				this.EnableContent(false);
			}
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x0004B870 File Offset: 0x00049C70
		private void EnableContent(bool enabled)
		{
			if (this.m_Content.Length > 0)
			{
				foreach (GameObject gameObject in this.m_Content)
				{
					if (gameObject != null)
					{
						gameObject.SetActive(enabled);
					}
				}
			}
			if (this.m_ChildrenOfThisObject)
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
			if (this.m_MonoBehaviours.Length > 0)
			{
				foreach (MonoBehaviour monoBehaviour in this.m_MonoBehaviours)
				{
					monoBehaviour.enabled = enabled;
				}
			}
		}

		// Token: 0x04000C3D RID: 3133
		[SerializeField]
		private PlatformSpecificContent.BuildTargetGroup m_BuildTargetGroup;

		// Token: 0x04000C3E RID: 3134
		[SerializeField]
		private GameObject[] m_Content = new GameObject[0];

		// Token: 0x04000C3F RID: 3135
		[SerializeField]
		private MonoBehaviour[] m_MonoBehaviours = new MonoBehaviour[0];

		// Token: 0x04000C40 RID: 3136
		[SerializeField]
		private bool m_ChildrenOfThisObject;

		// Token: 0x020001C4 RID: 452
		private enum BuildTargetGroup
		{
			// Token: 0x04000C42 RID: 3138
			Standalone,
			// Token: 0x04000C43 RID: 3139
			Mobile
		}
	}
}
