using System;
using System.Collections;
using DG.Tweening;
using SWS;
using UnityEngine;

// Token: 0x020000F9 RID: 249
public class RapidInputDemo : MonoBehaviour
{
	// Token: 0x060006F8 RID: 1784 RVA: 0x0002DB78 File Offset: 0x0002BF78
	private void Start()
	{
		this.move = base.GetComponent<splineMove>();
		if (!this.move)
		{
			Debug.LogWarning(base.gameObject.name + " missing movement script!");
			return;
		}
		this.move.speed = 0.01f;
		this.move.StartMove();
		this.move.Pause(0f);
		this.move.speed = 0f;
	}

	// Token: 0x060006F9 RID: 1785 RVA: 0x0002DBF8 File Offset: 0x0002BFF8
	private void Update()
	{
		if (this.move.tween == null || !this.move.tween.IsActive() || this.move.tween.IsComplete())
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			if (!this.move.tween.IsPlaying())
			{
				this.move.Resume();
			}
			float num = this.currentSpeed + this.addSpeed;
			if (num >= this.topSpeed)
			{
				num = this.topSpeed;
			}
			this.move.ChangeSpeed(num);
			base.StopAllCoroutines();
			base.StartCoroutine("SlowDown");
		}
		this.speedDisplay.text = "YOUR SPEED: " + Mathf.Round(this.move.speed * 100f) / 100f;
		this.timeCounter += Time.deltaTime;
		this.timeDisplay.text = "YOUR TIME: " + Mathf.Round(this.timeCounter * 100f) / 100f;
	}

	// Token: 0x060006FA RID: 1786 RVA: 0x0002DD28 File Offset: 0x0002C128
	private IEnumerator SlowDown()
	{
		yield return new WaitForSeconds(this.delay);
		float t = 0f;
		float rate = 1f / this.slowTime;
		float speed = this.move.speed;
		while (t < 1f)
		{
			t += Time.deltaTime * rate;
			this.currentSpeed = Mathf.Lerp(speed, 0f, t);
			this.move.ChangeSpeed(this.currentSpeed);
			float pitchFactor = this.maxPitch - this.minPitch;
			float pitch = this.minPitch + this.move.speed / this.topSpeed * pitchFactor;
			if (base.GetComponent<AudioSource>())
			{
				base.GetComponent<AudioSource>().pitch = Mathf.SmoothStep(base.GetComponent<AudioSource>().pitch, pitch, 0.2f);
			}
			yield return null;
		}
		yield break;
	}

	// Token: 0x040005F2 RID: 1522
	public TextMesh speedDisplay;

	// Token: 0x040005F3 RID: 1523
	public TextMesh timeDisplay;

	// Token: 0x040005F4 RID: 1524
	public float topSpeed = 15f;

	// Token: 0x040005F5 RID: 1525
	public float addSpeed = 2f;

	// Token: 0x040005F6 RID: 1526
	public float delay = 0.05f;

	// Token: 0x040005F7 RID: 1527
	public float slowTime = 0.5f;

	// Token: 0x040005F8 RID: 1528
	public float minPitch;

	// Token: 0x040005F9 RID: 1529
	public float maxPitch = 2f;

	// Token: 0x040005FA RID: 1530
	private splineMove move;

	// Token: 0x040005FB RID: 1531
	private float currentSpeed;

	// Token: 0x040005FC RID: 1532
	private float timeCounter;
}
