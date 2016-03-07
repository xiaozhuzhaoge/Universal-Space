using UnityEngine;
using System.Collections;
using System;

public enum MapUIType
{
    PEACE=1,
    PVE=2,
    PVP=3,
	Money=4,
	Exp=5,
	LegionSeal=6,
	PkKingReady=7,
	PkKingFight=8,
	TimeSpaceDun=9,
	AwakeDun=10,
	PkKingRest=11,
	VipDun=12,
	WorldBoss=13,
	RockCave=14,
}

public enum MapType
{
	Null=-1,
	Open=1,
	Dungeon=2,
	Arena=3,
	Babel=4,
	TownMagic=5,
	MoneyDun=6,
	ExpDun=7,
	Legion=8,
	EquipDun=9,
	PkKingReadyDun=10,
	PkKingFightDun=11,
	WorldBoss=12,
	TimeSpaceDun=14,
	AwakeDun=15,
	RockCave=16,
	VipDun=17
}

public class MapConfig : IdIconfig
{
	//public int id;
    public string  name;
    public int  levelLimit;
    public int  levelMax;
    public int  condition;
    public int  safeType;
	public MapType  mapType;
	public MapUIType  ui;
	public int  mapGroup;
	public int  dungeonType;
	public int  cost;
	public int  moduleId;
	public int  music;
	public int  inPos;
	public int  relivePos;
	public int  reliveLimit;
	public int  reliveTimes;
	public int  reliveGroup;
	public int  recoverLimit;
	public int  liveTime;
	public int  playerMax;
	public int  inCond;
	public int  inFunct;
	public int  outCond;
	public int  outFunct;
	public int  subType;
	public int  scriptId;
	public bool ifAuto;
	public bool ifSync;
	public bool  showMinimap;
    public int seekId;
    public string loadingUI;
    public string action;

    public MapConfig()
    {

    }

    public MapConfig(SimpleJson.JsonObject o)
    {
        Init(o);
    } 

    #region IConfig implementation

	public override void Init (SimpleJson.JsonObject o)
	{
		id = Convert.ToInt32 (o ["mapId"]);
		name = Convert.ToString (o ["name"]);
		levelLimit = Convert.ToInt32 (o ["levelLimit"]);
		levelMax = Convert.ToInt32 (o ["levelMax"]);
		condition = Convert.ToInt32 (o ["condition"]);
		safeType = Convert.ToInt32 (o ["safeType"]);
		mapType = (MapType)Convert.ToInt32 (o ["mapType"]);
		ui = (MapUIType)Convert.ToInt32 (o ["interface"]);
		mapGroup = Convert.ToInt32 (o ["mapGroup"]);
		dungeonType = Convert.ToInt32 (o ["dungeonType"]);
		moduleId = Convert.ToInt32 (o ["moduleId"]);
		inPos = Convert.ToInt32 (o ["inPos"]);
		relivePos = Convert.ToInt32 (o ["relivePos"]);
		reliveLimit = Convert.ToInt32 (o ["reliveLimit"]);
		reliveTimes = Convert.ToInt32 (o ["reliveTimes"]);
		reliveGroup = Convert.ToInt32 (o ["reliveGroup"]);
		recoverLimit = Convert.ToInt32 (o ["recoverLimit"]);
		liveTime = Convert.ToInt32 (o ["liveTime"]);
		playerMax = Convert.ToInt32 (o ["playerMax"]);
		inCond = Convert.ToInt32 (o ["inCond"]);
		inFunct = Convert.ToInt32 (o ["inFunct"]);
		outCond = Convert.ToInt32 (o ["outCond"]);
		outFunct = Convert.ToInt32 (o ["outFunct"]);
		scriptId = Convert.ToInt32 (o ["scriptId"]);   
		this.subType = Convert.ToInt32 (o ["subType"]);
		this.ifAuto = Convert.ToInt32 (o ["ifAuto"]) == 1;
		this.ifSync = Convert.ToInt32 (o ["ifSync"]) == 1;
	    showMinimap = Convert.ToInt32(o["showMinimap"]) == 1;
		this.music = Convert.ToInt32(o["music"]);
        this.seekId = Convert.ToInt32(o["seekId"]);
        this.loadingUI = Convert.ToString (o ["loadingUi"]);
        this.action = Convert.ToString(o["action"]);
	}
    
    #endregion

   
}
