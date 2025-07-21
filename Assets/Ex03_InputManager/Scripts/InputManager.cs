using UnityEngine;
using UnityEngine.Events;

public class InputManager : Singleton<InputManager>
{
    public UnityEvent<float, float> evtDpad = new UnityEvent<float, float>();
    public UnityEvent evtMenuToggle = new UnityEvent();
    public UnityEvent evtSave = new UnityEvent();
    private float axisX;
    private float axisY;

    private void Update() {
        axisX = 0;
        axisY = 0;

        if (Input.GetKey("d")) {
            axisX = 1f;
        }
        if (Input.GetKey("a")) {
            axisX = -1f;
        }
        if (Input.GetKey("w")) {
            axisY = 1f;
        }
        if (Input.GetKey("s")) {
            axisY = -1f;
        }

        evtDpad?.Invoke(axisX, axisY);

        if (Input.GetKeyDown("`")) {
            evtMenuToggle?.Invoke();
        }

        if (Input.GetKeyDown("1")) {
            evtSave?.Invoke();
        }
    }

    public void TestDpad(float movX, float movY) {
        print($"movX: {movX}, movY: {movY}");
    }

    public void TestMenuToggle() {
        print($"Menu toggled.");
    }

#region Subscribe / Unsubscribe
    public void SubscribeDpad(UnityAction<float, float> action) {
        evtDpad.AddListener(action);
    }

    public void UnsubscribeDpad(UnityAction<float, float> action) {
        evtDpad.RemoveListener(action);
    }

    public void SubscribeMenuToggle(UnityAction action) {
        evtMenuToggle.AddListener(action);
    }

    public void UnsubscribeMenuToggle(UnityAction action) {
        evtMenuToggle.RemoveListener(action);
    }

    public void SubscribeSave(UnityAction action) {
        evtSave.AddListener(action);
    }

    public void UnsubscribeSave(UnityAction action) {
        evtSave.RemoveListener(action);
    }
#endregion
}
