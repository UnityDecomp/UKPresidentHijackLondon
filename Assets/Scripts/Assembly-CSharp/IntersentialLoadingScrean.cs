using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000144 RID: 324
public class IntersentialLoadingScrean : MonoBehaviour
{
	// Token: 0x06000A15 RID: 2581 RVA: 0x0003DB78 File Offset: 0x0003BF78
	private void OnEnable()
	{
		this.m_time = 3f;
	}

	// Token: 0x06000A16 RID: 2582 RVA: 0x0003DB88 File Offset: 0x0003BF88
	private void Update()
	{
		if (base.gameObject.activeSelf)
		{
			this.m_time -= Time.deltaTime;
			int num = (int)Mathf.Ceil(this.m_time);
			string text = string.Empty;
			if (num > 0)
			{
				text = text + "Loading ad in " + num.ToString();
			}
			else
			{
				int num2 = Mathf.Abs(num % 4);
				string text2 = string.Empty;
				for (int i = 0; i < num2; i++)
				{
					text2 += ".";
				}
				text = "Loading " + text2;
			}
			this.m_loadingMessage.text = text;
		}
	}

	// Token: 0x04000942 RID: 2370
	public Text m_loadingMessage;

	// Token: 0x04000943 RID: 2371
	private float m_time = 3f;
}
