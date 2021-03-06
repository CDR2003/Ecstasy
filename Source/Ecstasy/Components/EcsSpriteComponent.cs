﻿using Ecstasy.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy.Components
{
	public class EcsSpriteComponent : EcsComponent
	{
		public Texture2D Texture;

		public Rectangle? SourceRect;

		public Vector2 Anchor;

		public Color Color;

		public EcsSpriteComponent()
		{
			this.Texture = null;
			this.SourceRect = null;
			this.Anchor = new Vector2( 0.5f, 0.5f );
			this.Color = Color.White;
		}

		public override EcsComponent Clone()
		{
			var component = new EcsSpriteComponent();
			component.Texture = this.Texture;
			component.SourceRect = this.SourceRect;
			component.Anchor = this.Anchor;
			component.Color = this.Color;
			return component;
		}
	}
}
