using UnityEngine;

public class LvManager : MonoBehaviour 
{   
    [SerializeField] private Player player; 
    [SerializeField] private Transform startPoint;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(player.PlayerHp.PlayerDead)
            {
                player.transform.localPosition = startPoint.position;
                player.RestartPlayer(); 
            }
        }
    }
    

}