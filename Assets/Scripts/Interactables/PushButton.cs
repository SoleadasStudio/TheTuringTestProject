using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour
{
    [SerializeField] private Material defaultColor;
    [SerializeField] private Material hoverColor;
    [SerializeField] private MeshRenderer _renderer;

    public UnityEvent onButtonPush;

    public void OnHoverEnter()
    {
        _renderer.material = hoverColor;
    }
    public void OnHoverExit()
    {
        _renderer.material = defaultColor;
    }
    public void OnSelect()
    {
        onButtonPush?.Invoke();
    }
}
