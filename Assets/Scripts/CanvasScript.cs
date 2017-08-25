using System.Collections.Generic;
using System.Linq;
using PDollarGestureRecognizer;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasScript : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler {
	private enum Turn {
		Player = 0, Slime
	}
	public PlayerController Player;
	public PlayerController Slime;

	private readonly LinkedList<Point> _pointBuffer = new LinkedList<Point>();
	private Gesture[] _gestures;

	private void OnEnable() {
		_gestures = Resources.LoadAll<Gesture>("");
	}

	public void OnBeginDrag(PointerEventData eventData) {
		_pointBuffer.Clear();
	}

	public void OnDrag(PointerEventData eventData) {
		_pointBuffer.AddLast(new Point(Input.mousePosition, 0));
	}

	public void OnEndDrag(PointerEventData eventData) {
		var sample = _pointBuffer.ToArray().Normalize(32, PointOrigin.BottomLeft);
		var gesture = PointCloudRecognizer.Classify(sample, _gestures, .15f);
		if (gesture == string.Empty) Debug.Log("<color=#57A64A>-->No match.</color>");
		else Debug.Log(string.Format("<color=#57A64A>-->Match {0}!</color>",gesture));
		ProccessGesture(gesture);
	}

	private void ProccessGesture(string gesture) {
		switch (gesture) {
			case "LeftArrow":
				Slime.Attack();
				break;
			case "Z":
				Player.Attack();
				break;
		}
	}
}
