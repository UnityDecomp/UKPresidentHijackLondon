using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000123 RID: 291
public class MyScript : MonoBehaviour
{
	// Token: 0x060007B9 RID: 1977 RVA: 0x000335C0 File Offset: 0x000319C0
	private void Start()
	{
		MonoBehaviour.print("Level No : 0" + PlayerPrefs.GetInt("Quest"));
		this.qms = (UnityEngine.Object.FindObjectOfType(typeof(QuestManager)) as QuestManager);
		if (PlayerPrefs.GetInt("Quest") == 0)
		{
			this.Player1Camera.gameObject.SetActive(true);
		}
		else
		{
			this.Player1Camera.gameObject.SetActive(false);
		}
		this.VanCamera.gameObject.SetActive(false);
		this.fade.enabled = false;
		for (int i = 0; i < this.checkpoints.Length; i++)
		{
			this.checkpoints[i].gameObject.SetActive(false);
		}
		if (PlayerPrefs.GetInt("Quest") == 0)
		{
			this.checkpoints[0].gameObject.SetActive(true);
			this.minimap.GetComponent<MapCanvasController>().playerTransform = this.MainModel.transform;
			this.qms.CrossHaire.gameObject.SetActive(false);
		}
		else if (PlayerPrefs.GetInt("Quest") == 1)
		{
			MonoBehaviour.print("ya 2 level ha");
			this.checkpoints[2].gameObject.SetActive(true);
			this.minimap.GetComponent<MapCanvasController>().playerTransform = this.GunModel.transform;
		}
	}

	// Token: 0x060007BA RID: 1978 RVA: 0x00033724 File Offset: 0x00031B24
	private void Update()
	{
	}

	// Token: 0x060007BB RID: 1979 RVA: 0x00033728 File Offset: 0x00031B28
	private IEnumerator Fading()
	{
		this.fade.enabled = true;
		yield return new WaitForSeconds(0.5f);
		this.fade.enabled = false;
		yield break;
	}

	// Token: 0x060007BC RID: 1980 RVA: 0x00033744 File Offset: 0x00031B44
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("VanIn"))
		{
			MonoBehaviour.print("van in : call ");
			this.Player1Camera.gameObject.SetActive(false);
			this.VanCamera.gameObject.SetActive(true);
			this.RccCanvas.gameObject.SetActive(true);
			this.mark = other.gameObject;
			base.StartCoroutine(this.Marker());
			if (PlayerPrefs.GetInt("Quest") == 0)
			{
				this.checkpoints[1].gameObject.SetActive(true);
				this.minimap.GetComponent<MapCanvasController>().playerTransform = this.Van.transform;
				this.qms.CFPP.GetComponent<TouchController>().touchZones[5].Hide(true);
			}
			if (PlayerPrefs.GetInt("Quest") == 1)
			{
				this.qms.CrossHaire.gameObject.SetActive(false);
				this.checkpoints[3].gameObject.SetActive(true);
				this.minimap.GetComponent<MapCanvasController>().playerTransform = this.Truck.transform;
				this.qms.CFPP.GetComponent<TouchController>().touchZones[0].Hide(true);
				this.qms.CFPP.GetComponent<TouchController>().touchZones[1].Hide(true);
				this.qms.panelInteract.gameObject.SetActive(false);
			}
		}
		if (other.gameObject.CompareTag("VanOut"))
		{
			MonoBehaviour.print("parking : call ");
			this.Player1Camera.gameObject.SetActive(true);
			this.RccCanvas.gameObject.SetActive(false);
			this.mark = other.gameObject;
			base.StartCoroutine(this.MarkerVan());
		}
		if (other.gameObject.CompareTag("Parking"))
		{
			base.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
			this.RccCanvas.gameObject.SetActive(false);
			other.gameObject.SetActive(false);
			this.Player1Camera.gameObject.SetActive(false);
			this.WegonRotateCam.gameObject.SetActive(true);
		}
		if (other.gameObject.CompareTag("PickMoney"))
		{
			this.Guard3.gameObject.SetActive(true);
			base.StartCoroutine(this.Fading());
		}
	}

	// Token: 0x060007BD RID: 1981 RVA: 0x000339B0 File Offset: 0x00031DB0
	private IEnumerator MarkerVan()
	{
		this.mark.GetComponent<MapMarker>().isActive = false;
		yield return new WaitForSeconds(0.02f);
		this.mark.gameObject.SetActive(false);
		if (PlayerPrefs.GetInt("Quest") == 0)
		{
			this.minimap.GetComponent<MapCanvasController>().playerTransform = this.MainModel.transform;
			this.Guard1.gameObject.SetActive(true);
			this.MainModel.gameObject.SetActive(true);
			this.VanCamera.gameObject.SetActive(false);
			this.Van.gameObject.SetActive(false);
			this.qms.CFPP.GetComponent<TouchController>().touchZones[5].Show(true);
			this.MainModel.position = this.Van.position;
		}
		if (PlayerPrefs.GetInt("Quest") == 1)
		{
			this.minimap.GetComponent<MapCanvasController>().playerTransform = this.GunModel.transform;
			this.Truck.gameObject.SetActive(false);
			this.GunModel.gameObject.SetActive(true);
			this.GunModel.position = this.Truck.position;
			this.Guard2.gameObject.SetActive(true);
			this.qms.CFPP.GetComponent<TouchController>().touchZones[0].Show(true);
			this.qms.CFPP.GetComponent<TouchController>().touchZones[1].Show(true);
			this.qms.panelInteract.gameObject.SetActive(true);
		}
		yield break;
	}

	// Token: 0x060007BE RID: 1982 RVA: 0x000339CC File Offset: 0x00031DCC
	private IEnumerator Marker()
	{
		this.mark.GetComponent<MapMarker>().isActive = false;
		yield return new WaitForSeconds(0.02f);
		this.MainModel.gameObject.SetActive(false);
		this.mark.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x040006C1 RID: 1729
	private QuestManager qms;

	// Token: 0x040006C2 RID: 1730
	private int questId;

	// Token: 0x040006C3 RID: 1731
	public Camera Player1Camera;

	// Token: 0x040006C4 RID: 1732
	public Camera VanCamera;

	// Token: 0x040006C5 RID: 1733
	public Camera WegonRotateCam;

	// Token: 0x040006C6 RID: 1734
	public Transform MainModel;

	// Token: 0x040006C7 RID: 1735
	public Transform GunModel;

	// Token: 0x040006C8 RID: 1736
	public Transform Van;

	// Token: 0x040006C9 RID: 1737
	public Transform Truck;

	// Token: 0x040006CA RID: 1738
	public Transform Guard1;

	// Token: 0x040006CB RID: 1739
	public Transform Guard2;

	// Token: 0x040006CC RID: 1740
	public Transform Guard3;

	// Token: 0x040006CD RID: 1741
	public GameObject RccCanvas;

	// Token: 0x040006CE RID: 1742
	public GameObject minimap;

	// Token: 0x040006CF RID: 1743
	public GameObject mark;

	// Token: 0x040006D0 RID: 1744
	public EasyJoystick Joystick;

	// Token: 0x040006D1 RID: 1745
	public bool switchplayer;

	// Token: 0x040006D2 RID: 1746
	public GameObject[] checkpoints;

	// Token: 0x040006D3 RID: 1747
	public Image fade;
}
