using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class CardManagement : MonoBehaviour
{

    
    
    public int noOfCards;
    public class ProfiterCardMgmt
    {
        //Data Definition
        public int cardIndex { get; set; }
        public int cardItem { get; set; } // Rice=1, Wheat=2, Gram=3,
        public int goodsQty { get; set; } //In Tonnes for M type cards is production & C-type cards its Consumption / Requirement
        public bool cardValidity { get; set; } //True or False
        public int timeInSeconds { get; set; } //valid for time in seconds
        public char cardCategory { get; set; }//M:MarketPlace, C-City
        public int originIndex { get; set; }
        public int pricePerTonne { get; set; } //The goods price per tonne
        public bool cardCreated { get; set; }
        public GameObject cardGameObj { get; set; }

        //Default constructor
        public ProfiterCardMgmt() { }

        public ProfiterCardMgmt(int cardIndex, int cardItem, int goodsQty, bool cardValidity, int timeInSeconds, int originIndex, char cardCategory, int pricePerTonne, GameObject cardGameObj, bool cardCreated = false)
        {
            this.cardIndex = cardIndex;
            this.cardItem = cardItem;
            this.goodsQty = goodsQty;
            this.cardValidity = cardValidity;
            this.timeInSeconds = timeInSeconds;
            this.originIndex = originIndex;
            this.cardCategory = cardCategory;
            this.pricePerTonne = pricePerTonne;
            this.cardCreated = cardCreated;
            this.cardGameObj = cardGameObj;
        }
    }

    //List object which will hold the currently available cards and will be used for all the processing
    public List<ProfiterCardMgmt> updateCardDataList = new List<ProfiterCardMgmt>();

    /// <summary>
    /// The function will be used to process the card from the backend. This process the card for
    /// 1. createcard
    /// 2. updatecard --> Updating an exsiting list time with the cardindex number and then create a new card which will then be rendered by the Unity Update function
    /// 3. deletecard --> Deletes the card from the list with the cardindex from the backend JSON
    /// 4. default case has been added to communicate back to the backend to inform the error in the client
    /// </summary>
    /// <param name="jsonObjFromBackend"></param>
    public void UpdateCard(JObject jsonObjFromBackend)
    {
        GameObject cardGameObj = new GameObject();
        switch (jsonObjFromBackend["createcard"].ToString())
        {
            case "createcard":
                updateCardDataList.Add(new
                    ProfiterCardMgmt(
                        Int32.Parse(jsonObjFromBackend["cardIndex"].ToString()),
                        Int32.Parse(jsonObjFromBackend["cardItem"].ToString()),
                        Int32.Parse(jsonObjFromBackend["goodsQty"].ToString()),
                        bool.Parse(jsonObjFromBackend["cardValidity"].ToString()),
                        Int32.Parse(jsonObjFromBackend["timeInSeconds"].ToString()),
                        Int32.Parse(jsonObjFromBackend["originIndex"].ToString()),
                        Char.Parse(jsonObjFromBackend["cardCategory"].ToString()),
                        Int32.Parse(jsonObjFromBackend["pricePerTonne"].ToString()),
                        cardGameObj
                    ));
                break;

            case "updatecard":
                if (updateCardDataList.RemoveAll(a => a.cardIndex == Int32.Parse(jsonObjFromBackend["cardIndex"].ToString())) == 1)
                {
                    updateCardDataList.Add(new
                        ProfiterCardMgmt(
                        Int32.Parse(jsonObjFromBackend["cardIndex"].ToString()),
                        Int32.Parse(jsonObjFromBackend["cardItem"].ToString()),
                        Int32.Parse(jsonObjFromBackend["goodsQty"].ToString()),
                        bool.Parse(jsonObjFromBackend["cardValidity"].ToString()),
                        Int32.Parse(jsonObjFromBackend["timeInSeconds"].ToString()),
                        Int32.Parse(jsonObjFromBackend["originIndex"].ToString()),
                        Char.Parse(jsonObjFromBackend["cardCategory"].ToString()),
                        Int32.Parse(jsonObjFromBackend["pricePerTonne"].ToString()),
                        cardGameObj
                    ));
                }
                break;

            case "deletecard":
                //This should destroy the game object as well. Should be tested.
                DeleteCard(Int32.Parse(jsonObjFromBackend["cardIndex"].ToString()));
                break;
            default:
                Debug.Log("No Matching event found");
                //Backend communication should be sent for debug purpose and finding any errors in the client should be handled at a later stage
                break;
        }
    }

    /// <summary>
    /// Function for deleting the card from backaned and as well as from other places like once the player selects the cards etc...
    /// Uses the card index to delete the card from the list
    /// </summary>
    /// <param name="cardIndex"></param>
    /// <returns></returns>
    public bool DeleteCard(int cardIndex)
    {
        try
        {
            if (updateCardDataList.RemoveAll(a => a.cardIndex == cardIndex) == 1)
            {
                return true;
            }
        }
        catch (Exception)
        {
            //Comminicate with backend on failure to delete the card to be added
            throw;
        }
        
        return false;
    }

    private void CardPostion() {
    
    }

	// Use this for initialization
	private void Start () {
            
            
            // not required???

        }
	private void Update()
	{

        // scan the carMgmt List  for which gameobject is not created 
        // Create card type prefab game objects  
        // call the CardPosition() function to identiy the position for this card
        // destroy any old cards that need to deleted 
        //
        
	

	}
}
