using UnityEngine;
using System.Collections;

public class WebCameraController : MonoBehaviour {
	public int Width = 960;
	public int Height = 540;
	public int FPS = 30;

	public WebCamTexture webcamTexture;
	public Color32[] color32;

	void Awake () {

	}

	void Start () {
		var devices = WebCamTexture.devices;
		if (devices.Length == 0) {
			Debug.LogError ("Webカメラが検出できませんでした。");
			return;
		}
		// WebCamテクスチャを作成する
		var webcamTexture = new WebCamTexture( Width, Height, FPS );
		GetComponent<Renderer> ().material.mainTexture = webcamTexture;
		webcamTexture.Play ();
	}

	void OnEnable() {
		
	}

	void OnDisable() {
		if (webcamTexture.isPlaying) {
			webcamTexture.Stop ();
		}
	}

	void Update () {
		if (!webcamTexture.isPlaying) {
			webcamTexture.Play ();
		}
	}
}
