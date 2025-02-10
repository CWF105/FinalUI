using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollView : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform sampleListItem;
    public HorizontalLayoutGroup HLG;

    public float snapForce = 10f;
    public float scaleMultiplier = 1.5f; // Scale factor for selected item
    public float normalScale = 1f; // Default scale
    public float scalingSpeed = 10f; // Speed of scaling
    public float scrollSpeed = 10f; // Speed of scrolling when clicking an item

    private bool isSnapped;
    private float snapSpeed;
    private bool isScrollingToTarget = false;
    private float targetPositionX;

    void Start()
    {
        isSnapped = false;
        AssignClickEvents(); // Attach click events to each item
        SnapToClosestItem();
    }

    void Update()
    {
        if (isScrollingToTarget)
        {
            contentPanel.localPosition = new Vector3(
                Mathf.Lerp(contentPanel.localPosition.x, targetPositionX, Time.deltaTime * scrollSpeed),
                contentPanel.localPosition.y,
                contentPanel.localPosition.z
            );

            if (Mathf.Abs(contentPanel.localPosition.x - targetPositionX) < 0.1f)
            {
                contentPanel.localPosition = new Vector3(targetPositionX, contentPanel.localPosition.y, contentPanel.localPosition.z);
                isScrollingToTarget = false;
                SnapToClosestItem();
            }
            return;
        }

        int currentItem = Mathf.RoundToInt((0 - contentPanel.localPosition.x) / (sampleListItem.rect.width + HLG.spacing));
        float targetX = 0 - (currentItem * (sampleListItem.rect.width + HLG.spacing));

        if (scrollRect.velocity.magnitude < 200 && !isSnapped)
        {
            scrollRect.velocity = Vector2.zero;
            snapSpeed += snapForce * Time.deltaTime;
            contentPanel.localPosition = new Vector3(
                Mathf.MoveTowards(contentPanel.localPosition.x, targetX, snapSpeed),
                contentPanel.localPosition.y,
                contentPanel.localPosition.z
            );

            if (Mathf.Approximately(contentPanel.localPosition.x, targetX))
            {
                isSnapped = true;
                SnapToClosestItem();
            }
        }

        if (scrollRect.velocity.magnitude > 200)
        {
            isSnapped = false;
            snapSpeed = 0;
        }
    }

    void SnapToClosestItem()
    {
        int closestIndex = Mathf.RoundToInt((0 - contentPanel.localPosition.x) / (sampleListItem.rect.width + HLG.spacing));

        for (int i = 0; i < contentPanel.childCount; i++)
        {
            RectTransform item = contentPanel.GetChild(i) as RectTransform;
            if (item == null) continue;

            float targetScale = (i == closestIndex) ? scaleMultiplier : normalScale;
            item.localScale = Vector3.Lerp(item.localScale, new Vector3(targetScale, targetScale, 1f), Time.deltaTime * scalingSpeed);
        }
    }

    void AssignClickEvents()
    {
        for (int i = 0; i < contentPanel.childCount; i++)
        {
            RectTransform item = contentPanel.GetChild(i) as RectTransform;
            if (item == null) continue;

            Button button = item.GetComponent<Button>();
            if (button == null)
            {
                button = item.gameObject.AddComponent<Button>();
            }

            int index = i; // Capture index for the delegate
            button.onClick.AddListener(() => ScrollToItem(index));
        }
    }

    void ScrollToItem(int index)
    {
        targetPositionX = 0 - (index * (sampleListItem.rect.width + HLG.spacing));
        isScrollingToTarget = true;
    }
}