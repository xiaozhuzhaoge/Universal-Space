using UnityEngine;
using System.Collections;

public class SpaceShipManager : MonoBehaviour {

    public static SpaceShipManager instance;
    public UICenterOnChild center;
    public CardInfo CurrentPointDriver;
    public UILabel currentContent;
    public Draw valueCanvas;


    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }
	// Use this for initialization
	void Start () {
        center.onFinished += CheckCurrentData;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void CheckCurrentData()
    {
        if(center.centeredObject != null)
            CurrentPointDriver = center.centeredObject.GetComponent<CardInfo>();
        currentContent.text = CurrentPointDriver.config.CardName + "'s ID is " + CurrentPointDriver.config.ID + "SPACE ENIGNEER";
        AddToCurrentValueCanvas();
    }

    public void AddToCurrentValueCanvas()
    {
        valueCanvas.ATK = 0;
        valueCanvas.ATK += CurrentPointDriver.config.ATK;
        valueCanvas.DEF = 0;
        valueCanvas.DEF += CurrentPointDriver.config.DEF;
        valueCanvas.ADV = 0;
        valueCanvas.ADV += CurrentPointDriver.config.ADV;
        valueCanvas.RES = 0;
        valueCanvas.RES += CurrentPointDriver.config.RES;
        valueCanvas.LUK = 0;
        valueCanvas.LUK += CurrentPointDriver.config.LUK;
        valueCanvas.INT = 0;
        valueCanvas.INT += CurrentPointDriver.config.INT;
    }

    public void CloseSpaceShipManager()
    {
        gameObject.SetActive(false);
    }
   
    public void ShowSpaceShipManager()
    {
        gameObject.SetActive(true);
    }
}
