using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : BaoMonoBehaviour
{
    [SerializeField] protected Animator anim;

    protected override void Awake()
    {
        this.anim = GetComponent<Animator>();
    }

    public void PlayerRunAnim(float x, float y)
    {
        this.anim.SetBool("Run", x != 0 || y != 0);
    }

    public void PlayerHitAnim()
    {
        this.anim.SetTrigger("Hit");
    }
}
