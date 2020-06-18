public class DefendAbility : Ability
{
    public override int APCost => 2;

    public override string Name => "Defend";

    public override int LevelLearned => 1;

    public override TargetTypes TargetType { get => TargetTypes.SelfOnly; set => base.TargetType = value; }
}