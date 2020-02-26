using System;
using UnityEngine;

// Token: 0x02000044 RID: 68
[Serializable]
public class Gate : MonoBehaviour
{
	// Token: 0x060000CB RID: 203 RVA: 0x0000A218 File Offset: 0x00008418
	public Gate()
	{
		this.text = "Text Here";
		this.text2 = "Text Here";
		this.moveY = 5f;
		this.duration = 1f;
	}

	// Token: 0x060000CC RID: 204 RVA: 0x0000A258 File Offset: 0x00008458
	public virtual void Update()
	{
		if (this.move)
		{
			this.mainGate.transform.Translate(this.moveX * Time.deltaTime, this.moveY * Time.deltaTime, this.moveZ * Time.deltaTime);
			if (this.wait >= this.duration)
			{
				this.move = false;
				this.complete = true;
			}
		}
		if (Input.GetButtonDown("Fire1") && this.talking)
		{
			this.talking = false;
			Time.timeScale = 1f;
		}
		if (Input.GetKeyDown("e") && this.enter)
		{
			if (this.talking)
			{
				this.talking = false;
				Time.timeScale = 1f;
			}
			else if (this.key >= 2)
			{
				this.wait += Time.deltaTime;
				this.move = true;
			}
			else
			{
				this.talking = true;
			}
		}
	}

	// Token: 0x060000CD RID: 205 RVA: 0x0000A35C File Offset: 0x0000855C
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.enter = true;
			this.talking = false;
		}
	}

	// Token: 0x060000CE RID: 206 RVA: 0x0000A394 File Offset: 0x00008594
	public virtual void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			this.enter = false;
			this.talking = false;
		}
	}

	// Token: 0x060000CF RID: 207 RVA: 0x0000A3CC File Offset: 0x000085CC
	public virtual void OnTriggerStay(Collider other)
	{
		if (!(other.gameObject.tag == "Player") || this.complete)
		{
		}
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x0000A404 File Offset: 0x00008604
	public virtual void OnGUI()
	{
		if (this.enter && !this.talking && !this.complete)
		{
			GUI.DrawTexture(new Rect((float)(Screen.width / 2 - 130), (float)(Screen.height - 120), (float)260, (float)80), this.button);
		}
		if (this.talking)
		{
			GUI.DrawTexture(new Rect((float)32, (float)(Screen.height - 245), (float)564, (float)220), this.textWindow);
			GUI.Label(new Rect((float)55, (float)(Screen.height - 220), (float)500, (float)200), this.text, this.textStyle);
			GUI.Label(new Rect((float)55, (float)(Screen.height - 185), (float)500, (float)200), this.text2, this.textStyle);
		}
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x0000A4FC File Offset: 0x000086FC
	public virtual void Main()
	{
	}

	// Token: 0x04000174 RID: 372
	public GameObject mainGate;

	// Token: 0x04000175 RID: 373
	public Texture2D button;

	// Token: 0x04000176 RID: 374
	public Texture2D textWindow;

	// Token: 0x04000177 RID: 375
	public string text;

	// Token: 0x04000178 RID: 376
	public string text2;

	// Token: 0x04000179 RID: 377
	public int key;

	// Token: 0x0400017A RID: 378
	public float moveX;

	// Token: 0x0400017B RID: 379
	public float moveY;

	// Token: 0x0400017C RID: 380
	public float moveZ;

	// Token: 0x0400017D RID: 381
	public float duration;

	// Token: 0x0400017E RID: 382
	private bool move;

	// Token: 0x0400017F RID: 383
	private bool talking;

	// Token: 0x04000180 RID: 384
	private bool enter;

	// Token: 0x04000181 RID: 385
	private bool complete;

	// Token: 0x04000182 RID: 386
	private float wait;

	// Token: 0x04000183 RID: 387
	public GUIStyle textStyle;
}
