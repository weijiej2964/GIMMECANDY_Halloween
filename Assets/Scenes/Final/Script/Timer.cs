using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeInSeconds; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeInSeconds -= Time.deltaTime;
        UpdateTimer();

        if (timeInSeconds <= 0)
        {
            Debug.Log("times out");
        }
    }

    private void UpdateTimer()
    {
        timerText.text = ((int)(timeInSeconds / 60.0)).ToString() + ':' + ((int)(timeInSeconds % 60.0)/10).ToString() + ((int)(timeInSeconds%60.0)%10).ToString();
    }
}
