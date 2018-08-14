using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;
using Dijkstra.NET.Contract;
using Dijkstra.NET.Model;
using Dijkstra.NET.ShortestPath;

public class WaypointCollection:MonoBehaviour
{
    ProfiterWPShortestPath profiterWPShortestPathObj = new ProfiterWPShortestPath();
    public List<Transform> getShortestTruckTransitionPath(string currentCity, string destinationCity, string currentLocationWP)
    {
        
        int truckWPNo = Int32.Parse(currentLocationWP.Split('_')[0]);

        List<Transform> sortedListWP = new List<Transform>();
        List<Transform> wayPointList = new List<Transform>();

        wayPointList = GameObject.FindObjectsOfType<Transform>().ToList().FindAll
            (
                wp => wp.name.ToString().ToLower().Contains("_wp_" + currentCity) ||
                wp.name.ToString().ToLower().Contains("_wp_" + destinationCity + "_" + currentCity)
            );

        int connectedRoadWPNO = Int32.Parse(wayPointList.Find(
            wp => wp.name.ToString().ToLower().Contains("_wp_" + currentCity + "_" + destinationCity))
            .name.ToString().Split('_')[0].ToString());

        string[] temp = profiterWPShortestPathObj.wpRouteFinder(truckWPNo, connectedRoadWPNO);

        for (int i = 0; i < temp.Length; i++)
        {
            sortedListWP.Add(wayPointList.Find(wp => wp.name.ToString().Split('_')[0] == temp[i].ToString() && !wp.name.ToString().ToLower().Contains("_wp_" + destinationCity + "_" + currentCity)));
        }
        return sortedListWP;
    }

    void Start()
    {
        //string source = "kashmir";
        //string destination = "delhi";
        //string truckLocationWP = "7_WP_Kashmir";
        //int truckWPNo = Int32.Parse(truckLocationWP.Split('_')[0]);

        //List<Transform> sortedListWP = new List<Transform>();
        //List<Transform> wayPointList = new List<Transform>();

        //wayPointList = gameObject.GetComponentsInChildren<Transform>().ToList().FindAll
        //    (
        //        wp => wp.name.ToString().ToLower().Contains("_wp_" + source) ||
        //        wp.name.ToString().ToLower().Contains("_wp_" + destination + "_" + source)
        //    );

        //int connectedRoadWPNO = Int32.Parse(wayPointList.Find(wp => wp.name.ToString().ToLower().Contains("_wp_" + source + "_" + destination)).name.ToString().Split('_')[0].ToString());

        //string[] temp = wpRouteFinder(truckWPNo, connectedRoadWPNO);
        
        //for (int i = 0; i < temp.Length; i++)
        //{
        //    sortedListWP.Add(wayPointList.Find(wp => wp.name.ToString().Split('_')[0] == temp[i].ToString() && !wp.name.ToString().ToLower().Contains("_wp_" + destination + "_" + source)));
        //}

        //foreach (var item in sortedListWP)
        //{
        //    Debug.Log(item.name.ToString());
        //}
        //Debug.Log("test");
        //chennai_to_assam = (GameObject.FindGameObjectWithTag ("Chennai_To_Assam")).GetComponentsInChildren<Transform> ();
    }


}
