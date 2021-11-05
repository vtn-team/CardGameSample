using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlayerController
{
    int _mana = 99; //tbd
    List<CardData> _hand = new List<CardData>();

    public List<CardData> Hand => _hand;
    public int Mana => _mana;

    public void Setup(List<CardData> hand)
    {
        _hand = hand;
    }

    public void Draw()
    {
        //tbd
    }

    public void Discard()
    {
        //tbd
    }
}
