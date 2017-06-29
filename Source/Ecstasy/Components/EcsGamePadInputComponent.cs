using Ecstasy.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy.Components
{
	public class EcsGamePadInputComponent : EcsComponent
	{
		public Vector2 LeftStick;

		public Vector2 RightStick;

		public bool A;

		public bool B;

		public bool X;

		public bool Y;

		public override EcsComponent Clone()
		{
			var component = new EcsGamePadInputComponent();
			component.LeftStick = this.LeftStick;
			component.RightStick = this.RightStick;
			component.A = this.A;
			component.B = this.B;
			component.X = this.X;
			component.Y = this.Y;
			return component;
		}
	}
}
