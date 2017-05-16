using UnityEngine;
using System.Collections;

public class Cercle : MonoBehaviour {

	Animator Anim;
    float time;
    int frequance = 0;
    void Start () {
		Anim = GetComponent<Animator>();
        time = 0;
        
	}

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time<5)
        {
            SetSpeed(frequance);
        }
        else
        {
            time = 0;
            frequance += 2;
        }
        Debug.Log(frequance);
    }

    public void SetSpeed(string newSpeed)
	{
		Anim.speed = int.Parse(newSpeed);
	}
    public void SetSpeed(int newSpeed)
    {
        Anim.speed = newSpeed;
    }
}
