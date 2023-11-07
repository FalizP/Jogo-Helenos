using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Genrenciador : MonoBehaviour
{

    public Button Comprar;
    public Button Hit;
    public Button Stand;
    public Button Bet;
    
    private int standClicks = 0;

    public PlayerCarta playerScript;
    public PlayerCarta dealerScript;

    public Text MainText;
    public Text scoreText;
    public Text dealerScoreText;
    public Text betsText;
    public Text cashText;
    

    public Text standBntText;

    public GameObject hideCard;
    int pot = 0;

    // Start is called before the first frame update
    void Start()
    {

        Comprar.onClick.AddListener(() => DealClicked());
        Hit.onClick.AddListener(() => HitClicked());
        Stand.onClick.AddListener(() => StandClicked());
        Bet.onClick.AddListener(() => BetClicked());

    }

    private void HitClicked()
    {

        if (playerScript.GetCard() <= 10) 
        {

            playerScript.GetCard();
            scoreText.text = "Hand " + playerScript.handValue.ToString();
            if (playerScript.handValue > 20)
            {

                Rest();

            }
        }

    }

    private void DealClicked()
    {

        playerScript.ResetHand();
        dealerScript.ResetHand();
        MainText.gameObject.SetActive(false);
        dealerScoreText.gameObject.SetActive(false);
        GameObject.Find("Baralho").GetComponent<Baralho>().Shuffle();
        playerScript.StartHeand();
        dealerScript.StartHeand();
        scoreText.text = "Hand " + playerScript.handValue.ToString();
        dealerScoreText.text = "Hand " + dealerScript.handValue.ToString();
        hideCard.GetComponent<Renderer>().enabled = true;
        Comprar.gameObject.SetActive(false);
        Hit.gameObject.SetActive(true);
        Stand.gameObject.SetActive(true);
        standBntText.text = "Stand";
        pot = 40;
        betsText.text = "Besr: $" + pot.ToString();
        playerScript.AdjustMoney(-20);
        cashText.text = "$" + playerScript.GetMoney().ToString();


    }

    private void StandClicked()
    {

        standClicks++;
        if (standClicks > 1)
        {

            Rest();
        
        }

        HitDealer();
        standBntText.text = "call";
        
    }

    private void HitDealer()
    {

        while(dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {

            dealerScript.GetCard();
            scoreText.text = "Hand " + playerScript.handValue.ToString();
            dealerScoreText.text = "Hand " + dealerScript.handValue.ToString();
            if (dealerScript.handValue > 20)
            {

                Rest();

            }

        }

    }

    private void Rest()
    {

        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = dealerScript.handValue > 21;
        bool player21 = playerScript.handValue == 21;
        bool dealer21 = dealerScript.handValue == 21;

        if (standClicks < 2 && !playerBust && !dealerBust && !player21 && !dealer21) return;
        bool roundOver = true;
        if (playerBust && dealerBust)
        {

            MainText.text = "All Bust: Bests returned";
            playerScript.AdjustMoney(pot / 2);

        }else if (playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {

            MainText.text = "Mais que macacada!";

        }
        else if (dealerBust || (!playerBust && playerScript.handValue > dealerScript.handValue))
        {

            MainText.text = "Macacos mim mordam";
            playerScript.AdjustMoney(pot);

        }else if (playerScript.handValue == dealerScript.handValue)
        {

            MainText.text = "Push: Best returned";
            playerScript.AdjustMoney(pot / 2);

        }
        else 
        { 
        
            roundOver = false;
        
        }

        if(roundOver)
        {

            Hit.gameObject.SetActive(false);
            Stand.gameObject.SetActive(false);
            Comprar.gameObject.SetActive(true);
            MainText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);
            hideCard.GetComponent<Renderer>().enabled = false;
            cashText.text = "$" + playerScript.GetMoney().ToString();
            standClicks = 0;

        }

    }

    private void BetClicked()
    {
        
        Text newBet = Bet.GetComponentInChildren(typeof(Text)) as Text;
        int intBet = int.Parse(newBet.text.ToString().Remove(0, 1));
        playerScript.AdjustMoney(-intBet);
        cashText.text = "$" + playerScript.GetMoney().ToString();
        pot += (intBet * 2);
        betsText.text = "Besr: $" + pot.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Hand " + playerScript.handValue.ToString();

    }
}
