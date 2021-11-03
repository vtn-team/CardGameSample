using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIElement : MonoBehaviour
{
    public bool IsActive { get; protected set; }
    public RectTransform RectTransform { get; protected set; }
    protected CanvasGroup _canvasGroup = null;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        AwakeCall();
    }

    protected virtual void AwakeCall()
    {

    }

    public virtual void Active()
    {
        _canvasGroup.alpha = 1.0f;
        IsActive = true;
    }

    public virtual void Disactive()
    {
        _canvasGroup.alpha = 0.0f;
        IsActive = false;
    }
}
