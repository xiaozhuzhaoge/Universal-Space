using UnityEngine;
using System.Collections;
using System;

public enum MonsterRefreshType
{
	AUTO=1,
	TRIGGER=2
}

public class MonsterConfig : IConfig
{
	public float direction;
	public int id;
	public int posType;
	public Vector3 pos;
	public int monsterId;
	public string name;
	public int levelType;
	public int minLevel;
	public int maxLevel;
	public int liveTime;
	public int mapId;
	public int skinId;
	public int mkId;
	public int signId;
	public int minRetime;
	public int maxRetime;
	public MonsterRefreshType refreshType;
	public int refreshRadius;
	public int refreshId;
	public int script;
	public int obstruct;
	public int runaway;
	public MonsterConfig ()
	{

	}
    
	public MonsterConfig (SimpleJson.JsonObject obj)
	{
		Init (obj);
	}

	public void Init (SimpleJson.JsonObject obj)
	{
		direction = Convert.ToSingle (obj ["direction"]);
		id = Convert.ToInt32 (obj ["id"]);
		posType = Convert.ToInt32 (obj ["posType"]);
		pos = Utility.GetMapObjectPos ((string)obj ["posValue"]);
        
		monsterId = Convert.ToInt32 (obj ["monsterId"]);
		name = Convert.ToString (obj ["name"]);
		levelType = Convert.ToInt32 (obj ["levelType"]);
		minLevel = Convert.ToInt32 (obj ["minLevel"]);
		maxLevel = Convert.ToInt32 (obj ["maxLevel"]);
		liveTime = Convert.ToInt32 (obj ["liveTime"]);
		mapId = Convert.ToInt32 (obj ["mapId"]);
		skinId = Convert.ToInt32 (obj ["skinId"]);
		mkId = Convert.ToInt32 (obj ["mkId"]);
		signId = Convert.ToInt32 (obj ["signId"]);
		minRetime = Convert.ToInt32 (obj ["minRetime"]);
		maxRetime = Convert.ToInt32 (obj ["maxRetime"]);
		refreshType = (MonsterRefreshType)Convert.ToInt32 (obj ["refreshType"]);
		refreshRadius = Convert.ToInt32 (obj ["refreshRadius"]);
		refreshId = Convert.ToInt32 (obj ["refreshId"]);
		script = Convert.ToInt32 (obj ["script"]);   
		obstruct = Convert.ToInt32 (obj ["obstruct"]);
		runaway = Convert.ToInt32 (obj ["runaway"]);
	}

	public Vector3 GetWorldPos ()
	{
		return pos;
	}


}
