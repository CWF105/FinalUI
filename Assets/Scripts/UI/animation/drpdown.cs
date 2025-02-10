using UnityEngine;
using UnityEngine.UI;

public class drpdown : MonoBehaviour
{
    public GameObject drpmenu; 
    public Image buttonImage;  
    public Sprite openSprite;  
    public Sprite closeSprite;
    private Animator animator;

    void Start()
    {
        if (drpmenu != null)
        {
            animator = drpmenu.GetComponent<Animator>();
            if (animator != null)
            {
                // Ensure the initial sprite matches the animator's starting state
                bool isDrp = animator.GetBool("drp");
            }
        }
    }

    public void OpenMenu()
    {
        if (animator != null)
        {
            bool isDrp = animator.GetBool("drp");
            animator.SetBool("drp", !isDrp);

            if(buttonImage.sprite == closeSprite) {
                buttonImage.sprite = openSprite;
            }
            else {
                buttonImage.sprite = closeSprite;
            }
            // // Update the sprite AFTER toggling the menu
            // buttonImage.sprite = !isDrp ? openSprite : closeSprite;
        }
    }
}
