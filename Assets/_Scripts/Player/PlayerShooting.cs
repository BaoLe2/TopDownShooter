using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : BaoMonoBehaviour
{
    public float shootTimer;
    public float shootDelay = 3;
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected Transform gunRotation;
    [SerializeField] protected Transform smokePoint;
    [SerializeField] protected AudioClip shootSound;
    [SerializeField] protected Transform mainCamera;

    protected override void Start()
    {
        this.shootTimer = this.shootDelay;
    }

    public virtual void Shooting()
    {
        this.shootTimer += Time.deltaTime;
        if(this.shootTimer < this.shootDelay) return;

        AudioSource.PlayClipAtPoint(this.shootSound, this.mainCamera.position, 1.0f);

        GameObject newBullet = BulletPool.Instance.GetPooledObject();
        GameObject newSmoke = SmokePool.Instance.GetPooledObject();

        newBullet.transform.position = this.firePoint.position;
        newBullet.transform.rotation = this.gunRotation.rotation;
        newBullet.SetActive(true);

        newSmoke.transform.position = this.smokePoint.position;
        newSmoke.transform.rotation = this.gunRotation.rotation;
        newSmoke.SetActive(true);

        this.shootTimer = 0;
    }
}
