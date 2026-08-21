using System;
using System.Windows.Forms;

// Token: 0x020000BB RID: 187
public abstract class GClass115 : Panel
{
	// Token: 0x06000620 RID: 1568 RVA: 0x000044AA File Offset: 0x000026AA
	public GClass115()
	{
	}

	// Token: 0x06000621 RID: 1569 RVA: 0x000044BD File Offset: 0x000026BD
	public float method_0()
	{
		return this.float_0;
	}

	// Token: 0x06000622 RID: 1570 RVA: 0x000044C5 File Offset: 0x000026C5
	public void method_1(float float_1)
	{
		this.float_0 = float_1;
	}

	// Token: 0x06000623 RID: 1571 RVA: 0x000044CE File Offset: 0x000026CE
	public int method_2()
	{
		return this.int_0;
	}

	// Token: 0x06000624 RID: 1572 RVA: 0x000044D6 File Offset: 0x000026D6
	public void method_3(int int_2)
	{
		this.int_0 = int_2;
	}

	// Token: 0x06000625 RID: 1573
	public abstract void ScrollIncrease(bool bool_0);

	// Token: 0x06000626 RID: 1574
	public abstract void ScrollDescrease(bool bool_0);

	// Token: 0x0400056C RID: 1388
	protected float float_0 = 1f;

	// Token: 0x0400056D RID: 1389
	protected int int_0;

	// Token: 0x0400056E RID: 1390
	protected int int_1;
}
