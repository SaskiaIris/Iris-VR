using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField]
    private GameObject waypointHolder;

    private GameObject[] waypoints;

    // Start is called before the first frame update
    void Start() {
        waypoints = new GameObject[waypointHolder.transform.childCount];
		for(int i = 0; i < waypointHolder.transform.childCount; i++) {
            waypoints[i] = waypointHolder.transform.GetChild(i).gameObject;
		}
    }

    // Update is called once per frame
    void Update() {
        
    }
}