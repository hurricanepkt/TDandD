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

		// TODO: change return from bool to AttackResult
		// TODO: AttackResult should return success and if critical hit
		public AttackResult Attack(int roll, int armorClass)
		{
			return new AttackResult
			{
				Success = roll + Strength.Modifier >= armorClass
			};
		}
		// TODO: change to be ApplyDamage?
		// TODO: Should take an AttackResult, Attacker
		public void DefendAttack(int unmodifiedRoll) 
		{
			var isAHit = Attack(unmodifiedRoll, ArmorClass);

			if(isAHit.Success)
				HitPoints = HitPoints - CalculateDamage(unmodifiedRoll);
		}
		
		private static int CalculateDamage(int unmodifiedRoll)
		{
			return unmodifiedRoll == CRITICAL_ROLL ? 2 : 1;
		}
	}
}
