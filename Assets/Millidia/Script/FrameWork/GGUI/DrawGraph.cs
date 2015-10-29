using UnityEngine;
using System.Collections;

public class DrawGraph : MonoBehaviour {

    public int numEdge;
    public LineRenderer drawOutSideLine;
    public int boundSize;

	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        DrawLineOutSide();
	}

    public void DrawLineOutSide()
    {
        drawOutSideLine.name = "OutSide";
        drawOutSideLine.SetVertexCount(numEdge + 1);
        drawOutSideLine.SetPosition(0, new Vector3(0, (boundSize / 2) * Mathf.Sqrt(3), 0));
        drawOutSideLine.SetPosition(1, new Vector3((boundSize / 2) * Mathf.Sqrt(3), -boundSize / 2, 0));
        drawOutSideLine.SetPosition(2, new Vector3(-(boundSize / 2) * Mathf.Sqrt(3), -boundSize / 2, 0));
        drawOutSideLine.SetPosition(3, new Vector3(0, (boundSize / 2) * Mathf.Sqrt(3), 0));
  
    }
}
