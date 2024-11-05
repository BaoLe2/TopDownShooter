using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaoMonoBehaviour
{
    //Component
    public Transform playerPos;
    public EnemyCtrl enemyCtrl;
    public Transform bloodParticle;
    
    protected override void Awake()
    {
        this.enemyCtrl = GetComponent<EnemyCtrl>();
    }

    protected override void Update()
    {
        if(GameManager.Instance.GameOver) return;
        this.Moving();
        this.Flip();
    }

    protected virtual void Moving()
    {
        transform.position = Vector3.MoveTowards(transform.position,
        this.playerPos.position, this.enemyCtrl.enemyStatus.speed * Time.deltaTime);
    }

    protected virtual void Flip()
    {
        Vector2 diff = this.playerPos.position - transform.position;
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
        transform.rotation = rotation;

        if (transform.eulerAngles.y > 90 && transform.eulerAngles.y < 270)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            this.enemyCtrl.enemyStatus.DamageReceive();
            GameObject bloodhit = Instantiate(this.bloodParticle.gameObject, transform.position, Quaternion.identity);
            other.gameObject.SetActive(false);
        }
    }
}
