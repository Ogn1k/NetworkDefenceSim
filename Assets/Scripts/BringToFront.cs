using UnityEngine;
using UnityEngine.UI;
public class BringToFront : MonoBehaviour
{
	public GameObject targetObject; // ������, ������� ����� �������

	void Start()
	{
		//Button button = GetComponent<Button>();
		//button.onClick.AddListener(MoveToTop);
	}

	public void MoveToTop()
	{
		if (targetObject != null)
		{
			targetObject.transform.SetAsLastSibling();
		}
	}
}
