using System;
using System.Collections;
using System.IO;
using System.Text;

namespace ChartboostSDK
{
	// Token: 0x02000006 RID: 6
	public static class CBJSON
	{
		// Token: 0x06000062 RID: 98 RVA: 0x00003ED8 File Offset: 0x000022D8
		public static object Deserialize(string json)
		{
			if (json == null)
			{
				return null;
			}
			return CBJSON.Parser.Parse(json);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003EE8 File Offset: 0x000022E8
		public static string Serialize(object obj)
		{
			return CBJSON.Serializer.Serialize(obj);
		}

		// Token: 0x02000007 RID: 7
		private sealed class Parser : IDisposable
		{
			// Token: 0x06000064 RID: 100 RVA: 0x00003EF0 File Offset: 0x000022F0
			private Parser(string jsonString)
			{
				this.json = new StringReader(jsonString);
			}

			// Token: 0x06000065 RID: 101 RVA: 0x00003F04 File Offset: 0x00002304
			public static bool IsWordBreak(char c)
			{
				return char.IsWhiteSpace(c) || "{}[],:\"".IndexOf(c) != -1;
			}

			// Token: 0x06000066 RID: 102 RVA: 0x00003F28 File Offset: 0x00002328
			public static object Parse(string jsonString)
			{
				object result;
				using (CBJSON.Parser parser = new CBJSON.Parser(jsonString))
				{
					result = parser.ParseValue();
				}
				return result;
			}

			// Token: 0x06000067 RID: 103 RVA: 0x00003F68 File Offset: 0x00002368
			public void Dispose()
			{
				this.json.Dispose();
				this.json = null;
			}

			// Token: 0x06000068 RID: 104 RVA: 0x00003F7C File Offset: 0x0000237C
			private Hashtable ParseObject()
			{
				Hashtable hashtable = new Hashtable();
				this.json.Read();
				for (;;)
				{
					CBJSON.Parser.TOKEN nextToken = this.NextToken;
					switch (nextToken)
					{
					case CBJSON.Parser.TOKEN.NONE:
						goto IL_37;
					default:
						if (nextToken != CBJSON.Parser.TOKEN.COMMA)
						{
							string text = this.ParseString();
							if (text == null)
							{
								goto Block_2;
							}
							if (this.NextToken != CBJSON.Parser.TOKEN.COLON)
							{
								goto Block_3;
							}
							this.json.Read();
							hashtable[text] = this.ParseValue();
						}
						break;
					case CBJSON.Parser.TOKEN.CURLY_CLOSE:
						return hashtable;
					}
				}
				IL_37:
				return null;
				Block_2:
				return null;
				Block_3:
				return null;
			}

			// Token: 0x06000069 RID: 105 RVA: 0x00004008 File Offset: 0x00002408
			private ArrayList ParseArray()
			{
				ArrayList arrayList = new ArrayList();
				this.json.Read();
				bool flag = true;
				while (flag)
				{
					CBJSON.Parser.TOKEN nextToken = this.NextToken;
					switch (nextToken)
					{
					case CBJSON.Parser.TOKEN.SQUARED_CLOSE:
						flag = false;
						break;
					default:
					{
						if (nextToken == CBJSON.Parser.TOKEN.NONE)
						{
							return null;
						}
						object value = this.ParseByToken(nextToken);
						arrayList.Add(value);
						break;
					}
					case CBJSON.Parser.TOKEN.COMMA:
						break;
					}
				}
				return arrayList;
			}

			// Token: 0x0600006A RID: 106 RVA: 0x00004080 File Offset: 0x00002480
			private object ParseValue()
			{
				CBJSON.Parser.TOKEN nextToken = this.NextToken;
				return this.ParseByToken(nextToken);
			}

			// Token: 0x0600006B RID: 107 RVA: 0x0000409C File Offset: 0x0000249C
			private object ParseByToken(CBJSON.Parser.TOKEN token)
			{
				switch (token)
				{
				case CBJSON.Parser.TOKEN.STRING:
					return this.ParseString();
				case CBJSON.Parser.TOKEN.NUMBER:
					return this.ParseNumber();
				case CBJSON.Parser.TOKEN.TRUE:
					return true;
				case CBJSON.Parser.TOKEN.FALSE:
					return false;
				case CBJSON.Parser.TOKEN.NULL:
					return null;
				default:
					switch (token)
					{
					case CBJSON.Parser.TOKEN.CURLY_OPEN:
						return this.ParseObject();
					case CBJSON.Parser.TOKEN.SQUARED_OPEN:
						return this.ParseArray();
					}
					return null;
				}
			}

