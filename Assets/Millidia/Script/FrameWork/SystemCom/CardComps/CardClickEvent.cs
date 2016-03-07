using UnityEngine;
using System.Collections;

public class CardClickEvent : UIButton{

    public TweenTransform tran;
    public bool isSelected = false;

	// Use this for initialization
    void Start()
    {
        SetTransformAnimation();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ClickEvent()
    {
        if (!isSelected)
            PlayF();
        else
            PlayR();
    }

    void SetTransformAnimation()
    {
        tran = this.GetComponent<TweenTransform>(); 
    }

    void PlayF()
    {
        isSelected = !isSelected;
        tran.enabled = true;
        tran.PlayForward();
    }

    void PlayR()
    {
        isSelected = !isSelected;
        tran.enabled = true;
        tran.PlayReverse();
    }
    
}
