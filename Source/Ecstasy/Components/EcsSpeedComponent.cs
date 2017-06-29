using Ecstasy.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy.Components
{
	public class EcsSpeedComponent : EcsComponent
	{
		public float Speed;

		public EcsSpeedComponent()
		{
			this.Speed = 0.0f;
		}

		public override EcsComponent Clone()
		{
			var component = new EcsSpeedComponent();
			component.Speed = this.Speed;
			return component;
		}
	}
}