			// Token: 0x0600006C RID: 108 RVA: 0x0000410C File Offset: 0x0000250C
			private string ParseString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				this.json.Read();
				bool flag = true;
				while (flag)
				{
					if (this.json.Peek() == -1)
					{
						break;
					}
					char nextChar = this.NextChar;
					if (nextChar != '"')
					{
						if (nextChar != '\\')
						{
							stringBuilder.Append(nextChar);
						}
						else if (this.json.Peek() == -1)
						{
							flag = false;
						}
						else
						{
							nextChar = this.NextChar;
							switch (nextChar)
							{
							case 'r':
								stringBuilder.Append('\r');
								break;
							default:
								if (nextChar != '"' && nextChar != '/' && nextChar != '\\')
								{
									if (nextChar != 'b')
									{
										if (nextChar != 'f')
										{
											if (nextChar == 'n')
											{
												stringBuilder.Append('\n');
											}
										}
										else
										{
											stringBuilder.Append('\f');
										}
									}
									else
									{
										stringBuilder.Append('\b');
									}
								}
								else
								{
									stringBuilder.Append(nextChar);
								}
								break;
							case 't':
								stringBuilder.Append('\t');
								break;
							case 'u':
							{
								char[] array = new char[4];
								for (int i = 0; i < 4; i++)
								{
									array[i] = this.NextChar;
								}
								stringBuilder.Append((char)Convert.ToInt32(new string(array), 16));
								break;
							}
							}
						}
					}
					else
					{
						flag = false;
					}
				}
				return stringBuilder.ToString();
			}

			// Token: 0x0600006D RID: 109 RVA: 0x0000428C File Offset: 0x0000268C
			private object ParseNumber()
			{
				string nextWord = this.NextWord;
				if (nextWord.IndexOf('.') == -1)
				{
					long num;
					long.TryParse(nextWord, out num);
					return num;
				}
				double num2;
				double.TryParse(nextWord, out num2);
				return num2;
			}

			// Token: 0x0600006E RID: 110 RVA: 0x000042CD File Offset: 0x000026CD
			private void EatWhitespace()
			{
				while (char.IsWhiteSpace(this.PeekChar))
				{
					this.json.Read();
					if (this.json.Peek() == -1)
					{
						break;
					}
				}
			}

			// Token: 0x17000001 RID: 1
			// (get) Token: 0x0600006F RID: 111 RVA: 0x00004306 File Offset: 0x00002706
			private char PeekChar
			{
				get
				{
					return Convert.ToChar(this.json.Peek());
				}
			}

			// Token: 0x17000002 RID: 2
			// (get) Token: 0x06000070 RID: 112 RVA: 0x00004318 File Offset: 0x00002718
			private char NextChar
			{
				get
				{
					return Convert.ToChar(this.json.Read());
				}
			}

			// Token: 0x17000003 RID: 3
			// (get) Token: 0x06000071 RID: 113 RVA: 0x0000432C File Offset: 0x0000272C
			private string NextWord
			{
				get
				{
					StringBuilder stringBuilder = new StringBuilder();
					while (!CBJSON.Parser.IsWordBreak(this.PeekChar))
					{
						stringBuilder.Append(this.NextChar);
						if (this.json.Peek() == -1)
						{
							break;
						}
					}
					return stringBuilder.ToString();
				}
			}

			// Token: 0x17000004 RID: 4
			// (get) Token: 0x06000072 RID: 114 RVA: 0x00004380 File Offset: 0x00002780
			private CBJSON.Parser.TOKEN NextToken
			{
				get
				{
					this.EatWhitespace();
					if (this.json.Peek() == -1)
					{
						return CBJSON.Parser.TOKEN.NONE;
					}
					char peekChar = this.PeekChar;
					switch (peekChar)
					{
					case ',':
						this.json.Read();
						return CBJSON.Parser.TOKEN.COMMA;
					case '-':
					case '0':
					case '1':
					case '2':
					case '3':
					case '4':
					case '5':
					case '6':
					case '7':
					case '8':
					case '9':
						return CBJSON.Parser.TOKEN.NUMBER;
					default:
						switch (peekChar)
						{
						case '[':
							return CBJSON.Parser.TOKEN.SQUARED_OPEN;
						default:
							switch (peekChar)
							{
							case '{':
								return CBJSON.Parser.TOKEN.CURLY_OPEN;
							default:
								if (peekChar != '"')
								{
									string nextWord = this.NextWord;
									if (nextWord != null)
									{
										if (nextWord == "false")
										{
											return CBJSON.Parser.TOKEN.FALSE;
										}
										if (nextWord == "true")
										{
											return CBJSON.Parser.TOKEN.TRUE;
										}
										if (nextWord == "null")
										{
											return CBJSON.Parser.TOKEN.NULL;
										}
									}
									return CBJSON.Parser.TOKEN.NONE;
								}
								return CBJSON.Parser.TOKEN.STRING;
							case '}':
								this.json.Read();
								return CBJSON.Parser.TOKEN.CURLY_CLOSE;
							}
							break;
						case ']':
							this.json.Read();
							return CBJSON.Parser.TOKEN.SQUARED_CLOSE;
						}
						break;
					case ':':
						return CBJSON.Parser.TOKEN.COLON;
					}
				}
			}

			// Token: 0x04000025 RID: 37
			private const string WORD_BREAK = "{}[],:\"";

			// Token: 0x04000026 RID: 38
			private StringReader json;

