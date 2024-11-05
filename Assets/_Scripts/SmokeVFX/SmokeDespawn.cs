using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDespawn : Despawn
{
    [SerializeField] protected float timer;
    [SerializeField] protected float timeDelay;


    protected override bool CanDespawn()
    {
        this.timer += Time.deltaTime;
        if(this.timer < this.timeDelay) return false;
        this.timer = 0;
        return true;
    }
}
