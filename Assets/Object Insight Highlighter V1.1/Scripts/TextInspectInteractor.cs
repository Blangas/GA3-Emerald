using UnityEngine;

namespace TextInspectSystem
{
    public class TextInspectInteractor : MonoBehaviour
    {
        [Header("Raycast Features")]
        [SerializeField] private float rayLength = 5;
        private Camera _camera;

        private TextInspectItem textItem;

        [Header("Input Key")]
        [SerializeField] private KeyCode interactKey;

        void Start()
        {
            if (!TryGetComponent<Camera>(out _camera))
            {
                Debug.LogError("Camera component not found on the GameObject.");
            }
        }

        private void Update()
        {
            if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, rayLength))
            {
                var readableItem = hit.collider.GetComponent<TextInspectItem>();
                if (readableItem != null)
                {
                    textItem = readableItem;
                    textItem.ShowObjectName(true);
                    HighlightCrosshair(true);
                }
                else
                {
                    ClearText();
                }
            }
            else
            {
                ClearText();
            }

            if (textItem != null)
            {
                if (Input.GetKeyDown(interactKey))
                {
                    textItem.ShowDetails();

                    // Mine addition to check if the item is pickable and deactivate it
                    if (textItem.isPickable)
                    {
                        textItem.displayIcon.SetActive(true); // Hide the icon
                        textItem.gameObject.SetActive(false);
                        // Implement pickable item logic here
                        Debug.Log("Picked up: " + textItem.name);
                    }
                }
            }
        }

        void ClearText()
        {
            if (textItem != null)
            {
                textItem.ShowObjectName(false);
                HighlightCrosshair(false);
                textItem = null;
            }
        }

        void HighlightCrosshair(bool on)
        {
            TextInspectUIManager.instance.HighlightCrosshair(on);
        }
    }
}

