using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Body : MonoBehaviour
{
	public enum Part
	{
		CHEST=0,
		LEFTHAND=1,
		RIGHTHAND=2,
		LEFTFOOT=3,
		RIGHTFOOT=4,
		HEAD=5,
		BASE=8,
		ROOT=9,
		IDLE_WEAPON_L=10,
		IDLE_WEAPON_R=11,
		PELVIS = 12,
		Decoration,
		Secondary_L,
		Secondary_R,
		Back,
		Back2
	}

	[HideInInspector]
	public float
	scale {
		get{
			return transform.localScale.y;
		}
	}
	public Transform LHand;
	public Transform RHand;
	public Transform namePoint;
	public Transform chest;
	public Transform head;
	public Transform LFoot;
	public Transform RFoot;
	public Transform root;
	public Transform pelvis;
	public Transform idleWeaponPointL;
	public Transform idleWeaponPointR;
	public Transform Decoration;
	public Transform secondary_l;
	public Transform secondary_r;
	public Transform back;
	public Transform back2;

	[HideInInspector]
	public Weapon mainWeapon;
	[HideInInspector]
	public Weapon secondaryWeapon;

	void Start ()
	{
		if (Utility.instance == null) {
			return;
		}


		if (namePoint == null) {
			Debug.LogWarning ("no name point at " + gameObject.name, this);
		}
	}

	public void ScaleTo (float scale)
	{
		transform.localScale = Vector3.one * scale;
	}

	public Transform GetBodyPartTransform (Part part)
	{
		switch (part) {
		case Part.CHEST:
			return chest;
                
		case Part.HEAD:
			return head;
                
		case Part.LEFTHAND:
			return LHand.transform;
                
		case Part.RIGHTHAND:
			return RHand.transform;
                
		case Part.RIGHTFOOT:
			return RFoot.transform;
                
		case Part.LEFTFOOT:
			return LFoot.transform;
                
		case Part.BASE:
			return transform.parent;

		case Part.ROOT:
			return root;

		case Part.IDLE_WEAPON_L:
			return idleWeaponPointL;

		case Part.IDLE_WEAPON_R:
			return idleWeaponPointR;

		case Part.PELVIS:
			return pelvis;

		case Part.Decoration:
			return this.Decoration;

		case Part.Secondary_L:
			return this.secondary_l;

		case Part.Secondary_R:
			return this.secondary_r;

		case Part.Back:
			return this.back;

		case Part.Back2:
			return this.back2;

		default:
			return transform;
		}
	}

	[HideInInspector]
	public List<GameObject>
		temps = new List<GameObject> ();

	public void ClearTemp ()
	{
		foreach (var temp in temps) {
			Destroy (temp.gameObject);
		}

		temps.Clear ();
	}

	List<Body> hangedBody = new List<Body> ();



	public void ReleaseHangedBody ()
	{
		foreach (var body in hangedBody) {
			body.transform.parent = SceneRoot.instance.characterRoot;
		}
		hangedBody.Clear ();
	}

	public void Hang (Part pos, Transform item)
	{
		var part = GetBodyPartTransform (pos);
		Cinch (part, item);
	}

	void Cinch (Transform bodyPart, Transform item)
	{
		item.parent = bodyPart;
		Utility.ResetTransform (item);
	}

	#if UNITY_EDITOR
	[ContextMenu("找到各部位")]
	public void Exe ()//editor only
	{
		foreach (var t in GetComponentsInChildren<Transform>(true)) {
			if (t.name.Equals ("wapon_DummyL") || t.name.Equals ("wapon_DummyR")) {

				if (t.name.Equals ("wapon_DummyL")) {
					LHand = t;
				} else {
					RHand = t;
				}
			} else if (t.name.Equals ("namePoint")) {
				namePoint = t;
			} else if (t.name.Equals ("Bip01 Spine1") || t.name.Equals ("Bip001 Spine1")) {
				chest = t;
			} else if (t.name.Equals ("Bip01 L Foot") || t.name.Equals ("Bip001 L Foot")) {
				LFoot = t;
			} else if (t.name.Equals ("Bip01 R Foot") || t.name.Equals ("Bip001 R Foot")) {
				RFoot = t;
			} else if (t.name.Equals ("Bip01 Head") || t.name.Equals ("Bip001 Head")) {
				head = t;
			} else if (t.name.Contains ("ummy")) {
				root = t;
			} else if (t.name.ToLower ().Contains ("pelvis")) {
				pelvis = t;
			} 
		}
	}
	#endif

}
