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

		public AttackResult Attack(int unmodifiedRoll, int armorClass)
		{
			return new AttackResult
			{
				Success = unmodifiedRoll + Strength.Modifier >= armorClass,
                IsCriticalHit = (unmodifiedRoll == CRITICAL_ROLL),
                UnmodifiedRoll =  unmodifiedRoll
			};
		}

	    public void ApplyDamage(AttackResult attack)
	    {
	        if (attack.Success)
	            HitPoints = HitPoints - CalculateDamage(attack.IsCriticalHit);
	    }

     
		
		private static int CalculateDamage(bool isCriticalHit)
		{
			return isCriticalHit ? 2 : 1;
		}
	}
}
