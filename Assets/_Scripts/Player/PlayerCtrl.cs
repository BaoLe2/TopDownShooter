using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : BaoMonoBehaviour
{
    public Player player;
    public PlayerShooting playerShooting;
    public PlayerStatus playerStatus;
    public PlayerAnim playerAnim;
    public Gun gun;

    protected override void Awake()
    {
        this.player = GetComponent<Player>();
        this.playerShooting = GetComponentInChildren<PlayerShooting>();
        this.playerStatus = GetComponentInChildren<PlayerStatus>();
        this.playerAnim = GetComponentInChildren<PlayerAnim>();
        this.gun = GetComponentInChildren<Gun>();
    }
}
