using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

// Token: 0x0200005B RID: 91
[Serializable]
public class MinimapCamera : MonoBehaviour
{
	// Token: 0x0600011F RID: 287 RVA: 0x0000F29C File Offset: 0x0000D49C
	public MinimapCamera()
	{
		this.zoomMin = (float)20;
		this.zoomMax = (float)70;
	}

	// Token: 0x06000120 RID: 288 RVA: 0x0000F2B8 File Offset: 0x0000D4B8
	public virtual IEnumerator Start()
	{
		return new MinimapCamera.$Start$185(this).GetEnumerator();
	}

	// Token: 0x06000121 RID: 289 RVA: 0x0000F2C8 File Offset: 0x0000D4C8
	public virtual void Update()
	{
		if (this.target)
		{
			this.transform.position = new Vector3(this.target.position.x, this.transform.position.y, this.target.position.z);
			if (Input.GetKeyDown(KeyCode.KeypadPlus) && this.GetComponent<Camera>().orthographicSize >= this.zoomMin)
			{
				this.GetComponent<Camera>().orthographic = true;
				this.GetComponent<Camera>().orthographicSize = this.GetComponent<Camera>().orthographicSize - (float)10;
			}
			if (Input.GetKeyDown(KeyCode.KeypadMinus) && this.GetComponent<Camera>().orthographicSize <= this.zoomMax)
			{
				this.GetComponent<Camera>().orthographic = true;
				this.GetComponent<Camera>().orthographicSize = this.GetComponent<Camera>().orthographicSize + (float)10;
			}
		}
	}

	// Token: 0x06000122 RID: 290 RVA: 0x0000F3CC File Offset: 0x0000D5CC
	public virtual void FindTarget()
	{
		if (!this.target)
		{
			Transform transform = GameObject.FindWithTag("Player").transform;
			if (transform)
			{
				this.target = transform;
			}
		}
	}

	// Token: 0x06000123 RID: 291 RVA: 0x0000F410 File Offset: 0x0000D610
	public virtual void Main()
	{
	}

	// Token: 0x04000209 RID: 521
	public Transform target;

	// Token: 0x0400020A RID: 522
	public float zoomMin;

	// Token: 0x0400020B RID: 523
	public float zoomMax;

	// Token: 0x0200005C RID: 92
	[CompilerGenerated]
	[Serializable]
	internal sealed class $Start$185 : GenericGenerator<WaitForSeconds>
	{
		// Token: 0x06000124 RID: 292 RVA: 0x0000F414 File Offset: 0x0000D614
		public $Start$185(MinimapCamera self_)
		{
			this.$self_$187 = self_;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0000F424 File Offset: 0x0000D624
		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new MinimapCamera.$Start$185.$(this.$self_$187);
		}

		// Token: 0x0400020C RID: 524
		internal MinimapCamera $self_$187;
	}
}
