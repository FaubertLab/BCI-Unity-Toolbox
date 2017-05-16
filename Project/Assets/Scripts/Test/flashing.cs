using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashing : MonoBehaviour {

    float deltaTime = 0.0f;
    string fpsText;
    string ThreadCalculFrequency;

    public string stringToEdit1 = "40";
    public string stringToEdit2 = "2";
    public string stringToEdit3 = "5";
    public string stringToEdit4 = "1";

    
    float Input_MAX_frequence;
    float Input_pas;
    float Input_duree;
    float Input_size;

    [SerializeField] KeyCode m_enableKey = KeyCode.Escape;
    [SerializeField] Color BackgroundColor = Color.grey;
    float time;
    float time2;
    float Hz;
    bool visible;
    bool start;
    bool m_enable;
    bool hide ;

    float frequence ;
    float MAX_frequence;
    float pas;
    float duree;
       
    string Sfrequance;
    string SMAX_frequence;
    string Spas;
    string Sduree;

    float SliderMAX_frequence;
    float Sliderpas;
    float Sliderduree;

    Rect rectangle;
    Rect rectangleInput;
    float size;

    Texture2D BackgroundTexture;

    Texture2D BackgroundTexture2;

    void Start()
    {
        BackgroundTexture = new Texture2D(1, 1);
        BackgroundTexture.SetPixel(0, 0, BackgroundColor);
        BackgroundTexture.Apply();

        size = gameObject.transform.localScale.x;

        start = false;

        MAX_frequence = 40;
        pas = 2;
        duree = 5;

        SliderMAX_frequence = MAX_frequence;
        Sliderpas = pas;
        Sliderduree = duree;

        visible = true;
        time = 0;
        time2 = 0;
        frequence = 0;
        Show();
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {

        ///FPS Displayer
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        fpsText = "Escape to config";
        GUI.Label(rect, fpsText, style);
        ThreadCalculFrequency = "\n"+Time.deltaTime.ToString()+ "\n";


        GUI.skin.box.normal.background = BackgroundTexture2;
        ShowText();

        hide = GUI.Toggle(new Rect(0, Screen.height / 3, 10, 10), hide, "test");

        if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 50, 100, 50), "Exit"))
        {
            Application.Quit();
        }


        if (m_enable)
        {
            GUI.skin.box.normal.background = BackgroundTexture;

            GUI.Box(new Rect(0, 0, Screen.width, Screen.height / 3), GUIContent.none);

            rectangleInput = new Rect(10, 20, 50, 20);
            if(!hide)
                stringToEdit1 = GUI.TextField(rectangleInput, stringToEdit1, 25);

            rectangle = new Rect(rectangleInput.width+10, 0, Screen.width - rectangleInput.width- 20, 20);
            GUI.Box(rectangle, "MAX_frequence");  
            rectangle.y += 20;
            SliderMAX_frequence = (int)GUI.HorizontalSlider(rectangle, SliderMAX_frequence, 0, 120);


            rectangleInput.y += 30;
            if (!hide)
                stringToEdit2 = GUI.TextField(rectangleInput, stringToEdit2, 25); 
            rectangle.y = rectangleInput.y-20;
            GUI.Box(rectangle, "pas");
            rectangle.y += 20;
            Sliderpas = (int)GUI.HorizontalSlider(rectangle, Sliderpas, 0, 10);

            rectangleInput.y += 30;
            if (!hide)
                stringToEdit3 = GUI.TextField(rectangleInput, stringToEdit3, 25); 
            rectangle.y = rectangleInput.y - 20;
            GUI.Box(rectangle, "duree");
            rectangle.y += 20;
            Sliderduree = (int)GUI.HorizontalSlider(rectangle, Sliderduree, 1, 20);

            rectangleInput.y += 30;
            if (!hide)
                stringToEdit4 = GUI.TextField(rectangleInput, stringToEdit4, 25); 
            rectangle.y = rectangleInput.y - 20;
            GUI.Box(rectangle, "Taille");
            rectangle.y += 20;
            size = GUI.HorizontalSlider(rectangle, size, 0, 8);
            if (!start) { gameObject.transform.localScale = new Vector3(size, size, 1); }
            if (!hide)
                updateValues();

        }


        if (GUI.Button(new Rect((Screen.width - 150) / 2, Screen.height - 50, 100, 50), "Start"))
        {
            frequence = 0;
            start = true;
            MAX_frequence = (int)SliderMAX_frequence;
            pas = (int)Sliderpas;
            duree = (int)Sliderduree;
        }
        if (GUI.Button(new Rect((Screen.width + 150) / 2, Screen.height - 50, 100, 50), "Stop"))
        {
            start = false;
        }
        

    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(m_enableKey))
        {
            m_enable = !m_enable;
        }

            if (start)
        {
            Sfrequance = " Frequence : " + frequence.ToString() + "Hz \n";
            SMAX_frequence = " Frequence max : " + MAX_frequence.ToString() + "Hz \n";
            Spas = "Le pas de la frequence : " + pas.ToString() + " \n";
            Sduree = "duree en seconde pour une frequence :" + duree.ToString() + " \n";
        }
        else
        {
            Sfrequance = "";
            SMAX_frequence = " Frequence max : " + SliderMAX_frequence.ToString() + "Hz \n";
            Spas = "Le pas de la frequence : " + Sliderpas.ToString() + " \n";
            Sduree = "duree en seconde pour une frequence :" + Sliderduree.ToString() + " \n";
        }                  
        
        if (frequence> MAX_frequence)
        {
            frequence = 0;
            pas = 0;
            start = false;
            //end
        }
        time += Time.deltaTime;
        time2 += Time.deltaTime;
        Hz = 1f / frequence;
        if(start)
        {
            if (time > duree)
            {
                time = 0;

                frequence += pas;
            }
            if (visible == true)
            {
                if (time2 > Hz)
                {
                    Hide();
                }
            }
            else
            {
                if (time2 > Hz)
                {
                    Show();
                }
            }
        }        

    }
    

    void Hide()
    {
        visible = false;
        GetComponent<Renderer>().transform.localScale = new Vector3(0,0,0);
        time2 = 0;
    }

    void Show()
    {
        visible = true;
        GetComponent<Renderer>().transform.localScale = new Vector3(size, size, 1);
        time2 = 0;
    }
    
    void ShowText ()
    {
        GUI.Box(new Rect(0, Screen.height / 3, Screen.width/3, Screen.height ), Sfrequance + SMAX_frequence + Spas + Sduree + fpsText + ThreadCalculFrequency);
    }

    void updateValues()
    {
        Input_MAX_frequence= float.Parse(stringToEdit1);
        TruncateValue(ref Input_MAX_frequence,0,120);        
        MAX_frequence = Input_MAX_frequence;
        SliderMAX_frequence = MAX_frequence;

        Input_pas = float.Parse(stringToEdit2);
        TruncateValue(ref Input_pas, 0, 20);
        pas = Input_pas;
        Sliderpas = pas;

        Input_duree = float.Parse(stringToEdit3);
        TruncateValue(ref Input_duree, 0, 20);
        duree = Input_duree;
        Sliderduree = duree;        

    }

    void TruncateValue(ref float input ,float mini,float maxi)
    {
        if (input < mini)
        {
            input = mini;
        }
        if (input > maxi)
        {
            input = maxi;
        }
    }
        
}
