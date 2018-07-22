using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCollection:MonoBehaviour
{

	public Transform[] kashmir_to_mumbai,kashmir_to_kanyakumari;
	public Transform[] kanyakumari_to_hyderabad,kanyakumari_to_kolkata;
	public Transform[] assam_to_mp;

	void Start()
	{
		//chennai_to_assam = (GameObject.FindGameObjectWithTag ("Chennai_To_Assam")).GetComponentsInChildren<Transform> ();
	}


}
