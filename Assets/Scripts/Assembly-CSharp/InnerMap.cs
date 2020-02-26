using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200011C RID: 284
[AddComponentMenu("MiniMap/Inner map")]
[RequireComponent(typeof(Image))]
public class InnerMap : MonoBehaviour
{
	// Token: 0x17000036 RID: 54
	// (get) Token: 0x06000793 RID: 1939 RVA: 0x00032BAE File Offset: 0x00030FAE
	public RectTransform InnerMapRect
	{
		get
		{
			if (!this._innerMapRect)
			{
				this._innerMapRect = base.GetComponent<RectTransform>();
			}
			return this._innerMapRect;
		}
	}

	// Token: 0x06000794 RID: 1940 RVA: 0x00032BD4 File Offset: 0x00030FD4
	public float getMapRadius()
	{
		Vector3[] array = new Vector3[4];
		this.InnerMapRect.GetLocalCorners(array);
		float result;
		if (Mathf.Abs(array[0].x) < Mathf.Abs(array[0].y))
		{
			result = Mathf.Abs(array[0].x);
		}
		else
		{
			result = Mathf.Abs(array[0].y);
		}
		return result;
	}

	// Token: 0x040006A4 RID: 1700
	private RectTransform _innerMapRect;
}
