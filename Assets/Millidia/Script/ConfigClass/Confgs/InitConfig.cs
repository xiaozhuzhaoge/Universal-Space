using UnityEngine;
using System.Collections;
using System;

public class InitConfig : IConfig
{
	public int id;
	public CareerType career;
	public int name;
	public int level;
	public Vector3 coordinate;
	public int map;
	public int modelId;
	public int weaponId;//道具编号
	public int head;
	public int type;
	public int task;
	public float direction;
	public float radius1;
	public float radius2;
	public float moveSpd;//m
	public string estEquip;//模型编号，逗号分隔
	public int estSkill;
	public int estPro;
	public int estText;

	public InitConfig ()
	{

	}

	public InitConfig (SimpleJson.JsonObject o)
	{
		Init (o);
	}

    #region IConfig implementation
	public void Init (SimpleJson.JsonObject o)
	{
		this.id = Convert.ToInt32 (o ["id"]);
		this.career = (CareerType)Convert.ToInt32 (o ["class"]);
		this.name = Convert.ToInt32 (o ["name"]);
		this.level = Convert.ToInt32 (o ["level"]);
		this.type = Convert.ToInt32 (o ["class"]);
		this.modelId = Convert.ToInt32 (o ["modelId"]);
		this.weaponId = Convert.ToInt32 (o ["weaponID"]);
		this.head = Convert.ToInt32 (o ["head"]);
		this.map = Convert.ToInt32 (o ["map"]);
		this.task = Convert.ToInt32 (o ["task"]);
		this.direction = Convert.ToSingle (o ["direction"]);
		string[] coors = ((string)o ["coordinate"]).Split (',');
		this.coordinate = new Vector3 (Convert.ToSingle (coors [0]), Convert.ToSingle (coors [1]), Convert.ToSingle (coors [2]));
		this.radius1 = Convert.ToInt32 (o ["radius1"]) / 100f;
		this.radius2 = Convert.ToInt32 (o ["radius2"]) / 100f;
		this.moveSpd = Convert.ToInt32 (o ["moveSpd"]) / 100f;
		this.estEquip = Convert.ToString (o ["estEquip"]);
		this.estSkill = Convert.ToInt32 (o ["estSkill"]);
		this.estPro = Convert.ToInt32 (o ["estPro"]);
		this.estText = Convert.ToInt32 (o ["estText"]);
	}
    #endregion
}
