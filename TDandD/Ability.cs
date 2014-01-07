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
                if (value < 1 || value > 20)
                    throw new ArgumentOutOfRangeException("value", "Value must be between 1 and 20");
                m_value = value;
            }
        }

        private static Dictionary<int, int> ValueToModifierConst = new Dictionary<int, int>
	    {
	        {1, -5},
	        {2, -4},
	        {3, -4},
            {4, -3},
	        {5, -3},
	        {6, -2},
            {7, -2},
	        {8, -1},
	        {9, -1},
            {10, 0},
	        {11, 0},
	        {12, 1},
	        {13, 1},
            {14, 2},
	        {15, 2},
	        {16, 3},
	        {17, 3},
	        {18, 4},
	        {19, 4},
            {20, 5}
	    };
        public int Modifier
        {
            get
            {
                return ValueToModifierConst[Value];
            }
        }

        public Ability()
        {
            Value = DEFAULT_VALUE;
        }

    }
}
