using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class LoadingPanel : MonoBehaviour
{
    public SpeedProgress progress;
    public UILabel percent;
    public UILabel tips;
    public GameObject forwardView;
    public Transform tipsParent;
    public static LoadingPanel tipsPanel;
    public static LoadingPanel defaultPanel;

    bool onlyBackground;


    IEnumerator ShowTips ()
    {
        while (true) {
            tips.text = LocaleConfig.Get (UnityEngine.Random.Range (100048, 100078));
            yield return new WaitForSeconds (3f);
        }
    }

    public void SetLoadingPercentByDowlanding (int currentStep, int totalStep)
    {
        int value = (int)(100 * (float)currentStep / (float)totalStep);
        SetLoadingPercent (value);
    }

    public void SetLoadingPercent (int percent, bool direct = false)
    {     
        float value = percent / 100f;
        if (value < progress.bar.value || direct) {
            progress.bar.value = value;
            progress.targetValue = value;
        } else {
            progress.targetValue = value;
        }
        Update ();
    }

    public void ShowLoading (bool onlyBackground = false)
    {
        ShowSysTips ();
        this.onlyBackground = onlyBackground;
        forwardView.SetActive (!onlyBackground);
        gameObject.SetActive (true); 
        if (tips != null) {
            StopCoroutine ("ShowTips");
            if (!onlyBackground) {
                StartCoroutine ("ShowTips");
            }
        }
    }

    public void CancelLoading ()
    {
        gameObject.SetActive (false);     
    }

    void Update ()
    {
        if (!onlyBackground) {
            this.percent.text = LocaleConfig.Get (100427, (int)(progress.bar.value * 100));
        }
    }

    public void ShowSysTips ()
    {
		if (tipsParent != null&&PlayerData.curLevel!=null) {
            var name = PlayerData.curLevel.config.loadingUI;
            Debug.Log ("ShowSysTips====" + name);
            for (int i = 0; i < tipsParent.childCount; i++) {
                var go = tipsParent.GetChild (i).gameObject;
                go.SetActive (go.name == name);
            }
        }
    }
}
