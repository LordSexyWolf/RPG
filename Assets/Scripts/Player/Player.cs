using UnityEngine;


public class Player : MonoBehaviour
{
    public PlayerHp PlayerHp { get; private set; }
    public PlayerAnimations PlayerAnimations { get; private set; }
    public PlayerMana PlayerMana { get; private set; }

    private void Awake() 
    {
        PlayerHp = GetComponent<PlayerHp>();
        PlayerAnimations = GetComponent<PlayerAnimations>();
        PlayerMana = GetComponent<PlayerMana>();
    }

    public void RestartPlayer()
    {
        PlayerHp.RestartPlayer();
        PlayerAnimations.RestarPlayer();
        PlayerMana.FullMana();
    }
}