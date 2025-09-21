using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnomalyMenuController : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] GameObject panelRoot;          // AnomalyMenu object
    [SerializeField] CanvasGroup panelGroup;        // leave empty; will be added if missing

    [Header("Open/Close Button")]
    [SerializeField] Button   openCloseButton;      // your tablet button
    [SerializeField] TMP_Text openCloseLabel;       // its TMP child
    [SerializeField] string   openText  = "OPEN ANOMALY MENU";
    [SerializeField] string   closeText = "CLOSE ANOMALY MENU";

    [Header("Selection (optional labels)")]
    [SerializeField] TMP_Text roomLabel;            // e.g., a small TMP to show room picked
    [SerializeField] TMP_Text typeLabel;            // e.g., a small TMP to show type picked

    public string SelectedRoom  { get; private set; }
    public string SelectedType  { get; private set; }
    bool isOpen;

    void Awake()
    {
        if (!panelRoot) panelRoot = gameObject;
        if (!panelGroup)
        {
            panelGroup = panelRoot.GetComponent<CanvasGroup>();
            if (!panelGroup) panelGroup = panelRoot.AddComponent<CanvasGroup>();
        }
        Show(false, true);
    }

    // Hook this ONCE in the Button's OnClick list
    public void ToggleMenu() => Show(!isOpen);

    public void Show(bool value, bool instant = false)
    {
        isOpen = value;

        panelRoot.SetActive(true);                 // stay active for layout
        panelGroup.alpha = value ? 1f : 0f;
        panelGroup.interactable   = value;
        panelGroup.blocksRaycasts = value;         // blocks clicks only when open

        if (openCloseLabel) openCloseLabel.text = value ? closeText : openText;
    }

    // === Missing methods that AnomalyChoiceButton expects ===
    public void SelectRoom(string roomId)
    {
        SelectedRoom = roomId;
        if (roomLabel) roomLabel.text = roomId;
        // Debug.Log($"Room selected: {roomId}");
    }

    public void SelectType(string typeId)
    {
        SelectedType = typeId;
        if (typeLabel) typeLabel.text = typeId;
        // Debug.Log($"Type selected: {typeId}");
    }

    // Optional helpers
    public void ClearSelection()
    {
        SelectedRoom = null;
        SelectedType = null;
        if (roomLabel) roomLabel.text = string.Empty;
        if (typeLabel) typeLabel.text = string.Empty;
    }
}
