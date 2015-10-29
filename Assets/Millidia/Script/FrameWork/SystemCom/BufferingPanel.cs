using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BufferingPanel: MonoBehaviour
{
	static float hideTime=3.0f;
	static float outTime=30.0f;
	static float pastTime;
	static bool isShowing;
	static bool isVisable;
	public GameObject juhua;
	public UIPanel buffPanel;

	void Awake()
	{
		pastTime=0.0f;
		isShowing=false;
		isVisable = true;
	}

	void Update()
	{
		if (isVisable&&!isShowing)
		    return;
		pastTime += Time.deltaTime;
		if(pastTime>=hideTime&&!isVisable)
			StartShow();
		if (!isShowing)
			return;

		if(pastTime>=outTime)
		{
			CancelBuffering();
			GUIRoot.instance.FloatMessage(LocaleConfig.Get(700091));
		}
	}

	public void ShowBuffering()
	{
		gameObject.SetActive(true); 
		juhua.gameObject.SetActive(false);
		buffPanel.alpha =0.01f;
		isVisable = false;
		isShowing = false;
		pastTime=0.0f;
	}
	
	public void CancelBuffering()
	{  
		buffPanel.alpha = 1.0f;
		juhua.gameObject.SetActive(false);
		gameObject.SetActive(false); 
		isShowing = false;
		isVisable=true;
		pastTime=0.0f;
	} 

	void StartShow()
    {
		buffPanel.alpha = 1.0f;
		juhua.gameObject.SetActive(true);
		isVisable = true;
		isShowing=true;
	}
}
