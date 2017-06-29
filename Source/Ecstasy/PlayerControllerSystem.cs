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
	public class PlayerControllerSystem : EcsSystem
	{
		public override void Update( float deltaTime )
		{
			var inputs = this.GetComponents<EcsGamePadInputComponent>();
			foreach( EcsGamePadInputComponent input in inputs )
			{
				var speed = input.GetSibling<EcsSpeedComponent>();
				var transform = input.GetSibling<EcsTransformComponent>();

				var offset = Vector3.Zero;
				offset.X = input.LeftStick.X * speed.Speed * deltaTime;
				offset.Y = -input.LeftStick.Y * speed.Speed * deltaTime;

				transform.Position += offset;
			}
		}
	}
}
