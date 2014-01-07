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
			var critical = (unmodifiedRoll == CRITICAL_ROLL);
			var modifier = ModifierCalc(critical, Strength.Modifier);
			var success = unmodifiedRoll + modifier >= armorClass;

			return new AttackResult
			{
				Success =  success,
				IsCriticalHit =  critical,
				AttackModifier = modifier
			};
		}

		private int ModifierCalc(bool critical, int modifier)
		{
			if (!critical)
				return modifier;
			return modifier * 2;
		}

		public void ApplyDamage(AttackResult attack)
		{
			if (attack.Success)
				HitPoints = HitPoints - CalculateDamage(attack);
		}

	 
		
		private static int CalculateDamage(AttackResult attack)
		{
			var damage = 1;

			damage = damage + attack.AttackModifier;

			// This should alway be last (for now)
			if(attack.IsCriticalHit)
				damage = damage * 2;

			if(damage < 1)
				return 1;

			return damage;
		}
	}
}
