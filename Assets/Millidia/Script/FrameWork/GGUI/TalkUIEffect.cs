
using UnityEngine;
using System.Collections;

public class TalkUIEffect : MonoBehaviour {

    public TweenTransform tween;
    public TweenAlpha talpha;
    public TweenAlpha nameEffect;
	public string currentSprite;
	public string changedSprite;
	public UITexture currentUI;
	public bool isNPC;
	// Use this for initialization
	void Start () {
		currentSprite = currentUI.mainTexture.name;
	}
	
	// Update is called once per frame
	void Update () {
		ResetData ();
	}
	void ResetData()
	{
		if (isNPC) {
			currentSprite = currentUI.mainTexture.name;
			if (currentSprite != changedSprite) {
				changedSprite = currentSprite;
				tween.ResetToBeginning();
				talpha.ResetToBeginning();
				nameEffect.ResetToBeginning();
				talpha.PlayForward();
				tween.PlayForward();
				nameEffect.PlayForward();
			}
		}

	}

    void OnEnable()
    {
		changedSprite = currentUI.mainTexture.name;
		Play ();
    }
	void Play(){
		tween.PlayForward();
		talpha.PlayForward();
		nameEffect.PlayForward();
	}
	void Reset()
	{
		tween.ResetToBeginning();
		talpha.ResetToBeginning();
		nameEffect.ResetToBeginning();
	}
    void OnDisable()
    {
		Reset ();
        //tween.PlayReverse();
    }
}

