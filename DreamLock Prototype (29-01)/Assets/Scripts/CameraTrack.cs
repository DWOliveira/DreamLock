using UnityEngine;
using System.Collections;

public class CameraTrack : MonoBehaviour {

	public float offsetx;
	public float offsety;

	public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.position.x + offsetx, player.position.y + offsety, this.transform.position.z);

	}
}
