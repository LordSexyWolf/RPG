using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{

    [SerializeField] private float initialMana;
    [SerializeField] private float maxMana;
    [SerializeField] private float manaRecover;

    public float CurrentMana { get; private set; }
    private PlayerHp _hpPlayer;


    private void Awake()
    {
        _hpPlayer = GetComponent<PlayerHp>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentMana = initialMana;
        UpdateMana();
        InvokeRepeating(nameof(ManaRecover), time:1, repeatRate:1);
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            WasteMana(amountMana:10);
        }    
    }

    public void WasteMana(float amountMana)
    {
        if(CurrentMana >= amountMana)
        {
            CurrentMana -= amountMana;
            UpdateMana(); 
        }
    }

    private void ManaRecover()
    {
        if (_hpPlayer.Hp > 0f && CurrentMana < maxMana)
        {
            CurrentMana += manaRecover;
            UpdateMana();
        }
    }

    public void FullMana()
    {
        CurrentMana = initialMana;
        UpdateMana();
    }
    
    private void UpdateMana()
    {
        UIManager.Instance.UpdateManaPlayer(CurrentMana, maxMana);
    }
}
