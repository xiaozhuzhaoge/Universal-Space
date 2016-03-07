using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SimpleJson;
using System.Linq;

public enum CareerType
{
	SWORDMAN=1,
	ASSASIN=2,
	DESTROYER = 3,
	TAOIST=4
}

public class CharInfo:IBattleInfo
{
    #region 战斗数据加密
    private GetChatTool gct = new GetChatTool();


    public int MinAttack
    {
        get
        {
            return (int)gct.GetProp(GetChatTool.PropEnum.MinAttack);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.MinAttack, value);
        }
    }
    public int MaxAttack
    {
        get
        {
            //return maxAttack;
            return (int)gct.GetProp(GetChatTool.PropEnum.MaxAttack);
        }
        set
        {
            //maxAttack = value;
            gct.SetProp(GetChatTool.PropEnum.MaxAttack, value);
        }
    }
    public int CritValue
    {
        get
        {
            return (int)gct.GetProp(GetChatTool.PropEnum.CritValue);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.CritValue, value);
        }
    }
    public int CritDmg
    {
        get
        {
            return (int)gct.GetProp(GetChatTool.PropEnum.CritDmg);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.CritDmg, value);
        }
    }
    public int CritRate
    {
        get
        {
            return (int)gct.GetProp(GetChatTool.PropEnum.CritRate);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.CritRate, value);
        }
    }
    public int CritRateValue
    {
        get
        {
            return (int)gct.GetProp(GetChatTool.PropEnum.CritRateValue);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.CritRateValue, value);
        }
    }
    public int CritRateChange
    {
        get
        {
            return (int)gct.GetProp(GetChatTool.PropEnum.CritRateChange);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.CritRateChange, value);
        }
    }
    public int CritDmgChange
    {
        get
        {
            return (int)gct.GetProp(GetChatTool.PropEnum.CritDmgChange);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.CritDmgChange, value);
        }
    }
    public int BreakV
    {
        get
        {
            return (int)gct.GetProp(GetChatTool.PropEnum.BreakV);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.BreakV, value);
        }
    }
    public int Pierce
    {
        get
        {
            return (int)gct.GetProp(GetChatTool.PropEnum.Pierce);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.Pierce, value);
        }
    }
    public int CritDef
    {
        get
        {
            return (int)gct.GetProp(GetChatTool.PropEnum.CritDef);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.CritDef, value);
        }
    }
    public int CritDefValue
    {
        get
        {
            return (int)gct.GetProp(GetChatTool.PropEnum.CritDefValue);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.CritDefValue, value);
        }
    }
    public int CritDefChange
    {
        get
        {
            return (int)gct.GetProp(GetChatTool.PropEnum.CritDefChange);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.CritDefChange, value);
        }
    }
    public int InjuryRate
    {
        get
        {
            return (int)gct.GetProp(GetChatTool.PropEnum.InjuryRate);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.InjuryRate, value);
        }
    }
    public int Defence
    {
        get
        {
            return (int)gct.GetProp(GetChatTool.PropEnum.Defence);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.Defence, value);
        }
    }
    public int CurHP
    {
        get
        {
            //return curHP;
            return (int)gct.GetProp(GetChatTool.PropEnum.CurHP);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.CurHP, value);

            if (OnHPChange != null)
            {
                OnHPChange(value);
            }
            if (OnProChange != null)
            {
                OnProChange();
            }
        }
    }
    public int MaxHP
    {
        get
        {
            //return maxHP;
            return (int)gct.GetProp(GetChatTool.PropEnum.MaxHP);
        }
        set
        {
            gct.SetProp(GetChatTool.PropEnum.MaxHP, value);
            if (OnProChange != null)
            {
                OnProChange();
            }
        }
    }    
    public int MaxArmor
    {
        get
        {
            //return maxArmor;
            return (int)gct.GetProp(GetChatTool.PropEnum.MaxArmor);
        }
        set
        {

            gct.SetProp(GetChatTool.PropEnum.MaxArmor, value);
            if (OnProChange != null)
            {
                OnProChange();
            }
        }
    }
    public int ArtId
    {
        get
        {
            //return artId;
            return (int)gct.GetProp(GetChatTool.PropEnum.ArtId);
        }

        set
        {
            gct.SetProp(GetChatTool.PropEnum.ArtId, value);
        }
    }
    #endregion

    public int signInCount;
    /// <summary>
    /// -1：未知 0：已经签到  1：没有签到
    /// </summary>
    public int isSignIn = -1;
	public List<int> receivedLevelGifts = new List<int> ();
	public List<int> receivedVipGifts = new List<int> ();
    public List<int> payRewards = new List<int>();
    public List<int> receivedPayRewards = new List<int>();
    public bool payRewardInTime = false;
	public long id;
	public string name;
	public string oldName;
	public CareerType career;
	public long loginTime;
    public long worldLevel;
	long exp;
    public bool showEquipTipFlag = false;

	public event Action OnLvUpEvent ;
	public event Action OnTaskChangedEvent;
	public event Action<int> OnHPChange;

	public event Action OnProChange;


    private int curArmor;
    public int CurArmor
    {
        get
        {
            return curArmor;
        }
        set
        {
            curArmor = value;
            if (OnProChange != null)
            {
                OnProChange();
            }
        }
    }
    public int DradonTaskBuyCount=0;
    public int DradonTaskCount = 0;
	int armorDef;
	public int defChange;
	int curMaxArmor;
	public int awakeLevel;
	public int freeChangeTimes;
	long armorExp;
	
	
	public int online;
	public int relation;//0：好友；1：黑名单；2：陌生人
	//public int keyNum;
    public long leaveTime;
	public long leaveExp;
	public int pkKillCount;
    public int freeReliveTimes;
	public int killValue;
    public TaskData LastPrizedMainTask = null;
	public int robotId=0;
	public string syncMoName="";

    /// <summary>
    /// ghost id ;;;item id;;;;item num
    /// </summary>
    public Dictionary<int, List<KeyValuePair<int, int>>> drops = new Dictionary<int, List<KeyValuePair<int, int>>>();

    private int vip;
    public int Vip
    {
        get
        {
            return vip;
        }
        set
        {
            var oldVip = vip;
            vip = value;
            if (oldVip < vip)
            {
                if (vipChangedEvent != null)
                {
                    vipChangedEvent();
                }
            }
        }
    }


    public int friendCount;
	public int blackListCount;
	public long awakeExp;
	public int bloodLv;
    private long bloodSoul;
    private long nucleus;
	public int curPower = 0;
	public int maxPower = 999999;
	public float PowerSpeed{
		get {
			return powerSpeedPer * maxPower + powerSpeedVal;
		}
	}
	public float powerSpeedPer;
	public int powerSpeedVal;

    private long gold;
    private long currency;
    public long courage;
	public int reliveTime;
    private long giftMoney;
  
	public long luckPoints;
	public int exploitLv;
	public long exploitExp;

	public long payCount;
    private long payGold;
    public long openTime;
	public Dictionary<long, CharInfo> lastPkPlayers = new Dictionary<long, CharInfo> ();
	int camp;

	public int OnlineCount = 0;
	public List<int> discount = new List<int> ();
	
	public long sessionId;

    public List<int> GeneralPasvSkills;
    public int onfightSkill = 0;

    public int luck=-1;

    public int curVitality = -1;

    public int curCanGetVitalityId = 0;
    public int nextCanGetVitalityId = -1;

    /// <summary>
    /// -1 有错误  0 未开始  1 进行中  2 可领取
    /// </summary>
    public int alchemyState = -1;
    public int canGetAlchemyExp = -1;

    /// <summary>
    /// -1：没有约战 0：刚刚完成或失败 其他：当前有约战
    /// </summary>
    public int fightId = -1;
    public static long lastLoginCharId = -1;

    public DateTime lastSiginTime;

	public struct SBuff
	{
		public int buffId;
		public int lastTime;
	}
	public List<SBuff> buffs = new List<SBuff>();

    public List<long> blacklistPlayersId = new List<long>();
	
	public enum ActionType
	{
		NORMAL,
		AI
	}

	public long nextSupplyTime;

	public void InitByID (int id)
	{
		this.id = id;
	}

	public JsonObject initJson;

	struct SAddBuff
	{
		public int buffId;
		public List<int> timeOverLays;
	}
	List<SAddBuff> addBuffs = new List<SAddBuff>();

	public void Init (JsonObject obj)
	{
		initJson = obj;
		reliveTime = -1;
		camp = 1;
        payRewards.Clear();
        receivedPayRewards.Clear();
        ArtId = -1;
        luck = -1;
	}


    #region 属性变化监听

    #region 被监听的属性
    public long Exp
    {
        get
        {
            return exp;
        }

        set
        {
          
        }
    }
    //Vip
    public long PayGold
    {
        get
        {
            return payGold;
        }

        set
        {                       
            payGold = value;
            //var oldVip = Vip; 
            //if (oldVip < Vip)
            //{
            //    if (vipChangedEvent != null)
            //    {
            //        vipChangedEvent();
            //    }
            //}
        }
    }
    /// <summary>
    /// 血魄
    /// </summary>
    public long BloodSoul
    {
        get
        {
            return bloodSoul;
        }

        set
        {            
            bloodSoul = value;
            if (bloodSoulChangedEvent != null)
            {
                bloodSoulChangedEvent();
            }
        }
    }
    /// <summary>
    /// 核心点 pieceNum
    /// </summary>
    public long Nucleus
    {
        get 
        {
            return nucleus;
        }

        set
        {
            nucleus = value;
        }
    }
    /// <summary>
    /// 元宝
    /// </summary>
    public long Gold
    {
        get
        {
            return gold;
        }

        set
        {            
            gold = value;
            if (goldChangedEvent != null)
            {
                goldChangedEvent();
            }
        }
    }
    /// <summary>
    /// 金钱
    /// </summary>
    public long Currency
    {
        get
        {
            return currency;
        }

        set
        {
            currency = value;
            if (currencyChangedEvent != null)
            {
                currencyChangedEvent();
            }
        }
    }
    /// <summary>
    /// 礼金
    /// </summary>
    public long GiftMoney
    {
        get
        {
            return giftMoney;
        }

        set
        {            
            giftMoney = value;
            if (giftMoneyChangedEvent != null)
            {
                giftMoneyChangedEvent();
            }
        }
    }
    

    #endregion

    public delegate void VipChangedEventHandler();
    public event VipChangedEventHandler vipChangedEvent;

    public delegate void BloodSoulChangedEventHandler();
    public event BloodSoulChangedEventHandler bloodSoulChangedEvent;

    public delegate void GoldChangedEventHandler();
    public event GoldChangedEventHandler goldChangedEvent;

    public delegate void CurrencyChangedEventHandler();
    public event CurrencyChangedEventHandler currencyChangedEvent;

    public delegate void GiftMoneyChangedEventHandler();
    public event GiftMoneyChangedEventHandler giftMoneyChangedEvent;

    public delegate void LevelChangedEventHandler();
    public event LevelChangedEventHandler levelChangedEvent;

    public delegate void DivisorChangedEventHandler();
    public event DivisorChangedEventHandler divisorChangedEvent;


    public void DivisorChange()
    {
        if (divisorChangedEvent != null)
        {
            divisorChangedEvent();
        }
    }

    #endregion
}
