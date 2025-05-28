using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
	[SerializeField] private TMP_Text infoText; // Текстовый элемент для вывода информации
	private DraggableAttachment currentItem; // Текущий содержащийся объект

	public TMP_InputField inputField;
	public TMP_Text inputText;
	System.Random r = new System.Random();
	void Start()
	{
		// Подписываемся на событие окончания редактирования
		inputField.onEndEdit.AddListener(OnInputEndEdit);
	}

	private void OnInputEndEdit(string text)
	{
		// Проверяем, был ли нажат Enter (KeyCode.Return)
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			if(r.Next(0,100) > 50)
			{
				inputText.color = Color.red;
				inputText.text = "Обнаружено вредоносное ПО!";
			}
			else 
			{
				inputText.color = Color.green;
				inputText.text = "Вредоносное ПО не обнаружено";
			}
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (currentItem != null)
		{
			Debug.Log("Зона уже содержит объект!");
			return;
		}

		DraggableAttachment draggedItem = eventData.pointerDrag.GetComponent<DraggableAttachment>();
		if (draggedItem != null)
		{
			currentItem = draggedItem;
			// Устанавливаем новый родительский объект
			draggedItem.transform.SetParent(transform);
			draggedItem.transform.localPosition = Vector3.zero;

			// Выводим информацию о перетаскиваемом объекте
			if (infoText != null)
			{
				if (draggedItem.GetItemInfo().Contains("virus") || draggedItem.GetItemInfo().Contains("Virus"))
				{
					infoText.color = Color.red;
					infoText.text = $"{draggedItem.GetItemInfo()} Это вирус!!";
					
				}
				else
				{
					infoText.color = Color.white;
					infoText.text = $"{draggedItem.GetItemInfo()} не вирус";
					
				}
			}

			// Подписываемся на событие, если объект будет удален/перемещен
			draggedItem.OnItemRemoved += HandleItemRemoved;
		}
	}
	// Обработчик удаления/перемещения объекта из зоны
	private void HandleItemRemoved(DraggableAttachment item)
	{
		if (item == currentItem)
		{
			currentItem = null;
			if (infoText != null)
			{
				infoText.text = "Зона пуста";
			}
		}
	}
	
}
