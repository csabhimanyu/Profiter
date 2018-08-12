using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dijkstra.NET.Contract;
using Dijkstra.NET.Model;
using Dijkstra.NET.ShortestPath;
using System;

public class ProfiterWPShortestPath : MonoBehaviour {
    /// <summary>
    /// Finding the shortest distance to move the truck along the city
    /// </summary>
    /// <param name="startNumber"></param>
    /// <param name="endNumber"></param>
    /// <returns></returns>
    public string[] wpRouteFinder(int startingWPNum, int endingWPNumber)
    {
        List<string> pathList = new List<string>();
        var graph = new Graph<int, string>();

        graph.AddNode(1); //0th WayPoint
        graph.AddNode(2); 
        graph.AddNode(3); 
        graph.AddNode(4);
        graph.AddNode(5);
        graph.AddNode(6);
        graph.AddNode(7);
        graph.AddNode(8); //7th WayPoint

        //Connecting WayPoints on both sides
        graph.Connect(0, 1, 1, "");
        graph.Connect(1, 0, 1, "");

        graph.Connect(1, 2, 1, "");
        graph.Connect(2, 1, 1, "");

        graph.Connect(2, 3, 1, "");
        graph.Connect(3, 2, 1, "");

        graph.Connect(3, 4, 1, "");
        graph.Connect(4, 3, 1, "");

        graph.Connect(4, 5, 1, "");
        graph.Connect(5, 4, 1, "");

        graph.Connect(5, 6, 1, "");
        graph.Connect(6, 5, 1, "");

        graph.Connect(6, 7, 1, "");
        graph.Connect(7, 6, 1, "");

        graph.Connect(7, 0, 1, "");
        graph.Connect(0, 7, 1, "");

        var dijkstra = new Dijkstra<int, string>(graph);

        IShortestPathResult result = dijkstra.Process(Convert.ToUInt32(startingWPNum), Convert.ToUInt32(endingWPNumber));
        result.GetPath();

        foreach (var item in result.GetPath())
        {
            pathList.Add(item.ToString());
        }
        return pathList.ToArray();
    }

}
