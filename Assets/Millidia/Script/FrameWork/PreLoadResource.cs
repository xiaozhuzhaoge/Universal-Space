using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PreLoadResource : MonoBehaviour
{
	public static void PreLoadDamageUI ()
	{

	}

	static void Init (GameObject go)
	{
		go.transform.parent = SceneRoot.instance.tempRoot;
		go.transform.localPosition = new Vector3 (0, -9000, 0);
    }

	static void DeactiveTemp (GameObject go)
	{
		go.transform.parent = SceneRoot.instance.tempRoot;
		go.SetActive (false);
	}
}
