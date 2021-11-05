using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Game/CardData", order = 1)]
public class CardData : ScriptableObject
{
    [SerializeField] string _id;
    [SerializeField] string _name;
    [SerializeField] int _cost;
    [SerializeField] string _effectText;

    [SerializeField, SerializeReference, SubclassSelector]
    List<ICondition> _useCondition = new List<ICondition>();

    [SerializeField]
    List<CardEffect> _effects = new List<CardEffect>();

    public string Name => _name;
    public int Cost => _cost;

    public bool CheckUse()
    {
        if (GameManager.Player.Mana < _cost) return false; 

        return _useCondition.All(c => c.Check(null));
    }

    public Evaluator Evaluate()
    {
        Evaluator eval = new Evaluator();
        _effects.ForEach(e => e.Evaluate(eval));
        return eval;
    }

    public void Execute(Evaluator eval)
    {

    }

    static public bool IsSelectableTareget(TargetType type)
    {
        switch(type)
        {
            case TargetType.All:
            case TargetType.AllFriends:
            case TargetType.AllOpponents:
            case TargetType.None:
            case TargetType.RandomOne:
            default:
                return false;

            case TargetType.SelectFriend:
            case TargetType.SelectOne:
            case TargetType.SelectOpponent:
                return true;
        }
    }

    //処理を簡潔にするため、複数の選択処理があってはならない(仕様)
    public TargetType GetTarget()
    {
        TargetType ret = TargetType.None;
        _effects.ForEach(e =>
        {
            if(IsSelectableTareget(ret) && IsSelectableTareget(e.TargetType))
            {
                //invalid case
            }

            if (!IsSelectableTareget(ret))
            {
                ret = e.TargetType;
            }
        });
        return ret;
    }

    public string GetEffectText(Evaluator eval)
    {
        string text = _effectText;
        var matches = Regex.Matches(_effectText, "{%efval_([0-9])}");
        foreach (Match m in matches)
        {
            int index = int.Parse(m.Groups[1].Value);
            text = text.Replace(m.Value, _effects[index].Value.ToString());
        }

        return text;
    }
}
