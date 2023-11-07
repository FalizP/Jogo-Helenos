using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarta : MonoBehaviour
{

    public Carta cardScript;
    public Baralho deckScript;

    public int handValue = 0;

    public int money = 1000;

    public GameObject[] hand;

    public int cardIndex = 0;

    List<Carta> aceList = new List<Carta>();

    // Start is called before the first frame update
    public void StartHeand()
    {

        GetCard();
        GetCard();

    }

    public int GetCard()
    {

        int cardValue = deckScript.DealCard(hand[cardIndex].GetComponent<Carta>());
        hand[cardIndex].GetComponent<Renderer>().enabled = true;
        handValue += cardValue;

        if(cardValue == 1)
        {

            aceList.Add(hand[cardIndex].GetComponent<Carta>());

        }

        AceCheck();
        cardIndex++;
        return handValue;

    }

    public void AceCheck()
    {
            
        foreach(Carta ace in aceList)
        { 
        
            if(handValue + 10 < 22 && ace.GetValueOfCard() == 1)
            {

                ace.SetValue(11);
                handValue += 10;

            } else if (handValue > 21 && ace.GetValueOfCard() == 11)
            {

                ace.SetValue(1);
                handValue -= 10;

            }
        
        }

    }

    public void AdjustMoney(int amount)
    {

        money += amount;

    }

    public int GetMoney()
    {

        return money;

    }

    public void ResetHand()
    {
        
        for (int i = 0; i < hand.Length; i++)
        {

            hand[i].GetComponent<Carta>().ResetCard();
            hand[i].GetComponent <Renderer>().enabled = false;

        }

        cardIndex = 0;
        handValue = 0;
        aceList = new List<Carta>();

    }
}
