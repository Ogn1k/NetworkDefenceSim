using System;
using TMPro;
using UnityEngine;

public class TimeText : MonoBehaviour
{
	[SerializeField] private TMP_Text timeText;
	[SerializeField] private string timeFormat = "HH:mm:ss";
	[SerializeField] private float updateInterval = 1f;

	private float timer;

	private void Update()
	{
		timer += Time.deltaTime;

		if (timer >= updateInterval)
		{
			timer = 0f;
			UpdateTime();
		}
	}

	private void UpdateTime()
	{
		// �������� ������� ��������� �����
		DateTime currentTime = DateTime.Now;

		// ����������� ����� �������� ��������� �������
		timeText.text = currentTime.ToString(timeFormat);
	}
}
