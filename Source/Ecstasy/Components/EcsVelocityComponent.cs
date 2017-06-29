using Ecstasy.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy.Components
{
	public class EcsVelocityComponent : EcsComponent
	{
		public Vector3 Velocity;

		public EcsVelocityComponent()
		{
			this.Velocity = Vector3.Zero;
		}
	}
}
