using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableAttachment : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	[SerializeField] public string itemInfo; // Информация об объекте

	private CanvasGroup canvasGroup;
	private RectTransform rectTransform;
	private Transform originalParent;
	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
		if (canvasGroup == null)
		{
			canvasGroup = gameObject.AddComponent<CanvasGroup>();
		}
		originalParent = transform.parent;
	}
	public void OnBeginDrag(PointerEventData eventData)
	{
		canvasGroup.alpha = 0.6f;
		canvasGroup.blocksRaycasts = false;
		transform.SetParent(transform.root); // Перемещаем на верхний уровень иерархии
	}
	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
	}
	public void OnEndDrag(PointerEventData eventData)
	{
		canvasGroup.alpha = 1f;
		canvasGroup.blocksRaycasts = true;

		// Если не был сброшен в целевой объект, возвращаем на исходное место
		if (transform.parent == transform.root)
		{
			transform.SetParent(originalParent);
			rectTransform.anchoredPosition = Vector2.zero;
			NotifyAboutRemoval();
		}
	}
	public string GetItemInfo()
	{
		return itemInfo;
	}

	public event Action<DraggableAttachment> OnItemRemoved;

	// Вызывается при удалении объекта из зоны
	public void RemoveFromZone()
	{
		transform.SetParent(originalParent);
		rectTransform.anchoredPosition = Vector2.zero;
		NotifyAboutRemoval();
	}

	private void NotifyAboutRemoval()
	{
		OnItemRemoved?.Invoke(this);
	}
}
