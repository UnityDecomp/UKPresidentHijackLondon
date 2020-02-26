using System;
using UnityEngine;

// Token: 0x020001DB RID: 475
public class Climbing : MonoBehaviour
{
	// Token: 0x06000C59 RID: 3161 RVA: 0x0004E426 File Offset: 0x0004C826
	private void Start()
	{
	}

	// Token: 0x06000C5A RID: 3162 RVA: 0x0004E428 File Offset: 0x0004C828
	private void Update()
	{
	}

	// Token: 0x06000C5B RID: 3163 RVA: 0x0004E42C File Offset: 0x0004C82C
	public void turnONClimbJoystick()
	{
		this.climbJoystick.SetActive(true);
		this.climbJoystick.GetComponent<EasyJoystick>().yAxisCharacterController = this.players[gameplay.count].GetComponent<CharacterController>();
		this.joysticks[gameplay.count].SetActive(false);
	}

	// Token: 0x06000C5C RID: 3164 RVA: 0x0004E478 File Offset: 0x0004C878
	public void turnOFFClimbJoystick()
	{
		this.climbJoystick.SetActive(false);
		this.joysticks[gameplay.count].SetActive(true);
	}

	// Token: 0x04000CCB RID: 3275
	public GameObject[] joysticks;

	// Token: 0x04000CCC RID: 3276
	public GameObject[] players;

	// Token: 0x04000CCD RID: 3277
	public GameObject climbJoystick;
}
