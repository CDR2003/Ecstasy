using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy.Core
{
	public class EcsComponent
	{
		public EcsEntity Entity { get; internal set; }

		public EcsComponent()
		{
		}

		public EcsComponent GetSibling( Type type )
		{
			return this.Entity.GetComponent( type );
		}

		public T GetSibling<T>() where T : EcsComponent
		{
			return this.Entity.GetComponent<T>();
		}
	}
}
