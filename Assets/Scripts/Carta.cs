using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    
    public int value = 0;

    public int GetValueOfCard()
    {

        return value;

    }

    public void SetValue(int newValue)
    {

        value = newValue;

    }

    public string GetStringName()
    {

        return GetComponent<SpriteRenderer>().sprite.name;

    }

    public void SetSprite(Sprite newSprite) 
    {

        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;

    }

    public void ResetCard()
    {

        Sprite back = GameObject.Find("Baralho").GetComponent<Baralho>().GetCardBack();
        gameObject.GetComponent<SpriteRenderer>().sprite = back;
        value = 0;

    }

}
