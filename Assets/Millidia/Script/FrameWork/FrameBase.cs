using UnityEngine;
using System.Collections;

public class FrameBase : MonoBehaviour {

    static public FrameBase instance;
    ConfigInfo config;
    void Awake()
    {
        config = new ConfigInfo();
    }

	// Use this for initialization
	void Start () {
	  
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
