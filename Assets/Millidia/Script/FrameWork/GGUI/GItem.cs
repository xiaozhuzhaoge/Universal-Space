using UnityEngine;
using System.Collections;
using System;

public class GItem : MonoBehaviour
{

    public enum SystemTypePage
    {
    };

    public EventDelegate OnChange;
    private string name;
    public SystemTypePage system;
    public string Name
    {
        set
        {
            string oldv = name;
            name = value;
            if (OnChange != null && oldv != value)
                OnChange.Execute();

        }
        get { return name; }
    }


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Name = transform.name;
    }

    public void SetData()
    {
       
    }

}
