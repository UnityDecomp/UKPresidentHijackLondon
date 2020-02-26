using System;
using System.Text;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	// Token: 0x0200002B RID: 43
	internal static class StringPluginExtensions
	{
		// Token: 0x060001EC RID: 492 RVA: 0x0000B454 File Offset: 0x00009654
		static StringPluginExtensions()
		{
			StringPluginExtensions.ScrambledCharsAll.ScrambleChars();
			StringPluginExtensions.ScrambledCharsUppercase.ScrambleChars();
			StringPluginExtensions.ScrambledCharsLowercase.ScrambleChars();
			StringPluginExtensions.ScrambledCharsNumerals.ScrambleChars();
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0000B4E8 File Offset: 0x000096E8
		internal static void ScrambleChars(this char[] chars)
		{
			int num = chars.Length;
			for (int i = 0; i < num; i++)
			{
				char c = chars[i];
				int num2 = UnityEngine.Random.Range(i, num);
				chars[i] = chars[num2];
				chars[num2] = c;
			}
		}

		// Token: 0x060001EE RID: 494 RVA: 0x0000B51C File Offset: 0x0000971C
		internal static StringBuilder AppendScrambledChars(this StringBuilder buffer, int length, char[] chars)
		{
			if (length <= 0)
			{
				return buffer;
			}
			int num = chars.Length;
			int num2;
			for (num2 = StringPluginExtensions._lastRndSeed; num2 == StringPluginExtensions._lastRndSeed; num2 = UnityEngine.Random.Range(0, num))
			{
			}
			StringPluginExtensions._lastRndSeed = num2;
			for (int i = 0; i < length; i++)
			{
				if (num2 >= num)
				{
					num2 = 0;
				}
				buffer.Append(chars[num2]);
				num2++;
			}
			return buffer;
		}

		// Token: 0x040000C1 RID: 193
		public static readonly char[] ScrambledCharsAll = new char[]
		{
			'A',
			'B',
			'C',
			'D',
			'E',
			'F',
			'G',
			'H',
			'I',
			'J',
			'K',
			'L',
			'M',
			'N',
			'O',
			'P',
			'Q',
			'R',
			'S',
			'T',
			'U',
			'V',
			'X',
			'Y',
			'Z',
			'a',
			'b',
			'c',
			'd',
			'e',
			'f',
			'g',
			'h',
			'i',
			'j',
			'k',
			'l',
			'm',
			'n',
			'o',
			'p',
			'q',
			'r',
			's',
			't',
			'u',
			'v',
			'x',
			'y',
			'z',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9',
			'0'
		};

		// Token: 0x040000C2 RID: 194
		public static readonly char[] ScrambledCharsUppercase = new char[]
		{
			'A',
			'B',
			'C',
			'D',
			'E',
			'F',
			'G',
			'H',
			'I',
			'J',
			'K',
			'L',
			'M',
			'N',
			'O',
			'P',
			'Q',
			'R',
			'S',
			'T',
			'U',
			'V',
			'X',
			'Y',
			'Z'
		};

		// Token: 0x040000C3 RID: 195
		public static readonly char[] ScrambledCharsLowercase = new char[]
		{
			'a',
			'b',
			'c',
			'd',
			'e',
			'f',
			'g',
			'h',
			'i',
			'j',
			'k',
			'l',
			'm',
			'n',
			'o',
			'p',
			'q',
			'r',
			's',
			't',
			'u',
			'v',
			'x',
			'y',
			'z'
		};

		// Token: 0x040000C4 RID: 196
		public static readonly char[] ScrambledCharsNumerals = new char[]
		{
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9',
			'0'
		};

		// Token: 0x040000C5 RID: 197
		private static int _lastRndSeed;
	}
}
