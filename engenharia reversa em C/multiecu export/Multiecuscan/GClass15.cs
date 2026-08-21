using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;

// Token: 0x02000057 RID: 87
public sealed class GClass15 : GClass12
{
	// Token: 0x06000360 RID: 864 RVA: 0x0005562C File Offset: 0x0005382C
	protected override void r6()
	{
		try
		{
			if (GClass125.smethod_48())
			{
				this.tcpClient_0 = new TcpClient();
				this.tcpClient_0.Connect(GClass125.smethod_50(), GClass125.smethod_51());
				if (!this.tcpClient_0.Connected)
				{
					throw new Exception("WiFi device not connected!");
				}
				GClass126.smethod_2("WiFi device connect successfull!", 0);
				for (int i = 0; i < 5; i++)
				{
					if (GClass126.bool_25)
					{
						throw new Exception("ESC");
					}
					Thread.Sleep(100);
				}
			}
			else
			{
				this.serialPort_0 = new SerialPort(GClass125.smethod_55(), GClass125.smethod_57(), Parity.None, 8, StopBits.One);
				this.serialPort_0.WriteBufferSize = 2;
				this.serialPort_0.WriteTimeout = 5000;
				this.serialPort_0.ReceivedBytesThreshold = 1000;
				this.serialPort_0.Handshake = Handshake.None;
				this.serialPort_0.NewLine = "\r";
				this.serialPort_0.Open();
				GClass126.smethod_2("Serial port opened!", 1);
				this.serialPort_0.ReadTimeout = 5000;
			}
			GClass126.smethod_2("Init OBDKey and Wakeup ECU.", 1);
			this.r9("ATZ");
			GClass126.smethod_2("Init OBDKey interface", 1);
			if (!this.rb().Contains("OBDKey"))
			{
				GClass126.smethod_2("Invalid OBDKey interface!", 1);
				throw new Exception("Invalid OBDKey interface!");
			}
			if (GClass125.smethod_44() == 4)
			{
				this.serialPort_0.ReadTimeout = 100;
				this.r9("ATBRD16");
				string text = ((char)this.serialPort_0.ReadByte()).ToString() ?? "";
				while (!text.Contains("OK\r") && !text.Contains("?") && text.Length < 20)
				{
					text += ((char)this.serialPort_0.ReadByte()).ToString();
				}
				this.serialPort_0.BaudRate = 250000;
				this.serialPort_0.ReadTimeout = 80;
				text = (((char)this.serialPort_0.ReadByte()).ToString() ?? "");
				while (!text.Contains("\r") && text.Length < 20)
				{
					text += ((char)this.serialPort_0.ReadByte()).ToString();
				}
				this.ra("");
			}
			if (this.serialPort_0 != null)
			{
				this.serialPort_0.ReadTimeout = 1600;
			}
			this.ra("ATI");
			this.ra("ATE0");
			this.ra("ATL0");
			this.ra("ATH0");
			this.ra("ATSPC");
			this.ra("ATS0");
			this.ra("ATCRA " + this.string_2);
			this.ra("ATSH 7B0");
			if (!this.bool_7)
			{
				this.ra("ATCAF0");
				this.ra("ATCFC0");
			}
			this.ra("ATAT1");
			if (GClass125.smethod_46())
			{
				this.string_22 = "ATST29";
				this.string_23 = "ATST30";
			}
			this.ra(this.string_22);
			this.ra("ATBI");
			this.ra("ATV0");
			this.ra("ATAL");
			byte[] array = base.method_46(this.byte_4);
			if (array.Length < 3 || array[1] != 80 || array[2] != 129)
			{
				throw new Exception("OBDKey->ECU Connection failed!");
			}
		}
		catch (Exception ex)
		{
			GClass126.smethod_2(ex.Message, 1);
			this.string_8 = ex.Message;
			throw new Exception("0");
		}
		GClass126.smethod_2("ECU wakeup completed", 1);
	}

	// Token: 0x06000361 RID: 865 RVA: 0x000559F8 File Offset: 0x00053BF8
	protected override byte[] r8(byte[] byte_8)
	{
		if (this.bool_7 && byte_8.Length < 40)
		{
			return this.method_57(byte_8);
		}
		if (this.bool_7)
		{
			this.ra("ATCFC0");
			this.ra("ATCAF0");
			this.ra("ATCEA");
		}
		byte[] result = this.method_56(byte_8);
		if (this.bool_7)
		{
			this.ra("ATCFC1");
			this.ra("ATCAF1");
			this.ra("ATCEA " + GClass127.smethod_23(this.byte_0));
		}
		return result;
	}

