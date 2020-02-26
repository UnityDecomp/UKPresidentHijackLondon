using System;

// Token: 0x02000031 RID: 49
[Serializable]
public class CharacterMotorSliding
{
	// Token: 0x0600007A RID: 122 RVA: 0x00006D0C File Offset: 0x00004F0C
	public CharacterMotorSliding()
	{
		this.enabled = true;
		this.slidingSpeed = (float)15;
		this.sidewaysControl = 1f;
		this.speedControl = 0.4f;
	}

	// Token: 0x0400011F RID: 287
	public bool enabled;

	// Token: 0x04000120 RID: 288
	public float slidingSpeed;

	// Token: 0x04000121 RID: 289
	public float sidewaysControl;

	// Token: 0x04000122 RID: 290
	public float speedControl;
}
