using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : BaoMonoBehaviour
{
    protected int levelUp = 1;
    public Text levelUpText;
    public bool canDestroyEnemy;

    protected override void Update()
    {
        if (GameCtrl.Instance.timer.remainingTime <= 0)
        {
            GameCtrl.Instance.timer.remainingTime = 90;
            this.levelUp += 1;
            this.canDestroyEnemy = true;
            GameCtrl.Instance.enemySpawner.count = 0;
            StartCoroutine(CanDestroyEnemyCouroutine());
            switch (levelUp)
            {
                case 1:
                    this.levelUpText.text = "Level " + this.levelUp;
                    this.levelUpText.gameObject.SetActive(true);
                    break;
                case 2:
                    this.levelUpText.text = "Level " + this.levelUp;
                    this.levelUpText.gameObject.SetActive(true);
                    GameCtrl.Instance.playerCtrl.player.damageEnd = 20;
                    GameCtrl.Instance.enemyCtrl.enemyStatus.health += 10;
                    GameCtrl.Instance.enemyCtrl.enemyStatus.speed += 0.2f;
                    GameCtrl.Instance.enemySpawner.enemyTimeDelay -= 0.8f;
                    break;
                case 3:
                    this.levelUpText.text = "Level " + this.levelUp;
                    this.levelUpText.gameObject.SetActive(true);
                    GameCtrl.Instance.playerCtrl.player.damageEnd = 30;
                    GameCtrl.Instance.enemyCtrl.enemyStatus.health += 10;
                    GameCtrl.Instance.enemyCtrl.enemyStatus.speed += 0.3f;
                    GameCtrl.Instance.enemySpawner.enemyTimeDelay -= 1f;
                    break;
                case 4:
                    this.levelUpText.text = "Level " + this.levelUp;
                    this.levelUpText.gameObject.SetActive(true);
                    GameCtrl.Instance.playerCtrl.player.damageEnd = 40;
                    GameCtrl.Instance.enemyCtrl.enemyStatus.health += 10;
                    GameCtrl.Instance.enemyCtrl.enemyStatus.speed += 0.2f;
                    GameCtrl.Instance.enemySpawner.enemyTimeDelay -= 1f;
                    break;
                case 5:
                    this.levelUpText.text = "Level " + this.levelUp;
                    this.levelUpText.gameObject.SetActive(true);
                    GameCtrl.Instance.playerCtrl.player.damageEnd = 50;
                    GameCtrl.Instance.enemyCtrl.enemyStatus.health += 8;
                    GameCtrl.Instance.enemyCtrl.enemyStatus.speed += 0.5f;
                    GameCtrl.Instance.enemySpawner.enemyTimeDelay -= 0.4f;
                    break;
                case 7:
                    GameManager.Instance.Win = true;
                    GameCtrl.Instance.timer.DestroyObject();
                    break;
            }
        }
    }

    IEnumerator CanDestroyEnemyCouroutine()
    {
        yield return new WaitForSeconds(5f);
        this.canDestroyEnemy = false;
    }
}
