using System;
using UnityEngine;

// Token: 0x02000065 RID: 101
[Serializable]
public class MoveForward : MonoBehaviour
{
	// Token: 0x0600013A RID: 314 RVA: 0x0000F92C File Offset: 0x0000DB2C
	public MoveForward()
	{
		this.Speed = (float)20;
		this.relativeDirection = Vector3.forward;
		this.duration = 1f;
	}

	// Token: 0x0600013B RID: 315 RVA: 0x0000F954 File Offset: 0x0000DB54
	public virtual void Start()
	{
		UnityEngine.Object.Destroy(this.gameObject, this.duration);
	}

	// Token: 0x0600013C RID: 316 RVA: 0x0000F968 File Offset: 0x0000DB68
	public virtual void Update()
	{
		Vector3 a = this.transform.rotation * this.relativeDirection;
		this.transform.position = this.transform.position + a * this.Speed * Time.deltaTime;
	}

	// Token: 0x0600013D RID: 317 RVA: 0x0000F9C0 File Offset: 0x0000DBC0
	public virtual void Main()
	{
	}

	// Token: 0x04000224 RID: 548
	public float Speed;

	// Token: 0x04000225 RID: 549
	public Vector3 relativeDirection;

	// Token: 0x04000226 RID: 550
	public float duration;
}
