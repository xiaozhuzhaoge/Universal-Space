using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJson;

public class ConfigReader
{
    static string URL = "Values/";
    static string ReadConfig(string name, string content)
    {

        string _content = null;
        if (String.IsNullOrEmpty(content))
        {
            TextAsset ta = Resources.Load<TextAsset>(name);
            _content = ta.text;
        }
        else
        {
            _content = content;
        }
        return _content;
    }

    static public string ReadJsonConfig(string name, string content)
    {
        string _content = ReadConfig(name, content);
        return _content;
    }

    static public object ReadJsonConfigObject(string name, string content)
    {
        object output;
        var _content = ReadConfig(name, content);

        var result = SimpleJson.SimpleJson.TryDeserializeObject(_content, out output);
        if (!result)
        {
            throw new Exception("cant parse json:" + name);
        }
        return output;
    }


    public static UnityEngine.Object[] ReadDir(string path)
    {
        return Resources.LoadAll(path);
    }

    public static Hashtable cache = new Hashtable();

    public static void ReadObject2JsonObject(string configName, bool useCache, Action<JsonObject> callback, string content = null)
    {
        if (cache.ContainsKey(configName) && useCache)
        {
            callback((JsonObject)cache[configName]);
            return;
        }
        JsonObject temp = (JsonObject)SimpleJson.SimpleJson.DeserializeObject(ReadJsonConfig(configName, content));
        cache.Remove(configName);
        cache.Add(configName, temp);
        callback(temp);
    }

    public static void ReadArray2Class<T>(string configName, bool useCache, Action<List<T>> callback, string content = null) where T : IConfig, new()
    {
        if (cache.ContainsKey(configName) && useCache)
        {
            callback((List<T>)cache[configName]);
            return;
        }
        List<T> infos = new List<T>();
        configName = URL + configName;
        JsonArray temp = (JsonArray)SimpleJson.SimpleJson.DeserializeObject(ReadJsonConfig(configName, content));
        foreach (var val in temp)
        {
            JsonObject jo = (JsonObject)val;
            T item = new T();
            item.Init(jo);
            infos.Add(item);
        }

        cache.Remove(configName);
        cache.Add(configName, infos);
        callback(infos);
    }

    public static void ReadObject2Class<T>(string configName, bool useCache, Action<List<T>> callback, string content = null) where T : IConfig, new()
    {
        if (cache.ContainsKey(configName) && useCache)
        {
            callback((List<T>)cache[configName]);
            return;
        }
        List<T> infos = new List<T>();
        try
        {
            
            JsonObject temp = (JsonObject)SimpleJson.SimpleJson.DeserializeObject(ReadJsonConfig(configName, content));
            foreach (var val in temp)
            {
                JsonObject jo = (JsonObject)val.Value;
                T item = new T();
                item.Init(jo);
                infos.Add(item);
            }
        }
        catch (InvalidCastException e)
        {
            Debug.LogError("ReadObject2Class config name:" + configName);
            Debug.LogException(e);
        }

        cache.Remove(configName);
        cache.Add(configName, infos);
        callback(infos);
    }

    public static Dictionary<string, string> configs = new Dictionary<string, string>();

    public static void UpdateConfig(string configName, string config)
    {
        configs[configName] = config;
    }
}
