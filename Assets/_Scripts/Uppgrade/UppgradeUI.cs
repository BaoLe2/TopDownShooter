using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UppgradeUI : BaoMonoBehaviour
{
    public GameObject uppgradePanel;
    public GameObject speedButton;
    public GameObject shootSpeedButton;
    public GameObject openUppgradeButton;
    public Text coinBuySpeed;
    public Text coinBuyShootSpeed;
    public Text coinBuyDamage;
    
    public void OpenUppgrade(){
        uppgradePanel.SetActive(true);
        GameManager.Instance.GameOver = true;
    }

    public void CloseUppgrade(){
        uppgradePanel.SetActive(false);
        GameManager.Instance.GameOver = false;
    }

    public void UpdateCoinBuySpeed(float value){
        this.coinBuySpeed.text = "x " + value;
    }

    public void UpdateCoinBuyShootSpeed(float value)
    {
        this.coinBuyShootSpeed.text = "x " + value;
    }

    public void UpdateCoinBuyDamage(float value)
    {
        this.coinBuyDamage.text = "x " + value;
    }
}
