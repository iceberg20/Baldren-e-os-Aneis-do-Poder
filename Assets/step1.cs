using UnityEngine;
using System.Collections;

public class step1 : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		Debug.Log("setp1");
		Destroy(other.gameObject);
	}
}
