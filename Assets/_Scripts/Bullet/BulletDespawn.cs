using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : Despawn
{
    [SerializeField] protected float distance;
    [SerializeField] protected float distanceLimit = 30f;
    [SerializeField] public Transform mainCamera;

    protected override void Awake()
    {
        this.mainCamera = GameObject.Find("Main Camera").GetComponent<Transform>();
    }
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, this.mainCamera.position);
        if (this.distance >= this.distanceLimit) return true;
        return false;
    }
}
