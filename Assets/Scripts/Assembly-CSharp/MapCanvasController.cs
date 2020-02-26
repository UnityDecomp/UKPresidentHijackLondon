using System;
using UnityEngine;

// Token: 0x0200011E RID: 286
[AddComponentMenu("MiniMap/Map canvas controller")]
[RequireComponent(typeof(RectTransform))]
public class MapCanvasController : MonoBehaviour
{
	// Token: 0x17000038 RID: 56
	// (get) Token: 0x06000799 RID: 1945 RVA: 0x00032CEC File Offset: 0x000310EC
	public static MapCanvasController Instance
	{
		get
		{
			if (!MapCanvasController._instance)
			{
				MapCanvasController[] array = UnityEngine.Object.FindObjectsOfType<MapCanvasController>();
				if (array.Length != 0)
				{
					if (array.Length == 1)
					{
						MapCanvasController._instance = array[0];
					}
					else
					{
						Debug.LogError("You have more than one MapCanvasController in the scene.");
					}
				}
				else
				{
					Debug.LogError("You should add Map prefab to your canvas");
				}
			}
			return MapCanvasController._instance;
		}
	}

	// Token: 0x17000039 RID: 57
	// (get) Token: 0x0600079A RID: 1946 RVA: 0x00032D4A File Offset: 0x0003114A
	public InnerMap InnerMapComponent
	{
		get
		{
			return this.innerMap;
		}
	}

	// Token: 0x1700003A RID: 58
	// (get) Token: 0x0600079B RID: 1947 RVA: 0x00032D52 File Offset: 0x00031152
	public MarkerGroup MarkerGroup
	{
		get
		{
			return this.markerGroup;
		}
	}

	// Token: 0x0600079C RID: 1948 RVA: 0x00032D5C File Offset: 0x0003115C
	private void Awake()
	{
		if (!this.playerTransform)
		{
			Debug.LogError("You must specify the player transform");
		}
		this.mapRect = base.GetComponent<RectTransform>();
		this.innerMap = base.GetComponentInChildren<InnerMap>();
		if (!this.innerMap)
		{
			Debug.LogError("InnerMap component is missing from children");
		}
		this.mapArrow = base.GetComponentInChildren<MapArrow>();
		if (!this.mapArrow)
		{
			Debug.LogError("MapArrow component is missing from children");
		}
		this.markerGroup = base.GetComponentInChildren<MarkerGroup>();
		if (!this.markerGroup)
		{
			Debug.LogError("MerkerGroup component is missing. It must be a child of InnerMap");
		}
		this.innerMapRadius = this.innerMap.getMapRadius();
	}

	// Token: 0x0600079D RID: 1949 RVA: 0x00032E14 File Offset: 0x00031214
	private void Update()
	{
		if (!this.playerTransform)
		{
			return;
		}
		if (this.rotateMap)
		{
			this.mapRect.rotation = Quaternion.Euler(new Vector3(0f, 0f, this.playerTransform.eulerAngles.y));
			this.mapArrow.rotate(Quaternion.identity);
		}
		else
		{
			this.mapArrow.rotate(Quaternion.Euler(new Vector3(0f, 0f, -this.playerTransform.eulerAngles.y)));
		}
	}

	// Token: 0x0600079E RID: 1950 RVA: 0x00032EB8 File Offset: 0x000312B8
	public void checkIn(MapMarker marker)
	{
		if (!this.playerTransform)
		{
			return;
		}
		float num = this.radarDistance * this.scale;
		float num2 = this.maxRadarDistance * this.scale;
		if (marker.isActive)
		{
			float num3 = this.distanceToPlayer(marker.getPosition());
			float num4 = 1f;
			if (num3 > num)
			{
				if (this.hideOutOfRadius)
				{
					if (marker.isVisible())
					{
						marker.hide();
					}
					return;
				}
				if (num3 > num2)
				{
					if (marker.isVisible())
					{
						marker.hide();
					}
					return;
				}
				if (this.useOpacity)
				{
					float num5 = num2 - num;
					if (num5 <= 0f)
					{
						Debug.LogError("Max radar distance should be bigger than radar distance");
						return;
					}
					float num6 = num3 - num;
					num4 = 1f - num6 / num5;
					if (num4 < this.minimalOpacity)
					{
						num4 = this.minimalOpacity;
					}
				}
				num3 = num;
			}
			if (!marker.isVisible())
			{
				marker.show();
			}
			Vector3 vector = marker.getPosition() - this.playerTransform.position;
			Vector3 vector2 = new Vector3(vector.x, vector.z, 0f);
			vector2.Normalize();
			float num7 = marker.markerSize / 2f;
			float d = num3 / num * (this.innerMapRadius - num7);
			vector2 *= d;
			marker.setLocalPos(vector2);
			marker.setOpacity(num4);
		}
		else if (marker.isVisible())
		{
			marker.hide();
		}
	}

	// Token: 0x0600079F RID: 1951 RVA: 0x00033034 File Offset: 0x00031434
	private float distanceToPlayer(Vector3 other)
	{
		return Vector2.Distance(new Vector2(this.playerTransform.position.x, this.playerTransform.position.z), new Vector2(other.x, other.z));
	}

	// Token: 0x040006A6 RID: 1702
	private static MapCanvasController _instance;

	// Token: 0x040006A7 RID: 1703
	public Transform playerTransform;

	// Token: 0x040006A8 RID: 1704
	public float radarDistance = 10f;

	// Token: 0x040006A9 RID: 1705
	public bool hideOutOfRadius = true;

	// Token: 0x040006AA RID: 1706
	public bool useOpacity = true;

	// Token: 0x040006AB RID: 1707
	public float maxRadarDistance = 10f;

	// Token: 0x040006AC RID: 1708
	public bool rotateMap;

	// Token: 0x040006AD RID: 1709
	public float scale = 1f;

	// Token: 0x040006AE RID: 1710
	public float minimalOpacity = 0.3f;

	// Token: 0x040006AF RID: 1711
	private RectTransform mapRect;

	// Token: 0x040006B0 RID: 1712
	private InnerMap innerMap;

	// Token: 0x040006B1 RID: 1713
	private MapArrow mapArrow;

	// Token: 0x040006B2 RID: 1714
	private MarkerGroup markerGroup;

	// Token: 0x040006B3 RID: 1715
	private float innerMapRadius;
}
