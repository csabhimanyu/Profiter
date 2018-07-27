using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManagement : MonoBehaviour
{

    // 
    public class ProfiterCardMgmt
    {
        int cardType;    // Rice =1, Wheat =2,....
        int goodsQty;    // in tons 
        bool cardValidity;
        Time timeInSeconds;  //valid for 
        char cardCategory; //M:MarketPlace
        int originIndex;
        GameObject cardObjectList;

        public void ProfiterCardMgmt(int type, int qty, bool validity, Time seconds, int origin)
        {

            cardType = type;
            goodsQty = qty;
            cardValidity = validity;
            timeInSeconds = seconds;
            originIndex = origin;
        }

        public int noOfCards;



    }
    private ProfiterMgmt imeInSecotempCard;
    public List<ProfiterCardMgmt> cardMgmt;   //Is this the right way to manage cards 

    Public void UpdateCard(Jason obj)
    {


        switch (obj.cardUpdateType)
        {

            case "CreateCard":
                tempCard = new
                cardMgmt.Add()
                break;
            case "UpdateCard":
                break;
            case "DeleteCard":


        }


    }

    private void CardPostion() {
    
    }

	// Use this for initialization
	void Start () {
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
