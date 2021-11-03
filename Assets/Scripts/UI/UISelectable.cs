using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class UISelectable : UIElement
{
    protected List<UIElement> _elements;
    protected int _selectIndex;


    public abstract void StartSelect();

    public abstract void Select(int select);
    
    public abstract UIResultCode Decide();

    public abstract UISelectable GetNext();

    public abstract void Term();
}
