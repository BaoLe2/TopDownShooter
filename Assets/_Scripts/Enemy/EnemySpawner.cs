using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : BaoMonoBehaviour
{
    public Timer timer;
    protected static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }
    [SerializeField] protected GameObject enemyPrefab;
    [SerializeField] protected float enemyTimer;
    public float enemyTimeDelay = 3f;
    [SerializeField] protected Transform[] positionRan;
    [SerializeField] protected Transform holder;

    [SerializeField] public bool isShoot = false;
    public int count;

    protected override void Awake()
    {
        if (EnemySpawner.instance != null) Debug.LogError("Only 1 EnemySpawner");
        EnemySpawner.instance = this;
    }

    protected override void Update()
    {
        if(this.enemyTimeDelay <= 0.5f){
            this.enemyTimeDelay = 0.5f;
        }
        this.Spawning();
    }

    protected virtual void Spawning()
    {
        if(GameManager.Instance.startGame == false) return;
        enemyTimer += Time.deltaTime;
        if (enemyTimer < enemyTimeDelay) return;
        this.SpawnEnemy();
        this.isShoot = true;
        enemyTimer = 0;
    }

    protected virtual void SpawnEnemy()
    {
        if(GameManager.Instance.Win) return;
        if(GameManager.Instance.GameOver) return;
        if(GameCtrl.Instance.levelSystem.canDestroyEnemy) return;
        if(count >= 500) return;
        this.count += 1;
        GameObject newEnemy = Instantiate(this.enemyPrefab);
        newEnemy.SetActive(true);
        newEnemy.name = this.enemyPrefab.name;
        newEnemy.transform.parent = this.holder;
        int randomPos = Random.Range(0, 4);
        newEnemy.transform.position = this.positionRan[randomPos].position;
    }
}
