using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : BaoMonoBehaviour
{
    protected PlayerCtrl playerCtrl;
    public Transform detectPoint;
    public float detectRange;
    public LayerMask enemyLayers;

    protected override void Awake()
    {
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }

    protected override void Update()
    {
        this.DetectedEnemy();
    }

    public void DetectedEnemy()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(this.detectPoint.position, this.detectRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies){
            if (EnemySpawner.Instance.isShoot == false) return;
            this.playerCtrl.gun.RotateGun(enemy.gameObject.transform);
            this.playerCtrl.playerShooting.Shooting();
        }
    }

    private void OnDrawGizmosSelected() {
        if(this.detectPoint == null)
        return;

        Gizmos.DrawWireSphere(this.detectPoint.position, this.detectRange);
    }
}
