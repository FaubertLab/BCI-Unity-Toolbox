using UnityEngine;
using UnityEngine.UI;

public class FlashControl_Raw : MonoBehaviour {
	
	RawImage Img;
	RawImage BackgroundImg;
	Animator Anim;

	[SerializeField]
	Image slider;
	[SerializeField]
	Image backslider;

	void Start () {
		Img = GetComponent<RawImage>();
		BackgroundImg = transform.parent.GetComponent<RawImage>();
		Anim = GetComponent<Animator>();
	}

	public void SetSpeed(string newSpeed)
	{
		Anim.speed = int.Parse(newSpeed);
	}

	public void SetColor(float hue)
	{
		Img.color = hueToColor(hue,1,1,1);
		slider.color = Img.color;
	}

	public void SetBackgroundColor(float hue)
	{
		BackgroundImg.color = hueToColor(hue, 1, 1, 1);
		backslider.color = BackgroundImg.color;
	}

	public static Color hueToColor(float INPUT_H, float INPUT_S, float INPUT_B, float INPUT_A)
	{
		float r = INPUT_B;
		float g = INPUT_B;
		float b = INPUT_B;

		if (INPUT_S != 0)
		{
			float max = INPUT_B;
			float dif = INPUT_B * INPUT_S;
			float min = INPUT_B - dif;

			float h = INPUT_H * 360f;

			if (h < 60f)
			{
				r = max;
				g = h * dif / 60f + min;
				b = min;
			}
			else if (h < 120f)
			{
				r = -(h - 120f) * dif / 60f + min;
				g = max;
				b = min;
			}
			else if (h < 180f)
			{
				r = min;
				g = max;
				b = (h - 120f) * dif / 60f + min;
			}
			else if (h < 240f)
			{
				r = min;
				g = -(h - 240f) * dif / 60f + min;
				b = max;
			}
			else if (h < 300f)
			{
				r = (h - 240f) * dif / 60f + min;
				g = min;
				b = max;
			}
			else if (h <= 360f)
			{
				r = max;
				g = min;
				b = -(h - 360f) * dif / 60 + min;
			}
			else
			{
				r = 0;
				g = 0;
				b = 0;
			}
		}

		return new Color(Mathf.Clamp01(r), Mathf.Clamp01(g), Mathf.Clamp01(b), INPUT_A);
	}
}
