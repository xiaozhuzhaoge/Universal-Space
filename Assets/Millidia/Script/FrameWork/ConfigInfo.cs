using System;
using UnityEngine;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
class ConfigInfo
{
    public static ConfigInfo instance;
    public Dictionary<int, CardConfig> CARDS = new Dictionary<int, CardConfig>();
    public Dictionary<int, TaskConfig> TASK = new Dictionary<int, TaskConfig>();
    public Dictionary<int, ModelConfig> MODEL_RESOURCES = new Dictionary<int, ModelConfig>();
    public Dictionary<int, InitConfig> INIT_INFO = new Dictionary<int, InitConfig>();

    public Dictionary<int, LocaleConfig> LOCALES = new Dictionary<int, LocaleConfig>();
    public Dictionary<int, int> STATUS_LOCALE = new Dictionary<int, int>();
    public Dictionary<string, UIRuleConfig> UIRules = new Dictionary<string, UIRuleConfig>();
    public ConfigInfo()
    {
        instance = this;
        Init();
    }

    public static void Init()
    {
        ConfigReader.ReadArray2Class<CardConfig>("Cards", false, (list) =>
        {
            foreach (var data in list)
            {
                instance.CARDS.Add(data.ID, data);
            }

        });
    }


}

