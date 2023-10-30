using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeInSeconds;
    public ControlPlayer player;
    private bool timesUp = false;
    public GameObject GameoverPanel;
    public Candy candyScore;
    public TextMeshProUGUI finalCandyText; 

    public 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeInSeconds -= Time.deltaTime;
        UpdateTimer();

        if (timeInSeconds <= 0 && timesUp == false)
        {
            timesUp = true;
            finalCandyText.text = candyScore.getCandyAmount().ToString();
            GameoverPanel.SetActive(true);
            player.moveSpeed = 0;
        }
    }

    private void UpdateTimer()
    {
        timerText.text = ((int)(timeInSeconds / 60.0)).ToString() + ':' + ((int)(timeInSeconds % 60.0)/10).ToString() + ((int)(timeInSeconds%60.0)%10).ToString();
    }

}
