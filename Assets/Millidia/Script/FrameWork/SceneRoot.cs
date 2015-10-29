using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJson;
using System.Linq;

public class SceneRoot : MonoBehaviour
{
	static public SceneRoot instance;
	[NonSerialized]
	public List<GameObject> SceneCache = new List<GameObject> ();
	public int curLoadIndex = 0;
	public SceneContainer curScene;
	public Transform sceneRoot;
	public Transform characterRoot;
	public Transform effectRoot;
	public Transform soundRoot;
	public Transform tempRoot;

	public GameObject player;
	public int defaultPlayerMapID;
	public List<CharInfo> nextLevelDefaultPlayers = new List<CharInfo> ();
	public Camera MapCamera;

	void Awake ()
	{
		SceneRoot.instance = this;
	}
    
    public float updateInterval = 1F;
    private float lastInterval;
    private int frames = 0;
    public float FPS;
    public float FPSLimit = 10.5f;
	void Start ()
	{
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
	}

  
    void Update()
    {
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            FPS = frames / (timeNow - lastInterval);
            frames = 0;
            lastInterval = timeNow;
        }

    }

	public event Action OnLevelWasLoadedEvent;

	public bool wasSceneLoaded = false;

	IEnumerator InitScene ()
	{  
		yield return new WaitForSeconds (0.01f);

		if (SceneRoot.instance.curScene != null) {

			MapConfig mapinfo = PlayerData.curLevel.config;

			GUIRoot.instance.loading.SetLoadingPercent (80);
			SceneRoot.instance.ResetCharInfo ();
			SceneRoot.instance.SpawnGateWay ();
			SceneRoot.instance.SpawnAreaObject ();
			GUIRoot.instance.loading.SetLoadingPercent (90);

			RefreshAutoSpawnMonster ();
		}        
		GUIRoot.instance.loading.SetLoadingPercent (100);

		if (PlayerData.curLevel != null && PlayerData.curLevel.config != null) {         
		} else {
			GUIRoot.instance.loading.SetLoadingPercent (100, true);
		}           

		yield return new WaitForSeconds (0.8f);
        
		if (PlayerData.curLevel != null && !PlayerData.curLevel.config.ifSync) {
			if( PlayerData.curLevel.config.mapType != MapType.Dungeon ) {
				GUIRoot.instance.loading.CancelLoading ();
			}
		} else if( PlayerData.curLevel == null )
		{
			GUIRoot.instance.loading.CancelLoading ();
		}
		AfterProcessLoaded ();
		wasSceneLoaded = true;
    }

	
	

	void FixedUpdate ()
	{

	}


	void ResetCharInfo ()
	{
		if (PlayerData.curLevel.config.ui == MapUIType.PEACE) {
			PlayerData.curCharacter.CurHP = PlayerData.curCharacter.MaxHP;
			PlayerData.curCharacter.CurArmor = PlayerData.curCharacter.MaxArmor;
			PlayerData.curCharacter.curPower = PlayerData.curCharacter.maxPower;
		}
	}

	

	public event Action<IBattleInfo> OnIBattleInfoInstantiated ;

	
	public void SpawnCharacter (CharInfo charInfo, CharacterType type, bool AIActive, Vector3 pos, Vector3 angles, Action<GameObject> callback=null)
	{
		
	}


	public void SpawnMonster (MonsterConfig monster, int level, int HP, int armor, int maxArmor, Vector3 pos, float dir, BoolAction<GameObject> Cb = null)
	{

	}

	public void RefreshAutoSpawnMonster ()
	{
		
	}

	Dictionary<int,GameObject> preloadMonsters = new Dictionary<int, GameObject> ();

	void PreLoadMonster (MonsterConfig monster)
	{

	}

	public void LoadSceneByConfig (string UI, string level)
	{      
		wasSceneLoaded = false;

		if (!String.IsNullOrEmpty (UI) && (UI.Equals ("login") || UI.Equals ("choose"))) {
			PlayerData.curLevel = null;
		}

		GUIRoot.instance.loading.ShowLoading ();

		curLoadIndex ++;
		Utility.StartSceneCoroutine<string,string> (LoadProcess, UI, level);
	}



	public string targetSundries;
	string loadLevel = "";

	IEnumerator LoadProcess (string ui, string level)
	{
        curScene = null;
        CharactersRoot.instance.characters.Clear ();
        CharactersRoot.instance.ghosters.Clear ();
      
        preloadMonsters.Clear ();

        foreach (GameObject go in SceneCache) {
            if (go != null) {
                Destroy (go);
            }
        }
        SceneCache.Clear ();  
        yield return new WaitForSeconds (0.01f);//等待 destroy 执行完成
        yield return Resources.UnloadUnusedAssets ();
        GC.Collect ();

		GUIRoot.instance.loading.SetLoadingPercent (40);
		yield return new WaitForSeconds (0.01f);

		if (!String.IsNullOrEmpty (level)) {


			//Application.LoadLevel ("empty");
			loadLevel = level;

			Application.LoadLevel (loadLevel);
			targetSundries = ui;


		} else {
			LoadSundries (ui);
		}
	}

	void OnLevelWasLoaded ()
	{
		LoadSundries (targetSundries);
	}


	void AfterProcessLoaded ()
	{
		if (SceneRoot.instance.curScene == null)
			return;
		
	   
	}

	void LoadSundries (string target)
	{
		GUIRoot.instance.loading.SetLoadingPercent (60);

		if (!String.IsNullOrEmpty (target)) {	

			LoadEffect (target);
			LoadSound (target);
			LoadGUI (target);
			print ("LoadGUI over=\t" + Time.realtimeSinceStartup);
		}

		if (OnLevelWasLoadedEvent != null) {
			OnLevelWasLoadedEvent ();
		}
	
	}

    public void StartInitScene()
	{
        StopInitScene();
		StartCoroutine("InitScene");
	}
	public void StopInitScene()
	{
		StopCoroutine("InitScene");
	}

	void LoadEffect (string target)
	{

	}

	void LoadSound (string target)
	{
		
	}

	void LoadGUI (string target)
	{
		print ("start LoadGUI=\t" + Time.realtimeSinceStartup);

		foreach (string gui in SpaceApplication.instance.sundries["ui"][target]) {
			GUIRoot.instance.LoadSceneGUI (gui);
			print (gui + " Loaded=\t" + Time.realtimeSinceStartup);
		}

	}
    
	public void SpawnGateWay ()
	{
		
	}


	public void SpawnAreaObject ()
	{
	
	}



	public void SpawnObstructObject (MonsterConfig monster, IBattleInfo ghost)
	{
		
	}

}