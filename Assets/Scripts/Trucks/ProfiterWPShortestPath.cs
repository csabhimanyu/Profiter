using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dijkstra.NET.Contract;
using Dijkstra.NET.Model;
using Dijkstra.NET.ShortestPath;
using System;

public class ProfiterWPShortestPath : MonoBehaviour
{
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

        for (int i = 0; i < 24; i++)
        {
            graph.AddNode(i + 1);
        }

        for (int i = 0; i < 24; i++)
        {
            if (i != 23)
            {
                graph.Connect(Convert.ToUInt32(i), Convert.ToUInt32(i + 1), 1, "");
                graph.Connect(Convert.ToUInt32(i + 1), Convert.ToUInt32(i), 1, "");
            }

            else
            {
                graph.Connect(Convert.ToUInt32(i), Convert.ToUInt32(0), 1, "");
                graph.Connect(Convert.ToUInt32(0), Convert.ToUInt32(i), 1, "");
            }

        }

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
