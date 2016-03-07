using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StretchWidgetAdaptiveScreen : MonoBehaviour
{
    public bool stretchHeight = true;
    public bool stretchWidth = true;
	bool disableParentScale=true;
    public Vector2 overFlow ;
	int preFrame = -1;
    public float lastUIPanelWidth;
    public float lastUIPanelHeight;

    // Use this for initialization
    void Start()
    {
        Adapter();
    }
    void Adapter()
    {

        if (lastUIPanelHeight == GUIRoot.instance.uiPanel.height && lastUIPanelWidth == GUIRoot.instance.uiPanel.width)
            return;

        UIWidget widget = GetComponent<UIWidget>();

        if (stretchWidth)
        {
            widget.width = Mathf.CeilToInt(GUIRoot.instance.uiPanel.width + overFlow.x);
        }

        if (stretchHeight)
        {
            widget.height = Mathf.CeilToInt(GUIRoot.instance.uiPanel.height + overFlow.y);
        }
        if (disableParentScale)
        {
            Vector3 finalScale = GetParentsScale(transform);
            widget.width = (int)(widget.width / finalScale.x);
            widget.height = (int)(widget.height / finalScale.y);
        }
        lastUIPanelWidth = GUIRoot.instance.uiPanel.width;
        lastUIPanelHeight = GUIRoot.instance.uiPanel.height;

    }
	void Update()
	{
        Adapter();
	}
	public static Vector3 GetParentsScale(Transform trans)
	{
		List<Vector3> scaleList = new List<Vector3> ();
		GetScaleList (ref scaleList,trans);
		Vector3 finalScale = scaleList [0];
		for(int i=1;i<scaleList.Count;i++)
		{
			finalScale.Scale(scaleList[i]);
		}
		return finalScale;

	}
	public static void GetScaleList(ref List<Vector3> scaleList,Transform trans)
	{
		scaleList.Add (trans.localScale);
		if (trans.parent == null || trans.parent.transform.gameObject == GUIRoot.instance.gameObject)
			return;
		GetScaleList (ref scaleList,trans.parent);
	}
}
