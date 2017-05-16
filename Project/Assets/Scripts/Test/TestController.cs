using UnityEngine;

public class TestController : MonoBehaviour {
	
	[SerializeField]	GameObject TestObj;
	[SerializeField]	GameObject Cercle;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!Cercle.activeSelf)
				Cercle.SetActive(true);
			else if(!TestObj.activeSelf)
				TestObj.SetActive(true);
			else
			{
				Cercle.SetActive(false);
				TestObj.SetActive(false);
			}
		}
	}
}
