using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHandler : MonoBehaviour
{
    public int cardIndex;
    public string state;
    public string item;
    public int cip;
    public int qty;
    public int pricepertonn;

    public Text stateText;
    public Text itemText;
    public Text cipText;
    public Text quantityText;
    public Text pricepertonneText;

    public void UpdateCardDisplay()
    {
        stateText.text = state;
        itemText.text = item;
        cipText.text = cip.ToString();
        quantityText.text = qty.ToString();
        pricepertonneText.text = pricepertonn.ToString();
    }
    public void DestroyCard()
    {
        Destroy(this.gameObject);
    }
}
//public int cardIndex;
//public CardItem cardItem;// Rice=1, Wheat=2, Gram=3,
//public CreateCard createCard;
//public int goodsQty; //In Tonnes for M type cards is production & C-type cards its Consumption / Requirement
//public bool cardValidity; //True or False
//public int timeInSeconds; //valid for time in seconds
//public CardCategory cardCategory;//M:MarketPlace, C-City
//public States state;
//public int originIndex;
//public int pricePerTonne; //The goods price per tonne
//public bool cardCreated;
//public GameObject cardGameObj;