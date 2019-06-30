﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private Animator _sword;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _sword = transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Move(float move)
    {
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping)
    {
        _anim.SetBool("Jumping", jumping);
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
        _sword.SetTrigger("SwordAnimation");
    }
}
