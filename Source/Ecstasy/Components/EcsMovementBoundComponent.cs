using Ecstasy.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy.Components
{
	public class EcsMovementBoundComponent : EcsComponent
	{
		public Vector3 Minimum;

		public Vector3 Maximum;

		public EcsMovementBoundComponent()
		{
			this.Minimum = new Vector3( float.MinValue, float.MinValue, float.MinValue );
			this.Maximum = new Vector3( float.MaxValue, float.MaxValue, float.MaxValue );
		}
	}
}
