using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

// Token: 0x02000049 RID: 73
internal static class Class4
{
	// Token: 0x06000207 RID: 519 RVA: 0x0005B4E8 File Offset: 0x000596E8
	internal static long smethod_0()
	{
		if (Assembly.GetCallingAssembly() == typeof(Class4).Assembly && Class4.smethod_1())
		{
			long result;
			lock (Class4.class5_0)
			{
				long num = Class4.class5_0.method_0();
				if (num == 0L)
				{
					Assembly executingAssembly = Assembly.GetExecutingAssembly();
					List<byte> list = new List<byte>();
					AssemblyName assemblyName;
					try
					{
						assemblyName = executingAssembly.GetName();
					}
					catch
					{
						assemblyName = new AssemblyName(executingAssembly.FullName);
					}
					byte[] array = assemblyName.GetPublicKeyToken();
					if (array != null && array.Length == 0)
					{
						array = null;
					}
					if (array != null)
					{
						list.AddRange(array);
					}
					list.AddRange(Encoding.Unicode.GetBytes(assemblyName.Name));
					int num2 = Class4.smethod_3(typeof(Class4));
					int num3 = Class4.Class7.smethod_0();
					list.Add((byte)(num2 >> 24));
					list.Add((byte)(num3 >> 16));
					list.Add((byte)(num2 >> 8));
					list.Add((byte)num3);
					list.Add((byte)(num2 >> 16));
					list.Add((byte)(num3 >> 8));
					list.Add((byte)num2);
					list.Add((byte)(num3 >> 24));
					int count = list.Count;
					ulong num4 = 0UL;
					for (int num5 = 0; num5 != count; num5++)
					{
						num4 += (ulong)list[num5];
						num4 += num4 << 20;
						num4 ^= num4 >> 12;
						list[num5] = 0;
					}
					num4 += num4 << 6;
					num4 ^= num4 >> 22;
					num4 += num4 << 30;
					num = (long)num4;
					num ^= 438566016726159729L;
					Class4.class5_0.method_1(num);
				}
				result = num;
			}
			return result;
		}
		return 5038234971328056794L;
	}

	// Token: 0x06000208 RID: 520 RVA: 0x00002E50 File Offset: 0x00001050
	private static bool smethod_1()
	{
		return Class4.smethod_2();
	}

	// Token: 0x06000209 RID: 521 RVA: 0x0005B6E0 File Offset: 0x000598E0
	private static bool smethod_2()
	{
		StackTrace stackTrace = new StackTrace();
		StackFrame frame = stackTrace.GetFrame(3);
		MethodBase methodBase = (frame == null) ? null : frame.GetMethod();
		Type type = (methodBase == null) ? null : methodBase.DeclaringType;
		return type != typeof(RuntimeMethodHandle) && type != null && type.Assembly == typeof(Class4).Assembly;
	}

	// Token: 0x0600020A RID: 522 RVA: 0x00002E5C File Offset: 0x0000105C
	private static int smethod_3(Type type_0)
	{
		return type_0.MetadataToken;
	}

	// Token: 0x0400038A RID: 906
	private static Class4.Class5 class5_0 = new Class4.Class5();

