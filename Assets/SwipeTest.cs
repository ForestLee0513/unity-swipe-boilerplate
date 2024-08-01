using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SwipeTest : MonoBehaviour
{
    [SerializeField]
    private SwipeEventAsset _swipeEventAsset;
    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _swipeEventAsset.eventRaised += DisplaySwipeText;
    }

    private void OnDisable()
    {
        _swipeEventAsset.eventRaised -= DisplaySwipeText;
    }

    private void DisplaySwipeText(object sender, SwipeData args)
    {
        text.text = "Swipe Raised";
        StartCoroutine(DisplaySwipeTextCoroutine());
    }

    private IEnumerator DisplaySwipeTextCoroutine()
    {
        yield return new WaitForSeconds(1f);
        text.text = "";
    }
}
