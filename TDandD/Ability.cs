using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDandD
{
	public class Ability
	{
		const int DEFAULT_VALUE = 10;
		private int m_value;
		public int Value
		{
			get { return m_value; }
			set
			{
				if(value < 1 || value > 20)
					throw new ArgumentOutOfRangeException("value", "Value must be between 1 and 20");
				m_value = value;
			}
		}

		public int Modifier { 
			get {
				return -5;
			} 
		}

		public Ability()
		{
			Value = DEFAULT_VALUE;
		}

	}
}
