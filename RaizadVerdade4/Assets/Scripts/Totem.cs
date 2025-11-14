using UnityEngine;

public class Totem : MonoBehaviour
{
    public int id;
    [TextArea] public string message;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"[Totem] OnTriggerEnter2D triggered on {gameObject.name} by {other.name} (tag={other.tag})");
        if (other.CompareTag("Player"))
        {
            Debug.Log($"[Totem] Player entrou no totem {id}");
            if (DialogueManager.Instance != null)
                DialogueManager.Instance.Show(message, transform.position);
            else
                Debug.LogWarning("[Totem] DialogueManager.Instance é null!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"[Totem] OnTriggerExit2D: {other.name}");
        if (other.CompareTag("Player"))
        {
            if (DialogueManager.Instance != null)
                DialogueManager.Instance.Hide();
        }
    }
}
