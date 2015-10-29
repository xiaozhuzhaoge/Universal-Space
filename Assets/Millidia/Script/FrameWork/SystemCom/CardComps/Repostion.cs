using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class Repostion : MonoBehaviour {

    public Transform backPosition;
    public int max = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
      
	}

    void FixedUpdate()
    {
        RepostionNow();
    }

    void RepostionNow()
    {
        List<CardInfo> trans = transform.GetComponentsInChildren<CardInfo>().ToList<CardInfo>();
        trans.Remove(this.GetComponent<CardInfo>());
        if (trans.Count == max)
        {
            trans.First<CardInfo>().transform.localPosition = Vector3.zero;
            trans.First<CardInfo>().texture.depth = -1;
        }
        else if(trans.Count > max)
        {
            trans.First<CardInfo>().transform.parent = backPosition;
            trans.First<CardInfo>().transform.localPosition = Vector3.zero;
            backPosition.GetComponent<UIGrid>().repositionNow = true;
        }
    }
}
