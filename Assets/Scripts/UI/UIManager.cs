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
    UIHand _startSelectUI;

    public void Setup()
    {
        TaskManager.Instance.Register(Update, this, 0);

        _startSelectUI = GameObject.Find("UI/Hand").GetComponent<UIHand>();
        StartMain();
    }

    public void StartMain()
    {
        _uiStack.Clear();
        _startSelectUI.StartSelect();
        _select = _startSelectUI;
    }

    void Cancel()
    {
        if (_uiStack.Count > 0)
        {
            _select.Term();
            _select = _uiStack.Pop();
            _select.StartSelect();
        }
    }

    int Update()
    {
        if (_select == null) return 0;

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
                    _select.Term();
                    _select = null;
                    GameManager.Instance.ExecuteCard();
                    break;

                case UIResultCode.NextUI:
                    {
                        var next = _select.GetNext();
                        _uiStack.Push(_select);
                        _select.Term();
                        next.StartSelect();
                        _select = next;
                    }
                    break;
            }
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("cancel");
            Cancel();
        }

        return 0;
    }
}
