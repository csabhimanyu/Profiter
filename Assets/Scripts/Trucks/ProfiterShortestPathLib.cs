using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Dijkstra.NET.Model;
using Dijkstra.NET.Contract;
using Dijkstra.NET.ShortestPath;


public class ProfiterShortestPathLib : MonoBehaviour {
    static Dictionary<int, string> routeNodeMapDict = new Dictionary<int, string>();
    static Dictionary<string, int> routeNodeMapIDDict = new Dictionary<string, int>();

    // Use this for initialization
    void Start () {

    }
    /// <summary>
    /// This function will be used to process the JSON received from the backend and extract the connected routes from the JSON
    /// </summary>
    /// <param name="jsonFromBackend"></param>
    /// <returns>
    /// This returns an JObject which contains the valid routes received from the backend this object should be used by the consumer to determine the valid routes in the map.
    /// If no routes are found in the JSON provided then returns a null value
    /// </returns>
    public JObject ExtractRoutes(JObject jsonFromBackend)
    {
        JProperty temp = jsonFromBackend.Property("routes");
        JObject routesFromBackend = JObject.Parse(temp.Value.ToString());
        return routesFromBackend;
    }

    /// <summary>
    /// This function will be used to create graph for the cities obtained from the backend
    /// Extracts the route_nodes from the jsonFromBackend
    /// Creates the graph with the connected routes from the backend from the source and destination
    /// Retunrs Graph<int, string>
    /// </summary>
    /// <param name="jsonFromBackend"></param>
    /// <param name="jObjRoutesJosn"></param>
    public Graph<int, string> CreatesRouteGraph(JObject jsonFromBackend, JObject jObjRoutesJosn)
    {
        JProperty jPropertyRouteNodes = jsonFromBackend.Property("route_nodes");
        var routeNodesGraph = new Graph<int, string>();
        int count = 0;

        foreach (var item in jPropertyRouteNodes.Value.ToString().Split(','))
        {
            routeNodesGraph.AddNode(count);
            routeNodeMapDict.Add(count, item.Trim());
            routeNodeMapIDDict.Add(item.Trim(), count);
            count += 1;
        }
        foreach (var item in jObjRoutesJosn)
        {
            Console.WriteLine(item.Value["route_enabled"]);
            if (item.Value["route_enabled"].ToString() == "True")
            {
                routeNodesGraph.Connect(Convert.ToUInt32(routeNodeMapIDDict[item.Value["source"].ToString()]),
                Convert.ToUInt32(routeNodeMapIDDict[item.Value["destination"].ToString()]),
                Int32.Parse(item.Value["distance"].ToString()) *
                Int32.Parse(item.Value["weight"].ToString()) *
                Int32.Parse(item.Value["traffic_multiplier"].ToString()), "");
            }
        }
        return routeNodesGraph;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    /// <param name="dijkstra"></param>
    /// <returns></returns>
    public IEnumerable<uint> GetShortestPath(string source, string destination, Dijkstra<int, string> dijkstra)
    {
        IShortestPathResult iShortestPathResult = dijkstra.Process(Convert.ToUInt32(routeNodeMapIDDict[source]), Convert.ToUInt32(routeNodeMapIDDict[destination]));
        var shortestPathResult = iShortestPathResult.GetPath();
        return shortestPathResult;
    }





    // Update is called once per frame
    void Update () {
		
	}
}
