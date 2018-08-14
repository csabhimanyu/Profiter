using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_3_Mover : MonoBehaviour 
{

	public int start_option;																				//for start
	public int end_option;																					//for destination 
	private WaypointCollection my_collection;																//waypoint class refrence
	int current_transform=0;																				//tracking current point int the selected array
	private float angle;																					//for rotation calculation
	private Quaternion rotate_angle;																		//
	private Vector3 direction;																				//
	public float speed;																						//speed of the truck
	public float rotate_speed;																				//rotation speed of the truck		
	private bool car_3_go;																					//for trcuk button

	void Start () 
	{
		my_collection = FindObjectOfType<WaypointCollection> ();
	}


	//void Update ()
	//{
	//	if (car_3_go) 
	//	{
	//		switch (start_option) 
	//		{
	//		case 3:
	//			if((end_option)==0)				
	//			if (current_transform < my_collection.assam_to_mp.Length) 
	//			{
	//				direction = my_collection.assam_to_mp [current_transform].position - transform.position;
	//				angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
	//				rotate_angle = Quaternion.AngleAxis (angle, Vector3.forward);
	//				if (transform.position == my_collection.assam_to_mp [current_transform].position) 
	//				{
	//					current_transform++;
	//				}
	//			}
	//			break;
	//			}
		
	//		}
	//	}


	//void FixedUpdate()
	//{
	//	if (car_3_go) 
	//	{
	//		switch (start_option) 
	//		{
	//		case 3:
	//			if (end_option == 0) 
	//			{
	//				if (current_transform < my_collection.assam_to_mp.Length) 
	//				{
	//					transform.position = Vector3.MoveTowards (transform.position, my_collection.assam_to_mp [current_transform].position, speed * Time.deltaTime);
	//					transform.rotation = Quaternion.Lerp (transform.rotation, rotate_angle, rotate_speed * Time.deltaTime);
	//				}
	//			}
				
	//			break;
	//		}


	//	}

	//}

	//public void Car_3_Button()
	//{
	//	car_3_go = true;
	//}
}

