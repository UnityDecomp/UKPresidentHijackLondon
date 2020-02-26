using System;
using UnityEngine;

// Token: 0x0200011D RID: 285
[AddComponentMenu("MiniMap/Map arrow")]
public class MapArrow : MonoBehaviour
{
	// Token: 0x17000037 RID: 55
	// (get) Token: 0x06000796 RID: 1942 RVA: 0x00032C4D File Offset: 0x0003104D
	public RectTransform ArrowRect
	{
		get
		{
			if (!this._arrowRect)
			{
				this._arrowRect = base.GetComponent<RectTransform>();
				if (!this._arrowRect)
				{
					Debug.LogError("RectTransform not found. MapArrow script must by attached to an Image.");
				}
			}
			return this._arrowRect;
		}
	}

	// Token: 0x06000797 RID: 1943 RVA: 0x00032C8B File Offset: 0x0003108B
	public void rotate(Quaternion quat)
	{
		this.ArrowRect.rotation = quat;
	}

	// Token: 0x040006A5 RID: 1701
	private RectTransform _arrowRect;
}
