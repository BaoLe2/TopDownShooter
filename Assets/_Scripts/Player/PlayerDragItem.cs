using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragItem : BaoMonoBehaviour
{
    public Transform mainCamera;
    public PlayerCtrl playerCtrl;
    public AudioClip coinSound;
    public AudioClip healthPotionSound;

    protected override void Awake()
    {
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Coin"))
        {
            int randomCoin = Random.Range(3, 7);
            GameCtrl.Instance.itemManager.dragCoin(randomCoin);
            GameCtrl.Instance.itemManager.UpdateCoinDisplay(GameCtrl.Instance.itemManager.coin);
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(this.coinSound, this.mainCamera.position, 1.0f);
        }

        if (other.CompareTag("Diamond"))
        {
            int randomDiamon = Random.Range(10, 21);
            GameCtrl.Instance.itemManager.dragDiamond(randomDiamon);
            GameCtrl.Instance.itemManager.UpdateCoinDisplay(GameCtrl.Instance.itemManager.coin);
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(this.coinSound, this.mainCamera.position, 1.0f);
        }

        if (other.CompareTag("Potion"))
        {
            this.playerCtrl.playerStatus.health += 10;
            GameCtrl.Instance.itemManager.coin += 5;
            GameCtrl.Instance.itemManager.UpdateCoinDisplay(GameCtrl.Instance.itemManager.coin);

            if (this.playerCtrl.playerStatus.health > this.playerCtrl.playerStatus.healthMax)
            this.playerCtrl.playerStatus.health = this.playerCtrl.playerStatus.healthMax;
            
            this.playerCtrl.playerStatus.UpdateHealthBar();
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(this.healthPotionSound, this.mainCamera.position, 1.0f);
        }
    }
}
