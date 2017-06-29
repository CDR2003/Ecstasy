using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecstasy.Core
{
	public class EcsPrefabLibrary
	{
		private Dictionary<string, EcsEntity> _prefabs;

		internal EcsPrefabLibrary()
		{
			_prefabs = new Dictionary<string, EcsEntity>();
		}

		public void AddPrefab( string name, EcsEntity prefab )
		{
			_prefabs.Add( name, prefab );
		}

		public EcsEntity GetPrefab( string name )
		{
			EcsEntity prefab = null;
			if( _prefabs.TryGetValue( name, out prefab ) )
			{
				return prefab;
			}
			else
			{
				return null;
			}
		}
	}
}
