using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UISystem :  MonoBehaviour{

    public static bool openBabelSystem = false;
    public static bool openGeneralBabelSystem = false;

    struct RequireItems
    {
        public int propId;
        public int cout;
    }

	public static void IntilizationBlocks(UIGrid grid , int number, GameObject itemPre , List<GameObject> list)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject gameO = (GameObject)GameObject.Instantiate(itemPre);
            gameO.transform.parent = grid.transform;
            gameO.transform.localScale = Vector3.one;
            gameO.transform.localPosition = Vector3.one;
            gameO.SetActive(true);
            gameO.name = i.ToString();
            list.Add(gameO);
        }
        grid.Reposition();
    }


    public static void IntilizationForWrapContent(UIWrapContent content , int number, GameObject itemPre, List<GameObject> list,bool active , float time, float time2, Action<List<GameObject>> callback = null)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject gameO = (GameObject)GameObject.Instantiate(itemPre);
            gameO.transform.parent = content.transform;
            gameO.transform.localScale = Vector3.one;
            gameO.transform.localPosition = Vector3.one;
            gameO.name = i.ToString();
            list.Add(gameO);
        }
        Utility.instance.WaitForSecs(time2, () =>
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                    list[i].SetActive(active);
            }
        });
        Utility.instance.WaitForSecs(time, () =>
        {
            content.WrapContent();
        });
      
    }


    public static string returnClass(int i)
    {
        if (i == 1)
            return LocaleConfig.Get(100029);
        else if (i == 2)
            return LocaleConfig.Get(100031);
        else if (i == 3)
            return LocaleConfig.Get(100033);
        else
            return "";
    }
    public static void IntilizationBlocksWaitForSecond(UIGrid grid, int number, GameObject itemPre, List<GameObject> list, float time, float time2, Action<List<GameObject>> callback = null)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject gameO = (GameObject)GameObject.Instantiate(itemPre);
            gameO.transform.parent = grid.transform;
            gameO.transform.localScale = Vector3.one;
            gameO.transform.localPosition = Vector3.one;
            gameO.name = i.ToString();
            list.Add(gameO);
        }
        Utility.instance.WaitForSecs(time, () =>
        {
            if(grid != null)
                grid.Reposition();
        });
        Utility.instance.WaitForSecs(time2, () =>
        {

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                    list[i].SetActive(true);
            }
        });
    }

    public static void IntilizationBlocksNoActive(UIGrid grid, int number, GameObject itemPre, List<GameObject> list)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject gameO = (GameObject)GameObject.Instantiate(itemPre);
            gameO.transform.parent = grid.transform;
            gameO.transform.localScale = Vector3.one;
            gameO.transform.localPosition = Vector3.one;
            gameO.name = i.ToString();
            list.Add(gameO);
        }
        grid.Reposition();
    }

    public static void ActiveAllObjects(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
            list[i].gameObject.SetActive(true);
    }

    public static void IntilizationTables(UITable table, int number, GameObject itemPre, List<GameObject> list)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject gameO = (GameObject)GameObject.Instantiate(itemPre);
            gameO.transform.parent = table.transform;
            gameO.transform.localScale = Vector3.one;
            gameO.transform.localPosition = Vector3.one;
            gameO.SetActive(true);
            gameO.name = i.ToString();
            list.Add(gameO);
        }
        Utility.instance.WaitForSecs(0.02f, () => {
            if(table != null)
            table.Reposition(); 
        });
     
    }


    public static void ResetAllGrids(UIGrid[] grids)
    {
        for (int i = 0; i < grids.Length; i++)
            grids[i].Reposition();
    }
    public static void ResetAllScrollView(UIScrollView[] views)
    {
        for (int i = 0; i < views.Length; i++)
            views[i].ResetPosition();
    }
    public static void UpdateTabs(List<GameObject> tabs, List<GameObject> cTabs)
    {
        int cuu = 0;
        try
        {
            cuu = Convert.ToInt32(UICamera.lastHit.collider.name);
        }catch(Exception e)
        {
            cuu = 1;
        }
        for (int i = 0; i < cTabs.Count; i++)
        {
            if (i == cuu)
                cTabs[i].gameObject.SetActive(true);
            else
                cTabs[i].gameObject.SetActive(false);
        }
    }

    public static void IntilizationTabs(List<GameObject> tabs, List<GameObject> cTabs ,int current)
    {
        for (int i = 0; i < cTabs.Count; i++)
        {
            if (i == current)
                cTabs[i].gameObject.SetActive(true);
            else
                cTabs[i].gameObject.SetActive(false);
        }

    }
    
    public static void RefreshScrollViews(UIScrollView [] sws , int currentIndex)
    {
        for (int i = 0; i < sws.Length; i++)
            sws[i].gameObject.SetActive(false);
        sws[currentIndex].gameObject.SetActive(true);
    }
    public static void SetOriginalStateForScrollViews(UIScrollView[] sws)
    {
        for (int i = 0; i < sws.Length; i++)
            sws[i].ResetPosition();
    }


    public static void ResetGameItemColor(UISprite back)
    {
        back.color = Color.white;
    }
    public static void rightShiftScrollView(UIScrollView scrollView,UIGrid grid)
    {
       float weight = grid.cellWidth;
       Vector3 currentPosition = scrollView.transform.localPosition;
       float maxWeight = (grid.GetChildList().Count) * grid.cellWidth/2;
       scrollView.transform.localPosition = new Vector3(currentPosition.x + weight, currentPosition.y, currentPosition.z);
       scrollView.GetComponent<UIPanel>().clipOffset = new Vector3(currentPosition.x + weight, currentPosition.y, currentPosition.z);
      
    }
    public static void leftShiftScrollView(UIScrollView scrollView, UIGrid grid)
    {
        float weight = grid.cellWidth;
        Vector3 currentPosition = scrollView.transform.localPosition;
        float maxWeight = (grid.GetChildList().Count) * grid.cellWidth / 2;
        scrollView.transform.localPosition = new Vector3(currentPosition.x - weight, currentPosition.y, currentPosition.z);
        scrollView.GetComponent<UIPanel>().clipOffset = new Vector3(currentPosition.x - weight, currentPosition.y, currentPosition.z);
    }

    public static GameObject RaysEvent(UIWidget rayOrignal, Camera camera , string rayCollider)
    {
        Ray center = camera.ScreenPointToRay(camera.WorldToScreenPoint(rayOrignal.transform.position));
        RaycastHit [] centerContant;
        centerContant = Physics.RaycastAll(center,20, 1 << 8);
        foreach (var o in centerContant)
            if (o.collider.name == rayCollider)
                return o.collider.gameObject;
        return null;
    }

    public static void SetAllSpriteForButton(UIButton button , string spriteName)
    {
        button.normalSprite = spriteName;
        button.pressedSprite = spriteName;
        button.hoverSprite = spriteName;
        button.disabledSprite = spriteName;
    }
    
    public static void CreateTimer(CoroutineAction co)
    {
        if (UIRoot.list[0].transform.FindChild("_ResetSeed"))
        {
            Destroy(UIRoot.list[0].transform.FindChild("_ResetSeed").gameObject);
        }
        GameObject go = new GameObject();
        CoroutineObj obj = go.AddComponent<CoroutineObj>();
        obj.StartCoroutine(co());
        obj.name = "_ResetSeed";
        obj.transform.parent = GUIRoot.instance.transform;
    }

    public static IEnumerator CheckDataPreSecond(float time , Action action = null)
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if(action != null)
                action();
        }
    }
    static int cout = 0;

    public static string returnTimeStamp(long passTime)
    {
        return (new TimeSpan(0, 0,(int)passTime).ToString());
    }

      
 
    public static string returtScoreForDung(int score)
    {
        if (score == 1)
            return "SSS";
        else if(score == 2)
            return "SS";
        else if(score == 3)
            return "S";
        else if(score == 4)
            return "A";
        else 
            return "B";

    }
   
}
