using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

/// <summary>
/// 加密类
/// </summary>
public  class GetChatTool
{
    public enum PropEnum
    {
        MaxAttack,
        MinAttack,
        CritValue,
        CritDmg,
        CritRate,
        CritRateValue,
        CritRateChange,
        CritDmgChange,
        BreakV,
        Pierce,
        CritDef,
        CritDefValue,
        CritDefChange,
        InjuryRate,
        Defence,
        CurHP,
        MaxHP,
        MaxArmor,
        ArtId
    }
    private static System.Random rand = new System.Random(DateTime.Now.Millisecond);
    private  Dictionary<PropEnum, long> tempRelPropDic = new Dictionary<PropEnum, long>();
    private  long[] falsePropList = new long[1];
    private  Dictionary<PropEnum, int> propKeyDic = new Dictionary<PropEnum, int>();
    private  Dictionary<PropEnum, string> md5PropDic = new Dictionary<PropEnum, string>();
    private  Dictionary<PropEnum, long> serverDataDic = new Dictionary<PropEnum, long>();
    public GetChatTool()
    {
		SetProp(PropEnum.MaxAttack, -1);
		SetProp(PropEnum.MinAttack, -1);
		SetProp(PropEnum.CritValue, -1);
		SetProp(PropEnum.CritDmg, -1);
		SetProp(PropEnum.CritRate, -1);
		SetProp(PropEnum.CritRateValue, -1);
		SetProp(PropEnum.CritRateChange, -1);
		SetProp(PropEnum.CritDmgChange, -1);
		SetProp(PropEnum.BreakV, -1);
		SetProp(PropEnum.Pierce, -1);
		SetProp(PropEnum.CritDef, -1);
		SetProp(PropEnum.CritDefValue, -1);
		SetProp(PropEnum.CritDefChange, -1);
		SetProp(PropEnum.InjuryRate, -1);
		SetProp(PropEnum.Defence, -1);
		SetProp(PropEnum.CurHP, -1);
		SetProp(PropEnum.MaxHP, -1);
		SetProp(PropEnum.MaxArmor, -1);
		SetProp(PropEnum.ArtId, -1);
    }

    public  void SetProp(PropEnum propEnum, int propValue)
    {
        md5PropDic.Clear();
        if (!propKeyDic.ContainsKey(propEnum))
        {
            propKeyDic.Add(propEnum, -1);
        }
        else
        {
            falsePropList[propKeyDic[propEnum]] = Sec(propValue);
        }

        foreach (var key in propKeyDic.Keys)
        {
            int k = propKeyDic[key];
            long v = 0;
            if (k == -1)
            {
                v = Sec(propValue);
            }
            else
            {
                v = falsePropList[k];
            }
            tempRelPropDic.Add(key, v);
            md5PropDic.Add(key, Md5Sec(v.ToString()));
        }

        propKeyDic.Clear();

        falsePropList = new long[tempRelPropDic.Count * 2];

        List<int> indexList = new List<int>();
        for (int i = 0; i < falsePropList.Length; i++)
        {
            indexList.Add(i);
        }
        List<int> tempIndexList = new List<int>();
        foreach (var key in tempRelPropDic.Keys)
        {
            int index = indexList[rand.Next(indexList.Count)];
            indexList.Remove(index);
            falsePropList[index] = tempRelPropDic[key];
            propKeyDic.Add(key, index);
            tempIndexList.Add(index);
        }
        tempRelPropDic.Clear();

        for (int i = 0; i < falsePropList.Length; i++)
        {
            long v = falsePropList[i];
            if (v == 0)
            {
                falsePropList[i] = falsePropList[tempIndexList[rand.Next(tempIndexList.Count)]];
            }
        }

        Utility.SortDictionary<PropEnum, int>(ref propKeyDic, (x, y) => { return rand.Next(100) > 50 ? 1 : 0; });
        Utility.SortDictionary<PropEnum, string>(ref md5PropDic, (x, y) => { return rand.Next(100) > 50 ? 1 : 0; });
    }

    private static long Sec(long v)
    {
        return v ^ 1830108;
    }

    public  long GetProp(PropEnum propEnum)
    {
        #if ARPG_Server
        return serverDataDic[propEnum];
        #endif

        long res = falsePropList[propKeyDic[propEnum]];
        string tempRes = Md5Sec(res.ToString());
        if (tempRes == md5PropDic[propEnum])
        {
            //Debug.Log("Get:" + propEnum + " value:" + Sec(res));
            return Sec(res);
        }
        else
        {
            return 0;
        }
    }

    private static string Md5Sec(string input)
    {
        byte[] result = Encoding.UTF8.GetBytes(input);
        MD5 m5 = new MD5CryptoServiceProvider();
        byte[] output = m5.ComputeHash(result);
        return Encoding.UTF8.GetString(output).Replace("-", "");
    }
}
