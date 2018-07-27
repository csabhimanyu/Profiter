using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManagement : MonoBehaviour {

    // 
    public class ProfiterCardMgmt {
        int cardType;    // Rice =1, Wheat =2,....
        int goodsQty;    // in tons 
        bool cardValidity;
        Time timeInSeconds;  //valid for 
        char cardCategory; //M:Male
        int originIndex;
        GameObject[] cardObjectList; 

        public void InitProfiterCardMgmt ( int type, int qty, bool validity, Time seconds, int origin) {

            cardType = type;
            goodsQty = qty;
            cardValidity = validity;
            timeInSeconds = seconds;
            originIndex = origin; 
        }

    }

    public  List<ProfiterCardMgmt> cardMgmt;   //Is this the right way to manage cards 



	// Use this for initialization
	void Start () {
		
	}
	private void Update()
	{
		
	}
}
