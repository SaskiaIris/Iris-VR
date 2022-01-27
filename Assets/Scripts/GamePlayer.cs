using System.Collections.Generic;
using UnityEngine;

public class GamePlayer : MonoBehaviour {
    [SerializeField]
    private Movement movement;

    [SerializeField]
    private List<GameState> gameStates = null;

    [SerializeField]
    private float minTimeBetweenStates = 10.0f;

    [SerializeField]
    private Animator fadeAnimator;

    private int currentState;
    private int previousState;
    private int endState;

    private float timer = 0.0f;
    private int zero = 0;
    private int timerInSeconds = 0;
    private int amountOfMSInASecond = 60;

    private bool isCounting = false;

    // Start is called before the first frame update
    void Start() {
        currentState = 0; //Maybe hierboven zetten
        if(gameStates.Count > 0) {
            endState = gameStates.Count-1;
        } else {
            endState = 0;
        }
        previousState = endState;

        StartTimer();
    }

    // Update is called once per frame
    void Update() {
        if(isCounting) {
            TimerCheck();
        }
    }

    //maybe private
    public void NextState() {
        if(!isCounting && currentState < endState) {
            fadeAnimator.SetTrigger("Fadeout");
            Debug.Log("Current State: " + currentState);
            StartTimer();
            currentState++;
            if(previousState == endState) {
                previousState = 0;
            } else {
                previousState++;
            }
        } else if(!isCounting && currentState == endState) {
            fadeAnimator.SetTrigger("Fadeout");
            Debug.Log("Current State: " + currentState);
            StartTimer();
            currentState = 0;
            previousState = endState;
        }
    }
        

    public void OnFadeComplete() {
        movement.MoveToWayPoint(currentState);
        SetNextPartOn();
        fadeAnimator.SetTrigger("Fadein");
	}

    public void SetNextPartOn() {
        gameStates[previousState].associatedExperience.SetActive(false);
        gameStates[currentState].associatedExperience.SetActive(true);
    }

    private void StartTimer() {
        isCounting = true;
    }

    private void ResetTimer() {
        isCounting = false;
        timer = zero;
        timerInSeconds = zero;
    }

    public void TimerCheck() {
        timer += Time.deltaTime;
        timerInSeconds = (int) timer % amountOfMSInASecond;

        if(timerInSeconds >= minTimeBetweenStates) {
            ResetTimer();
        }
    }
}