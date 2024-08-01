using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeEventController : MonoBehaviour
{
    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    #endregion


    [SerializeField]
    private SwipeInputActionReference _swipeInputActionReference;
    private Camera _mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (_swipeInputActionReference.SwipeTouch.action != null)
        {
            _swipeInputActionReference.SwipeTouch.action.started += ctx => StartTouchPrimary(ctx);
            _swipeInputActionReference.SwipeTouch.action.canceled += ctx => EndTouchPrimary(ctx);
        }

        _mainCamera = Camera.main;
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null)
        {
            if (context.control.device is not Pointer pointer)
            {
                Debug.LogError("Input actions are incorrectly configured. Expected a Pointer binding ScreenTapped.", this);
                return;
            }

            var tapPosition = pointer.position.ReadValue();

            OnStartTouch((tapPosition), (float)context.startTime);
        }
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
        {
            if (context.control.device is not Pointer pointer)
            {
                Debug.LogError("Input actions are incorrectly configured. Expected a Pointer binding ScreenTapped.", this);
                return;
            }

            var tapPosition = pointer.position.ReadValue();

            OnEndTouch((tapPosition), (float)context.time);
        }
    }
}
