using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_2_Mover : MonoBehaviour 
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
	private bool car_2_go;																					//for trcuk button

	void Start () 
	{
		my_collection = FindObjectOfType<WaypointCollection> ();
	}


	void Update ()
	{
		if (car_2_go) 
		{
			switch (start_option) 
			{
			case 2:
				if((end_option)==0)				
				if (current_transform < my_collection.kanyakumari_to_hyderabad.Length) 
				{
					direction = my_collection.kanyakumari_to_hyderabad [current_transform].position - transform.position;
					angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
					//Debug.Log ("Inside");
					rotate_angle = Quaternion.AngleAxis (angle, Vector3.forward);
					if (transform.position == my_collection.kanyakumari_to_hyderabad [current_transform].position) 
					{
						current_transform++;
					}
				}
				if(end_option==1)
				{
					if (current_transform < my_collection.kanyakumari_to_kolkata.Length) 
					{
						direction = my_collection.kanyakumari_to_kolkata[current_transform].position - transform.position;
						angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
						rotate_angle = Quaternion.AngleAxis (angle, Vector3.forward);
						if (transform.position == my_collection.kanyakumari_to_kolkata [current_transform].position) 
						{
							current_transform++;
						}
					}

				}
				break;
			}
		}
	}



	void FixedUpdate()
	{
		if (car_2_go) 
		{
			switch (start_option) 
			{
			case 2:
				if (end_option == 0) {
					if (current_transform < my_collection.kanyakumari_to_hyderabad.Length) {
						transform.position = Vector3.MoveTowards (transform.position, my_collection.kanyakumari_to_hyderabad [current_transform].position, speed * Time.deltaTime);
						transform.rotation = Quaternion.Lerp (transform.rotation, rotate_angle, rotate_speed * Time.deltaTime);
					}
				}

				if (end_option == 1) {
					if (current_transform < my_collection.kanyakumari_to_kolkata.Length) {
						transform.position = Vector3.MoveTowards (transform.position, my_collection.kanyakumari_to_kolkata [current_transform].position, speed * Time.deltaTime);
						transform.rotation = Quaternion.Lerp (transform.rotation, rotate_angle, rotate_speed * Time.deltaTime);
					}
				}
				break;
			}


		}

	}

	public void Car_2_Button()
	{
		car_2_go = true;
	}
}