	// Token: 0x06000362 RID: 866 RVA: 0x00055A8C File Offset: 0x00053C8C
	private byte[] method_56(byte[] byte_8)
	{
		if (this.serialPort_0 != null && this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		List<byte[]> list = new List<byte[]>();
		if (byte_8.Length < 8)
		{
			list.Add(new byte[8]);
			list[0][0] = this.byte_0;
			for (int i = 0; i < list[0].Length - 1; i++)
			{
				if (i < byte_8.Length)
				{
					list[0][i + 1] = byte_8[i];
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
			int j = 0;
			for (int k = 2; k < list[0].Length; k++)
			{
				if (j < byte_8.Length)
				{
					list[0][k] = byte_8[j];
					j++;
				}
				else
				{
					list[0][k] = 0;
				}
			}
			byte b = 32;
			while (j < byte_8.Length)
			{
				list.Add(new byte[8]);
				int index = list.Count - 1;
				list[index][0] = this.byte_0;
				list[index][1] = b;
				b += 1;
				if (b > 47)
				{
					b = 32;
				}
				for (int l = 2; l < list[index].Length; l++)
				{
					if (j < byte_8.Length)
					{
						list[index][l] = byte_8[j];
						j++;
					}
					else
					{
						list[index][l] = 0;
					}
				}
			}
		}
		if (list.Count > 1 && this.int_4 != 0)
		{
			if (this.int_4 == 1)
			{
				this.ra(this.string_38);
			}
			else
			{
				this.ra(this.string_37);
			}
		}
		this.r9(GClass127.smethod_11(list[0]));
		this.int_0 = GClass126.smethod_1();
		if (list.Count > 1)
		{
			GClass126.smethod_2(this.string_24, 0);
			string text = this.rb();
			if (this.int_4 == 0 && (text.Contains(this.string_25) || text.Contains(this.string_26) || text.Contains(this.string_27) || !text.Contains(this.string_28)))
			{
				return new byte[0];
			}
			int num = 0;
			int num2 = 0;
			while (num2 < text.Length && text[num2] != '\r' && text[num2] != '\n')
			{
				if (text[num2] == '>')
				{
					break;
				}
				num2++;
			}
			byte[] array = GClass127.smethod_32(text.Substring(0, num2));
			if (array.Length > 3 && array[1] == 48 && array[3] != 0)
			{
				num = (int)(array[3] + 1);
			}
			GClass126.smethod_2("Separation Time: " + num.ToString(), 0);
			if (this.int_4 != 0)
			{
				this.ra(this.string_33);
			}
			else if (GClass125.smethod_44() == 4)
			{
				this.ra(this.string_36);
			}
			else
			{
				this.ra(this.string_33);
			}
			for (int m = 1; m < list.Count; m++)
			{
				while (this.int_0 + num > GClass126.smethod_1())
				{
				}
				if (m == list.Count - 1)
				{
					if (this.int_4 == 0)
					{
						this.ra(this.string_39);
					}
					else
					{
						this.ra(this.string_40);
					}
				}
				this.r9(GClass127.smethod_11(list[m]));
				this.int_0 = GClass126.smethod_1();
				if (m < list.Count - 1)
				{
					this.rb();
				}
			}
		}
		string text2 = this.rb();
		if (this.int_4 != 0 && text2.Contains(this.string_25))
		{
			this.r9(GClass127.smethod_23(this.byte_0) + this.string_29);
			text2 = this.rb();
			if (this.int_4 != 0 && text2.Contains(this.string_25))
			{
				this.r9(GClass127.smethod_23(this.byte_0) + this.string_29);
				text2 = this.rb();
			}
		}
		if (list.Count > 1)
		{
			this.ra(this.string_22);
		}
		if (!text2.Contains(this.string_25) && !text2.Contains(this.string_26) && !text2.Contains(this.string_27))
		{
			int num3 = 0;
			while (num3 < text2.Length && text2[num3] != '\r' && text2[num3] != '\n')
			{
				if (text2[num3] == '>')
				{
					break;
				}
				num3++;
			}
			byte[] array2 = GClass127.smethod_32(text2.Substring(0, num3));
			if (array2.Length >= 2)
			{
				if (array2[0] == 241)
				{
					List<byte> list2 = new List<byte>();
					if (array2[1] < 16)
					{
						for (int n = 1; n < array2.Length; n++)
						{
							list2.Add(array2[n]);
						}
					}
					else if (array2[1] >= 16 && array2[1] < 32)
					{
						for (int num4 = 2; num4 < array2.Length; num4++)
						{
							list2.Add(array2[num4]);
						}
						if (GClass125.smethod_44() == 4)
						{
							this.ra(this.string_23);
						}
						this.r9(GClass127.smethod_23(this.byte_0) + this.string_42);
						text2 = this.rb();
						if (GClass125.smethod_44() == 4)
						{
							this.ra(this.string_22);
						}
						if (GClass125.smethod_46() && text2.Contains(this.string_25))
						{
							this.r9(GClass127.smethod_11(list[0]));
							this.int_0 = GClass126.smethod_1();
							while (this.int_0 + 180 > GClass126.smethod_1())
							{
							}
							this.r9(GClass127.smethod_23(this.byte_0) + this.string_42);
							text2 = this.rb();
							if (!text2.Contains(this.string_25) && !text2.Contains(this.string_26) && !text2.Contains(this.string_27))
							{
								num3 = 0;
								while (num3 < text2.Length && text2[num3] != '\r' && text2[num3] != '\n')
								{
									if (text2[num3] == '>')
									{
										break;
									}
									num3++;
								}
								array2 = GClass127.smethod_32(text2.Substring(0, num3));
								if (array2.Length >= 2)
								{
									if (array2[0] == 241)
									{
										list2.Clear();
										for (int num5 = 2; num5 < array2.Length; num5++)
										{
											list2.Add(array2[num5]);
										}
										text2 = this.rb();
										goto IL_716;
									}
								}
								return new byte[0];
							}
							return new byte[0];
						}
						IL_716:
						while (text2.StartsWith(this.string_31))
						{
							num3 = 0;
							while (num3 < text2.Length && text2[num3] != '\r' && text2[num3] != '\n')
							{
								if (text2[num3] == '>')
								{
									break;
								}
								num3++;
							}
							string string_ = text2.Substring(0, num3);
							text2 = text2.Substring(num3 + 1);
							array2 = GClass127.smethod_32(string_);
							if (array2.Length > 2 && array2[0] == 241 && array2[1] >= 32)
							{
								for (int num6 = 2; num6 < array2.Length; num6++)
								{
									list2.Add(array2[num6]);
								}
							}
						}
					}
					GClass126.smethod_2(this.string_32 + GClass127.smethod_11(list2.ToArray()), 0);
					byte[] array3 = list2.ToArray();
					if (list2.Count > 0 && list2[0] > 0 && list2[0] < 255 && (int)list2[0] < list2.Count - 1)
					{
						array3 = new byte[(int)(list2[0] + 1)];
						for (int num7 = 0; num7 <= (int)list2[0]; num7++)
						{
							array3[num7] = list2[num7];
						}
						GClass126.smethod_2("CLEANED RESPONSE: " + GClass127.smethod_11(array3), 0);
					}
					return array3;
				}
			}
			return new byte[0];
		}
		return new byte[0];
	}

	// Token: 0x06000363 RID: 867 RVA: 0x0005627C File Offset: 0x0005447C
	private byte[] method_57(byte[] byte_8)
	{
		if (this.serialPort_0 != null && this.serialPort_0.BytesToRead > 0)
		{
			this.serialPort_0.ReadExisting();
		}
		List<byte> list = new List<byte>();
		if (byte_8.Length < 2)
		{
			return new byte[0];
		}
		List<byte[]> list2 = new List<byte[]>();
		list2.Add(new byte[byte_8.Length - 1]);
		for (int i = 1; i < byte_8.Length; i++)
		{
			list2[0][i - 1] = byte_8[i];
		}
		this.r9(GClass127.smethod_11(list2[0]));
		this.int_0 = GClass126.smethod_1();
		string text = this.rb();
		if (!text.Contains("NO DATA") && !text.Contains("ERROR") && !text.Contains("?"))
		{
			int num;
			while (text.StartsWith("7F2178") || text.StartsWith("7F3078") || text.StartsWith("7F1A78") || text.StartsWith("7F1878"))
			{
				num = 0;
				while (num < text.Length && text[num] != '\r' && text[num] != '\n')
				{
					if (text[num] == '>')
					{
						break;
					}
					num++;
				}
				text = text.Substring(num + 1);
			}
			num = 0;
			while (num < text.Length && text[num] != '\r' && text[num] != '\n')
			{
				if (text[num] == '>')
				{
					break;
				}
				num++;
			}
			string text2 = text.Substring(0, num).Trim();
			text = text.Substring(num + 1);
			if (text2.Length == 3 && text2[0] == '0')
			{
				byte item = 0;
				try
				{
					item = GClass127.smethod_32(text2.Substring(1))[0];
				}
				catch (Exception)
				{
				}
				list.Add(item);
				while (text.Length > 2)
				{
					if (text[1] != ':')
					{
						break;
					}
					num = 0;
					while (num < text.Length && text[num] != '\r' && text[num] != '\n')
					{
						if (text[num] == '>')
						{
							break;
						}
						num++;
					}
					if (num > 2)
					{
						text2 = text.Substring(2, num - 2);
						byte[] array = GClass127.smethod_32(text2);
						for (int j = 0; j < array.Length; j++)
						{
							list.Add(array[j]);
						}
					}
					text = text.Substring(num + 1);
				}
			}
			else
			{
				byte[] array2 = GClass127.smethod_32(text2);
				list.Add((byte)array2.Length);
				for (int k = 0; k < array2.Length; k++)
				{
					list.Add(array2[k]);
				}
			}
			GClass126.smethod_2("DECODED RESPONSE: " + GClass127.smethod_11(list.ToArray()), 0);
			byte[] array3 = list.ToArray();
			if (list.Count > 0 && list[0] > 0 && list[0] < 255 && (int)list[0] < list.Count - 1)
			{
				array3 = new byte[(int)(list[0] + 1)];
				for (int l = 0; l <= (int)list[0]; l++)
				{
					array3[l] = list[l];
				}
				GClass126.smethod_2("CLEANED RESPONSE: " + GClass127.smethod_11(array3), 0);
			}
			return array3;
		}
		return new byte[0];
	}

	// Token: 0x04000267 RID: 615
	private bool bool_7;

	// Token: 0x04000268 RID: 616
	protected string string_42 = " 30 FF 00 00 00 00 00";
}
