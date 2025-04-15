using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "PCResources", menuName = "Custom/PCResources")]
public class ResourceMonitorScriptableObj : ScriptableObject
{
    public int cpu;
	public int network;
	public int memory;
	public int disk;
	public float updateInterval;

	public int cpuMax;
	public int networkMax;
	public int memoryMax;
	public int diskMax;
	
	private float[] cpuUsageData;
	private float[] networkUsageData;
	public float[] memoryUsageData;
	private float[] diskUsageData;

	public void init()
	{
		cpuUsageData = new float[cpuMax];
		networkUsageData = new float[networkMax];
		memoryUsageData = new float[memoryMax];
		diskUsageData = new float[diskMax];
		// ������������� ������� ������
		for (int i = 0; i < cpuMax; i++) cpuUsageData[i] = 0f;
		for (int i = 0; i < networkMax; i++) networkUsageData[i] = 0f;
		for (int i = 0; i < memoryMax; i++) memoryUsageData[i] = 0f;
		for (int i = 0; i < diskMax; i++) diskUsageData[i] = 0f;

	}

	public float cpuResource(int minDataPoints, int maxDataPoints)
	{
		for (int i = 0; i < maxDataPoints - 1; i++)
		{
			cpuUsageData[i] = cpuUsageData[i + 1];
		}

		// ��������� ����� ��������� �������� (�������� ������ CPU)
		cpuUsageData[maxDataPoints - 1] = Random.Range(minDataPoints, maxDataPoints);

		// ��������� �����
		return cpuUsageData[maxDataPoints - 1];
	}

	public float networkResource(int minDataPoints, int maxDataPoints)
	{
		for (int i = 0; i < maxDataPoints - 1; i++)
		{
			networkUsageData[i] = networkUsageData[i + 1];
		}

		networkUsageData[maxDataPoints - 1] = Random.Range(minDataPoints, maxDataPoints);

		// ��������� �����
		return networkUsageData[maxDataPoints - 1];
	}

	public float memoryResource(int minDataPoints, int maxDataPoints)
	{
		for (int i = 0; i < maxDataPoints - 1; i++)
		{
			memoryUsageData[i] = memoryUsageData[i + 1];
		}


		memoryUsageData[maxDataPoints - 1] = Random.Range(minDataPoints, maxDataPoints);

		// ��������� �����
		return memoryUsageData[maxDataPoints - 1];
	}

	public float diskResource(int minDataPoints, int maxDataPoints)
	{
		for (int i = 0; i <  maxDataPoints - 1; i++)
		{
			diskUsageData[i] = diskUsageData[i + 1];
		}

		diskUsageData[maxDataPoints - 1] = Random.Range(minDataPoints, maxDataPoints);

		// ��������� �����
		return diskUsageData[ maxDataPoints - 1];
		//diskMax = Random.Range(minDataPoints, maxDataPoints);
	}

}
