using System;
using UnityEngine;

// Token: 0x02000120 RID: 288
[AddComponentMenu("MiniMap/Marker Group")]
[RequireComponent(typeof(RectTransform))]
public class MarkerGroup : MonoBehaviour
{
	// Token: 0x1700003C RID: 60
	// (get) Token: 0x060007AC RID: 1964 RVA: 0x00033278 File Offset: 0x00031678
	public RectTransform MarkerGroupRect
	{
		get
		{
			if (!this._rectTransform)
			{
				this._rectTransform = base.GetComponent<RectTransform>();
			}
			return this._rectTransform;
		}
	}

	// Token: 0x040006B8 RID: 1720
	private RectTransform _rectTransform;
}
