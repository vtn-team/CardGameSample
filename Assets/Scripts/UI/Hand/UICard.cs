using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class UICard : UIElement
{
    [SerializeField] int _width;
    [SerializeField] Text _title;
    [SerializeField] Text _effect;
    public int Width => _width;
    public bool HasTargetSelect => CardData.IsSelectableTareget(TargetType);
    public TargetType TargetType => _card.GetTarget();
    CardData _card;
    Evaluator _eval = null;
    
    public void Setup(CardData c)
    {
        _card = c;
        _eval = _card.Evaluate();

        _title.text = c.Name;
        _effect.text = c.GetEffectText(_eval);
    }

    public bool CheckUse()
    {
        return _card.CheckUse();
    }
}
