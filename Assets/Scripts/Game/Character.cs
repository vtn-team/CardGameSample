using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum ForceType
{
    Friend,
    Opponent
}

class Character : MonoBehaviour
{
    [SerializeField] Text _hpText;
    [SerializeField] Text _atkText;
    [SerializeField] Text _forceText;

    protected ForceType _force;
    protected int _hp;
    protected int _maxHp;
    protected int _atk;
    protected int _baseAtk;

    public ForceType Force => _force;
    public int HP => _hp;
    public int MaxHP => _maxHp;
    public int ATK => _atk;

    protected void UpdateView()
    {
        _hpText.text = _hp.ToString();
        _atkText.text = _atk.ToString();
    }
}
