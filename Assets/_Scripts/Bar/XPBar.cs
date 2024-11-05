using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : BaoMonoBehaviour
{
    public AudioClip levelUpSound;
    public Transform mainCamera;
    [SerializeField] protected Image xpBar;
    [SerializeField] protected Text xpText;
    public int level = 0;

    protected override void Update()
    {
        this.xpBar.fillAmount = GameCtrl.Instance.playerCtrl.playerStatus.xp / GameCtrl.Instance.playerCtrl.playerStatus.xpMax;
        this.UpdateXP();
    }

    public void UpdateXP()
    {
        if (this.level == 30)
        {
            GameCtrl.Instance.playerCtrl.playerStatus.xp =
            GameCtrl.Instance.playerCtrl.playerStatus.xpMax;
            return;
        }
        else
        {
            if (GameCtrl.Instance.playerCtrl.playerStatus.xp / GameCtrl.Instance.playerCtrl.playerStatus.xpMax >= 1)
            {
                GameCtrl.Instance.playerCtrl.playerStatus.healthMax += 20;
                GameCtrl.Instance.playerCtrl.playerStatus.health = GameCtrl.Instance.playerCtrl.playerStatus.healthMax;
                GameCtrl.Instance.playerCtrl.playerStatus.UpdateHealthBar();
                GameCtrl.Instance.playerCtrl.playerStatus.xpMax *= 2;
                GameCtrl.Instance.playerCtrl.playerStatus.xp = 0;
                this.level += 1;
                AudioSource.PlayClipAtPoint(this.levelUpSound, this.mainCamera.position, 1.0f);
                this.xpText.text = "Level" + this.level;
            }
        }

    }
}
