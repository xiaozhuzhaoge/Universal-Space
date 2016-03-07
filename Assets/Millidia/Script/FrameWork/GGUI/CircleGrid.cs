using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CircleGrid : UIEventListener {

    public float degrees = 5;
    public Transform target;

    public Dictionary<float, Transform> items = new Dictionary<float, Transform>();
    public float rudis = 10;
    float oldvalue;
    float TimsStart = 0;
    public bool clamp = false;
    public float minValue = 0f;
    public float maxValue = 1000f;
    public float TimeDelay = 5f;
    public float speed = 4f;

	// Use this for initialization
	void Start () {
        DrawCircleState();
        Debug.Log(Mathf.Sin(30));
	}
	
	// Update is called once per frame
	void Update () {
        //PingPong();
        if(rudis != oldvalue)
        {
           oldvalue = rudis;
           SetPosition();
        }
      
	}

    void SetPosition()
    {
        if (items.Count > 0)
            foreach (var item in items)
            {
                //if(clamp)
                //    item.Value.GetComponent<TweenAlpha>().PlayForward();
                //else
                //    item.Value.GetComponent<TweenAlpha>().PlayReverse();
                item.Value.localPosition = new Vector3(-Mathf.Sin(Mathf.Deg2Rad * item.Key) * rudis, Mathf.Cos(Mathf.Deg2Rad * item.Key) * rudis, 0);
            }
    }

    void PingPong ()
    {
        if (Time.time - TimsStart > TimeDelay)
        {
            clamp = !clamp;
            TimsStart = Time.time;
        }

        if (clamp)
        {
            rudis = Mathf.Lerp(rudis, minValue, Time.deltaTime * speed);
            
        }

        else
        {
            rudis = Mathf.Lerp(rudis, maxValue, Time.deltaTime * speed);
        }
       
    }


    void AddCard(Transform card)
    {
        items.Add(card.localEulerAngles.z,card);
        card.parent = this.transform;
        card.localScale = Vector3.one;
    }

    void DrawCircleState()
    {
        float i = 0;
        while(i <= 360) 
        {    
            GameObject item = (GameObject)GameObject.Instantiate(target.gameObject);
            item.name = i.ToString();
            item.transform.localEulerAngles = new Vector3(0, 0, -i);
            AddCard(item.transform);
            i += degrees;
            item.gameObject.SetActive(true);
        }
    }

    public void OnDrag(Vector2 delta)
    {
      
    }
}
