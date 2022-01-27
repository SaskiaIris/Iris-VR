using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {
    [SerializeField]
    private float minAmp = 1.0f;
    [SerializeField]
    private float maxAmp = 2.0f;
    private float amplitude;

    [SerializeField]
    private float minSpeed = 1.0f;
    [SerializeField]
    private float maxSpeed = 1.5f;
    private float speed;

    private float tempVal;
    private Vector3 tempPos;

    void Start() {
        tempVal = transform.position.y;
        tempPos = transform.position;
        amplitude = Random.Range(minAmp, maxAmp);
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update() {
        tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = tempPos;
    }
}
