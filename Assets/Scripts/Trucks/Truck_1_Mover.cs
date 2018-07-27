using Newtonsoft.Json.Linq;
using UnityEngine;
using System.IO;
using Dijkstra.NET.Model;
using Dijkstra.NET.ShortestPath;


public class Truck_1_Mover : MonoBehaviour 
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
	private bool car_1_go;																					//for trcuk button

	void Start () 
	{
		my_collection = FindObjectOfType<WaypointCollection> ();

        /*temp implementation start
        string filepath = @"C:\Users\csabh\Desktop\RouteIdentifier.json";
        string json;

        using (StreamReader srReader = new StreamReader(filepath))
        {
            json = srReader.ReadToEnd();
        }
        JObject jObjJsonFromBackend = JObject.Parse(json);

        //Object for the Shortest path lib for handling all the queries to the library
        ProfiterShortestPathLib profiterShortestPathObj = new ProfiterShortestPathLib();

        //Extract the Routes from the JSON received from the backend for further processig of the routes on the
        //and for the constructing the shortest route
        JObject jObjRoutesJosn = profiterShortestPathObj.ExtractRoutes(jObjJsonFromBackend);

        //Create the graph for the routes for usagae in DIJSKTRA algo based shortest path identification
        Graph<int, string> rputeGraphForDijkstra = profiterShortestPathObj.CreatesRouteGraph(jObjJsonFromBackend, jObjRoutesJosn);

        var dijkstra = new Dijkstra<int, string>(rputeGraphForDijkstra);

        string source = "kashmir", destination = "kanyakumari";
        var shortestRoute = profiterShortestPathObj.GetShortestPath(source, destination, dijkstra);
        foreach (var item in shortestRoute)
        {
            Debug.Log(item);
        }
        //temp implementation end */
    }


    void Update ()
	{
		if (car_1_go) 
		{
			switch (start_option) 
			{
			case 1:
				if((end_option)==0)				
					if (current_transform < my_collection.kashmir_to_mumbai.Length) 
					{
						direction = my_collection.kashmir_to_mumbai [current_transform].position - transform.position;
						angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
						rotate_angle = Quaternion.AngleAxis (angle, Vector3.forward);
						if (transform.position == my_collection.kashmir_to_mumbai [current_transform].position) 
						{
							current_transform++;
						}
					}
				if((end_option)==1)
				{
					if (current_transform < my_collection.kashmir_to_kanyakumari.Length) 
					{
						direction = my_collection.kashmir_to_kanyakumari [current_transform].position - transform.position;
						angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
						rotate_angle = Quaternion.AngleAxis (angle, Vector3.forward);
						if (transform.position == my_collection.kashmir_to_kanyakumari [current_transform].position) 
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
		if (car_1_go) 
		{
			switch (start_option) 
			{
			case 1:
				if (end_option == 0) {
					if (current_transform < my_collection.kashmir_to_mumbai.Length) {
						transform.position = Vector3.MoveTowards (transform.position, my_collection.kashmir_to_mumbai [current_transform].position, speed * Time.deltaTime);
						transform.rotation = Quaternion.Lerp (transform.rotation, rotate_angle, rotate_speed * Time.deltaTime);
					}
				}

				if (end_option == 1) {
					if (current_transform < my_collection.kashmir_to_kanyakumari.Length) {
						transform.position = Vector3.MoveTowards (transform.position, my_collection.kashmir_to_kanyakumari [current_transform].position, speed * Time.deltaTime);
						transform.rotation = Quaternion.Lerp (transform.rotation, rotate_angle, rotate_speed * Time.deltaTime);
					}
				}
				break;
			}
			
		
		}
			
	}

	public void Car_1_Button()
	{
		car_1_go = true;
	}
}
