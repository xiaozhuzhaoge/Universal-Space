using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CardBox : MonoBehaviour {

    public UIGrid CARDBOX;
    public GameObject CardPre;
    public UIScrollView sv;

	// Use this for initialization
	void Start () {
        CloneCard(10);
        CARDBOX.onReposition += SortCardBox;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SortCardBox()
    {
       int d = -1;
       //CARDBOX.GetChildList().ForEach(card => { d++; card.GetComponent<CardInfo>().texture.depth = d;});
       
    }

    void CloneCard(int num)
    {
        for(int i = 0 ; i < num ; i++)
        {
            GameObject newCard = (GameObject)GameObject.Instantiate(CardPre);
            newCard.GetComponent<CardInfo>().SetCardConfigID(i+1);
            CARDBOX.AddChild(newCard.transform);
            newCard.transform.localScale = Vector3.one;
            newCard.SetActive(true);
        }
        CARDBOX.repositionNow = true;
    }
}
