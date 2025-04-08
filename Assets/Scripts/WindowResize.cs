using UnityEngine;
using UnityEngine.EventSystems;

public class WindowResize : MonoBehaviour, IPointerDownHandler, IDragHandler
{
	[SerializeField] private RectTransform windowToResize;
	[SerializeField] private Vector2 minSize = new Vector2(100, 100);
	[SerializeField] private Vector2 maxSize = new Vector2(1920, 1080);

	private Vector2 originalSize;
	private Vector2 originalMousePosition;

	public void OnPointerDown(PointerEventData eventData)
	{
		originalSize = windowToResize.sizeDelta;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(
			windowToResize,
			eventData.position,
			eventData.pressEventCamera,
			out originalMousePosition);
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (windowToResize == null) return;

		RectTransformUtility.ScreenPointToLocalPointInRectangle(
			windowToResize,
			eventData.position,
			eventData.pressEventCamera,
			out Vector2 currentMousePosition);

		Vector2 offset = currentMousePosition - originalMousePosition;

		Vector2 newSize = originalSize + new Vector2(offset.x, -offset.y);

		newSize.x = Mathf.Clamp(newSize.x, minSize.x, maxSize.x);
		newSize.y = Mathf.Clamp(newSize.y, minSize.y, maxSize.y);

		windowToResize.sizeDelta = newSize;
	}
}
