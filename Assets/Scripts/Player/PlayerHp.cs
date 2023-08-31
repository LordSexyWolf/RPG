using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHp : HpBase
{

    public static Action EventPlayerDead;

    public bool CanBeHealed => Hp < maxHp;

    //propety -> propTAB
    public bool PlayerDead { get; private set; }

    private BoxCollider2D _boxCollider2D;
    
    private void Awake() 
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    protected override void Start()
    {
        base.Start();
        UpdateHp(currentHp:Hp, maxHp);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            DmgHp(amount:10);
        }
        
        if(Input.GetKeyDown(KeyCode.Y))
        {
            HealHp(amount:10);
        }
    }

    public void HealHp(float amount)
    {
        if(PlayerDead)
        {
            return;
        }

        if(CanBeHealed)
        {
            Hp += amount;
            if(Hp > maxHp)
            {
                Hp = maxHp;
            }
            UpdateHp(currentHp:Hp, maxHp);
        }
    }

    protected override void DeadHp()
    {
        _boxCollider2D.enabled = false;
        PlayerDead = true;
        EventPlayerDead?.Invoke();
        /*
        if(EventPlayerDead != null)
        {
            EventPlayerDead.Invoke();
        }*/
    }

    public void RestartPlayer()
    {
        _boxCollider2D.enabled = true;
        PlayerDead = false;
        Hp = initialHp;
        UpdateHp(currentHp:Hp, initialHp);
    }

    protected override void UpdateHp(float currentHp, float maxHp)
    {
        UIManager.Instance.UpdateHp(currentHp, maxHp);
    }
}