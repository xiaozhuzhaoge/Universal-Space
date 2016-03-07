using UnityEngine;
using System.Collections;

public class TouchCreateWaterMark : MonoBehaviour {

    public GameObject prefab;
    public Transform root;
    public float CreatDelay = 1f;
    float StartTime;

	// Use this for initialization
	void Start () {
        StartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

      if (Input.GetMouseButtonDown(0))
      {
          CreateWaterMark();
      }
      
	}

    public void CreateWaterMark()
    {
        if (Time.time - StartTime < CreatDelay)
            return;

        GameObject waterMark = (GameObject)GameObject.Instantiate(prefab);
        waterMark.transform.parent = root;
        waterMark.transform.localPosition = UICamera.lastTouchPosition - new Vector2(Screen.width/2,Screen.height/2);
        waterMark.transform.localScale = Vector3.one;
        StartTime = Time.time;
        waterMark.SetActive(true);
    }

    void OnClick()
    {
        Debug.Log("Heeee");
    }
}
