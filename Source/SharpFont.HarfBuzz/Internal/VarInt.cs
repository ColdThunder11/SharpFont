using System;
using System.Runtime.InteropServices;

namespace SharpFont.HarfBuzz.Internal
{
	[StructLayout(LayoutKind.Sequential)]
	public struct VarInt
	{
		public uint u32;
		/*
		typedef union _hb_var_int_t {
		  uint32_t u32;
		  int32_t i32;
		  uint16_t u16[2];
		  int16_t i16[2];
		  uint8_t u8[4];
		  int8_t i8[4];
		} hb_var_int_t;
		 */
	}
}
