using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200011F RID: 287
[AddComponentMenu("MiniMap/Map marker")]
public class MapMarker : MonoBehaviour
{
	// Token: 0x1700003B RID: 59
	// (get) Token: 0x060007A1 RID: 1953 RVA: 0x0003309E File Offset: 0x0003149E
	public Image MarkerImage
	{
		get
		{
			return this.markerImage;
		}
	}

	// Token: 0x060007A2 RID: 1954 RVA: 0x000330A8 File Offset: 0x000314A8
	private void Start()
	{
		if (!this.markerSprite)
		{
			Debug.LogError(" Please, specify the marker sprite.");
		}
		GameObject gameObject = new GameObject("Marker");
		gameObject.AddComponent<Image>();
		MapCanvasController instance = MapCanvasController.Instance;
		if (!instance)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		gameObject.transform.SetParent(instance.MarkerGroup.MarkerGroupRect);
		this.markerImage = gameObject.GetComponent<Image>();
		this.markerImage.sprite = this.markerSprite;
		this.markerImage.rectTransform.localPosition = Vector3.zero;
		this.markerImage.rectTransform.localScale = Vector3.one;
		this.markerImage.rectTransform.sizeDelta = new Vector2(this.markerSize, this.markerSize);
		this.markerImage.gameObject.SetActive(false);
	}

	// Token: 0x060007A3 RID: 1955 RVA: 0x00033190 File Offset: 0x00031590
	private void Update()
	{
		MapCanvasController instance = MapCanvasController.Instance;
		if (!instance)
		{
			return;
		}
		MapCanvasController.Instance.checkIn(this);
		this.markerImage.rectTransform.rotation = Quaternion.identity;
	}

	// Token: 0x060007A4 RID: 1956 RVA: 0x000331CF File Offset: 0x000315CF
	private void OnDestroy()
	{
		if (this.markerImage)
		{
			UnityEngine.Object.Destroy(this.markerImage.gameObject);
		}
	}

	// Token: 0x060007A5 RID: 1957 RVA: 0x000331F1 File Offset: 0x000315F1
	public void show()
	{
		this.markerImage.gameObject.SetActive(true);
	}

	// Token: 0x060007A6 RID: 1958 RVA: 0x00033204 File Offset: 0x00031604
	public void hide()
	{
		this.markerImage.gameObject.SetActive(false);
	}

	// Token: 0x060007A7 RID: 1959 RVA: 0x00033217 File Offset: 0x00031617
	public bool isVisible()
	{
		return this.markerImage.gameObject.activeSelf;
	}

	// Token: 0x060007A8 RID: 1960 RVA: 0x00033229 File Offset: 0x00031629
	public Vector3 getPosition()
	{
		return base.gameObject.transform.position;
	}

	// Token: 0x060007A9 RID: 1961 RVA: 0x0003323B File Offset: 0x0003163B
	public void setLocalPos(Vector3 pos)
	{
		this.markerImage.rectTransform.localPosition = pos;
	}

	// Token: 0x060007AA RID: 1962 RVA: 0x0003324E File Offset: 0x0003164E
	public void setOpacity(float opacity)
	{
		this.markerImage.color = new Color(1f, 1f, 1f, opacity);
	}

	// Token: 0x040006B4 RID: 1716
	public Sprite markerSprite;

	// Token: 0x040006B5 RID: 1717
	public float markerSize = 6.5f;

	// Token: 0x040006B6 RID: 1718
	public bool isActive = true;

	// Token: 0x040006B7 RID: 1719
	private Image markerImage;
}
