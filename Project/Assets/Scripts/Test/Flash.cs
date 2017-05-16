using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour {
	
	[SerializeField]	SpriteRenderer[] childsSpriteRenderer;
	[SerializeField]	Sprite[] sprites;
	//[SerializeField]	UDPReceive Echangeur;

	Animator[] childsAnimator;

	SpriteRenderer[] croixSpriteRenderer;

	void Awake()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
	}

	public void Interface(string[] INPUT)
	{
		foreach (SpriteRenderer child in childsSpriteRenderer)
			child.enabled = (INPUT[0] == "1");
	}

	void Start () {
		childsAnimator = transform.Find("Objs").GetComponentsInChildren<Animator>();
		croixSpriteRenderer = transform.Find("Croix").GetComponentsInChildren<SpriteRenderer>();

		childsAnimator[0].speed = 12;
		childsAnimator[1].speed = 14;
		childsAnimator[2].speed = 16;
		childsAnimator[3].speed = 18;
	}

	public void ChangeSize(float newSize)
	{
		newSize = Mathf.Lerp(1, 150, newSize);

		for (int i = 0; i < 4; i++)
			childsAnimator[i].transform.localScale= new Vector3(newSize, newSize, newSize);
	}

	public void ChangeColor(float hue)
	{
		Color nCol = FlashControl_Raw.hueToColor(hue, 1, 1, 1);

		for (int id = 0; id < 4; id++)
			childsSpriteRenderer[id].color = nCol;
	}

	public void ChangeColorCroix(float hue)
	{
		Color nCol = FlashControl_Raw.hueToColor(hue, 1, 1, 1);

		for (int id = 0; id < 4; id++)
			croixSpriteRenderer[id].color = nCol;
	}

	public void ChangeSprite(int NewID)
	{
		for (int id = 0; id < 4; id++)
		{
			childsSpriteRenderer[id].sprite = sprites[NewID];
		}	
	}

	public void setRefreshRate(string newValue)
	{
		if(newValue.Length > 0)
			Application.targetFrameRate = int.Parse(newValue);
	}

	public void setNewFreqN(string freq)
	{
		if(freq.Length > 0)
			childsAnimator[0].speed = int.Parse(freq);
	}

	public void setNewFreqE(string freq)
	{
		if(freq.Length > 0)
			childsAnimator[1].speed = int.Parse(freq);
	}

	public void setNewFreqS(string freq)
	{
		if(freq.Length > 0)
			childsAnimator[2].speed = int.Parse(freq);
	}

	public void setNewFreqO(string freq)
	{
		if(freq.Length > 0)
			childsAnimator[3].speed = int.Parse(freq);
	}
}
