using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayer : MonoBehaviour {
    [SerializeField]
    private List<GameState> gameStates = null;

    private int currentState;
    // Start is called before the first frame update
    void Start() {
        currentState = 0;
    }

    //maybe private
    public void NextState() {
    }

    // Update is called once per frame
    void Update() {
        
    }
}