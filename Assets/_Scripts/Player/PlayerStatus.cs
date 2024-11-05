using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatus : BaoMonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] public float healthMax = 100;
    public float xp;
    public float xpMax = 10;
    public float speed = 1;
    public HealthBar healthBar;

    protected override void Update()
    {
        if(this.health <= 0) this.health = 0;
        this.IsDead();
    }

    protected override void Awake()
    {
        this.health = this.healthMax;
    }

    public void DamageReceive(int damage)
    {
        this.health -= damage;
    }

    public void UpdateHealthBar()
    {
        this.healthBar.UpdateHealth(this.health, this.healthMax);
    }

    protected virtual void IsDead()
    {
        if (this.health > 0) return;
        GameManager.Instance.GameOver = true;
        GameManager.Instance.gameOver2 = true;
    }
}
