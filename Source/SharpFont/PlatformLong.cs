using System;
using System.Runtime.InteropServices;

namespace SharpFont
{
	[StructLayout(LayoutKind.Sequential)]
	struct PlatformLong
	{
#if LONG_64
		public Int64 Long;
#else
		public Int32 Long;
#endif
		public PlatformLong(long value)
		{
#if LONG_64
			Long = value;
#else
			Long = (int)value;
#endif
		}

		public PlatformLong(int value)
		{
			Long = value;
		}
	}
}
