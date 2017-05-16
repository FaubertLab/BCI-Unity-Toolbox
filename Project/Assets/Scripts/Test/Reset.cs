using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour {

	public void reset()
	{
		Destroy(GameObject.Find("Grid"));
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
