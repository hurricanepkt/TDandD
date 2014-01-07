using NSpec;

namespace TDandD
{
    class describe_CharacterConstitution : nspec
    {
        Character bob;
        private const int default_HitPoints = Character.DEFAULT_HITPOINTS;

        void before_each()
        {
            bob = new Character();
        }
        void when_Constitution_modifier_applies()
        {
            context["given Constitution Value is 20"] = () =>
            {
                before = () => bob.Constitution.Value = 20;
                it["HitPoints should be increased by 5"] = () => bob.HitPoints.should_be(default_HitPoints + 5);
            };

            context["given Constitution Value is 1"] = () =>
            {
                before = () => bob.Constitution.Value = 1;
                it["HitPoints should be decreased by 5"] = () => bob.HitPoints.should_be(default_HitPoints - 5);
            };

            context["given Constitution Value is 10"] = () =>
            {
                before = () => bob.Constitution.Value = 10;
                it["HitPoints should remain the same"] = () => bob.HitPoints.should_be(default_HitPoints);
            };
        }
    }
}