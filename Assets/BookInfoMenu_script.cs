using UnityEngine;
using TMPro;

public class BookInfoMenu : MonoBehaviour
{
    public static BookInfoMenu instance;

    public GameObject menuPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI authorText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI escText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowMenu(string title, string author, string description)
    {
        if (menuPanel == null || titleText == null || authorText == null || descriptionText == null || escText == null)
        {
            Debug.LogError("Ein oder mehrere erforderliche Komponenten fehlen im BookInfoMenu.");
            return;
        }

        titleText.text = "Titel: " + title;
        authorText.text = "Autor: " + author;
        descriptionText.text = "Beschreibung: " + description;
        escText.text = "Drücken Sie ESC, um das Menü zu schließen";
        menuPanel.SetActive(true);
    }

    public void HideMenu()
    {
        if (menuPanel != null)
        {
            menuPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (menuPanel != null && menuPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            HideMenu();
        }
    }
}