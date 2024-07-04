using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPauseGame : BaseButton
{
    protected override void OnClick()
    {
        UIManager.Instance.GoToPage(1);
    }
}
