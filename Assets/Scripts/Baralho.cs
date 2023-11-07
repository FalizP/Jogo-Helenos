using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baralho : MonoBehaviour
{

    public Sprite[] cartasSprites;
    int[] cartasValor = new int[53];
    int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        GetCardValues();

    }

    // Update is called once per frame
    void GetCardValues()
    {
        
        int num = 0;
        for (int i = 0; i < cartasSprites.Length; i++)
        {

            num = i;
            num %= 13;

            if (num > 10 || num == 0)
            {

                num = 10;

            }

            cartasValor[i] = num;

        }

    }

    public void Shuffle()
    {

        for(int i = cartasSprites.Length -1; i > 0; --i)
        {

            int j = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * cartasSprites.Length - 1) + 1;
            Sprite face = cartasSprites[i];
            cartasSprites[i] = cartasSprites[j];
            cartasSprites[j] = face;

            int value = cartasValor[i];
            cartasValor[i] = cartasValor[j];
            cartasValor[j] = value;

        }

        currentIndex = 1;

    }

    public int DealCard(Carta cardScript)
    {

        cardScript.SetSprite(cartasSprites[currentIndex]);
        cardScript.SetValue(cartasValor[currentIndex]);
        currentIndex++;
        return cardScript.GetValueOfCard();

    }

    public Sprite GetCardBack()
    {

        return cartasSprites[0];

    }

}
