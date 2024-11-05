using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : BaoMonoBehaviour
{
    public Text timeText;
    private float elapsedTime;
    public float remainingTime;

    protected override void Start()
    {
        this.remainingTime = 90f;
    }

    protected override void Update()
    {
        if(GameManager.Instance.startGame == false) return;
        this.remainingTime -= Time.deltaTime;
        this.timeText.text = this.elapsedTime.ToString();
        int minutes = Mathf.FloorToInt(this.remainingTime / 60);
        int seconds = Mathf.FloorToInt(this.remainingTime % 60);
        this.timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
