using Ecstasy.Components;
using Ecstasy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy
{
	public class AutoMoveSystem : EcsSystem
	{
		public override void Update( float deltaTime )
		{
			var moveDirections = this.GetComponents<MoveDirectionComponent>();
			foreach( MoveDirectionComponent moveDirection in moveDirections )
			{
				var transform = moveDirection.GetSibling<EcsTransformComponent>();
				var speed = moveDirection.GetSibling<EcsSpeedComponent>();
				transform.Position += moveDirection.CurrentDirection * speed.Speed * deltaTime;
			}
		}
	}
}
