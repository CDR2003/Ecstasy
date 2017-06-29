using Ecstasy.Components;
using Ecstasy.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy.Systems
{
	public class EcsInputSystem : EcsSystem
	{
		public override void Update( float deltaTime )
		{
			var gamePadState = GamePad.GetState( PlayerIndex.One );

			var inputs = this.GetComponents<EcsGamePadInputComponent>();
			foreach( EcsGamePadInputComponent input in inputs )
			{
				input.LeftStick = gamePadState.ThumbSticks.Left;
				input.RightStick = gamePadState.ThumbSticks.Right;
				input.A = gamePadState.IsButtonDown( Buttons.A );
				input.B = gamePadState.IsButtonDown( Buttons.B );
				input.X = gamePadState.IsButtonDown( Buttons.X );
				input.Y = gamePadState.IsButtonDown( Buttons.Y );
			}
		}
	}
}
