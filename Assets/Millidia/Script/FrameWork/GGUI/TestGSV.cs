using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestGSV : MonoBehaviour {

    public static TestGSV instance;

    public int count;
    public GGrid grid;
    private int index = 0;
    private int i = 0;
    public List<int> testData = new List<int>();
    public GItem itemPre;

    void Awake()
    {
        instance = this;
    }

    void AddTestList()
    {
        for(int i = 0 ; i < count ; i ++)
        {
            testData.Add(i*1000);
        }
    }


	void Start () 
    {
        AddTestList();
        Add();
	}

    private void Add()
    {
        grid.AddItem(count);
    }

}


