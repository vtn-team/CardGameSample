using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class Enemy : Character
{
    [SerializeField] EnemyData _data;
    
    public override void Setup()
    {
        _force = ForceType.Opponent;
        _maxHp = _hp = _data.HP;
        _baseAtk = _atk = _data.Atk;

        UpdateView();
    }
}
