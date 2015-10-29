using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SimpleJson;

public class GUIRoot : MonoBehaviour
{
    public static GUIRoot instance;

    public UIPanel baseLoading;
    //public GameObject logos;
    public LoadingPanel loading{
        get {

            if (tipsLoadingPanel.gameObject.activeInHierarchy){
                return tipsLoadingPanel;
            } else if (defaultLoadingPanel.gameObject.activeInHierarchy) {
                return defaultLoadingPanel;
            } else if (PlayerData.curLevel != null && !String.IsNullOrEmpty (PlayerData.curLevel.config.loadingUI)) {                
                return tipsLoadingPanel;
            } else {
                return defaultLoadingPanel;
            }
        }
    }
    public LoadingPanel defaultLoadingPanel;
    public LoadingPanel tipsLoadingPanel;
    public BufferingPanel buffering;
    public Alert alert;
    public Alert OK_cancel;
    public UILabel floatMessage;
    public UIPanel uiPanel;
    public Transform ModelShowPoint;
    public Transform nameRoot_2D;
    public Transform nameRoot_3D;
    public static LayerMask NGUILayer = 1 << 8;
    public static LayerMask exclusiveLayer = 1 << 26;
    public static LayerMask propertyTip = 1 << 28;
    public Camera camera_UI;
    public Camera mapCamera;
    public Queue<GameObject> messagesQueue = new Queue<GameObject>();
    public UITable messageQueueTable;

    void Awake()
    {
        GUIRoot.instance = this;
    }

    void Start()
    {
     
    }

    public void LoadSceneGUI(string guiName, Action callback=null)
    {
        Utility.instance.LoadGameObject(guiName, (scene) => {
            scene.transform.parent = transform;
            scene.transform.rotation = Quaternion.identity;
            scene.transform.localPosition = Vector3.zero;
            scene.transform.localScale = Vector3.one;
            SceneRoot.instance.SceneCache.Add(scene);
            if (callback != null)
            {
                callback();
            }
        });
    }

    public void OpenUIByID(int ui, int num1, int num2)
    {
		Debug.Log ("OpenUIByID ui:"+ui);

        switch (ui)
        {
            
        }
    }
    
    public void FloatMessage(string message,bool overColor = false)
    {
        if (overColor)
        {
            _FloatMessage(message);
        }
        else
        {
            _FloatMessage(LocaleConfig.Get(104033, message));
        }
    }

    void _FloatMessage(string message)
    {
        GameObject go = (GameObject)Instantiate(floatMessage.gameObject);
        go.transform.parent = GUIRoot.instance.messageQueueTable.transform;
        go.transform.localScale = Vector3.one;
        go.transform.position = floatMessage.transform.position;
        go.name = TimeCom.GetUTCMS().ToString();
        UILabel label = go.GetComponent<UILabel>();
        label.text = message;
        messageQueueTable.Reposition();
        go.SetActive(false);
        messagesQueue.Enqueue(go);
        if (messagesQueue.Count >= 3)
        {
            while (messagesQueue.Count > 2)
                messagesQueue.Dequeue();
        }
        messagesQueue.Dequeue().gameObject.SetActive(true);
        messageQueueTable.Reposition();
       
    }

    IEnumerator WaitShow()
    {
        while(true)
        {
            if(messagesQueue.Count > 0)
                messagesQueue.Dequeue().SetActive(true);
            yield return new WaitForSeconds(1f);
            Debug.Log(messagesQueue.Count);
        }
      
    }


    public void Run()
    {
        StartCoroutine("WaitShow");
    }

    public void FloatStatusCode(int status)
    {
        if (ConfigInfo.instance.STATUS_LOCALE.ContainsKey(status))
        {
            FloatMessage(LocaleConfig.Get(ConfigInfo.instance.STATUS_LOCALE [status]));
        } else
        {
            Debug.LogError("no visualize for status code:" + status);
        }
    }

    public void FloatStatusCodeForWeb(JsonObject obj)
    {
        if(obj.ContainsKey("status"))
        {
            int status = Convert.ToInt32(obj["status"]);
            if (status == 1)
            {
                int errCode = Convert.ToInt32(obj["errCode"]);
                GUIRoot.instance.FloatMessage(LocaleConfig.Get(ConfigInfo.instance.STATUS_LOCALE[errCode]));
            }
            else {
                FloatStatusCode(status);
            }
        }


    }
	
}
