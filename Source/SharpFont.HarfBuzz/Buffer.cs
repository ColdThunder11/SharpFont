﻿//Copyright (c) 2014-2015 Robert Rouhani <robert.rouhani@gmail.com> and other contributors (see CONTRIBUTORS file).
//Licensed under the MIT License - https://raw.github.com/Robmaister/SharpFont.HarfBuzz/master/LICENSE

using System;
using System.Runtime.InteropServices;
using SharpFont.HarfBuzz.Internal;

namespace SharpFont.HarfBuzz
{
	public class Buffer
	{
		#region Fields

		internal IntPtr reference;

		#endregion

		#region Constructors

		public Buffer()
		{
			reference = HB.hb_buffer_create();
		}

		#endregion

		#region Properties

		public Direction Direction
		{
			set { HB.hb_buffer_set_direction(reference, value); }
		}

		// Arabic
		public Script Script
		{
			set { HB.hb_buffer_set_script(reference, value); }
		}

		public int Length
		{
			get { return HB.hb_buffer_get_length(reference); }
		}

		internal IntPtr Reference
		{
			get { return reference; }
		}

		#endregion

		#region Methods

		public void AddText(string str)
		{
			byte[] text = System.Text.Encoding.UTF8.GetBytes(str);
			HB.hb_buffer_add_utf8(reference, text, text.Length, 0, text.Length);
		}

		public GlyphInfo[] GlyphInfo()
		{
			int length;
			IntPtr glyphInfoPtr = HB.hb_buffer_get_glyph_infos(reference, out length);
			var glyphInfos = new GlyphInfo[length];
			var glyphInfoSize = Marshal.SizeOf(typeof(GlyphInfo));
			for (int i = 0; i < length; ++i)
			{
				// This version causes boxing.
				glyphInfos[i] = (GlyphInfo)Marshal.PtrToStructure(
					glyphInfoPtr + glyphInfoSize * i, typeof(GlyphInfo));
			}

			return glyphInfos;
		}

		public GlyphPosition[] GlyphPositions()
		{
			int length;
			IntPtr glyphPositionPtr = HB.hb_buffer_get_glyph_positions(reference, out length);
			var glyphPositions = new GlyphPosition[length];
			var glyphPositionSize = Marshal.SizeOf(typeof(GlyphPosition));
			for (int i = 0; i < length; ++i)
			{
				// This version causes boxing.
				glyphPositions[i] = (GlyphPosition)Marshal.PtrToStructure(
					glyphPositionPtr + glyphPositionSize * i, typeof(GlyphPosition));
			}

			return glyphPositions;
		}

		#endregion
	}
}
