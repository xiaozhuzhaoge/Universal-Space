using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SuperGrid : UIWidgetContainer{

    //每次刷新调用的事件
    public delegate void OnReposition();

    public enum Arrangement
    {
        Horizontal,
        Vertical,
        CellSnap,
    }

    public enum Sorting
    {
        None,
        Alphabetic,
        Horizontal,
        Vertical,
        Custom,
    }

    public Arrangement arrangement = Arrangement.Horizontal;
    public Sorting sorting = Sorting.None;
    public UIWidget.Pivot pivot = UIWidget.Pivot.TopLeft;

    //格子之间的宽度差
    public float cellWidth = 200f;
    //格子之间的高度差
    public float cellHeight = 200f;
    
    public bool animateSmoothly = false;
    public bool hideInactive = false;
    public bool keepWithinPanel = false;

    public OnReposition onReposition;
    public System.Comparison<Transform> onCustomSort;

    [HideInInspector][SerializeField] bool sorted = false;
    protected bool mReposition = false;
    protected UIPanel mPanel;
    protected bool mInitDone = false;

    //自动匹配高度开关
    public bool auto_mapping = false;
    //自动匹配高度开关-开
    //基于ScrollView的offset进行自动匹配高度
    private float height;
    
    //自动匹配高度开关-关
    //可以生成的最大行的缓存显示
    public  int maxLine;
    //可以生成得每行最大格子缓存显示
    public int maxPerLine;

    public bool repositionNow { set { if (value) { mReposition = true; enabled = true; } } }

    static public int SortByName(Transform a, Transform b) { return string.Compare(a.name, b.name); }
    static public int SortHorizontal(Transform a, Transform b) { return a.localPosition.x.CompareTo(b.localPosition.x); }
    static public int SortVertical(Transform a, Transform b) { return b.localPosition.y.CompareTo(a.localPosition.y); }

    public List<Transform> list;

    protected virtual void Sort(List<Transform> list) { }

    private UIScrollView mSv;
    private float lastY = -1;

    public int valueAmounts = 100;

    private Vector3 defaultVec;

    public List<Transform> GetChildList()
    {
        Transform myTrans = transform;
        List<Transform> list = new List<Transform>();

        for (int i = 0; i < myTrans.childCount; ++i)
        {
            Transform t = myTrans.GetChild(i);
            if (!hideInactive || (t && NGUITools.GetActive(t.gameObject)))
                list.Add(t);
        }

        // Sort the list using the desired sorting logic
        if (sorting != Sorting.None && arrangement != Arrangement.CellSnap)
        {
            if (sorting == Sorting.Alphabetic) list.Sort(SortByName);
            else if (sorting == Sorting.Horizontal) list.Sort(SortHorizontal);
            else if (sorting == Sorting.Vertical) list.Sort(SortVertical);
            else if (onCustomSort != null) list.Sort(onCustomSort);
            else Sort(list);
        }
        return list;
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    protected virtual void Update()
    {
        Reposition();
        enabled = false;
    }

    [ContextMenu("Execute")]
    void Reposition()
    {
        list = GetChildList();
        ResetPosition(list);
    }

    protected virtual void ResetPosition(List<Transform> list)
    {
        int x = 0;
        int y = 0;
        mReposition = false;
        for (int i = 0, imax = list.Count; i < imax; ++i)
        {
            Transform eachItem = list[i];

            Vector3 pos = eachItem.localPosition;
            float depth = pos.z;
            if (arrangement == Arrangement.CellSnap)
            {
                if (cellWidth > 0) pos.x = Mathf.Round(pos.x / cellWidth) * cellWidth;
                if (cellHeight > 0) pos.y = Mathf.Round(pos.y / cellHeight) * cellHeight;
            }
            else pos = (arrangement == Arrangement.Horizontal) ?
                new Vector3(cellWidth * x, -cellHeight * y, depth) :
                new Vector3(cellWidth * y, -cellHeight * x, depth);

            eachItem.localPosition = pos;

            if (++x >= maxPerLine && maxPerLine > 0)
            {
                x = 0;
                ++y;
            }
        }
       
    }

    public bool RemoveChild(Transform t)
    {
        List<Transform> list = GetChildList();

        if (list.Remove(t))
        {
            ResetPosition(list);
            return true;
        }
        return false;
    }

    [ContextMenu("Test")]
    public void UpdateBounds()
    {
       Vector3 vMin = new Vector3();
       vMin.x = -transform.localPosition.x;
       int realLines = valueAmounts / maxPerLine;
       vMin.y = transform.localPosition.y - realLines * cellHeight;
       vMin.z = transform.localPosition.z;
       Bounds b = new Bounds(vMin, Vector3.one); 
       b.Encapsulate(transform.localPosition);

    }
}
