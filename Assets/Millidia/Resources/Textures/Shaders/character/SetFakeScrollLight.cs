using UnityEngine;
using System.Collections;

public class SetFakeScrollLight : MonoBehaviour
{
	static Transform temp;
	public Vector3 rotateSpeed;
	Quaternion lastRotation = Quaternion.identity;

	void Update ()
	{

		if (temp == null) {
			temp = new GameObject ("SetFakeScrollLight").transform;
		}
		temp.rotation = lastRotation;
		temp.Rotate (rotateSpeed * Time.deltaTime, Space.World);
		lastRotation = temp.rotation;
		renderer.sharedMaterial.SetVector ("_LightDir", new Vector4 (temp.forward.x, temp.forward.y, temp.forward.z, 1));
		renderer.sharedMaterial.SetFloat ("_NowTime", Mathf.PingPong (Time.time,5)/20f);
	}
}
