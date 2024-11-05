using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected string tagName = "Enemy";
    [SerializeField] protected GameObject[] allEnemies;
    
    public virtual void RotateGun(Transform enemyPos)
    {
        //if (this.DetectedEnemy() == null) return;
        Vector2 diff = enemyPos.position - transform.position;
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1.7f, -1.7f, 1.7f);
        }
        else
        {
            transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
        }
    }
}
