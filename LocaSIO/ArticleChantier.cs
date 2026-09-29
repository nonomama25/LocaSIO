using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaSIO
{
	internal class ArticleChantier : Article
	{
		private string _typeEngin;
		private bool _cacesRequis;
		private int _poidsKg;

		public ArticleChantier(string typeEngin, bool cacesRequis, int poidsKg )
		{
			_typeEngin = typeEngin;
			_cacesRequis = cacesRequis;
			_poidsKg = poidsKg;
		}

		public string getTypeEngin()
		{
			return _typeEngin;
		}
		
		public void setTypeEngin( string typeEngin )
		{
			_typeEngin = typeEngin;
		}

		public bool getCacesRequis()
		{
			return _cacesRequis;
		}

		public void setCacesRequis( bool cacesRequis)
		{
			_cacesRequis = cacesRequis;
		}

		public int getPoidsKg()
		{
			return _poidsKg;
		}

		public void setPoidsKg( int poidsKg)
		{
			_poidsKg= poidsKg;
		}
	}
}