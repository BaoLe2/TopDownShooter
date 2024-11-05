using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : BaoMonoBehaviour
{
    public int coin;
    public int diamond;

    public Text coinText;

    protected override void Awake()
    {
        UpdateCoinDisplay(20);
    }

    protected override void Update()
    {
        if(this.coin <= 0) this.coin = 0;
    }

    public void dragCoin(int coin){
        this.coin += coin;
    }

    public void dragDiamond(int diamond)
    {
        this.coin += diamond;
        this.diamond += diamond;
    }

    public void UpdateCoinDisplay(int coin)
    {
        this.coinText.text = "x " + coin;
    }
}
