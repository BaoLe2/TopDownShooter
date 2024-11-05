using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : BaoMonoBehaviour
{
    protected static GameCtrl instance;
    public static GameCtrl Instance { get => instance; }
    public PlayerCtrl playerCtrl;
    public EnemyCtrl enemyCtrl;
    public EnemySpawner enemySpawner;
    public ItemManager itemManager;
    public LevelSystem levelSystem;
    public Timer timer;

    protected override void Awake()
    {
        if(GameCtrl.instance != null) Debug.LogError("Only 1 GameCotroller");
        GameCtrl.instance = this;
    }
}
