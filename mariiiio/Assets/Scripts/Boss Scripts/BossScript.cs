﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject stone;
    public Transform attackIns;
    private Animator anim;
    private string coroutine_Name="StartAttack";

        void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(coroutine_Name);
    }

    void Attck()
    {
        GameObject obj = Instantiate(stone, attackIns.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-300f, -700f), 0f));
    }
    void BlackToIdle()
    {
        anim.Play("Boss");
    }

    public void DeactiveateBossScript()
    {
        StopCoroutine(coroutine_Name);
        enabled=false;
    }



    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(Random.Range(2f,5f));
        anim.Play("BossAttack");
        StartCoroutine(coroutine_Name);
    }
}
