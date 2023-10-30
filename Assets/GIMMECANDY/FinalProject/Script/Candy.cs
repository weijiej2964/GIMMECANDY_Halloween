using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public TextMeshProUGUI CandyText;
    public GameObject GameoverPanel;
    public TextMeshProUGUI FinalCandyText;
    public ControlPlayer Player;

    private int _candyAmount;

    [SerializeField] private AudioSource getCandySFX;

    // Start is called before the first frame update
    private void Start()
    {
        _candyAmount = 0;
        UpdateCandyAmount();
    }

    public void UpdateCandyAmount()
    {
        CandyText.text = _candyAmount.ToString();
    }

   public void IncreaseCandyAmount(int amount)
    {
        getCandySFX.Play();
        _candyAmount += amount;
    }

    public void DecreaseCandyAmount(int amount)
    {
        _candyAmount -= amount;
        if( _candyAmount < 0 ) 
        {
            StartCoroutine(Gameover());
        }
    }

    public int getCandyAmount()
    {
        return _candyAmount;
    }

    IEnumerator Gameover()
    {
        Player.moveSpeed = 0;
        Player.PlayerDeathAnim();

        yield return new WaitForSeconds(1.5f);

        GameoverPanel.SetActive(true );
    }
}
