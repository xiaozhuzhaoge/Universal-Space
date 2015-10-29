using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CharactersRoot : MonoBehaviour
{
	static public CharactersRoot instance;
    public Dictionary<long, GameObject> characters = new Dictionary<long, GameObject>();
    public Dictionary<int, GameObject> ghosters = new Dictionary<int, GameObject>();
	public Dictionary<long, GameObject> names = new Dictionary<long, GameObject> ();
    GameObject target;

	
	void Awake ()
	{
		CharactersRoot.instance = this;
	}

	public enum Type
	{
		Character=1,
		Ghost=2,
		General=3
	}

	public enum AIType
	{
		None,
		PlayerWander,
		PlayerPK,
		PlayerPVE,	
		GhostCommonAI,
		Boss,
		General,
		Trigger,
		Robot
	}

	public GameObject Create (IBattleInfo info, ModelConfig modelConfig, CharacterType charType, AIType aiType, bool AIActive, string model =null, GameObject gameObject = null)
	{
		GameObject go = null;

		string modelName = String.IsNullOrEmpty (model) ? modelConfig.modelId.ToString () : model;
		if( charType == CharacterType.Character && 
		   				PlayerData.curLevel != null && 
		   							PlayerData.curLevel.config.ifSync ) {
			var charInfo = (info as CharInfo);
			charInfo.syncMoName = modelName;
		}

		if (gameObject == null) {
			//加载模型
			Utility.instance.LoadGameObject (("models/" + modelName), (m) => {
				go = m;
			});
		} else {
			go = gameObject;

		}
		go.SetActive(true);
		go.transform.parent = SceneRoot.instance.characterRoot;

		switch (charType) {
		case CharacterType.Character:
			var charInfo = info as CharInfo;
			//AssembleCharacter (charInfo, go);
			break;

		case CharacterType.Ghost:
			//AssembleGhost (info as GhostInfo, modelConfig, go);
			break;

	
		}



		AddAI (info, aiType, AIActive, go);
		return go;
	}

	
	void AddAI (IBattleInfo info, AIType type, bool AIActive, GameObject parent)
	{

	}

	void AssembleCharacter (CharInfo info, ModelConfig modelConfig, GameObject go)
	{
		go.name = "c_" + info.id;
	}
	void AssembleGhost (GhostInfo info, ModelConfig modelConfig, GameObject go)
	{
		go.name = "g_" + info.id;
	
	}

    static void SetShadow (GameObject go,BoolAction Condition)
    {
        Utility.instance.LoadGameObject ("template/projector", projector =>  {
            projector.transform.parent = go.transform;
            projector.transform.localPosition = Vector3.zero;
            projector.GetComponent<VisiableByCondition> ().Condition = Condition;
        });
    }

	void AssembleDecoration (GhostInfo info, ModelConfig modelConfig, GameObject go)
	{
	
	}
   
}
