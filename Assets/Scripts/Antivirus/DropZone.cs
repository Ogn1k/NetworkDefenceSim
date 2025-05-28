using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
	[SerializeField] private TMP_Text infoText; // ��������� ������� ��� ������ ����������
	private DraggableAttachment currentItem; // ������� ������������ ������

	public TMP_InputField inputField;
	public TMP_Text inputText;
	System.Random r = new System.Random();
	void Start()
	{
		// ������������� �� ������� ��������� ��������������
		inputField.onEndEdit.AddListener(OnInputEndEdit);
	}

	private void OnInputEndEdit(string text)
	{
		// ���������, ��� �� ����� Enter (KeyCode.Return)
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			if(r.Next(0,100) > 50)
			{
				inputText.color = Color.red;
				inputText.text = "���������� ����������� ��!";
			}
			else 
			{
				inputText.color = Color.green;
				inputText.text = "����������� �� �� ����������";
			}
		}
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (currentItem != null)
		{
			Debug.Log("���� ��� �������� ������!");
			return;
		}

		DraggableAttachment draggedItem = eventData.pointerDrag.GetComponent<DraggableAttachment>();
		if (draggedItem != null)
		{
			currentItem = draggedItem;
			// ������������� ����� ������������ ������
			draggedItem.transform.SetParent(transform);
			draggedItem.transform.localPosition = Vector3.zero;

			// ������� ���������� � ��������������� �������
			if (infoText != null)
			{
				if (draggedItem.GetItemInfo().Contains("virus") || draggedItem.GetItemInfo().Contains("Virus"))
				{
					infoText.color = Color.red;
					infoText.text = $"{draggedItem.GetItemInfo()} ��� �����!!";
					
				}
				else
				{
					infoText.color = Color.white;
					infoText.text = $"{draggedItem.GetItemInfo()} �� �����";
					
				}
			}

			// ������������� �� �������, ���� ������ ����� ������/���������
			draggedItem.OnItemRemoved += HandleItemRemoved;
		}
	}
	// ���������� ��������/����������� ������� �� ����
	private void HandleItemRemoved(DraggableAttachment item)
	{
		if (item == currentItem)
		{
			currentItem = null;
			if (infoText != null)
			{
				infoText.text = "���� �����";
			}
		}
	}
	
}
