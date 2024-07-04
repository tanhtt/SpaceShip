using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPage : SaiMonoBehaviour
{
    [Tooltip("The default UI seleceted when opening this page")]
    [SerializeField] GameObject defaultSelected;

    // Sets the currently selected UI to the one defaulted by this UIPage
    public void SetSelectedUIDefault()
    {
        if(GameManager.Instance != null && UIManager.Instance != null && defaultSelected != null)
        {
            GameManager.Instance.uiManager.eventSystem.SetSelectedGameObject(null);
            GameManager.Instance.uiManager.eventSystem.SetSelectedGameObject(defaultSelected);
        }
    }
}
