using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _playerBullet;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
       
       
    }

    // define variable animator for the player movement
    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    // define variable animator for the player jump
    public void Jump(bool jumping)
    {
        _anim.SetBool("Jumping", jumping);
    }
    // define variable animator for the player attack
    public void Attack()
    {
        _anim.SetTrigger("Shoot");
      
    }
}
