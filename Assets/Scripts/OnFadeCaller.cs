using UnityEngine;
using UnityEngine.Events;

public class OnFadeCaller : MonoBehaviour {
    [SerializeField]
    private UnityEvent onFadeOut;

    public void FadeOutDone() {
        onFadeOut.Invoke();
    }
}