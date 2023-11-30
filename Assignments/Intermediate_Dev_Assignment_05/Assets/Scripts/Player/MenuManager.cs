using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private static MenuManager _instance;
    public static MenuManager Instance => _instance;

    public delegate void MenuEvent();
    public event MenuEvent OnMenuOpen;
    public event MenuEvent OnMenuClosed;

    private void Awake()
    {
        _instance = this;
    }

    private void TriggerMenuOpenEvent() => OnMenuOpen?.Invoke();
    private void TriggerMenuClosedEvent() => OnMenuClosed?.Invoke();
}
