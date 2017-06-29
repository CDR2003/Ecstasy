using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy.Core
{
	public class EcsSystem
	{
		public EcsWorld World { get; internal set; }

		protected ContentManager ContentManager
		{
			get
			{
				return this.World.ContentManager;
			}
		}

		protected SpriteBatch SpriteBatch
		{
			get
			{
				return this.World.SpriteBatch;
			}
		}

		public EcsSystem()
		{
		}

		public virtual void Load()
		{
		}

		public virtual void Unload()
		{
		}

		public virtual void Update( float deltaTime )
		{
		}

		public virtual void Draw()
		{
		}

		protected List<EcsComponent> GetComponents( Type type )
		{
			return this.World.GetComponents( type );
		}

		protected List<EcsComponent> GetComponents<T>() where T : EcsComponent
		{
			return this.World.GetComponents<T>();
		}

		protected EcsEntity Instantiate( string name )
		{
			return this.World.Instantiate( name );
		}
	}
}
