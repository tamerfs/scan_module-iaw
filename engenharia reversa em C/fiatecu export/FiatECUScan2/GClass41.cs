using System;
using System.Collections.Generic;
using System.IO.Ports;

// Token: 0x0200001F RID: 31
public sealed class GClass41 : GClass40
{
	// Token: 0x06000140 RID: 320 RVA: 0x00036144 File Offset: 0x00034344
	protected override void vmethod_8()
	{
		try
		{
			this.serialPort_0 = new SerialPort(GClass61.smethod_39(), GClass61.smethod_41(), Parity.None, 8, StopBits.One);
			this.serialPort_0.WriteBufferSize = 2;
			this.serialPort_0.ReceivedBytesThreshold = 1000;
			this.serialPort_0.Handshake = Handshake.None;
			this.serialPort_0.NewLine = "\r";
			this.serialPort_0.Open();
			GClass3.smethod_2("Serial port opened!", 1);
			GClass3.smethod_2("Init OBDKey and Wakeup ECU.", 1);
			this.serialPort_0.ReadTimeout = 5000;
			base.method_42("ATZ");
			GClass3.smethod_2("Init OBDKey interface", 1);
			string text = base.method_44();
			if (!text.Contains("OBDKey"))
			{
				GClass3.smethod_2("Invalid OBDKey interface!", 1);
				throw new Exception("Invalid OBDKey interface!");
			}
			if (GClass61.smethod_36() == 4)
			{
				this.serialPort_0.ReadTimeout = 100;
				base.method_42("ATBRD16");
				string text2 = string.Concat((char)this.serialPort_0.ReadByte());
				while (!text2.Contains("OK\r") && !text2.Contains("?") && text2.Length < 20)
				{
					text2 += (char)this.serialPort_0.ReadByte();
				}
				this.serialPort_0.BaudRate = 250000;
				this.serialPort_0.ReadTimeout = 80;
				text2 = string.Concat((char)this.serialPort_0.ReadByte());
				while (!text2.Contains("\r") && text2.Length < 20)
				{
					text2 += (char)this.serialPort_0.ReadByte();
				}
				base.method_43(string.Empty);
			}
			this.serialPort_0.ReadTimeout = 1200;
			base.method_43("ATE0");
			base.method_43("ATL0");
			base.method_43("ATH0");
			base.method_43("ATSPC");
			base.method_43("ATS0");
			base.method_43("ATCAF0");
			base.method_43("ATCFC0");
			base.method_43("ATCRA " + this.string_1);
			base.method_43("ATSH 7B0");
			base.method_43("ATAT1");
			if (GClass61.smethod_38())
			{
				this.string_7 = "ATST29";
				this.string_8 = "ATST30";
			}
			base.method_43(this.string_7);
			base.method_43("ATBI");
			byte[] array = base.method_41(this.byte_3);
			if (array.Length < 3 || array[1] != 80 || array[2] != 129)
			{
				throw new Exception("ELM327->ECU Connection failed!");
			}
		}
		catch (Exception ex)
		{
			GClass3.smethod_2(ex.Message, 1);
			this.string_4 = ex.Message;
			throw new Exception("0");
		}
		GClass3.smethod_2("ECU wakeup completed", 1);
	}

