using Ecstasy.Components;
using Ecstasy.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ecstasy
{
	public class TestGame : Game
	{
		private GraphicsDeviceManager _graphics;

		private SpriteBatch _spriteBatch;

		private EcsWorld _world;

		public TestGame()
		{
			_graphics = new GraphicsDeviceManager( this );
			this.Content.RootDirectory = "Content";
		}
		
		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch( GraphicsDevice );

			_world = new EcsWorld( this.Content, _spriteBatch );
			this.InitializeEntities();
			_world.Load();
		}
		
		protected override void UnloadContent()
		{
			_world.Unload();
		}
		
		protected override void Update( GameTime gameTime )
		{
			if( GamePad.GetState( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown( Keys.Escape ) )
				Exit();

			_world.Update( gameTime );

			base.Update( gameTime );
		}
		
		protected override void Draw( GameTime gameTime )
		{
			GraphicsDevice.Clear( Color.CornflowerBlue );

			_world.Draw();

			base.Draw( gameTime );
		}

		private void InitializeEntities()
		{
			var player = this.CreatePlayer();
			_world.AddEntity( player );

			var bullet = this.CreateBullet();
			_world.PrefabLibrary.AddPrefab( "Bullet", bullet );
		}

		private EcsEntity CreatePlayer()
		{
			var windowSize = new Vector3( this.GraphicsDevice.Viewport.Bounds.Size.ToVector2(), 0.0f );

			var player = new EcsEntity( _world );
			player.Name = "Player";

			var transform = player.AddComponent<EcsTransformComponent>();
			transform.Position = windowSize / 2.0f;
			transform.Scale = Vector3.One / 2.0f;

			var sprite = player.AddComponent<EcsSpriteComponent>();
			sprite.Texture = this.Content.Load<Texture2D>( "Box" );

			var speed = player.AddComponent<EcsSpeedComponent>();
			speed.Speed = 200.0f;

			var shoot = player.AddComponent<ShootComponent>();
			shoot.ShootInterval = 0.2f;

			player.AddComponent<EcsGamePadInputComponent>();

			return player;
		}

		private EcsEntity CreateBullet()
		{
			var bullet = new EcsEntity( _world );
			bullet.Name = "Bullet";

			var transform = bullet.AddComponent<EcsTransformComponent>();
			transform.Scale = Vector3.One / 10.0f;

			var sprite = bullet.AddComponent<EcsSpriteComponent>();
			sprite.Texture = this.Content.Load<Texture2D>( "Box" );

			var speed = bullet.AddComponent<EcsSpeedComponent>();
			speed.Speed = 800.0f;

			bullet.AddComponent<MoveDirectionComponent>();

			return bullet;
		}
	}
}
