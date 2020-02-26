using System;
using UnityEngine;

// Token: 0x02000217 RID: 535
public class UnderWaterSystem : MonoBehaviour
{
	// Token: 0x06000DBD RID: 3517 RVA: 0x00057DE3 File Offset: 0x000561E3
	private void Start()
	{
	}

	// Token: 0x06000DBE RID: 3518 RVA: 0x00057DE5 File Offset: 0x000561E5
	private void Update()
	{
		if (this.up)
		{
			this.swimUp();
		}
		if (this.down)
		{
			this.swimDown();
		}
	}

	// Token: 0x06000DBF RID: 3519 RVA: 0x00057E0C File Offset: 0x0005620C
	public void activateSwimControls()
	{
		base.GetComponent<dogsactive>().getActivePlayer().GetComponent<CharacterMotorC>().movement.gravity = 0f;
		this.bubbles.SetActive(true);
		this.dLight.SetActive(false);
		this.swimLight.SetActive(true);
		this.swim = true;
	}

	// Token: 0x06000DC0 RID: 3520 RVA: 0x00057E63 File Offset: 0x00056263
	public void showSwimPanel()
	{
		this.swimPanel.SetActive(true);
	}

	// Token: 0x06000DC1 RID: 3521 RVA: 0x00057E71 File Offset: 0x00056271
	public void hideSwimPanel()
	{
		this.swimPanel.SetActive(false);
		this.up = false;
		this.down = false;
		this.bubbles.SetActive(false);
		this.swimLight.SetActive(false);
		this.dLight.SetActive(true);
	}

	// Token: 0x06000DC2 RID: 3522 RVA: 0x00057EB4 File Offset: 0x000562B4
	public void deactivateSwimControls()
	{
		base.GetComponent<dogsactive>().getActivePlayer().GetComponent<CharacterMotorC>().movement.gravity = 30f;
		this.bubbles.SetActive(false);
		this.dLight.SetActive(true);
		this.hideSwimPanel();
		this.swimLight.SetActive(false);
		this.swim = false;
	}

	// Token: 0x06000DC3 RID: 3523 RVA: 0x00057F11 File Offset: 0x00056311
	public void swimUp()
	{
		base.GetComponent<dogsactive>().getActivePlayer().GetComponent<CharacterController>().Move(Vector3.up * this.swimSpeed * Time.deltaTime);
	}

	// Token: 0x06000DC4 RID: 3524 RVA: 0x00057F43 File Offset: 0x00056343
	public void swimDown()
	{
		base.GetComponent<dogsactive>().getActivePlayer().GetComponent<CharacterController>().Move(Vector3.down * this.swimSpeed * Time.deltaTime);
	}

	// Token: 0x06000DC5 RID: 3525 RVA: 0x00057F75 File Offset: 0x00056375
	public void OnSwimUpPointerUp()
	{
		this.up = false;
	}

	// Token: 0x06000DC6 RID: 3526 RVA: 0x00057F7E File Offset: 0x0005637E
	public void OnSwimUpPointerDown()
	{
		this.up = true;
	}

	// Token: 0x06000DC7 RID: 3527 RVA: 0x00057F87 File Offset: 0x00056387
	public void OnSwimDownPointerUp()
	{
		this.down = false;
	}

	// Token: 0x06000DC8 RID: 3528 RVA: 0x00057F90 File Offset: 0x00056390
	public void OnSwimDownPointerDown()
	{
		this.down = true;
	}

	// Token: 0x04000E7B RID: 3707
	public GameObject dLight;

	// Token: 0x04000E7C RID: 3708
	public GameObject swimLight;

	// Token: 0x04000E7D RID: 3709
	public GameObject bubbles;

	// Token: 0x04000E7E RID: 3710
	public GameObject swimPanel;

	// Token: 0x04000E7F RID: 3711
	public float swimSpeed;

	// Token: 0x04000E80 RID: 3712
	private bool up;

	// Token: 0x04000E81 RID: 3713
	private bool down;

	// Token: 0x04000E82 RID: 3714
	public bool swim;
}
