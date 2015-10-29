using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class JoyStickerInput : MonoBehaviour
{
    public Transform moveTarget;

	Vector3 clickedPosition = Vector3.zero;
	public UISprite Sticker;
	public UISprite DownStickerBack;
	GameObject createSticker;
	public Camera UIcamera;
	public int maxDistance;//可以拖动的最大范围
	public int limit;
	public bool draging = false;
	public Vector3 keepLimit;
	public Vector3 marchedPostion;
	public Vector3 currentPosition;
	public float offset;
	public bool touchFlag;
	Vector3 moveSticker = new Vector3 ();
	public  static JoyStickerInput instance;
    Vector3 sendPosition;
    public CharacterController cc;
    public Vector3 lastRotation;

	void Awake ()
	{
		instance = this;
		Sticker.gameObject.SetActive (false);
	}

	// Use this for initialization
	void Start ()
	{
        currentPosition = moveTarget.transform.position;
	}

    void OnGUI()
    {
        GUILayout.TextField("Position" + sendPosition + "LastRotation" + lastRotation);
    }

	bool axisControl;
	// Update is called once per frame
    void FixedUpdate()
	{
		if (draging) {
			if (Input.touches.Length > 0) {
				int fingerIndex = 0;
				for (int i = 0; i < Input.touches.Length; i++) {
					if (Input.touches [i].position.x <= Screen.width / 2) {
						fingerIndex = i;
						break;
					}
				}
				moveSticker = UIcamera.ScreenToWorldPoint (Input.touches [fingerIndex].position);
			} else {
				moveSticker = UIcamera.ScreenToWorldPoint (Input.mousePosition);
			}
			Sticker.transform.position = moveSticker;
			DownStickerBack.transform.position = keepLimit;
			DownStickerBack.transform.localPosition = Vector3.ClampMagnitude (DownStickerBack.transform.localPosition, limit);
			keepLimit = DownStickerBack.transform.position;
			marchedPostion = Sticker.transform.position - DownStickerBack.transform.position;
            MoveTarget(marchedPostion);
		} else if(!axisControl) {
			Sticker.gameObject.SetActive (false);
			marchedPostion = Vector3.zero;
		}
        
	}
    
	public void CreateSticker ()//只有点击碰撞范围内才能执行 生成摇杆
	{
		if (Sticker.gameObject.activeSelf == false && draging != true) {//如果摇杆不现实或者不在拖拽状态时
			moveSticker = UICamera.lastTouchPosition;
			Sticker.transform.position = UIcamera.ScreenToWorldPoint (moveSticker);
			keepLimit = Sticker.transform.position;
			DownStickerBack.transform.localPosition = Vector3.zero;
			marchedPostion = Vector3.zero;
			draging = true;
		}
		Sticker.gameObject.SetActive (true);
	}

	public void DestorySticker ()
	{
		Sticker.gameObject.SetActive (false);
		Sticker.transform.localPosition = Vector3.zero;
		marchedPostion = Vector3.zero;
        MoveTarget(Vector3.zero);
		draging = false;
	}

    public void MoveTarget(Vector3 vector)
    {
        sendPosition = vector;

        Vector3 realDir = new Vector3(vector.x, 0, vector.y);
        if(cc != null)
            cc.Move(realDir);
        Debug.Log(Mathf.Atan2(vector.x, vector.y));
        moveTarget.Rotate(new Vector3(0,realDir.y,0));
    }
    
}