	// Token: 0x0200004A RID: 74
	private sealed class Class5
	{
		// Token: 0x0600020B RID: 523 RVA: 0x00002E64 File Offset: 0x00001064
		internal Class5()
		{
			this.method_1(0L);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0005B744 File Offset: 0x00059944
		internal long method_0()
		{
			if (Assembly.GetCallingAssembly() != typeof(Class4.Class5).Assembly)
			{
				return 2918384L;
			}
			if (!Class4.smethod_1())
			{
				return 2918384L;
			}
			int[] array = new int[]
			{
				0,
				0,
				0,
				280627520
			};
			array[1] = 1453824428;
			array[2] = -1002785970;
			array[0] = -1914822783;
			int num = this.int_0;
			int num2 = this.int_1;
			int num3 = -1640531527;
			int num4 = -957401312;
			for (int num5 = 0; num5 != 32; num5++)
			{
				num2 -= ((num << 4 ^ num >> 5) + num ^ num4 + array[num4 >> 11 & 3]);
				num4 -= num3;
				num -= ((num2 << 4 ^ num2 >> 5) + num2 ^ num4 + array[num4 & 3]);
			}
			for (int num6 = 0; num6 != 4; num6++)
			{
				array[num6] = 0;
			}
			ulong num7 = (ulong)((ulong)((long)num2) << 32);
			return (long)(num7 | (ulong)num);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0005B830 File Offset: 0x00059A30
		internal void method_1(long long_0)
		{
			if (Assembly.GetCallingAssembly() != typeof(Class4.Class5).Assembly)
			{
				return;
			}
			if (!Class4.smethod_1())
			{
				return;
			}
			int[] array = new int[4];
			array[1] = 1453824428;
			array[0] = -1914822783;
			array[2] = -1002785970;
			array[3] = 280627520;
			int num = -1640531527;
			int num2 = (int)long_0;
			int num3 = (int)(long_0 >> 32);
			int num4 = 0;
			for (int num5 = 0; num5 != 32; num5++)
			{
				num2 += ((num3 << 4 ^ num3 >> 5) + num3 ^ num4 + array[num4 & 3]);
				num4 += num;
				num3 += ((num2 << 4 ^ num2 >> 5) + num2 ^ num4 + array[num4 >> 11 & 3]);
			}
			for (int num6 = 0; num6 != 4; num6++)
			{
				array[num6] = 0;
			}
			this.int_0 = num2;
			this.int_1 = num3;
		}

		// Token: 0x0400038B RID: 907
		private int int_0;

		// Token: 0x0400038C RID: 908
		private int int_1;
	}

	// Token: 0x0200004B RID: 75
	private static class Class6
	{
		// Token: 0x0600020E RID: 526 RVA: 0x00002E7B File Offset: 0x0000107B
		internal static int smethod_0(int int_0, int int_1)
		{
			return int_0 ^ int_1 - 1037549918;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00002E86 File Offset: 0x00001086
		internal static int smethod_1(int int_0, int int_1)
		{
			return int_0 - -1624900444 ^ int_1 + 1778705841;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00002E97 File Offset: 0x00001097
		internal static int smethod_2(int int_0, int int_1)
		{
			return int_0 ^ (int_1 - -397693991 ^ int_0 - int_1);
		}
	}

	// Token: 0x0200004C RID: 76
	private sealed class Class7
	{
		// Token: 0x06000212 RID: 530 RVA: 0x0005B900 File Offset: 0x00059B00
		internal static int smethod_0()
		{
			if (Assembly.GetCallingAssembly() == typeof(Class4.Class7).Assembly && Class4.smethod_1())
			{
				return Class4.Class6.smethod_2(Class4.Class6.smethod_1(Class4.smethod_3(typeof(Class4.Class8)), Class4.Class6.smethod_2(Class4.smethod_3(typeof(Class4.Class7)), Class4.smethod_3(typeof(Class4.Class11)))), Class4.Class12.smethod_0());
			}
			return -1509110933;
		}
	}

	// Token: 0x0200004D RID: 77
	private sealed class Class8
	{
		// Token: 0x06000214 RID: 532 RVA: 0x0005B974 File Offset: 0x00059B74
		internal static int smethod_0()
		{
			if (Assembly.GetCallingAssembly() == typeof(Class4.Class8).Assembly && Class4.smethod_1())
			{
				return Class4.Class6.smethod_0(Class4.smethod_3(typeof(Class4.Class9)), Class4.smethod_3(typeof(Class4.Class10)) ^ Class4.Class6.smethod_1(Class4.smethod_3(typeof(Class4.Class8)), Class4.Class6.smethod_2(Class4.smethod_3(typeof(Class4.Class12)), Class4.Class10.smethod_0())));
			}
			return -82806859;
		}
	}

	// Token: 0x0200004E RID: 78
	private sealed class Class9
	{
		// Token: 0x06000216 RID: 534 RVA: 0x0005B9F8 File Offset: 0x00059BF8
		internal static int smethod_0()
		{
			if (Assembly.GetCallingAssembly() == typeof(Class4.Class9).Assembly && Class4.smethod_1())
			{
				return Class4.Class6.smethod_2(Class4.Class6.smethod_0(Class4.Class8.smethod_0() ^ 527758446, Class4.smethod_3(typeof(Class4.Class10))), Class4.Class6.smethod_1(Class4.smethod_3(typeof(Class4.Class7)) ^ Class4.smethod_3(typeof(Class4.Class12)), -375441726));
			}
			return 1294352278;
		}
	}

	// Token: 0x0200004F RID: 79
	private sealed class Class10
	{
		// Token: 0x06000218 RID: 536 RVA: 0x0005BA78 File Offset: 0x00059C78
		internal static int smethod_0()
		{
			if (Assembly.GetCallingAssembly() == typeof(Class4.Class10).Assembly && Class4.smethod_1())
			{
				return Class4.Class6.smethod_2(Class4.smethod_3(typeof(Class4.Class10)), Class4.Class6.smethod_0(Class4.smethod_3(typeof(Class4.Class7)), Class4.Class6.smethod_1(Class4.smethod_3(typeof(Class4.Class8)), Class4.Class6.smethod_2(Class4.smethod_3(typeof(Class4.Class9)), Class4.Class6.smethod_0(Class4.smethod_3(typeof(Class4.Class11)), Class4.smethod_3(typeof(Class4.Class12)))))));
			}
			return 402344241;
		}
	}

	// Token: 0x02000050 RID: 80
	private sealed class Class11
	{
		// Token: 0x0600021A RID: 538 RVA: 0x0005BB1C File Offset: 0x00059D1C
		internal static int smethod_0()
		{
			if (Assembly.GetCallingAssembly() == typeof(Class4.Class11).Assembly && Class4.smethod_1())
			{
				return Class4.Class6.smethod_1(Class4.Class6.smethod_1(Class4.Class9.smethod_0(), Class4.Class6.smethod_0(Class4.smethod_3(typeof(Class4.Class11)), Class4.Class8.smethod_0())), Class4.smethod_3(typeof(Class4.Class12)));
			}
			return -56237163;
		}
	}

	// Token: 0x02000051 RID: 81
	private sealed class Class12
	{
		// Token: 0x0600021C RID: 540 RVA: 0x0005BB84 File Offset: 0x00059D84
		internal static int smethod_0()
		{
			if (Assembly.GetCallingAssembly() == typeof(Class4.Class12).Assembly && Class4.smethod_1())
			{
				return Class4.Class6.smethod_0(Class4.smethod_3(typeof(Class4.Class12)), Class4.Class6.smethod_2(Class4.Class6.smethod_1(Class4.smethod_3(typeof(Class4.Class11)), Class4.smethod_3(typeof(Class4.Class7))), Class4.Class6.smethod_2(Class4.smethod_3(typeof(Class4.Class9)) ^ -197891505, Class4.Class11.smethod_0())));
			}
			return 1106695601;
		}
	}
}
