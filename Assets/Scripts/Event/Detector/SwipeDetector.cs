using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct SwipeData
{
    // viewport vector
    public Vector3 StartPosition;
    public Vector3 EndPosition;
    public float Distance;
    public Vector2 Direction;
    // time
    public float Duration;
}

public class SwipeDetector : MonoBehaviour
{
    [SerializeField]
    private SwipeEventAsset _swipeEventAsset;

    [SerializeField]
    private float minimumDistance = 0.2f;
    [SerializeField]
    private float maximumTime = 1f;

    private SwipeEventController _swipeEventController;

    // tocuh time
    private float startTime;
    private float endTime;

    // viewport vector
    private Vector2 startPosition;
    private Vector2 endPosition;

    private void Awake()
    {
        _swipeEventController = GetComponent<SwipeEventController>();
    }

    private void OnEnable()
    {
        _swipeEventController.OnStartTouch += SwipeStart;
        _swipeEventController.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        _swipeEventController.OnStartTouch -= SwipeStart;
        _swipeEventController.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = Camera.main.ScreenToViewportPoint(position);
        startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = Camera.main.ScreenToViewportPoint(position);
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        float distance = Vector2.Distance(startPosition, endPosition);
        float duration = endTime - startTime;

        if (distance >= minimumDistance && duration <= maximumTime)
        {
            Debug.Log($"Swipe Raised!!");
            Vector3 direction = (endPosition - startPosition).normalized;

            var data = new SwipeData()
            {
                StartPosition = startPosition,
                EndPosition = endPosition,
                Distance = distance,
                Direction = direction,
                Duration = duration
            };

            _swipeEventAsset.Raise(data);
        }
    }
}
