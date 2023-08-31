using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBase : MonoBehaviour
{
    [SerializeField] protected float initialHp;
    [SerializeField] protected float maxHp;
    
    //Modify value in the same class
    public float Hp { get; protected set; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Hp = initialHp;
    }

    public void DmgHp(float amount)
    {
        if(amount <= 0)
        {
            return;
        }
        if(Hp > 0)
        {
            Hp -= amount;
            UpdateHp(currentHp:Hp, maxHp);
            if(Hp <= 0f)
            {
                UpdateHp(currentHp:Hp, maxHp);
                DeadHp();
            }
        }
    }
    //override class
    protected virtual void UpdateHp(float currentHp, float maxHp)
    {

    }

    protected virtual void DeadHp()
    {
        
    }
}
