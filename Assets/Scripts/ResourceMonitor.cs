using TMPro;
using UnityEngine;

public class ResourceMonitor : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private int maxDataPoints = 100;
	[SerializeField] private int minDataPoints = 0;
	[SerializeField] private float updateInterval = 0.5f;

	[SerializeField] private TMP_Text cpuText;
	private float[] cpuUsageData;
	private float timer;

	private void Start()
	{
		cpuUsageData = new float[maxDataPoints];
		// ������������� ������� ������
		for (int i = 0; i < maxDataPoints; i++)
		{
			cpuUsageData[i] = 0f;
		}
	}

	
	private void UpdateCPUData()
	{
		// �������� ������ �����
		for (int i = 0; i < maxDataPoints - 1; i++)
		{
			cpuUsageData[i] = cpuUsageData[i + 1];
		}

		// ��������� ����� ��������� �������� (�������� ������ CPU)
		cpuUsageData[maxDataPoints - 1] = Random.Range(minDataPoints, maxDataPoints);

		// ��������� �����
		cpuText.text = $"{cpuUsageData[maxDataPoints - 1]:F1}%";
	}

	private void Update()
	{
		timer += Time.deltaTime;

		if (timer >= updateInterval)
		{
			timer = 0f;
			UpdateCPUData();
		}
	}
}
