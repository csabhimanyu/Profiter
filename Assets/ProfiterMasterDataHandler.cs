using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfiterMasterDataHandler {
    enum Routes
    {
        jammu =         01,
        chandigrah,
        delhi,
        jaipur,
        ahmedabad,
        bhopal,
        patna,
        guwahati,
        kolkota,
        hyderabad,
        bhubaneswar,
        mumbai,
        bengaluru,
        chennai,
        trivandrum
    }

    enum Goods
    {
        rice =          01,
        wheat,
        dal,
        mango,
        banana,
        apple,
        tea,
        coffee,
        vegetableoil,
        ghee,
        potato,
        onion,
        tomato,
        flowers
    }

    public static string enumMapper(string type, int value)
    {
        switch (type)
        {
            case "routes":
                return Enum.GetName(typeof(Routes), value).ToString();
            case "goods":
                return Enum.GetName(typeof(Goods), value).ToString();
            default:
                return null;
        }
    }

}
