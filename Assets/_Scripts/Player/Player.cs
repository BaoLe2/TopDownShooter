using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : BaoMonoBehaviour
{
    //GetComponent
    private Rigidbody2D rb;
    private Animator ani;
    private SpriteRenderer sprite;
    public PlayerCtrl playerCtrl;
    //Audio
    public Transform mainCamera;
    private AudioSource audioSource;
    public AudioClip gunSound;
    public AudioClip playerHitSound;
    protected bool isDamage;
    public int damage;
    public int damageEnd;
    public Joystick joystick;

    protected override void Awake()
    {
        this.playerCtrl = GetComponent<PlayerCtrl>();
    }

    protected override void Start()
    {
        this.isDamage = true;
        this.damage = 10;
        this.damageEnd = 12;
        this.rb = GetComponent<Rigidbody2D>();
        this.sprite = GetComponentInChildren<SpriteRenderer>();
        this.audioSource = GetComponent<AudioSource>();
        this.playerCtrl.playerStatus.UpdateHealthBar();
    }

    protected override void Update()
    {
        //this.Moving();
        this.JoystickMoving();
    }

    protected virtual void Moving()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        this.rb.velocity = new Vector2(horizontal, vertical) * this.playerCtrl.playerStatus.speed;
        this.Flip(horizontal);
        this.playerCtrl.playerAnim.PlayerRunAnim(horizontal, vertical);
    }

    protected virtual void JoystickMoving()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;

        this.rb.velocity = new Vector2(horizontal, vertical) * this.playerCtrl.playerStatus.speed;
        this.Flip(horizontal);
        this.playerCtrl.playerAnim.PlayerRunAnim(horizontal, vertical);
    }

    protected virtual void Flip(float horizontal)
    {
        if (horizontal < 0)
        {
            this.sprite.flipX = true;
        }
        else if (horizontal > 0)
        {
            this.sprite.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if(this.isDamage) 
            {
                this.damage = Random.Range(10, this.damageEnd);
                this.isDamage = false;
                this.playerCtrl.playerStatus.DamageReceive(damage);
                this.playerCtrl.playerStatus.UpdateHealthBar(); ;
                this.playerCtrl.playerAnim.PlayerHitAnim();
                AudioSource.PlayClipAtPoint(this.playerHitSound, this.mainCamera.position, 1.0f);
                StartCoroutine(ReceiveDamageRoutine());
            }
            
        }
    }

    IEnumerator ReceiveDamageRoutine(){
        yield return new WaitForSeconds(1.2f);
        this.isDamage = true;
    }
}
