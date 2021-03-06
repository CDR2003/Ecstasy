﻿using Ecstasy.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy.Core
{
	public class EcsWorld
	{
		public ContentManager ContentManager { get; private set; }

		public SpriteBatch SpriteBatch { get; private set; }

		public EcsPrefabLibrary PrefabLibrary { get; private set; }

		public List<EcsSystem> Systems { get; private set; }

		public List<EcsEntity> Entities { get; private set; }

		private Dictionary<Type, List<EcsComponent>> _componentGroups;

		public EcsWorld( ContentManager contentManager, SpriteBatch spriteBatch )
		{
			this.ContentManager = contentManager;
			this.SpriteBatch = spriteBatch;
			this.PrefabLibrary = new EcsPrefabLibrary();
			this.Systems = new List<EcsSystem>();
			this.Entities = new List<EcsEntity>();

			_componentGroups = new Dictionary<Type, List<EcsComponent>>();

			this.InitializeSystems();
		}

		public void AddEntity( EcsEntity entity )
		{
			this.Entities.Add( entity );

			foreach( var pair in entity.Components )
			{
				List<EcsComponent> componentGroup = null;
				if( _componentGroups.TryGetValue( pair.Key, out componentGroup ) == false )
				{
					componentGroup = new List<EcsComponent>();
					_componentGroups.Add( pair.Key, componentGroup );
				}
				componentGroup.Add( pair.Value );
			}
		}

		public void RemoveEntity( EcsEntity entity )
		{
			var removed = this.Entities.Remove( entity );
			if( removed )
			{
				foreach( var pair in entity.Components )
				{
					List<EcsComponent> componentGroup = null;
					if( _componentGroups.TryGetValue( pair.Key, out componentGroup ) )
					{
						componentGroup.Remove( pair.Value );
					}
				}
			}
		}

		public List<EcsComponent> GetComponents( Type type )
		{
			List<EcsComponent> components = null;
			if( _componentGroups.TryGetValue( type, out components ) )
			{
				return components;
			}
			else
			{
				return new List<EcsComponent>();
			}
		}

		public List<EcsComponent> GetComponents<T>() where T : EcsComponent
		{
			return this.GetComponents( typeof( T ) );
		}

		public EcsEntity Instantiate( string name )
		{
			return this.PrefabLibrary.GetPrefab( name ).Instantiate();
		}

		public void Load()
		{
			foreach( var system in this.Systems )
			{
				system.Load();
			}
		}

		public void Unload()
		{
			foreach( var system in this.Systems )
			{
				system.Unload();
			}
		}

		public void Update( GameTime gameTime )
		{
			foreach( var system in this.Systems )
			{
				system.Update( (float)gameTime.ElapsedGameTime.TotalSeconds );
			}
		}

		public void Draw()
		{
			this.SpriteBatch.Begin();
			foreach( var system in this.Systems )
			{
				system.Draw();
			}
			this.SpriteBatch.End();
		}

		private void AddSystem( Type type )
		{
			var system = Activator.CreateInstance( type ) as EcsSystem;
			system.World = this;
			this.Systems.Add( system );
		}

		private void InitializeSystems()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var types = assembly.GetTypes();
			foreach( var type in types )
			{
				if( type.BaseType == typeof( EcsSystem ) )
				{
					this.AddSystem( type );
				}
			}
		}
	}
}
