using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform content;
    public Transform Content => content;

    [Header("Inv Ctrl")]
    //[SerializeField] protected Transform content;
    [SerializeField] protected UIInvItemSpawner uiInvItemSpanwer;
    public UIInvItemSpawner UIInvItemSpanwer => uiInvItemSpanwer;

    protected override void Start()
    {
        base.Start();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadUIInvItemSpanwer();
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.LogWarning(transform.name + ": LoadContent", gameObject);
    }

    protected virtual void LoadUIInvItemSpanwer()
    {
        if (this.uiInvItemSpanwer != null) return;
        this.uiInvItemSpanwer = GetComponentInChildren<UIInvItemSpawner>();
        Debug.LogWarning(transform.name + ": LoadUIInvItemSpanwer", gameObject);
    }
}
