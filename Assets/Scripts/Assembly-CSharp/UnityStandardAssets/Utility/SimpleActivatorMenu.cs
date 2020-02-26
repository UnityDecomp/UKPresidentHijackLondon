using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
	// Token: 0x020001C5 RID: 453
	public class SimpleActivatorMenu : MonoBehaviour
	{
		// Token: 0x06000BF9 RID: 3065 RVA: 0x0004B974 File Offset: 0x00049D74
		private void OnEnable()
		{
			this.m_CurrentActiveObject = 0;
			this.camSwitchButton.text = this.objects[this.m_CurrentActiveObject].name;
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x0004B99C File Offset: 0x00049D9C
		public void NextCamera()
		{
			int num = (this.m_CurrentActiveObject + 1 < this.objects.Length) ? (this.m_CurrentActiveObject + 1) : 0;
			for (int i = 0; i < this.objects.Length; i++)
			{
				this.objects[i].SetActive(i == num);
			}
			this.m_CurrentActiveObject = num;
			this.camSwitchButton.text = this.objects[this.m_CurrentActiveObject].name;
		}

		// Token: 0x04000C44 RID: 3140
		public GUIText camSwitchButton;

		// Token: 0x04000C45 RID: 3141
		public GameObject[] objects;

		// Token: 0x04000C46 RID: 3142
		private int m_CurrentActiveObject;
	}
}
