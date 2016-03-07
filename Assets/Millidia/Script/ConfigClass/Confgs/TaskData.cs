using UnityEngine;
using System.Collections;
using System;
using SimpleJson;

public enum TaskStatus
{
    NONE = 0,
    ACCEPT=1,//已接，未完成
    COMPLETE=2,//完成，未提交
    PRIZED=3,//已经交付
    QUIT=4,//已经放弃
    BEFORE=5//未接
}

public class TaskData
{
    public int Count
    {
        get
        {
            if (TimeCom.IsYesterday(createTime))
            {
                return 0;
            } 
            return count;
        }
    }

   public int count;
    public int killCount = 0;//杀怪个数
    public long createTime;
    public long prizedTime;
    public long buyTime;
    public int templateID;
    public TaskStatus status;
    public int buyCount;
    public TaskMechanism taskType;
    public int starLevel;
    public int dragonId;

    public TaskConfig taskConfig
    {
        get
        {
           return ConfigInfo.instance.TASK [this.templateID];
        }

    }

    public int BuyCount
    {
        get
        {
            if (TimeCom.IsYesterday(buyTime))
            {
                return 0;
            }
            return buyCount;
        }
        set
        {
            buyCount = value;
        }
    }

    public TaskData()
    {
    }

    public TaskData(JsonObject o)
    {
        count = Convert.ToInt32(o ["count"]);
        killCount = Convert.ToInt32(o ["killCount"]);
        createTime = (long)Convert.ToInt64(o ["createtime"]);
        prizedTime = (long)Convert.ToInt64(o["finishtime"]);
        templateID = Convert.ToInt32(o ["tid"]);
        status = (TaskStatus)Convert.ToInt32(o ["status"]);       
        if (o.ContainsKey("buyCount"))
        {
            buyCount = Convert.ToInt32(o ["buyCount"]);
        }

        if (o.ContainsKey("buyTime"))
        {
            buyTime = (long)Convert.ToInt64(o ["buyTime"]);
        }

        taskType = (TaskMechanism)Convert.ToInt32(o ["taskType"]);

        if (o.ContainsKey("starLevel"))
        {
            starLevel = Convert.ToInt32(o["starLevel"]);
        }
    }
    public int GetStarRate(int random)
    {
        int[] startRates = { 250, 600, 1250, 1500, 1750, 1700, 1500, 850, 400, 200 };
        int[] rates = new int[10000];
        int index = 0;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < startRates[i]; j++)
            {
                rates[index] = i + 1;
                index++;
            }
        }
        return rates[random];
    }
}
