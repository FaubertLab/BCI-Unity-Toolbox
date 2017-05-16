using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.VR;

public class LevelManager : MonoBehaviour
{
	public delegate void test();

	public void Load(string Level)
	{
		if (Level == "SSVEP")
			VRSettings.enabled = true;
		else if(Level == "LPT_Test")
			VRSettings.enabled = false;

		SceneManager.LoadScene(Level);
	}
}
