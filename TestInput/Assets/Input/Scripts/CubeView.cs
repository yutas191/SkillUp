using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CubeView : MonoBehaviour {


	public List<GameObject> objTarget;
	public int targetNum;

	// Use this for initialization
	void Start () {
		foreach (GameObject obj in objTarget) {
			obj.SetActive (false);
		}
		targetNum = 0;
		objTarget [targetNum].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0.5f,1.0f,0.1f);
	}

	void OnMouseUp()
	{
		targetNum++;
		#if UNITY_EDITOR
		if(targetNum == 4) {
			targetNum++;
		}
		#endif
		if (targetNum >= objTarget.Count) {
			targetNum = 0;
		}
		foreach (GameObject obj in objTarget) {
			obj.SetActive (false);
		}
		if (targetNum == 3) {
			Texture2D tex = new Texture2D(0,0);
			tex.LoadImage(LoadBin(Application.persistentDataPath + "/" + "Image.jpg"));
			Debug.Log (Application.persistentDataPath + "/" + "Image.jpg");
			if (!tex.Equals (null)) {
				objTarget [targetNum].GetComponent<MeshRenderer> ().material.mainTexture = tex;
			}
		}
		objTarget [targetNum].SetActive (true);
	}

	private byte[] LoadBin(string path){
		FileStream fs = new FileStream(path, FileMode.Open);
		BinaryReader br = new BinaryReader(fs);
		byte[] buf = br.ReadBytes( (int)br.BaseStream.Length);
		br.Close();
		return buf;
	}

}
