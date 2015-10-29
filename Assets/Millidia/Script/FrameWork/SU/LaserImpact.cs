

using UnityEngine;
using System.Collections;

public class LaserImpact : MonoBehaviour {
	// Cache light transform to improve performance
	public Transform _cacheLight;

	void Start () {
		// If the child light exists...
		if (transform.Find("light") != null) {
			// Cache the transform to improve performance
			_cacheLight = transform.Find("light");
			// Find the child light and set intensity to 1.0
			_cacheLight.light.intensity = 1.0f;
			// Move the transform 5 units out so it's not spawn at impact point of the collider/mesh it just hit
			// which will light up the object better.
			_cacheLight.transform.Translate(Vector3.up*5, Space.Self);

		} else {
			Debug.LogWarning("Missing required child light. Impact light effect won't be visible");
		}
		
	}
		
	void Update () {
		// If the light exists...
		if (_cacheLight != null) {
			// Set the intensity depending on the number of particles visible
			_cacheLight.light.intensity = (float) (transform.particleEmitter.particleCount / 50.0f);
		}
	}
}
