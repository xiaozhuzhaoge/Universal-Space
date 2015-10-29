using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class SceneContainer : MonoBehaviour
{
    public Transform temp_GhostPoint;
    void Start()
    {
        if (SceneRoot.instance == null)
            return;
		transform.parent = SceneRoot.instance.sceneRoot;
        SceneRoot.instance.curScene = this;
        SceneRoot.instance.SceneCache.Add(gameObject);
    }
}
