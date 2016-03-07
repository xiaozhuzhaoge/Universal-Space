using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CardSlot : MonoBehaviour {

    public List<GameObject> slots = new List<GameObject>();
    List<CardInfo> cards = new List<CardInfo>();

	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
        //SetData();
	}

    public void SetData()
    {
        cards.Clear();
        slots.ForEach(item =>
        {
            if (item.GetComponentsInChildren<CardInfo>().Length != 0)
            {
                cards.Add(item.GetComponentsInChildren<CardInfo>().ToList<CardInfo>().First());
            }
        });

        Draw.instance.Reset();

        cards.ForEach(info =>
        {
            Draw.instance.ATK += info.config.ATK;
            Draw.instance.INT += info.config.INT;
            Draw.instance.DEF += info.config.DEF;
            Draw.instance.RES += info.config.RES;
            Draw.instance.ADV += info.config.ADV;
            Draw.instance.LUK += info.config.LUK;
        });
    }


}
