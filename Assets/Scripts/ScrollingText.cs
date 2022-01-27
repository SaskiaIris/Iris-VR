using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText : MonoBehaviour {
    private bool isScrolling;
    private float rotation;
    // Start is called before the first frame update
    void Start() {
        Setup();
    }

    // Update is called once per frame
    void Update() {
        // If we are scrolling, perform update action
        if(isScrolling) {
            // Get the current transform position of the panel
            Vector3 _currentUIPosition = gameObject.transform.position;
            Debug.Log("Current Positon: " + _currentUIPosition);// Increment the Y value of the panel 
            Vector3 _incrementYPosition =
              new Vector3(_currentUIPosition.x - .04f * Mathf.Cos(Mathf.Deg2Rad * rotation),
                          _currentUIPosition.y - .1f * Mathf.Sin(Mathf.Deg2Rad * rotation),
                          _currentUIPosition.z - .04f * Mathf.Cos(Mathf.Deg2Rad * rotation));// Change the transform position to the new one
            Debug.Log("New Position: " + _incrementYPosition);
            gameObject.transform.position = _incrementYPosition;
        }
    }

    private void Setup() {
        isScrolling = true;
        rotation = gameObject.GetComponentInParent<Transform>().eulerAngles.x;
        Debug.Log("Parent rotation: " + rotation);
    }
}