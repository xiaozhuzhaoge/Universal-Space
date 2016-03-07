using UnityEngine;
using System.Collections;
using System;

public enum WeaponType
{
	NONE = 0,
	SWORD=1,
	BOW=2,
	FIST=3,
	SPEAR=4,
	STAVES=5,
	STICK=6,
	DOUBLE=7
}

public class Weapon : MonoBehaviour
{
	public enum State
	{
		Idle,
		Hold
	}

	public Transform[] parts;
	public Body.Part[] holdPoints;
	public Body.Part[] idlePoints;

	public void Fold ()
	{
		foreach (var trans in parts) {
			trans.parent = transform;			
			Utility.ResetTransform (trans);
		}
	}
	
	void OnEnable ()
	{
		foreach (var trans in parts) {
			trans.gameObject.SetActive (true);
		}
	}

	void OnDisable ()
	{
		foreach (var trans in parts) {
			if(trans)
			trans.gameObject.SetActive (false);
		}
	}

	void OnDestroy ()
	{
		foreach (var trans in parts) {
			if(trans)
			Destroy (trans.gameObject);
		}
	}
}
