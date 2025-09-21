using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnomalyMenuController : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] GameObject panelRoot;          
    [SerializeField] CanvasGroup panelGroup;        

    [Header("Open/Close Button")]
    [SerializeField] Button   openCloseButton;     
    [SerializeField] TMP_Text openCloseLabel;       
    [SerializeField] string   openText  = "OPEN ANOMALY MENU";
    [SerializeField] string   closeText = "CLOSE ANOMALY MENU";

    [Header("Selection (optional labels)")]
    [SerializeField] TMP_Text roomLabel;            
    [SerializeField] TMP_Text typeLabel;            

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

    
    public void ToggleMenu() => Show(!isOpen);

    public void Show(bool value, bool instant = false)
    {
        isOpen = value;

        panelRoot.SetActive(true);                 
        panelGroup.alpha = value ? 1f : 0f;
        panelGroup.interactable   = value;
        panelGroup.blocksRaycasts = value;         

        if (openCloseLabel) openCloseLabel.text = value ? closeText : openText;
    }

    
    public void SelectRoom(string roomId)
    {
        SelectedRoom = roomId;
        if (roomLabel) roomLabel.text = roomId;
        
    }

    public void SelectType(string typeId)
    {
        SelectedType = typeId;
        if (typeLabel) typeLabel.text = typeId;
        
    }

    
    public void ClearSelection()
    {
        SelectedRoom = null;
        SelectedType = null;
        if (roomLabel) roomLabel.text = string.Empty;
        if (typeLabel) typeLabel.text = string.Empty;
    }
}
