using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class UIManager
{
    UISelectable _select = null;
    Stack<UISelectable> _uiStack = new Stack<UISelectable>();

    public void Setup()
    {
        TaskManager.Instance.Register(Update, this, 0);

        _select = GameObject.Find("UI/Hand").GetComponent<UIHand>();
        _uiStack.Push(_select);
    }

    void Cancel()
    {
        if (_uiStack.Count > 1)
        {
            _select.Term();
            _select = _uiStack.Pop();
        }
    }

    int Update()
    {
        if (Input.GetButtonDown("Next"))
        {
            _select.Select(+1);
        }
        if (Input.GetButtonDown("Prev"))
        {
            _select.Select(-1);
        }
        if (Input.GetButtonDown("Decide"))
        {
            UIResultCode result = _select.Decide();
            switch(result)
            {
                case UIResultCode.Cancel:
                    Cancel();
                    break;

                case UIResultCode.Execute:
                    break;

                case UIResultCode.NextUI:
                    _uiStack.Push(_select.GetNext());
                    break;
            }
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Cancel();
        }

        return 0;
    }
}
