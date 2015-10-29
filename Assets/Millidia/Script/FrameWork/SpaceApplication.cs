using UnityEngine;
using System.Collections.Generic;
using SimpleJson;
using System.Collections;
using System;
using System.IO;

public class SpaceApplication : MonoBehaviour
{
    static public SpaceApplication instance;
    public static string version = "";
    public string locale = "zh_CN";
    public Dictionary<string,int> assetsVersion = new Dictionary<string, int>();
    [NonSerialized]
    public string
        host;
    [NonSerialized]
    public string
        staticUrl;
    public static float bgmVolume = 1;
    public static float effectVolume = 1;
    public static bool mainLogic = false;
    public int serverOnly = -1;
	public Dictionary<string, Dictionary<string, List<string>>> sundries = new Dictionary<string, Dictionary<string, List<string>>> ();
	public static JsonObject configs;
    public static string url = "";

    void Awake()
    {
		print ("Awake=" + Time.realtimeSinceStartup);
        SpaceApplication.instance = this;
        DontDestroyOnLoad(this);

		InitResourceConfig();
		configs = (JsonObject)((JsonObject)ConfigReader.ReadJsonConfigObject("version", null))["configs"];
        JsonObject config = (JsonObject)ConfigReader.ReadJsonConfigObject("config", null);
        host = Convert.ToString(config ["host"]);
        staticUrl = host + Convert.ToString(config ["static"]);
        version = Convert.ToString(config ["cli_version"]);
        url = Convert.ToString(config["crashReport"]);
        PlayerData.cid = PlayerPrefs.GetString("cid");
		ConfigInfo.Init ();

        Application.targetFrameRate = 30;

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if(config.ContainsKey("serverOnly"))
            serverOnly = Convert.ToInt32(config["serverOnly"]);

        SetupReporter ();
        SetupCrashCatcher ();
        SetupRegisterLogCallback ();
    }

    public bool debugMode = false;
	public bool startClient = true;
	public bool md5pwd = false;

    void Start()
    {
        GUIRoot.instance.loading.ShowLoading(true);
        StartGame ();
    }


    public void StartGame()  
    {         
		GUIRoot.instance.loading.ShowLoading(true);
        //加载登陆配置文件
    } 

	void InitResourceConfig()
	{
		JsonObject resourceConfig = (JsonObject)ConfigReader.ReadJsonConfigObject ("resource", null);
		foreach (var name_config in resourceConfig) {
			foreach (var kv in (JsonObject)name_config.Value) {
				JsonArray obj = (JsonArray)kv.Value;
				List<string> items = new List<string> ();
				foreach (var g in obj) {
					items.Add ((string)g);
				}
				
				if (!sundries.ContainsKey (name_config.Key)) {
					sundries.Add (name_config.Key, new Dictionary<string, List<string>> ());
				}
				
				var config = sundries [name_config.Key];
				
				if (!config.ContainsKey (kv.Key)) {
					config.Add (kv.Key, new List<string> ());
				}
				
				config [kv.Key] = items;
			}
		}
	}

   
    Reporter reporter;
  
    void SetupReporter ()
    {
        #if !No_Reporter
        var go = new GameObject ("_reporter");
        go.AddComponent<ReporterMessageReceiver>();
        reporter = go.AddComponent<Reporter> ();
        reporter.size = new Vector2(25,25);
        reporter.maxSize = 20;
        reporter.numOfCircleToShow = 2;
        go.AddComponent<ReporterGUI> ();
        #endif
    }

    void SetupCrashCatcher(){
        //var go = new GameObject ("_CrashCatcher");
        //catcher = go.AddComponent<CrashCatcher>();
    }

    void SetupRegisterLogCallback(){
        Application.RegisterLogCallback(new Application.LogCallback(CaptureLog));
    }

    void CaptureLog(string condition, string stacktrace, LogType type)
    {
        reporter.CaptureLog (condition, stacktrace, type);
    }

}