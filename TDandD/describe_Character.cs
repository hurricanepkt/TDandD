using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSpec;

namespace TDandD
{
	class describe_Character : nspec
	{
		Character bob;
		void before_each()
		{
			bob = new Character();

			bob.Name = "Bob";
			bob.Alignment = AlignmentEnum.EVIL;
		}

		void given_a_character()
		{
			it["can set and get a Name"] = () => bob.Name.should_be("Bob");
			it["can set and get an Alignment"] = () => bob.Alignment.should_be(AlignmentEnum.EVIL);
			it["should have an Armor Class that defaults to 10"] = () => bob.ArmorClass.should_be(10);
			it["should have Hit Points that defaults to 5"] = () => bob.HitPoints.should_be(5);
			it["should be alive"] = () => bob.IsAlive.should_be_true();

			it["should have a Strength Ability"] = () => bob.Strength.should_not_be_null<Ability>();
			it["should have a Dexterity Ability"] = () => bob.Dexterity.should_not_be_null<Ability>();
			it["should have a Constitution Ability"] = () => bob.Constitution.should_not_be_null<Ability>();
			it["should have a Wisdom Ability"] = () => bob.Wisdom.should_not_be_null<Ability>();
			it["should have a Intelligence Ability"] = () => bob.Intelligence.should_not_be_null<Ability>();
			it["should have a Charisma Ability"] = () => bob.Charisma.should_not_be_null<Ability>();
		}

		void when_attacking_another_combatant()
		{
			it["attack is unsuccessful when roll is less than opponents ArmorClass"] = () => bob.Attack(5, 10).Success.should_be_false();
			it["attack is successful when roll is more than opponents ArmorClass"] = () => bob.Attack(15, 10).Success.should_be_true();
			it["attack is successful when roll is the same as than opponents ArmorClass"] = () => bob.Attack(10, 10).Success.should_be_true();
			it["attack is a CriticalHit when roll is a natural 20"] = () => bob.Attack(20, 10).IsCriticalHit.should_be_true();
			it["attack is not a CriticalHit when roll is less than a natural 20"] = () => bob.Attack(19, 10).IsCriticalHit.should_be_false();
		}

		void when_an_opponent_attacks()
		{
			context["if attack is successful"] = () =>
			{
				Character jim = new Character();
				act = () => jim.ApplyDamage(new AttackResult() { Success = true });
				it["then character takes 1 point of damage"] = () => jim.HitPoints.should_be(4);
				it["then character takes 1 point of damage"] = () => jim.HitPoints.should_be(3);
			};

			context["if attack is a critical hit"] = () =>
			{
				Character jim = new Character();
				act = () => jim.ApplyDamage(new AttackResult() { Success = true, IsCriticalHit = true });
				it["then character takes 2 point of damage"] = () => jim.HitPoints.should_be(3);
				it["then character takes 2 point of damage again"] = () => jim.HitPoints.should_be(1);
			};

			context["if attack is not successful"] = () =>
			{
				act = () => bob.ApplyDamage(new AttackResult());
				it["then character does not take damage"] = () => bob.HitPoints.should_be(5);
			};

			context["given a character is near death"] = () =>
			{
				Character jim = new Character();
				before = () => jim.HitPoints = 1;

				context["when HitPoints are above zero"] = () =>
				{
					before = () => jim.HitPoints = 3;

					act = () => jim.ApplyDamage(new AttackResult() { Success = true });
					it["then character is alive"] = () => jim.IsAlive.should_be_true();
				};

				context["when HitPoints fall to zero"] = () =>
				{
					act = () => jim.ApplyDamage(new AttackResult() { Success = true });
					it["then character is dead"] = () => jim.IsAlive.should_be_false();
				};

				context["when HitPoints fall below zero"] = () =>
				{
					act = () => jim.ApplyDamage(new AttackResult() { Success = true, IsCriticalHit = true });
					it["then character is dead"] = () => jim.IsAlive.should_be_false();
				};

			};


		}


		AttackResult result;
		void when_strength_modifier_applies() 
		{
			context["when attacking"] = () =>
			{
				context["given Strength Value is 20"] = () =>
				{
					before = () => bob.Strength.Value = 20;
					act = () => result = bob.Attack(5, 10);
					it["attack roll should be higher"] = () => result.Success.should_be_true();
					it["AttackModifier should be 5"] = () => result.AttackModifier.should_be(5);
				};

				context["given Strength Value is 1"] = () =>
				{
					before = () => bob.Strength.Value = 1;
					act = () => result = bob.Attack(12, 10);
					it["attack roll should be lowered"] = () => bob.Attack(12, 10).Success.should_be_false();
					it["AttackModifier should be -5"] = () => result.AttackModifier.should_be(-5);
				};

				context["given Strength Value is 10"] = () =>
				{
					before = () => bob.Strength.Value = 10;
					it["attack roll should be unmodified"] = () => bob.Attack(10, 10).Success.should_be_true();
					it["AttackModifier should be zero"] = () => bob.Attack(10, 10).AttackModifier.should_be(0);
					it["attack roll should be unmodified"] = () => bob.Attack(9, 10).Success.should_be_false();
				};


				context["given attack is a CriticalHit"] = () =>
				{
					act = () => result = bob.Attack(20, 10);
					context["given Strength of 12"] = () =>
					{
						before = () => bob.Strength.Value = 12;
						it["AttackModifier should be 2"] = () => result.AttackModifier.should_be(2);
					};

					context["given Strength of 8"] = () =>
					{
						before = () => bob.Strength.Value = 8;
						it["AttackModifier should be -2"] = () => result.AttackModifier.should_be(-2);
					};

					context["given Strength of 10"] = () =>
					{
						before = () => bob.Strength.Value = 10;
						it["AttackModifier should be 0"] = () => result.AttackModifier.should_be(0);
					};
				};
			};

			context["when applying damage"] = () =>
			{
				context["given AttackModifier of 1"] = () =>
				{
					act = () => bob.ApplyDamage(new AttackResult { Success = true, AttackModifier = 1});
					it["success attack should do 2 damage"] = () => bob.HitPoints.should_be(3);
				};

				context["given AttackModifier of 0"] = () =>
				{
					act = () => bob.ApplyDamage(new AttackResult { Success = true, AttackModifier = 0 });
					it["success attack should do 1 damage"] = () => bob.HitPoints.should_be(4);
				};

				context["given AttackModifier of -1"] = () =>
				{
					act = () => bob.ApplyDamage(new AttackResult { Success = true, AttackModifier = -1 });
					it["success attack should do 1 damage"] = () => bob.HitPoints.should_be(4);
				};

				context["given AttackModifier of -5"] = () =>
				{
					act = () => bob.ApplyDamage(new AttackResult { Success = true, AttackModifier = -5 });
					it["success attack should do 1 damage"] = () => bob.HitPoints.should_be(4);
				};
			};

		}

		void when_Dexterity_modifier_applies()
		{
			context["given Dexterity Value is 20"] = () =>
			{
				before = () => bob.Dexterity.Value = 20;
				it["ArmorClass should be increased by 5"] = () => bob.ArmorClass.should_be(15);
			};

			context["given Dexterity Value is 1"] = () =>
			{
				before = () => bob.Dexterity.Value = 1;
				it["ArmorClass should be decreased by 5"] = () => bob.ArmorClass.should_be(5);
			};

			context["given Dexterity Value is 10"] = () =>
			{
				before = () => bob.Dexterity.Value = 10;
				it["ArmorClass should remain the same"] = () => bob.ArmorClass.should_be(10);
			};
		}
	}
}