			// Token: 0x02000008 RID: 8
			private enum TOKEN
			{
				// Token: 0x04000028 RID: 40
				NONE,
				// Token: 0x04000029 RID: 41
				CURLY_OPEN,
				// Token: 0x0400002A RID: 42
				CURLY_CLOSE,
				// Token: 0x0400002B RID: 43
				SQUARED_OPEN,
				// Token: 0x0400002C RID: 44
				SQUARED_CLOSE,
				// Token: 0x0400002D RID: 45
				COLON,
				// Token: 0x0400002E RID: 46
				COMMA,
				// Token: 0x0400002F RID: 47
				STRING,
				// Token: 0x04000030 RID: 48
				NUMBER,
				// Token: 0x04000031 RID: 49
				TRUE,
				// Token: 0x04000032 RID: 50
				FALSE,
				// Token: 0x04000033 RID: 51
				NULL
			}
		}

		// Token: 0x02000009 RID: 9
		private sealed class Serializer
		{
			// Token: 0x06000073 RID: 115 RVA: 0x000044A9 File Offset: 0x000028A9
			private Serializer()
			{
				this.builder = new StringBuilder();
			}

			// Token: 0x06000074 RID: 116 RVA: 0x000044BC File Offset: 0x000028BC
			public static string Serialize(object obj)
			{
				CBJSON.Serializer serializer = new CBJSON.Serializer();
				serializer.SerializeValue(obj);
				return serializer.builder.ToString();
			}

			// Token: 0x06000075 RID: 117 RVA: 0x000044E4 File Offset: 0x000028E4
			private void SerializeValue(object val)
			{
				string str;
				ArrayList anArray;
				Hashtable obj;
				if (val == null)
				{
					this.builder.Append("null");
				}
				else if ((str = (val as string)) != null)
				{
					this.SerializeString(str);
				}
				else if (val is bool)
				{
					this.builder.Append((!(bool)val) ? "false" : "true");
				}
				else if ((anArray = (val as ArrayList)) != null)
				{
					this.SerializeArray(anArray);
				}
				else if ((obj = (val as Hashtable)) != null)
				{
					this.SerializeObject(obj);
				}
				else if (val is char)
				{
					this.SerializeString(new string((char)val, 1));
				}
				else
				{
					this.SerializeOther(val);
				}
			}

			// Token: 0x06000076 RID: 118 RVA: 0x000045B8 File Offset: 0x000029B8
			private void SerializeObject(Hashtable obj)
			{
				bool flag = true;
				this.builder.Append('{');
				IDictionaryEnumerator enumerator = obj.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj2 = enumerator.Current;
						DictionaryEntry dictionaryEntry = (DictionaryEntry)obj2;
						if (!flag)
						{
							this.builder.Append(',');
						}
						this.SerializeString(dictionaryEntry.Key.ToString());
						this.builder.Append(':');
						this.SerializeValue(dictionaryEntry.Value);
						flag = false;
					}
				}
				finally
				{
					IDisposable disposable;
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				this.builder.Append('}');
			}

			// Token: 0x06000077 RID: 119 RVA: 0x00004674 File Offset: 0x00002A74
			private void SerializeArray(ArrayList anArray)
			{
				this.builder.Append('[');
				bool flag = true;
				for (int i = 0; i < anArray.Count; i++)
				{
					object val = anArray[i];
					if (!flag)
					{
						this.builder.Append(',');
					}
					this.SerializeValue(val);
					flag = false;
				}
				this.builder.Append(']');
			}

			// Token: 0x06000078 RID: 120 RVA: 0x000046DC File Offset: 0x00002ADC
			private void SerializeString(string str)
			{
				this.builder.Append('"');
				foreach (char c in str.ToCharArray())
				{
					switch (c)
					{
					case '\b':
						this.builder.Append("\\b");
						break;
					case '\t':
						this.builder.Append("\\t");
						break;
					case '\n':
						this.builder.Append("\\n");
						break;
					default:
						if (c != '"')
						{
							if (c != '\\')
							{
								int num = Convert.ToInt32(c);
								if (num >= 32 && num <= 126)
								{
									this.builder.Append(c);
								}
								else
								{
									this.builder.Append("\\u");
									this.builder.Append(num.ToString("x4"));
								}
							}
							else
							{
								this.builder.Append("\\\\");
							}
						}
						else
						{
							this.builder.Append("\\\"");
						}
						break;
					case '\f':
						this.builder.Append("\\f");
						break;
					case '\r':
						this.builder.Append("\\r");
						break;
					}
				}
				this.builder.Append('"');
			}

			// Token: 0x06000079 RID: 121 RVA: 0x0000484C File Offset: 0x00002C4C
			private void SerializeOther(object val)
			{
				if (val is float)
				{
					this.builder.Append(((float)val).ToString("R"));
				}
				else if (val is int || val is uint || val is long || val is sbyte || val is byte || val is short || val is ushort || val is ulong)
				{
					this.builder.Append(val);
				}
				else if (val is double || val is decimal)
				{
					this.builder.Append(Convert.ToDouble(val).ToString("R"));
				}
				else
				{
					this.SerializeString(val.ToString());
				}
			}

			// Token: 0x04000034 RID: 52
			private StringBuilder builder;
		}
	}
}
