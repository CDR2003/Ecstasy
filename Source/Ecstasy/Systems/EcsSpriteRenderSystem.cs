using Ecstasy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Ecstasy.Components;
using Microsoft.Xna.Framework;

namespace Ecstasy.Systems
{
	public class EcsSpriteRenderSystem : EcsSystem
	{
		public override void Draw()
		{
			var sprites = this.GetComponents<EcsSpriteComponent>();
			foreach( EcsSpriteComponent sprite in sprites )
			{
				var transform = sprite.GetSibling<EcsTransformComponent>();
				this.DrawSprite( sprite, transform );
			}
		}

		private void DrawSprite( EcsSpriteComponent sprite, EcsTransformComponent transform )
		{
			var sourceRect = Rectangle.Empty;
			if( sprite.SourceRect.HasValue )
			{
				sourceRect = sprite.SourceRect.Value;
			}
			else
			{
				sourceRect.X = 0;
				sourceRect.Y = 0;
				sourceRect.Width = sprite.Texture.Width;
				sourceRect.Height = sprite.Texture.Height;
			}

			var destRect = new Rectangle();
			destRect.Width = (int)( sourceRect.Width * transform.Scale.X );
			destRect.Height = (int)( sourceRect.Height * transform.Scale.Y );
			destRect.X = (int)( transform.Position.X - destRect.Width * sprite.Anchor.X );
			destRect.Y = (int)( transform.Position.Y - destRect.Height * sprite.Anchor.Y );

			this.SpriteBatch.Draw( sprite.Texture, destRect, sourceRect, sprite.Color );
		}
	}
}
