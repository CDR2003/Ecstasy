using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy.Core
{
	public class EcsEntity
	{
		public EcsWorld World { get; private set; }

		public string Name { get; set; }

		public Dictionary<Type, EcsComponent> Components { get; private set; }

		public EcsEntity( EcsWorld world )
		{
			this.World = world;
			this.Name = "Entity";
			this.Components = new Dictionary<Type, EcsComponent>();
		}

		public T AddComponent<T>() where T : EcsComponent, new()
		{
			var component = new T();
			component.Entity = this;

			this.Components.Add( typeof( T ), component );
			return component;
		}

		public EcsComponent GetComponent( Type type )
		{
			EcsComponent component = null;
			if( this.Components.TryGetValue( type, out component ) )
			{
				return component;
			}
			else
			{
				return null;
			}
		}

		public T GetComponent<T>() where T : EcsComponent
		{
			return this.GetComponent( typeof( T ) ) as T;
		}

		public EcsEntity Instantiate()
		{
			var entity = new EcsEntity( this.World );
			entity.Name = this.Name + " (Clone)";
			entity.Components = new Dictionary<Type, EcsComponent>();
			foreach( var pair in this.Components )
			{
				var component = pair.Value.Clone();
				component.Entity = entity;
				entity.Components.Add( pair.Key, component );
			}
			return entity;
		}
	}
}
