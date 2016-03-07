using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Draw : MonoBehaviour {

    public static Draw instance;

    public float width = 10f;
    public float maxWidth = 70f;
    public float minWidth = 10f;

    public float factor = 0.2f;
    public float effect = 4f;
    float Atk;
    public float ATK { set { Atk = Mathf.RoundToInt(Mathf.SmoothStep(Atk, value, Time.deltaTime * effect)); } get { return Atk; } }

    float Int;
    public float INT { set { Int = Mathf.RoundToInt(Mathf.SmoothStep(Int, value, Time.deltaTime * effect)); } get { return Int; } }

    float Def;
    public float DEF { set { Def = Mathf.RoundToInt(Mathf.SmoothStep(Def, value, Time.deltaTime * effect)); } get { return Def; } }

    float Luk;
    public float LUK { set { Luk = Mathf.RoundToInt(Mathf.SmoothStep(Luk, value, Time.deltaTime * effect)); } get { return Luk; } }

    float Res;
    public float RES { set { Res = Mathf.RoundToInt(Mathf.SmoothStep(Res, value, Time.deltaTime * effect)); } get { return Res; } }

    float Adv;
    public float ADV { set { Adv = Mathf.RoundToInt(Mathf.SmoothStep(Adv, value, Time.deltaTime * effect)); } get { return Adv; } }


    public GameObject ga;
    public List<UILabel> labels = new List<UILabel>();

    void Awake()
    {
        instance = this;
    }
	// Use this for initialization
	void Start () {
        Reset();
	}
	
	// Update is called once per frame
	void Update () {
       
        MeshFilter meshFilter = (MeshFilter)ga.GetComponent<MeshFilter>();
        Mesh mesh = meshFilter.mesh;
        mesh.vertices = new Vector3[] { Vector3.zero, new Vector3(ATK * factor, 0, 0), new Vector3(0.5f * INT * factor, 0.866f * INT * factor, 0), 
            Vector3.zero, new Vector3(0.5f * INT * factor, 0.866f * INT * factor, 0), new Vector3(-0.5f * DEF * factor, 0.866f * DEF * factor, 0), 
            Vector3.zero, new Vector3(-0.5f * DEF * factor, 0.866f * DEF * factor, 0), new Vector3(-LUK * factor, 0, 0), 
            Vector3.zero, new Vector3(-LUK * factor, 0, 0), new Vector3(-0.5f * RES * factor, -0.866f * RES * factor, 0), 
            Vector3.zero, new Vector3(-0.5f * RES * factor, -0.866f * RES * factor, 0), new Vector3(0.5f * ADV * factor, -0.866f * ADV * factor, 0),
            Vector3.zero, new Vector3(0.5f * ADV * factor, -0.866f * ADV * factor, 0), new Vector3(ATK * factor, 0, 0)};
        
        mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1),
        new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1),
        new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1)};
        mesh.RecalculateNormals();
        mesh.triangles = new int[] {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17};
        SetValue();
	}

    void SetValue()
    { 
       labels[0].text = ((ATK * 100)).ToString();
       labels[1].text = ((INT * 100)).ToString();
       labels[2].text = ((DEF * 100)).ToString();
       labels[3].text = ((LUK * 100)).ToString();
       labels[4].text = ((RES * 100)).ToString();
       labels[5].text = ((ADV * 100)).ToString();
    }

    public void Reset()
    {
        ATK = width;
        INT = width;
        DEF = width;
        LUK = width;
        RES = width;
        ADV = width;
    }
    //void OnGUI()
    //{
    //    GUILayout.BeginVertical(GUILayout.Height(50));
    //    GUILayout.BeginHorizontal();
    //    GUILayout.Label("ATK:");
    //    ATK = GUILayout.HorizontalSlider(ATK, minWidth, maxWidth, GUILayout.Width(100));
    //    GUILayout.EndHorizontal();
      
    //    GUILayout.BeginHorizontal();
    //    GUILayout.Label("INT:");
    //    INT = GUILayout.HorizontalSlider(INT, minWidth, maxWidth, GUILayout.Width(100));
      
    //    GUILayout.EndHorizontal();
    //    GUILayout.BeginHorizontal();
    //    GUILayout.Label("DEF:");
    //    DEF = GUILayout.HorizontalSlider(DEF, minWidth, maxWidth, GUILayout.Width(100));
        
    //    GUILayout.EndHorizontal();
    //    GUILayout.BeginHorizontal();
    //    GUILayout.Label("LUK:");
    //    LUK = GUILayout.HorizontalSlider(LUK, minWidth, maxWidth, GUILayout.Width(100));
      
    //    GUILayout.EndHorizontal();
    //    GUILayout.BeginHorizontal();
    //    GUILayout.Label("RES:");
    //    RES = GUILayout.HorizontalSlider(RES, minWidth, maxWidth, GUILayout.Width(100));
       
    //    GUILayout.EndHorizontal();
    //    GUILayout.BeginHorizontal();
    //    GUILayout.Label("ADV:");
    //    ADV = GUILayout.HorizontalSlider(ADV, minWidth, maxWidth, GUILayout.Width(100));
       
    //    GUILayout.EndHorizontal();

    //    GUILayout.EndVertical();
    //}
}
