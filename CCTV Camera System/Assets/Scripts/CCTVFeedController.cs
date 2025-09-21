using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CCTVFeedController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private RawImage feedImage;          // your RawImage on the tablet
    [SerializeField] private RenderTexture feedTexture;   // the RT all CCTV cams render into
    [SerializeField] private TMP_Text cameraLabel;        // <-- drag CameraLabel here in Inspector
    [SerializeField] private string labelSuffix = "_CAMERA";

    [Header("Cameras (cycling order)")]
    [SerializeField] private List<Camera> cameras = new List<Camera>();

    [Tooltip("Optional: if set and length matches cameras, these names override GameObject names.")]
    [SerializeField] private List<string> customNames = new List<string>();

    private int index;

    private void Awake()
    {
        // Make sure every CCTV camera writes into the same RT and starts disabled.
        foreach (var cam in cameras)
        {
            if (!cam) continue;
            cam.targetTexture = feedTexture;
            cam.enabled = false;
        }

        if (feedImage) feedImage.texture = feedTexture;
    }

    private void OnEnable()
    {
        // Refresh label when tablet (panel) is re-opened.
        if (cameras.Count > 0) Show(index);
    }

    private void Start()
    {
        if (cameras.Count > 0) Show(0);
    }

    public void NextCam() => Show(index + 1);
    public void PrevCam() => Show(index - 1);

    private void Show(int newIndex)
    {
        if (cameras.Count == 0) return;

        // Wrap index
        index = (newIndex % cameras.Count + cameras.Count) % cameras.Count;

        // Enable only the active cam
        for (int i = 0; i < cameras.Count; i++)
        {
            if (!cameras[i]) continue;
            cameras[i].enabled = (i == index);
        }

        // Update label
        if (cameraLabel)
        {
            string name;
            if (customNames != null && customNames.Count == cameras.Count && !string.IsNullOrWhiteSpace(customNames[index]))
                name = customNames[index];
            else
                name = cameras[index].gameObject.name.Replace("_", " "); // nicer formatting

            cameraLabel.SetText($"{name}{labelSuffix}");
        }
    }
}
