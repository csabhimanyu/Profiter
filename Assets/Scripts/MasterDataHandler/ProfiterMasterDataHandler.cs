using System;

public class ProfiterMasterDataHandler {
    enum CityMarketPlace
    {
        //00 to 49 market places list
        jammu =         00,
        chandigrah =    01,
        ahmedabad =     02,
        bhopal =        03,
        patna =         04,
        bhubaneswar =   05,
        hyderabad =     06,
        trivandrum =    07,

        //50 to 99 city places list
        delhi =         50,
        jaipur =        51,
        guwahati =      52,
        kolkota =       53,
        mumbai =        54,
        bengaluru =     55,
        chennai =       56
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
            case "CityMarketPlace":
                return Enum.GetName(typeof(CityMarketPlace), value).ToString();
            case "goods":
                return Enum.GetName(typeof(Goods), value).ToString();
            default:
                return null;
        }
    }

}