	// Token: 0x06000141 RID: 321 RVA: 0x00036460 File Offset: 0x00034660
	protected override byte[] vmethod_10(byte[] byte_7)
	{
		if (this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		List<byte[]> list = new List<byte[]>();
		if (byte_7.Length < 8)
		{
			list.Add(new byte[8]);
			list[0][0] = this.byte_0;
			for (int i = 0; i < list[0].Length - 1; i++)
			{
				if (i < byte_7.Length)
				{
					list[0][i + 1] = byte_7[i];
				}
				else
				{
					list[0][i + 1] = 0;
				}
			}
		}
		else
		{
			list.Add(new byte[8]);
			list[0][0] = this.byte_0;
			list[0][1] = 16;
			int num = 0;
			for (int i = 2; i < list[0].Length; i++)
			{
				if (num < byte_7.Length)
				{
					list[0][i] = byte_7[num];
					num++;
				}
				else
				{
					list[0][i] = 0;
				}
			}
			byte b = 32;
			while (num < byte_7.Length && b < 47)
			{
				list.Add(new byte[8]);
				int index = list.Count - 1;
				list[index][0] = this.byte_0;
				list[index][1] = b;
				b += 1;
				for (int i = 2; i < list[index].Length; i++)
				{
					if (num < byte_7.Length)
					{
						list[index][i] = byte_7[num];
						num++;
					}
					else
					{
						list[index][i] = 0;
					}
				}
			}
		}
		if (list.Count > 1 && this.int_4 != 0 && !GClass3.bool_12)
		{
			if (this.int_4 == 1)
			{
				base.method_43(this.string_22);
			}
			else
			{
				base.method_43(this.string_21);
			}
		}
		base.method_42(GClass16.smethod_1(list[0]) + " 0");
		this.int_0 = GClass3.smethod_1();
		if (list.Count > 1)
		{
			GClass3.smethod_2(this.string_9, 0);
			string text = base.method_44();
			if (this.int_4 == 0 && (text.Contains(this.string_10) || text.Contains(this.string_11) || text.Contains(this.string_12) || !text.Contains(this.string_13)))
			{
				return new byte[0];
			}
			if (this.int_4 != 0 && !GClass3.bool_12)
			{
				base.method_43(this.string_18);
			}
			else if (GClass61.smethod_36() == 4)
			{
				base.method_43(this.string_20);
			}
			else
			{
				base.method_43(this.string_18);
			}
			for (int j = 1; j < list.Count; j++)
			{
				if (j == list.Count - 1)
				{
					if (this.int_4 == 0)
					{
						base.method_43(this.string_23);
					}
					else
					{
						base.method_43(this.string_24);
					}
				}
				base.method_42(GClass16.smethod_1(list[j]));
				this.int_0 = GClass3.smethod_1();
				if (j < list.Count - 1)
				{
					base.method_44();
				}
			}
		}
		string text2 = base.method_44();
		if (this.int_4 != 0 && text2.Contains(this.string_10))
		{
			base.method_42(GClass16.smethod_0(this.byte_0) + this.string_14);
			text2 = base.method_44();
			if (this.int_4 != 0 && text2.Contains(this.string_10))
			{
				base.method_42(GClass16.smethod_0(this.byte_0) + this.string_14);
				text2 = base.method_44();
			}
		}
		if (list.Count > 1)
		{
			base.method_43(this.string_7);
		}
		byte[] result;
		if (text2.Contains(this.string_10) || text2.Contains(this.string_11) || text2.Contains(this.string_12))
		{
			result = new byte[0];
		}
		else
		{
			int num2 = 0;
			while (num2 < text2.Length && text2[num2] != '\r' && text2[num2] != '\n' && text2[num2] != '>')
			{
				num2++;
			}
			string string_ = text2.Substring(0, num2);
			byte[] array = GClass16.smethod_2(string_);
			if (array.Length < 2 || array[0] != 241)
			{
				result = new byte[0];
			}
			else
			{
				List<byte> list2 = new List<byte>();
				if (array[1] < 16)
				{
					for (int i = 1; i < array.Length; i++)
					{
						list2.Add(array[i]);
					}
				}
				else if (array[1] >= 16 && array[1] < 32)
				{
					for (int i = 2; i < array.Length; i++)
					{
						list2.Add(array[i]);
					}
					if (GClass61.smethod_36() == 4)
					{
						base.method_43(this.string_8);
					}
					base.method_42(GClass16.smethod_0(this.byte_0) + this.string_33);
					text2 = base.method_44();
					if (GClass61.smethod_36() == 4)
					{
						base.method_43(this.string_7);
					}
					if (GClass61.smethod_38() && text2.Contains(this.string_10))
					{
						base.method_42(GClass16.smethod_1(list[0]));
						this.int_0 = GClass3.smethod_1();
						while (this.int_0 + 180 > GClass3.smethod_1())
						{
						}
						base.method_42(GClass16.smethod_0(this.byte_0) + this.string_33);
						text2 = base.method_44();
						if (text2.Contains(this.string_10) || text2.Contains(this.string_11) || text2.Contains(this.string_12))
						{
							return new byte[0];
						}
						num2 = 0;
						while (num2 < text2.Length && text2[num2] != '\r' && text2[num2] != '\n' && text2[num2] != '>')
						{
							num2++;
						}
						string_ = text2.Substring(0, num2);
						array = GClass16.smethod_2(string_);
						if (array.Length < 2 || array[0] != 241)
						{
							return new byte[0];
						}
						list2.Clear();
						for (int i = 2; i < array.Length; i++)
						{
							list2.Add(array[i]);
						}
						text2 = base.method_44();
					}
					while (text2.StartsWith(this.string_16))
					{
						num2 = 0;
						string_ = string.Empty;
						while (num2 < text2.Length && text2[num2] != '\r' && text2[num2] != '\n' && text2[num2] != '>')
						{
							num2++;
						}
						string_ = text2.Substring(0, num2);
						text2 = text2.Substring(num2 + 1);
						array = GClass16.smethod_2(string_);
						if (array.Length > 2 && array[0] == 241 && array[1] >= 32)
						{
							for (int i = 2; i < array.Length; i++)
							{
								list2.Add(array[i]);
							}
						}
					}
				}
				GClass3.smethod_2(this.string_17 + GClass16.smethod_1(list2.ToArray()), 0);
				byte[] array2 = new byte[0];
				if (list2.Count > 0 && list2[0] > 0 && (int)list2[0] < list2.Count)
				{
					array2 = new byte[(int)(list2[0] + 1)];
					for (int i = 0; i <= (int)list2[0]; i++)
					{
						array2[i] = list2[i];
					}
				}
				result = array2;
			}
		}
		return result;
	}

	// Token: 0x04000124 RID: 292
	protected string string_33 = " 30 FF 00 00 00 00 00";
}
