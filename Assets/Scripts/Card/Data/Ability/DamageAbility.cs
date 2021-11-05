using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class DamageAbility : IAbility
{
    [SerializeField] int _damage;

    public int Value => _damage;
    public AbilityType AbilityType => AbilityType.Damage;

    public void Evaluate(Evaluator eval)
    {
        eval.Stack(this);
    }

    public void Execute()
    {
        //なし
    }
}
