using System;
using System.Collections;
using UnityEngine;

// Token: 0x020001F0 RID: 496
public class MenuDirector : MonoBehaviour
{
	// Token: 0x06000CCE RID: 3278 RVA: 0x000508DE File Offset: 0x0004ECDE
	private void Start()
	{
		base.StartCoroutine(this.ActExecution());
	}

	// Token: 0x06000CCF RID: 3279 RVA: 0x000508F0 File Offset: 0x0004ECF0
	private IEnumerator ActExecution()
	{
		for (int i = 0; i < this.acts.Length; i++)
		{
			this.acts[i].Cam.SetActive(true);
			this.camInitialPosition = this.acts[i].Cam.transform.localPosition;
			this.camInitialRotation = this.acts[i].Cam.transform.localRotation;
			this.acts[i].Actor.SetActive(true);
			if (this.acts[i].targetPoint)
			{
				this.acts[i].Cam.GetComponent<CameraDirector>().target = this.acts[i].targetPoint;
			}
			this.acts[i].Cam.GetComponent<CameraDirector>().speed = this.acts[i].speed;
			if (this.acts[i].camType == MenuDirector.Action.CamType.RotateAround)
			{
				this.acts[i].Cam.GetComponent<CameraDirector>().camType = CameraDirector.CamType.RotateAround;
			}
			if (this.acts[i].camType == MenuDirector.Action.CamType.RotateItself)
			{
				this.acts[i].Cam.GetComponent<CameraDirector>().camType = CameraDirector.CamType.RotateItself;
			}
			if (this.acts[i].camType == MenuDirector.Action.CamType.MoveToward)
			{
				this.acts[i].Cam.GetComponent<CameraDirector>().camType = CameraDirector.CamType.MoveToward;
			}
			this.acts[i].Cam.GetComponent<CameraDirector>().allowCam = true;
			yield return new WaitForSeconds(this.acts[i].delay);
			if (this.fader)
			{
				this.fader.SetActive(true);
				this.fader.GetComponent<Fader>().ExecuteFading();
				yield return new WaitForSeconds(0.6f);
			}
			this.acts[i].Cam.SetActive(false);
			this.acts[i].Actor.SetActive(false);
			if (this.acts[i].retainPosition)
			{
				this.acts[i].Cam.transform.localPosition = new Vector3(this.camInitialPosition.x, this.camInitialPosition.y, this.camInitialPosition.z);
				this.acts[i].Cam.transform.localRotation = this.camInitialRotation;
			}
			if (i == this.acts.Length - 1)
			{
				i = -1;
			}
		}
		yield break;
	}

	// Token: 0x04000D41 RID: 3393
	private Vector3 camInitialPosition = Vector3.zero;

	// Token: 0x04000D42 RID: 3394
	private Quaternion camInitialRotation = Quaternion.Euler(Vector3.zero);

	// Token: 0x04000D43 RID: 3395
	public GameObject fader;

	// Token: 0x04000D44 RID: 3396
	public MenuDirector.Action[] acts;

	// Token: 0x020001F1 RID: 497
	[Serializable]
	public class Action
	{
		// Token: 0x04000D45 RID: 3397
		public GameObject Cam;

		// Token: 0x04000D46 RID: 3398
		public GameObject Actor;

		// Token: 0x04000D47 RID: 3399
		public Transform targetPoint;

		// Token: 0x04000D48 RID: 3400
		public float speed = 5f;

		// Token: 0x04000D49 RID: 3401
		public float delay = 5f;

		// Token: 0x04000D4A RID: 3402
		public MenuDirector.Action.CamType camType;

		// Token: 0x04000D4B RID: 3403
		public bool retainPosition;

		// Token: 0x020001F2 RID: 498
		public enum CamType
		{
			// Token: 0x04000D4D RID: 3405
			RotateItself,
			// Token: 0x04000D4E RID: 3406
			RotateAround,
			// Token: 0x04000D4F RID: 3407
			MoveToward
		}
	}
}
