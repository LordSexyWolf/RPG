using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private string idleLayer;
    [SerializeField] private string walkLayer;

    private Animator _animator;
    //reference to the another class
    private PlayerController _playerController;

    //StringHash
    private readonly int directionX = Animator.StringToHash(name:"x");
    private readonly int directionY = Animator.StringToHash(name:"y");
    private readonly int deadPlayer = Animator.StringToHash(name:"dead");
    
    private void Awake() 
    {
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLayers();

        if(_playerController.InMovement == false)
        {
            return;
        }
        _animator.SetFloat(directionX, _playerController.MovementDirection.x);
        _animator.SetFloat(directionY, _playerController.MovementDirection.y);
    }

    private void ActivateLayer(string nameLayer)
    {
        for (int i = 0; i < _animator.layerCount; i++)
        {
            //weight:0 -> desactive/instead same
            _animator.SetLayerWeight(i, weight:0);
        }

        _animator.SetLayerWeight(_animator.GetLayerIndex(nameLayer), weight:1);
    }

    private void UpdateLayers()
    {
        if(_playerController.InMovement)
        {
            ActivateLayer(walkLayer);
        }else{
            ActivateLayer(idleLayer);
        }
    }

    public void RestarPlayer()
    {
        ActivateLayer(idleLayer);
        _animator.SetBool(deadPlayer, value:false);
    }

    private void PlayerDeadCall()
    {
        if(_animator.GetLayerWeight(_animator.GetLayerIndex(idleLayer)) == 1)
        {
            _animator.SetBool(deadPlayer, value:true);
        }
    }

    private void OnEnable()
    {
        PlayerHp.EventPlayerDead += PlayerDeadCall;
    }

    private void OnDisable()
    {
        PlayerHp.EventPlayerDead -= PlayerDeadCall; 
    }
}
