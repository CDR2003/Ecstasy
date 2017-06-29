using Ecstasy.Components;
using Ecstasy.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy
{
	public class ShootSystem : EcsSystem
	{
		public override void Update( float deltaTime )
		{
			var shoots = this.GetComponents<ShootComponent>();
			foreach( ShootComponent shoot in shoots )
			{
				var input = shoot.GetSibling<EcsGamePadInputComponent>();

				shoot.CurrentShootTime += deltaTime;
				if( shoot.CurrentShootTime >= shoot.ShootInterval && input.RightStick.Length() > 0.5f )
				{
					shoot.CurrentShootTime = 0.0f;
					this.ShootBullet( shoot, Vector2.Normalize( input.RightStick ) );
				}
			}
		}

		private void ShootBullet( ShootComponent shoot, Vector2 direction )
		{
			var transform = shoot.GetSibling<EcsTransformComponent>();

			var bullet = this.Instantiate( "Bullet" );
			bullet.GetComponent<EcsTransformComponent>().Position = transform.Position;
			bullet.GetComponent<MoveDirectionComponent>().CurrentDirection = new Vector3( direction.X, -direction.Y, 0.0f );
			this.World.AddEntity( bullet );
		}
	}
}
