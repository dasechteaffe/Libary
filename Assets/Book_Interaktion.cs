using UnityEngine;

public class BookInteraction : MonoBehaviour
{
    public string bookTitle;
    public string bookAuthor;
    public string bookDescription;
    public float interactionDistance = 2f;

    private bool playerInRange = false;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            playerInRange = distance <= interactionDistance;

            if (playerInRange && Input.GetKeyDown(KeyCode.E))
            {
                ShowBookInfo();
            }
        }
    }

    void ShowBookInfo()
    {
        BookInfoMenu.instance.ShowMenu(bookTitle, bookAuthor, bookDescription);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}