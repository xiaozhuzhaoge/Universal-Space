using UnityEngine;
using System.Collections;

public class DynmaicLabel : MonoBehaviour {

    public UILabel text;
    public UISprite back;
    public UISprite face;
    public GameObject faceItem;

    public int height;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    [ContextMenu("Reset")]
    public void Reset()
    {
        back.height = text.height + height;

    }


}
