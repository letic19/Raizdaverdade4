using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    public Canvas canvas;
    public RectTransform bubbleRect;
    public TextMeshProUGUI bubbleText;
    public float showTime = 3f;

    Coroutine currentCoroutine;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Show(string message, Vector3 worldPosition)
    {
        if (currentCoroutine != null) StopCoroutine(currentCoroutine);

        bubbleText.text = message;
        bubbleRect.gameObject.SetActive(true);

        Vector2 screenPoint = Camera.main.WorldToScreenPoint(worldPosition);
        bubbleRect.position = screenPoint;

        currentCoroutine = StartCoroutine(HideAfter(showTime));
    }

    IEnumerator HideAfter(float t)
    {
        yield return new WaitForSeconds(t);
        bubbleRect.gameObject.SetActive(false);
    }

    public void Hide()
    {
        bubbleRect.gameObject.SetActive(false);

        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }
    }
}
