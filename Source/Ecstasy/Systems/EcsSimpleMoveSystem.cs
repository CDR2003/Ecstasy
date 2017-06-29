using Ecstasy.Components;
using Ecstasy.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy.Systems
{
	public class EcsSimpleMoveSystem : EcsSystem
	{
		public override void Update( float deltaTime )
		{
			var velocityComponents = this.GetComponents<EcsVelocityComponent>();
			foreach( EcsVelocityComponent velocity in velocityComponents )
			{
				var transform = velocity.GetSibling<EcsTransformComponent>();
				var bound = velocity.GetSibling<EcsMovementBoundComponent>();
				this.Move( velocity, transform, bound, deltaTime );
			}
		}

		private void Move( EcsVelocityComponent velocity, EcsTransformComponent transform, EcsMovementBoundComponent bound, float deltaTime )
		{
			var offset = velocity.Velocity * deltaTime;
			transform.Position += offset;

			if( transform.Position.X < bound.Minimum.X || transform.Position.X > bound.Maximum.X )
			{
				transform.Position.X -= offset.X;
				velocity.Velocity.X *= -1.0f;
			}
			if( transform.Position.Y < bound.Minimum.Y || transform.Position.Y > bound.Maximum.Y )
			{
				transform.Position.Y -= offset.Y;
				velocity.Velocity.Y *= -1.0f;
			}
			if( transform.Position.Z < bound.Minimum.Z || transform.Position.Z > bound.Maximum.Z )
			{
				transform.Position.Z -= offset.Z;
				velocity.Velocity.Z *= -1.0f;
			}
		}
	}
}
