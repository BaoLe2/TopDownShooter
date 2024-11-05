using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : BaoMonoBehaviour
{
    public EnemyAnim enemyAnim;
    public EnemyStatus enemyStatus;

    protected override void Awake()
    {
        this.enemyAnim = GetComponentInChildren<EnemyAnim>();
        this.enemyStatus = GetComponentInChildren<EnemyStatus>();
    }
}
