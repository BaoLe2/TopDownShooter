using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : BaoMonoBehaviour
{
    

    protected override void Update()
    {
        this.Despawning();
    }

    protected virtual void Despawning(){
        if(!this.CanDespawn()) return;
        this.DespawnObject();
    }

    protected virtual void DespawnObject(){
        transform.parent.gameObject.SetActive(false);
    }

    protected abstract bool CanDespawn();
}
