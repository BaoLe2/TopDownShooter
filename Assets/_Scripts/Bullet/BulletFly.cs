using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Vector3 direction = Vector3.right;
    
    void Update()
    {
        transform.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
