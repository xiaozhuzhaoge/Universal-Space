using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestTttt :   {

    public delegate Tyr Finish();
    public Finish finish;
    public List<Finish> types = new List<Finish>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void Open(Finish fish)
    {
        types.Add(fish);
    }

    void A()
    {
        Debug.Log("A");
    }

    void B()
    {
        Debug.Log("B");
    }

    void C()
    {
        Debug.Log("C");
    }

   
    
}
