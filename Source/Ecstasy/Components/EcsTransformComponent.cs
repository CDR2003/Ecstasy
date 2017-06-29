using Ecstasy.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy.Components
{
	public class EcsTransformComponent : EcsComponent
	{
		public Vector3 Position;

		public Vector3 Scale;

		public EcsTransformComponent()
		{
			this.Position = Vector3.Zero;
			this.Scale = Vector3.One;
		}
	}
}
