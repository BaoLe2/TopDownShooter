using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uppgrades : BaoMonoBehaviour
{
    public Transform mainCamera;
    public AudioClip uppgradeSound;
    public UppgradeUI uppgradeUI;
    public int coinBuySpeed;
    public int coinBuyShootSpeed;
    public int coinBuyDamage;

    protected override void Awake()
    {
        this.coinBuySpeed = 10;
        this.coinBuyShootSpeed = 10;
        this.coinBuyDamage = 10;
    }

    public void DamageIncrement(float value)
    {
        if (GameCtrl.Instance.enemyCtrl.enemyStatus.damage >= 5f)
        {
            GameCtrl.Instance.enemyCtrl.enemyStatus.damage = 5f;
            return;
        }

        if (GameCtrl.Instance.itemManager.coin < this.coinBuyDamage) return;
        //Đủ tiền mua, trừ tiền và nâng cấp
        GameCtrl.Instance.itemManager.coin -= this.coinBuyDamage;
        GameCtrl.Instance.enemyCtrl.enemyStatus.damage += value;
        //Cập nhật lại giá nâng cấp
        this.coinBuyDamage *= 2;
        this.uppgradeUI.UpdateCoinBuyDamage(this.coinBuyDamage);
        //Cập nhật lại số tiền còn lại
        GameCtrl.Instance.itemManager.UpdateCoinDisplay(GameCtrl.Instance.itemManager.coin);
        AudioSource.PlayClipAtPoint(this.uppgradeSound, this.mainCamera.position, 0.1f);
    }

    public void ShootSpeedIncrement(float value)
    {
        if (GameCtrl.Instance.playerCtrl.playerShooting.shootDelay <= 0.1f)
        {
            GameCtrl.Instance.playerCtrl.playerShooting.shootDelay = 0.1f;
            return;
        }

        if (GameCtrl.Instance.itemManager.coin < this.coinBuyShootSpeed) return;
        //Đủ tiền mua, nâng cấp và trừ tiền
        GameCtrl.Instance.itemManager.coin -= this.coinBuyShootSpeed;
        GameCtrl.Instance.playerCtrl.playerShooting.shootDelay -= value;
        //Cập nhật lại giá nâng cấp
        this.coinBuyShootSpeed *= 2;
        this.uppgradeUI.UpdateCoinBuyShootSpeed(this.coinBuyShootSpeed);
        //Cập nhật số tiền còn lại
        GameCtrl.Instance.itemManager.UpdateCoinDisplay(GameCtrl.Instance.itemManager.coin);
        AudioSource.PlayClipAtPoint(this.uppgradeSound, this.mainCamera.position, 0.1f);
    }

    public void SpeedIncrement(float value)
    {
        if (GameCtrl.Instance.playerCtrl.playerStatus.speed >= 7f)
        {
            GameCtrl.Instance.playerCtrl.playerStatus.speed = 7f;
            return;
        }

        if (GameCtrl.Instance.itemManager.coin < this.coinBuySpeed) return;
        //Đủ tiền mua, trừ tiền và nâng cấp
        GameCtrl.Instance.itemManager.coin -= this.coinBuySpeed;
        GameCtrl.Instance.playerCtrl.playerStatus.speed += value;
        //Cập nhật lại giá nâng cấp
        this.coinBuySpeed *= 2;
        this.uppgradeUI.UpdateCoinBuySpeed(this.coinBuySpeed);
        //Cập nhật lại số tiền còn lại
        GameCtrl.Instance.itemManager.UpdateCoinDisplay(GameCtrl.Instance.itemManager.coin);
        AudioSource.PlayClipAtPoint(this.uppgradeSound, this.mainCamera.position, 0.1f);
    }
}
