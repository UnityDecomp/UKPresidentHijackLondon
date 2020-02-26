using System;

// Token: 0x0200008E RID: 142
[Serializable]
public class elem
{
	// Token: 0x060001F2 RID: 498 RVA: 0x00019E18 File Offset: 0x00018018
	public elem()
	{
		this.elementName = string.Empty;
		this.effective = 100;
	}

	// Token: 0x04000330 RID: 816
	public string elementName;

	// Token: 0x04000331 RID: 817
	public int effective;
}
