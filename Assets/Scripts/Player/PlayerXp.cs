using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    [SerializeField] private int maxLv;
    [SerializeField] private int baseXp;
    [SerializeField] private int increaseValue;
    
    public int Lv { get; set; }

    private float currentTempXp;
    private float requiredXpLv;
    
    // Start is called before the first frame update
    void Start()
    {
        Lv = 1;
        requiredXpLv = baseXp;
        UpdateXpBar();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddXp(xp:2f);
        }
    }

    public void AddXp(float xp)
    {
        if (xp > 0f) //kill one -> 10xp
        {
            float restXpLv = requiredXpLv - currentTempXp; // 2 - 0 = 2
            if (xp >= restXpLv) // 10 >= 2
            {
                xp -= restXpLv; // 10 - 2 = 8
                UpdateLv();
                AddXp(xp);
            }
            else
            {
                currentTempXp += xp;
                if (currentTempXp == requiredXpLv)
                {
                    UpdateLv();
                }
            }
        }
        UpdateXpBar();
    }

    private void UpdateLv()
    {
        if (Lv < maxLv)
        {
            Lv++; //upLv
            currentTempXp = 0;
            requiredXpLv *= increaseValue; // 2 * 2 -> restXpLv
        }
    }

    private void UpdateXpBar()
    {
        UIManager.Instance.UpdateXpPlayer(currentTempXp, requiredXpLv);
    }
}
