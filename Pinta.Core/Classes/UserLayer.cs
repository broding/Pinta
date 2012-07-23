﻿// 
// UserLayer.cs
//  
// Author:
//       Andrew Davis <andrew.3.1415@gmail.com>
// 
// Copyright (c) 2012 Andrew Davis, GSoC 2012
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.ComponentModel;
using System.Collections.Specialized;
using Cairo;
using Gdk;

namespace Pinta.Core
{
	public class UserLayer : Layer
	{
		public UserLayer (ImageSurface surface) : base (surface)
		{
			SetupTextLayer();
		}

		public UserLayer(ImageSurface surface, bool hidden, double opacity, string name) : base(surface, hidden, opacity, name)
		{
			SetupTextLayer();
		}

		private void SetupTextLayer()
		{
			if (Surface == null)
			{
				//Should never happen?
				TextLayer = new Layer();
			}
			else
			{
				TextLayer = new Layer(new Cairo.ImageSurface(Cairo.Format.ARGB32, Surface.Width, Surface.Height));
			}
		}

		public Layer TextLayer;
		public TextEngine tEngine = new TextEngine();
		public Gdk.Rectangle old_bounds = Gdk.Rectangle.Zero;
		public Cairo.Color textColor;
	}
}
