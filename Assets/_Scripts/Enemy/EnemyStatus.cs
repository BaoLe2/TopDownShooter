using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : BaoMonoBehaviour
{
    public float speed;
    public float health;
    public float xp;
    public float damage;
    public GameObject[] items;
    private AudioSource audioSource;
    public AudioClip enemyDeadSound;
    public Transform mainCamera;
    public EnemyCtrl enemyCtrl;

    protected override void Awake()
    {
        this.enemyCtrl = GetComponentInParent<EnemyCtrl>();
    }

    protected override void Update()
    {
        if (this.speed >= 6) this.speed = 6;
        this.Deading();
    }

    public virtual void DamageReceive()
    {
        this.health -= damage;
    }

    protected virtual void Deading()
    {
        if(!this.IsDead()) return;
        this.Dead();
    }

    protected virtual bool IsDead()
    {
        if (this.health <= 0 || GameCtrl.Instance.levelSystem.canDestroyEnemy) return true;
        return false;
    }

    protected virtual void Dead()
    {
        this.enemyCtrl.enemyAnim.EnemyDead();
        GameCtrl.Instance.playerCtrl.playerStatus.xp += this.xp;
        Instantiate(this.items[Random.Range(0, 3)], transform.position, Quaternion.identity);
        Destroy(this.transform.parent.gameObject);
        AudioSource.PlayClipAtPoint(this.enemyDeadSound, this.mainCamera.transform.position, 1.0f);
    }
}
