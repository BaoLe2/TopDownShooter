using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDespawn : MonoBehaviour
{
    public float timeDelay;
    private void OnEnable() {
        Invoke("DespawnObject", this.timeDelay);
    }

    protected virtual void DespawnObject(){
        this.gameObject.SetActive(false);
    }
}
