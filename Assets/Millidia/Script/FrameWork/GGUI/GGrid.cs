using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GGrid : UIWidgetContainer
{
    public GameObject Item;

    public int m_cellHeight = 60;

    public int m_cellWidth = 700;

    private float m_height;

    private int m_maxLine;

    public List<Transform> m_cellList;

    public GScrollView mDrag;

    private float lastY = -1;

    private List<string> m_listData;

    private Vector3 defaultVec;

    void Awake()
    {
        
    }

    void Update()
    {
        if (mDrag.transform.localPosition.y != lastY)
        {
            if(m_listData.Count > 0)
                Validate();

            lastY = mDrag.transform.localPosition.y;
        }
    }

    private void UpdateBounds(int count)
    {
        Vector3 vMin = new Vector3();
        vMin.x = -transform.localPosition.x;
        vMin.y = transform.localPosition.y - count * m_cellHeight;
        vMin.z = transform.localPosition.z;
        Bounds b = new Bounds(vMin, Vector3.one);
        b.Encapsulate(transform.localPosition);

        mDrag.bounds = b;
        mDrag.UpdateScrollbars(true);
        mDrag.RestrictWithinBounds(true);
    }

    public void AddItem(int count)
    {
        defaultVec = new Vector3(0, m_cellHeight, 0);
        m_height = mDrag.panel.height;
        m_maxLine = Mathf.CeilToInt(m_height / m_cellHeight) + 1;

        if (m_listData == null)
            m_listData = new List<string>();
        else
            m_listData.Clear();

        if (m_cellList == null)
            m_cellList = new List<Transform>();
        else
        { 
            foreach(var item in m_cellList)
            {
                Destroy(item.gameObject);
            }
            m_cellList.Clear();
        }

        int i = 0;
        while (i < count)
        {
            m_listData.Add(i.ToString());
            i++; 
        }

        CreateItem();
        ResetAll();
        Validate();
        UpdateBounds(m_listData.Count);
    }

    [ContextMenu("Execute")]
    private void Validate()
    {
        Vector3 position = mDrag.panel.transform.localPosition;

        float _ver = Mathf.Max(position.y, 0);

        int startIndex = Mathf.FloorToInt(_ver / m_cellHeight);
        int endIndex = Mathf.Min(m_listData.Count, startIndex + m_maxLine);

        Transform cell;
        int index = 0;
        for (int i = startIndex; i < startIndex + m_maxLine; i++)
        {
            cell = m_cellList[index];

            if (i < endIndex)
            {
                cell.name = m_listData[i];
                cell.transform.localPosition = new Vector3(0, i * -m_cellHeight, 0);
                cell.gameObject.SetActive(true);
            }
            else
            {
                cell.transform.localPosition = defaultVec;
            }

            index++;
        }
    }

    private void CreateItem()
    {
        m_cellList = new List<Transform>();
        for (int i = 0; i < m_maxLine; i++)
        {
            GameObject go;
            go = Instantiate(Item) as GameObject;
            go.transform.parent = transform;
            go.transform.localScale = Vector3.one;
            go.SetActive(false);
            go.name = i.ToString();
            m_cellList.Add(go.transform);
        }
    }

    public void ResetAll()
    {
       for(int i = 0 ; i < m_cellList.Count ; i++)
       {
           m_cellList[i].name = i.ToString();
           m_cellList[i].GetComponent<GItem>().Name = i.ToString();
           m_cellList[i].GetComponent<GItem>().SetData();
       }
    }
}