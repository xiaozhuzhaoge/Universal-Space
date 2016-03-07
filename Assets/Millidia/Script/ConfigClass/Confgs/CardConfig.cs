using UnityEngine;
using System.Collections;
using SimpleJson;
using System.Collections.Generic;
using System;

public class CardConfig : IConfig{

    private int id;
    public int ID { get { return id; } set { id = value; } }
    
    private string cardName;
    public string CardName { get { return cardName; } set { cardName = value; } }
    
    private int hp;
    public int HP { get { return hp; } set { hp = value; } }
    
    private int mp;
    public int MP { get { return mp; } set { mp = value; } }
    

    
    public int ATK;
    public int DEF;
    public int INT;
    public int LUK;
    public int ADV;
    public int RES;



    private int ap;
    public int AP { get { return ap; } set { ap = value; } }
    
    private int level;
    public int LEVEL { get { return level; } set { level = value; } }
    
    private int exp;
    public int EXP { get { return exp; } set { exp = value; } }

    public int Rank;
    public int Quality;
    public int Category;

    public string ICON;

    public CardConfig()
    { 
       
    }

    public CardConfig(JsonObject obj)
    {
        Init(obj);
    }

    public void Init(JsonObject data)
    {
        ID = Convert.ToInt32(data["Id"]);
        CardName = Convert.ToString(data["Name"]);
        Rank = Convert.ToInt32(data["Rank"]);
        Quality = Convert.ToInt32(data["Rank"]);
        Category = Convert.ToInt32(data["Rank"]);
        ICON = Convert.ToString(data["ICON"]);
        ATK = Convert.ToInt32(data["ATK"]);
        DEF = Convert.ToInt32(data["DEF"]);
        INT = Convert.ToInt32(data["INT"]);
        LUK = Convert.ToInt32(data["LCK"]);
        ADV = Convert.ToInt32(data["ADV"]);
        RES = Convert.ToInt32(data["RES"]);
    }
}
