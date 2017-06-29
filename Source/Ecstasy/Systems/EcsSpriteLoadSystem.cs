using Ecstasy.Components;
using Ecstasy.Core;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy.Systems
{
	public class EcsSpriteLoadSystem : EcsSystem
	{
		public override void Load()
		{
			var sprites = this.GetComponents<EcsSpriteComponent>();
			foreach( EcsSpriteComponent sprite in sprites )
			{
				sprite.Texture = this.ContentManager.Load<Texture2D>( sprite.TextureName );
			}
		}
	}
}
