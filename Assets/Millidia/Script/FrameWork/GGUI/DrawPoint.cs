using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DrawPoint : MonoBehaviour {

    public LineRenderer render;
    public Camera ca;
    List<Vector3> point = new List<Vector3>();
    
	// Use this for initialization
	void Start () {
        ca = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        DrawPointm();
	}

    void OnGUI()
    {
        GUILayout.Label(Input.mousePosition.ToString());

    }

    void DrawPointm()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Vector3 here = Input.mousePosition;
            Debug.Log(here);
            point.Add(here);
            UpdateLine();
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    }

    void UpdateLine()
    {
        render.SetVertexCount(point.Count);
        for (int i = 0; i < point.Count; i++)
            render.SetPosition(i, point[i]);
    }

}
