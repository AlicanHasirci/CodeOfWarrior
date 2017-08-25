using UnityEngine;

public class FollowInput : MonoBehaviour {
	public int PlaneDistance = 10;

	private void Update () {
		if (!Input.GetMouseButton(0)) return;
		
		var mp = new Vector3(Input.mousePosition.x, Input.mousePosition.y, PlaneDistance);
		this.transform.position = Camera.main.ScreenToWorldPoint(mp);
	}
}
