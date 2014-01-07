﻿using System;
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
			it["when roll is less than opponents ArmorClass"] = () => bob.Attack(5, 10).should_be_false();
			it["when roll is more than opponents ArmorClass"] = () => bob.Attack(15, 10).should_be_true();
			it["when roll is the same as than opponents ArmorClass"] = () => bob.Attack(10, 10).should_be_true();

		}

		void when_an_opponent_attacks()
		{
			context["if attack is successful"] = () =>
			{
				Character jim = new Character();
				act = () => jim.DefendAttack(15);
				it["then character takes 1 point of damage"] = () => jim.HitPoints.should_be(5);
				it["then character takes 1 point of damage"] = () => jim.HitPoints.should_be(3);
			};

			context["if attack is a critical hit"] = () =>
			{
				Character jim = new Character();
				act = () => jim.DefendAttack(20);
				it["then character takes 2 point of damage"] = () => jim.HitPoints.should_be(3);
				it["then character takes 2 point of damage"] = () => jim.HitPoints.should_be(1);
			};

			context["if attack is not successful"] = () =>
			{
				act = () => bob.DefendAttack(5);
				it["then character does not take damage"] = () => bob.HitPoints.should_be(5); 
			};

			context["given a character is near death"] = () =>
			{
				Character jim = new Character();
				before = () => jim.HitPoints = 1;

				context["when HitPoints are above zero"] = () =>
				{
					before = () => jim.HitPoints = 3;

					act = () => jim.DefendAttack(15);
					it["then character is alive"] = () => jim.IsAlive.should_be_true();
				};

				context["when HitPoints fall to zero"] = () =>
				{
					act = () => jim.DefendAttack(15);
					it["then character is dead"] = () => jim.IsAlive.should_be_false();
				};

				context["when HitPoints fall below zero"] = () =>
				{
					act = () => jim.DefendAttack(20);
					it["then character is dead"] = () => jim.IsAlive.should_be_false();
				};

			};


		}




	}
}
