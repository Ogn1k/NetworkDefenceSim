using UnityEngine;
using UnityEngine.EventSystems;

public class DefaultAppScript : MonoBehaviour, IPointerDownHandler, IDragHandler
{//, IBeginDragHandler, IEndDragHandler
	[SerializeField] private RectTransform dragRectTransform;
	[SerializeField] private Canvas canvas;
	[SerializeField] private AppManager appManager;

	public void OnInstantiate()
	{
		canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
		appManager = GameObject.Find("Taskbar").GetComponent<AppManager>();

		if (dragRectTransform == null)
			dragRectTransform = GetComponent<RectTransform>();

	}

	public void OnDrag(PointerEventData eventData)
	{
		
		dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		// Делаем окно "верхним" в иерархии при клике
		dragRectTransform.SetAsLastSibling();

	}
	public void CloseAppF()
	{
		appManager.DeleteFromTaskbar(dragRectTransform.gameObject.name);
		Destroy(dragRectTransform.gameObject);
	}

}
