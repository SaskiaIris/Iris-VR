using UnityEngine;

public class Movement : MonoBehaviour {
    [SerializeField]
    private float playerHeight = 1.5f;

    [SerializeField]
    private GameObject waypointHolder;

    private GameObject[] waypoints;

    private Vector3 waypointPosition;
    private float waypointRotation;
    private float newRotation;

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

    public void MoveToWayPoint(int waypointIndex) {
        waypointPosition = waypoints[waypointIndex].transform.position;
        waypointRotation = waypoints[waypointIndex].transform.rotation.eulerAngles.y;
        newRotation = waypointRotation - this.gameObject.transform.rotation.eulerAngles.y;
        waypointPosition = new Vector3(waypointPosition.x, waypointPosition.y + playerHeight, waypointPosition.z);
        this.gameObject.transform.position = waypointPosition;
        this.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), newRotation);

    }
}