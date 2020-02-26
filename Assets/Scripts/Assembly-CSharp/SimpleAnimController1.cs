using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000121 RID: 289
public class SimpleAnimController1 : MonoBehaviour
{
	// Token: 0x060007AE RID: 1966 RVA: 0x000332AF File Offset: 0x000316AF
	private void Start()
	{
		this.UpdateTarget();
	}

	// Token: 0x060007AF RID: 1967 RVA: 0x000332B8 File Offset: 0x000316B8
	private void Update()
	{
		this.anim.SetFloat("speed", this.speed);
		this.anim.SetInteger("randomint", UnityEngine.Random.Range(0, 100));
		if (this.cameraAnchor != null)
		{
			this.cameraAnchor.transform.position = Vector3.Lerp(this.cameraAnchor.transform.position, this.target.transform.position, Time.deltaTime * 5f);
		}
	}

	// Token: 0x060007B0 RID: 1968 RVA: 0x00033344 File Offset: 0x00031744
	private void UpdateTarget()
	{
		if (!this.ValidateTargets())
		{
			return;
		}
		this.target = this.targets[this.currentTargetIdx];
		if (this.anim != null)
		{
			this.anim.SetFloat("speed", 0f);
			this.anim.SetInteger("randomint", 0);
		}
		this.anim = this.target.GetComponent<Animator>();
	}

	// Token: 0x060007B1 RID: 1969 RVA: 0x000333BC File Offset: 0x000317BC
	private bool ValidateTargets()
	{
		if (this.targets.Count == 0)
		{
			return false;
		}
		if (this.currentTargetIdx < 0)
		{
			this.currentTargetIdx = 0;
		}
		if (this.currentTargetIdx >= this.targets.Count)
		{
			this.currentTargetIdx = this.targets.Count - 1;
		}
		return true;
	}

	// Token: 0x060007B2 RID: 1970 RVA: 0x00033418 File Offset: 0x00031818
	private void NextTarget()
	{
		this.currentTargetIdx++;
		if (this.currentTargetIdx >= this.targets.Count)
		{
			this.currentTargetIdx = 0;
		}
		this.UpdateTarget();
	}

	// Token: 0x060007B3 RID: 1971 RVA: 0x0003344B File Offset: 0x0003184B
	private void PreviousTarget()
	{
		this.currentTargetIdx--;
		if (this.currentTargetIdx < 0)
		{
			this.currentTargetIdx = this.targets.Count - 1;
		}
		this.UpdateTarget();
	}

	// Token: 0x060007B4 RID: 1972 RVA: 0x00033480 File Offset: 0x00031880
	private void OnGUI()
	{
		if (GUI.Button(new Rect((float)(Screen.width / 2 - 50), (float)(Screen.height - 100), 50f, 50f), "<<"))
		{
			this.PreviousTarget();
		}
		if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height - 100), 50f, 50f), ">>"))
		{
			this.NextTarget();
		}
		this.speed = GUI.HorizontalSlider(new Rect((float)(Screen.width / 2 - 50), (float)(Screen.height - 40), 100f, 30f), this.speed, 0f, 1f);
		GUIStyle style = GUI.skin.GetStyle("Label");
		style.alignment = TextAnchor.MiddleCenter;
		GUI.Label(new Rect((float)(Screen.width / 2 - 100), 10f, 200f, 30f), this.target.name);
	}

	// Token: 0x040006B9 RID: 1721
	private GameObject target;

	// Token: 0x040006BA RID: 1722
	private Animator anim;

	// Token: 0x040006BB RID: 1723
	private float acceleration;

	// Token: 0x040006BC RID: 1724
	private float speed;

	// Token: 0x040006BD RID: 1725
	public List<GameObject> targets = new List<GameObject>();

	// Token: 0x040006BE RID: 1726
	public int currentTargetIdx;

	// Token: 0x040006BF RID: 1727
	public GameObject cameraAnchor;
}
