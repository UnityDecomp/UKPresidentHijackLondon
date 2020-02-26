using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200011B RID: 283
public class SimpleAnimController : MonoBehaviour
{
	// Token: 0x0600078B RID: 1931 RVA: 0x000328D8 File Offset: 0x00030CD8
	private void Start()
	{
		this.UpdateTarget();
	}

	// Token: 0x0600078C RID: 1932 RVA: 0x000328E0 File Offset: 0x00030CE0
	private void Update()
	{
		this.anim.SetFloat("speed", this.speed);
		this.anim.SetInteger("randomint", UnityEngine.Random.Range(0, 100));
		if (this.cameraAnchor != null)
		{
			this.cameraAnchor.transform.position = Vector3.Lerp(this.cameraAnchor.transform.position, this.target.transform.position, Time.deltaTime * 5f);
		}
	}

	// Token: 0x0600078D RID: 1933 RVA: 0x0003296C File Offset: 0x00030D6C
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

	// Token: 0x0600078E RID: 1934 RVA: 0x000329E4 File Offset: 0x00030DE4
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

	// Token: 0x0600078F RID: 1935 RVA: 0x00032A40 File Offset: 0x00030E40
	private void NextTarget()
	{
		this.currentTargetIdx++;
		if (this.currentTargetIdx >= this.targets.Count)
		{
			this.currentTargetIdx = 0;
		}
		this.UpdateTarget();
	}

	// Token: 0x06000790 RID: 1936 RVA: 0x00032A73 File Offset: 0x00030E73
	private void PreviousTarget()
	{
		this.currentTargetIdx--;
		if (this.currentTargetIdx < 0)
		{
			this.currentTargetIdx = this.targets.Count - 1;
		}
		this.UpdateTarget();
	}

	// Token: 0x06000791 RID: 1937 RVA: 0x00032AA8 File Offset: 0x00030EA8
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

	// Token: 0x0400069D RID: 1693
	private GameObject target;

	// Token: 0x0400069E RID: 1694
	private Animator anim;

	// Token: 0x0400069F RID: 1695
	private float acceleration;

	// Token: 0x040006A0 RID: 1696
	private float speed;

	// Token: 0x040006A1 RID: 1697
	public List<GameObject> targets = new List<GameObject>();

	// Token: 0x040006A2 RID: 1698
	public int currentTargetIdx;

	// Token: 0x040006A3 RID: 1699
	public GameObject cameraAnchor;
}
