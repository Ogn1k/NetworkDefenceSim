using UnityEngine;

public class OpenInfoPanel : MonoBehaviour
{
    public Animator animator;
    bool toOpen = false;

    public void InfoPanelButton()
    {
		toOpen = !toOpen;
        if (toOpen)
            animator.SetTrigger("Open");
        else
            animator.SetTrigger("Close");
    }
}
