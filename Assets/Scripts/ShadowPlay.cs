using UnityEngine;

public class ShadowPlay : MonoBehaviour {
	[SerializeField] private Camera _src;
	[SerializeField] private Camera _dst;
	[SerializeField] private MeshRenderer _renderer;
	
	private RenderTexture _renderTexture;
		
	private void Awake() {
		_dst = _dst ?? Camera.main;
		
		_renderTexture = new RenderTexture(1280, 720, 24){
			filterMode = FilterMode.Bilinear,
			antiAliasing = QualitySettings.antiAliasing > 0 ? QualitySettings.antiAliasing : 1
		};
		if (_src != null) _src.targetTexture = _renderTexture;
		_renderer.material.SetTexture("_MainTex", _renderTexture);
	}
}