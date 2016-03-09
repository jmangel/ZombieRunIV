using UnityEngine;
using System.Collections;

public class SunIntensity : MonoBehaviour {
	public float duration = 1.0F;
    public Light lt;
    void Start() {
        lt = GetComponent<Light>();
    }
    void Update() {
		float pos = GameObject.Find("Sun").transform.position.y;
		pos = (pos + 28)/120 + 0.2f;
        lt.intensity = pos;
    }
}
