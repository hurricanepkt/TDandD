using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDandD
{
	public class Character
	{
		const int CRITICAL_ROLL = 20;

		public string Name { get; set; }
		public AlignmentEnum Alignment { get; set; }
		public int ArmorClass { get; set; }
		public int HitPoints { get; set; }

		public bool IsAlive {
			get { return HitPoints > 0; }
		}

		public Ability Strength { get; set; }
		public Ability Dexterity { get; set; }
		public Ability Constitution { get; set; }
		public Ability Wisdom { get; set; }
		public Ability Intelligence { get; set; }
		public Ability Charisma { get; set; }

		public Character()
		{
			ArmorClass = 10;
			HitPoints = 5;
			Strength = new Ability();
			Dexterity = new Ability();
			Constitution = new Ability();
			Wisdom = new Ability();
			Intelligence = new Ability();
			Charisma = new Ability();
		}

		public bool Attack(int roll, int armorClass)
		{
			return roll >= armorClass;
		}

		public void DefendAttack(int roll) 
		{
			var isAHit = Attack(roll, ArmorClass);

			if(isAHit)
				HitPoints = HitPoints - CalculateDamage(roll);
		}
		
		private static int CalculateDamage(int roll)
		{
			return roll == CRITICAL_ROLL ? 2 : 1;
		}
	}
}
