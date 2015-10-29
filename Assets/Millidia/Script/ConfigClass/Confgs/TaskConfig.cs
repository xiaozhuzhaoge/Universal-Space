using UnityEngine;
using System.Collections;
using System;

public enum TaskMechanism
{
    MAIN=1,
    DRAGON=2,
    SUB1=3,
    SUB2=4,
    GUIDE=5
}

public class TaskConfig : IConfig
{
    public int id;
    public string name;
    public int level;
    public int limitId;
    public int limitTimes;
    public int start;
    public int end;
    public TaskMechanism mechanism;
    public int groupId;
    public int cmpType;
    public int objective;
    public int seekId1;
    public int seekId2;
    public int seekId3;
    public int amount;
    public string depict;
    public string desc;
    public int exp;
    public int armorExp;
    public int money;
    public int props;
    public int next;
    public int chapterGroup;
    public int dungeon;
    public int giveup;

    public TaskConfig()
    {

    }

    public TaskConfig(SimpleJson.JsonObject o)
    {
        Init(o);
    }

    #region IConfig implementation
    public void Init(SimpleJson.JsonObject o)
    {
        this.id = Convert.ToInt32(o ["id"]);
        this.name = Convert.ToString(o ["name"]);
        this.level = Convert.ToInt32(o ["level"]);
        this.limitId = Convert.ToInt32(o ["limitId"]);
        this.limitTimes = Convert.ToInt32(o ["limitTimes"]);
        this.start = Convert.ToInt32(o ["start"]);
        this.end = Convert.ToInt32(o ["end"]);
        this.mechanism = (TaskMechanism)Convert.ToInt32(o ["mechanism"]);
        this.groupId = Convert.ToInt32(o ["groupId"]);
        this.cmpType = Convert.ToInt32(o ["type"]);
        this.objective = Convert.ToInt32(o ["objective"]);
        this.seekId1 = Convert.ToInt32(o ["seekId1"]);
        this.seekId2 = Convert.ToInt32(o ["seekId2"]);
        this.seekId3 = Convert.ToInt32(o ["seekId3"]);

        this.next = Convert.ToInt32(o ["continue"]);

        this.amount = Convert.ToInt32(o ["amount"]);
        this.depict = Convert.ToString(o ["depict"]);
        this.desc = Convert.ToString(o ["desc"]);
        this.exp = Convert.ToInt32(o ["exp"]);
        this.armorExp = Convert.ToInt32(o["armorExp"]);
        this.money = Convert.ToInt32(o ["money"]);
        this.props = Convert.ToInt32(o ["props"]);

        this.chapterGroup = Convert.ToInt32(o ["section"]);
        this.dungeon = Convert.ToInt32(o ["dungeon"]);
        //this.giveup = Convert.ToInt32(o["giveup"]);
    }
    #endregion

}
