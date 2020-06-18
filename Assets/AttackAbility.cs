public class AttackAbility : Ability
{
    public override int APCost => 2;

    public override string Name => "Attack";

    public override int LevelLearned => 1;

    public override TargetTypes TargetType { get => TargetTypes.Enemy; set => base.TargetType = value; }
}