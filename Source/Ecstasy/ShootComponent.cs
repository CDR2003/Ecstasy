using Ecstasy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy
{
	public class ShootComponent : EcsComponent
	{
		public float ShootInterval;

		public float CurrentShootTime;

		public override EcsComponent Clone()
		{
			var component = new ShootComponent();
			component.ShootInterval = this.ShootInterval;
			component.CurrentShootTime = this.CurrentShootTime;
			return component;
		}
	}
}
