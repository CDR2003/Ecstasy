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
			var clientSize = new Vector3( this.Window.ClientBounds.Size.ToVector2(), 0.0f );

			var box = new EcsEntity( _world );

			var transform = box.AddComponent<EcsTransformComponent>();
			transform.Position = clientSize / 2.0f;

			var sprite = box.AddComponent<EcsSpriteComponent>();
			sprite.TextureName = "Box";

			var velocity = box.AddComponent<EcsVelocityComponent>();
			velocity.Velocity = new Vector3( 200.0f, 200.0f, 0.0f );

			var bound = box.AddComponent<EcsMovementBoundComponent>();
			bound.Minimum = Vector3.Zero;
			bound.Maximum = clientSize;

			_world.AddEntity( box );
		}
	}
}
