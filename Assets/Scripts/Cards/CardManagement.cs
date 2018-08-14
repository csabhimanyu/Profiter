using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public enum CardItem { Rice, Wheat, Gram };
public enum CardCategory { MarketPlace, City };
public enum States { Bengaluru, Bhopal, Chennai, Delhi, Guwahati, Hyderabad, Jaipur, Kochi, Kolkata, Mumbai, Patna, SriNagar };
public enum CreateCard { Create, Update, Delete };

[System.Serializable]
public class ProfiterCardMgmt
{
    //Data Definition
    public int cardIndex;
    public CardItem cardItem;// Rice=1, Wheat=2, Gram=3,
    public CreateCard createCard;
    public int goodsQty; //In Tonnes for M type cards is production & C-type cards its Consumption / Requirement
    public bool cardValidity; //True or False
    public int timeInSeconds; //valid for time in seconds
    public CardCategory cardCategory;//M:MarketPlace, C-City
    public States state;//Bengaluru, Bhopal, Chennai, Delhi, Guwahati, Hyderabad, Jaipur, Kochi, Kolkata, Mumbai, Patna, SriNagar 
    public int cip;
    public int originIndex;
    public int pricePerTonne; //The goods price per tonne
    public bool cardCreated;
    public GameObject cardGameObj;
}


public class CardManagement : MonoBehaviour
{
    public int noOfCards;
    //List object which will hold the currently available cards and will be used for all the processing
    public List<ProfiterCardMgmt> updateCardDataList = new List<ProfiterCardMgmt>();
    public GameObject cardPrefab;
    public GameObject cardHolder;
    public int currentActiveIndex;

    public int tempindx;
    /// <summary>
    /// The function will be used to process the card from the backend. This process the card for
    /// 1. createcard
    /// 2. updatecard --> Updating an exsiting list time with the cardindex number and then create a new card which will then be rendered by the Unity Update function
    /// 3. deletecard --> Deletes the card from the list with the cardindex from the backend JSON
    /// 4. default case has been added to communicate back to the backend to inform the error in the client
    /// </summary>
    /// <param name="jsonObjFromBackend"></param>
    public void UpdateCard()
    {
        currentActiveIndex = 0;
        foreach (var item in updateCardDataList)
        {
            switch (item.createCard)
            {
                case CreateCard.Create:
                    var cardObj = Instantiate(cardPrefab, cardHolder.transform);
                    cardObj.GetComponent<CardHandler>().state = ((States)item.state).ToString();
                    cardObj.GetComponent<CardHandler>().cardIndex = item.cardIndex;
                    cardObj.GetComponent<CardHandler>().item = item.cardItem.ToString();
                    cardObj.GetComponent<CardHandler>().cip = item.cip;
                    cardObj.GetComponent<CardHandler>().qty = item.goodsQty;
                    cardObj.GetComponent<CardHandler>().pricepertonn = item.pricePerTonne;
                    item.cardCreated = true;
                    cardObj.SetActive(false);
                    item.cardGameObj = cardObj;
                    cardObj.GetComponent<CardHandler>().UpdateCardDisplay();
                    
                    break;

                case CreateCard.Update:
                    //itrate throung list sent and update card;
                    item.cardGameObj.GetComponent<CardHandler>().state = ((States)item.state).ToString();
                    item.cardGameObj.GetComponent<CardHandler>().item = ((CardItem)item.cardItem).ToString();
                    item.cardGameObj.GetComponent<CardHandler>().cip = item.cip;
                    item.cardGameObj.GetComponent<CardHandler>().qty = item.goodsQty;
                    item.cardGameObj.GetComponent<CardHandler>().pricepertonn = item.pricePerTonne;
                    item.cardGameObj.GetComponent<CardHandler>().UpdateCardDisplay();
                    break;

                case CreateCard.Delete:
                    //This should destroy the game object as well. Should be tested.
                    DeleteCard(item.cardIndex);
                    break;
                default:
                    Debug.Log("No Matching event found");
                    //Backend communication should be sent for debug purpose and finding any errors in the client should be handled at a later stage
                    break;
            }
        }
        DisplayUpdate(1);
    }

    /// <summary>
    /// Function for deleting the card from backaned and as well as from other places like once the player selects the cards etc...
    /// Uses the card index to delete the card from the list
    /// </summary>
    /// <param name="cardIndex"></param>
    /// <returns></returns>
    public void DeleteCard(int cardIndex)
    {
        updateCardDataList[cardIndex].cardGameObj.GetComponent<CardHandler>().DestroyCard();
        updateCardDataList.RemoveAt(cardIndex);
              DisplayUpdate(0);
        
    }


    private void CardPostion()
    {

    }
   
    // Use this for initialization
    private void Start()
    {
        currentActiveIndex = 0;
        // not required???
        UpdateCard();
    }
    private void Update()
    {

        // scan the carMgmt List  for which gameobject is not created 
        // Create card type prefab game objects  
        // call the CardPosition() function to identiy the position for this card
        // destroy any old cards that need to deleted 
        //
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DeleteCard(tempindx);
        }


    }

    public void DisplayUpdate(int dispValue)
    {
        int count = 0;
        if (dispValue == 1)
        {
            for (int i = 0; i < updateCardDataList.Count; i++)
            {
                updateCardDataList[i].cardGameObj.gameObject.SetActive(false);
                if (i == currentActiveIndex && count < 4)
                {
                    updateCardDataList[i].cardGameObj.gameObject.SetActive(true);
                    count++;
                    currentActiveIndex++;
                    if(currentActiveIndex >= updateCardDataList.Count)
                    {
                        currentActiveIndex = 0;
                    }
                }

            }
        }
        else
        {
            for (int i = (updateCardDataList.Count-1); i >=0; i--)
            {
                updateCardDataList[i].cardGameObj.gameObject.SetActive(false);
                if (i == currentActiveIndex && count < 4)
                {
                    updateCardDataList[i].cardGameObj.gameObject.SetActive(true);
                    count++;
                    currentActiveIndex--;
                    if (currentActiveIndex < 0)
                    {
                        currentActiveIndex = (updateCardDataList.Count-1);
                    }
                    
                }

            }
        }
    }
    public void Next()
    {
        print("@!#$%");
       DisplayUpdate(1);
    }
    public void Prev()
    {
       DisplayUpdate(0);
    }
}
