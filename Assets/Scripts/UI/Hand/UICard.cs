using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class UICard : UIElement
{
    [SerializeField] Text _title;
    [SerializeField] Text _effect;
    public bool HasTargetSelect => CardData.IsSelectableTareget(TargetType);
    public TargetType TargetType => _card.GetTarget();
    CardData _card;
    
    public void Setup(CardData c)
    {
        _card = c;

        _title.text = c.Name;
        _effect.text = c.GetEffectText();
    }
}
