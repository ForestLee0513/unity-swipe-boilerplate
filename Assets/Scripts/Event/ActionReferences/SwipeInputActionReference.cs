using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Input Action/SwipeInputActionReference")]
public class SwipeInputActionReference : ScriptableObject
{
    public InputActionProperty SwipeTouch;
    public InputActionProperty SwipePosition;
}
