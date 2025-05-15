using UnityEngine;

public class NotificationScript : MonoBehaviour
{
	Animator animator;
	bool animationEnded = false;

	void Start()
	{
		animator = GetComponent<Animator>();
		animationEnded = false;
	}

	public void ChangeParent()
    {
		Transform infoPanelContent = GameObject.Find("InfoPanel").transform.Find("Content");

		transform.parent = infoPanelContent;
	}

	private void Update()
	{
		AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

		// Проверяем, что проигрывается нужный клип и он почти закончился
		if (state.IsName("NewNotification") && state.normalizedTime >= 1f && !animationEnded)
		{
			animationEnded = true;
			ChangeParent();
		}
	}
}
