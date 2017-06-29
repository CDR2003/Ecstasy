using Ecstasy.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy
{
	public class MoveDirectionComponent : EcsComponent
	{
		public Vector3 CurrentDirection;

		public override EcsComponent Clone()
		{
			var component = new MoveDirectionComponent();
			component.CurrentDirection = this.CurrentDirection;
			return component;
		}
	}
}
