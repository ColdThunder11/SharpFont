﻿#region MIT License
/*Copyright (c) 2012-2015 Robert Rouhani <robert.rouhani@gmail.com>

SharpFont based on Tao.FreeType, Copyright (c) 2003-2007 Tao Framework Team

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/
#endregion

using System;
using System.Runtime.InteropServices;

using FT_Long = System.Runtime.InteropServices.CLong;
using FT_ULong = System.Runtime.InteropServices.CULong;

namespace SharpFont.TrueType.Internal
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	internal unsafe struct PCLTRec
	{
		internal FT_Long Version;
		internal FT_ULong FontNumber;
		internal ushort Pitch;
		internal ushort xHeight;
		internal ushort Style;
		internal ushort TypeFamily;
		internal ushort CapHeight;
		internal ushort SymbolSet;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		internal string TypeFace;

		private fixed byte characterComplement[8];
		internal byte[] CharacterComplement
		{
			get
			{
				var array = new byte[8];
				fixed (byte* p = characterComplement)
				{
					for (int i = 0; i < array.Length; i++)
						array[i] = p[i];
				}
				return array;
			}
		}

		private fixed byte fileName[6];
		internal byte[] FileName
		{
			get
			{
				var array = new byte[6];

				fixed (byte* p = fileName)
				{
					for (int i = 0; i < array.Length; i++)
						array[i] = p[i];
				}

				return array;
			}
		}

		internal byte StrokeWeight;
		internal byte WidthType;
		internal byte SerifStyle;
		internal byte Reserved;
	}
}
