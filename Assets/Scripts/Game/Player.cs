using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Player : Character
{
    public override void Setup()
    {
        _force = ForceType.Friend;
        _maxHp = _hp = 100;
        _baseAtk = _atk = 5;

        UpdateView();
    }
}
