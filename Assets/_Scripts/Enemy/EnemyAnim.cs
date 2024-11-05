using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : BaoMonoBehaviour
{
    [SerializeField] protected Animator anim;

    protected override void Awake()
    {
        this.anim = GetComponent<Animator>();
    }

    public void EnemyDead()
    {
        this.anim.SetBool("Dead", true);
    }
}
