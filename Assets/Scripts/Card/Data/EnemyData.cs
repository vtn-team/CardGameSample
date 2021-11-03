using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    [SerializeField] string _id;
    [SerializeField] string _name;
    [SerializeField] int _hp;
    [SerializeField] int _atk;

    public int HP => _hp;
    public int Atk => _atk;
}

