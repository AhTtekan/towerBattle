﻿using System.Collections.Generic;
using UnityEngine;

public enum TargetTypes
{
    SelfOnly,
    Ally, //This includes self
    AllAllies,
    Enemy,
    AllEnemies
}

public static class TargetTypesExtensions
{
    public static IEnumerable<Unit> GetTargets(this TargetTypes targetType)
    {
        var characterManager = GameObject.FindObjectOfType<CharacterManager>();
        var battleManager = GameObject.FindObjectOfType<BattleManager>();
        var characterMovementController = GameObject.FindObjectOfType<CharacterMovementController>();

        switch (targetType)
        {
            case TargetTypes.SelfOnly:
                return new[]
                {
                    characterMovementController.SelectedCharacter
                };
            case TargetTypes.Ally:
                return characterManager.Characters;
            case TargetTypes.AllAllies:
                return new[]
                {
                    Unit.AllAllies()
                };
            case TargetTypes.Enemy:
                return battleManager.Encounter.Enemies;
            case TargetTypes.AllEnemies:
                return new[]
                {
                    Unit.AllEnemies()
                };
        }

        throw new System.Exception("Unable to find targets based on target type.");
    }
}
