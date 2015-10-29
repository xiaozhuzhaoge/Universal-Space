using UnityEngine;
using System.Collections;
using System;

public enum ActionType
{
	warrior = 101,
	assassin = 201,
	warriorG = 102,
	assassinG = 202,
	npc = 301,
	
	JianDunBing = 401,
	GongJianBing = 402,
	NanMan = 403,
	JiGuanShou = 404,
	LiRenJiGuanBing = 405,
	RongYanMoXiang = 406,
	RongYanMoHu = 407,
	LaoHu = 408,
	Lang = 409,
	WuYi = 410,
	
	ChangBingBing = 412,
	FeiLunJiGuanBing = 413,
	FuChuiJiGuanBing = 414,
	NvManBing = 415,
	LvBu = 501,
	MengHuo = 502,
	ZhuRong = 503,
	ZhenJi = 504,
	XiaHouDun = 505,
	ZhouYu = 506,
	HuangGai = 507,
	DianWei = 508,
	ZhangLiao = 509,
	DiaoChan = 510,
	WeiYan = 511,
	CaoRen = 512,
	XiuLuo = 513,
	MoHuaZhenJi = 514,
	MoHuaMengHuo = 515,
	MoHuaZhuRong = 516,
	MoHuaLvBu = 517,
	ZhaoYun = 518,
	XiaoQiao = 519,
	GuanPing = 520,
	SunShangXiang = 521,
	TaiShiCi = 522,
	RenXingZaBing = 523,
	ShouChengKuiLei = 524,

	GoldCoin = 601,
	ExpBoss = 602,
	CoinGuarder = 603,
	LightBall = 604,
	Mineral = 605,

	decoration = 701,
	MuXiang = 901,
	MuTong = 902,
	MuZhaLan = 903,
	ShaDaiQiang = 904,
	DaoDiMuTong = 905,
	TaoGuan = 906,

	DiCi = 801,
	DiaoXiang = 802

}

public class ModelConfig : IConfig
{
	public int id;
	public int modelId;
	public string name;
	public ActionType action;
	public WeaponType weapon;
	public int attack;
	public int hit;
	public int die;
	public int move;
	public int effect;
	public int bornArt;
	public int deathArt;
	public int hitArt ;
	public int armorHitArt;
	public int noArmorArt;

	public ModelConfig ()
	{

	}

	public ModelConfig (SimpleJson.JsonObject o)
	{
		Init (o);
	}

	public bool IsDecoration()
	{
		return ((int)action >= 701 && (int)action <= 950);
	}

    #region IConfig implementation

	public void Init (SimpleJson.JsonObject o)
	{
		id = Convert.ToInt32 (o ["id"]);
		modelId = Convert.ToInt32 (o ["modelId"]);
		name = Convert.ToString (o ["name"]);
		action = (ActionType)Convert.ToInt32 (o ["type1"]);
		weapon = (WeaponType)Convert.ToInt32 (o ["type2"]);

		attack = Convert.ToInt32 (o ["attack"]);
		hit = Convert.ToInt32 (o ["hit"]);
		die = Convert.ToInt32 (o ["die"]);
		move = Convert.ToInt32 (o ["move"]);
		effect = Convert.ToInt32 (o ["effect"]);
		bornArt = Convert.ToInt32 (o ["bornArt"]);
		deathArt = Convert.ToInt32 (o ["deathArt"]);
		hitArt = Convert.ToInt32 (o ["hitArt"]);
		armorHitArt = Convert.ToInt32 (o ["armorHitArt"]);
		noArmorArt = Convert.ToInt32 (o ["noArmorArt"]);
	}

    #endregion
}
