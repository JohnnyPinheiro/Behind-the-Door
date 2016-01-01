using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Colisor : MonoBehaviour {

	private bool nextLevel;
	private bool isGround;
	public Canvas msgComplete;

	void Start(){
		msgComplete.enabled = false;
	}

	void Update(){
		if(nextLevel){
	        StartCoroutine(ChangeLevel());
	        msgComplete.enabled = true;
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.tag == "NextLevel"){
			Debug.Log("bateu");
			nextLevel = true;
		}
	}
	
	IEnumerator ChangeLevel() {
  			yield return new WaitForSeconds(1f);
			float fadeTime = GameObject.Find("Controller").GetComponent<Fadein>().BeginFade(1);
			yield return new WaitForSeconds(fadeTime);
   			Application.LoadLevel(Application.loadedLevel + 1);
    }

}
