using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    #region variables
    AudioSource audioSource_on;
    public AudioClip OnSound;

    public AudioSource ThemeSound;

    public Material hitMaterial1;
    public Material hitMaterial2;
    public Material hitMaterial3;

    public Material mainMaterial1;
    public Material mainMaterial2;
    public Material mainMaterial3;

    MeshRenderer BlueRenderer;
    MeshRenderer GreenRenderer;
    MeshRenderer RedRenderer;

    public bool pushButton = false;
    public bool RedCount = false;
    public bool GreenCount = false;
    public bool BlueCount = false;
    public bool GameStart = false;

    public AudioSource themaSound
    {
        get { return ThemeSound; }
        set { ThemeSound = value; }
    }

    public bool gameStart
    {
        get { return GameStart; }
        set { GameStart = value; }
    }

    public GameObject BlueLight;
    public GameObject RedLight;
    public GameObject GreenLight;

    public Text timeCount;
    public float timeCost = 0f;

    private GameEnding End;

    private int numb = 0;
    private int Check = 0;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        End = FindObjectOfType<GameEnding>().GetComponent<GameEnding>();

        this.audioSource_on = this.gameObject.AddComponent<AudioSource> ();
        this.audioSource_on.clip = this.OnSound;
        this.audioSource_on.loop = false;

        this.audioSource_on = this.gameObject.AddComponent<AudioSource>();
        this.audioSource_on.clip = this.OnSound;
        this.audioSource_on.loop = true;

        BlueLight = GameObject.Find("Blue Light");
        RedLight = GameObject.Find("Red Light");
        GreenLight = GameObject.Find("Green Light");

        BlueLight.SetActive(false);
        RedLight.SetActive(false);
        GreenLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        #region Game Start
        if (GameStart == true && Check == 0)
        {
            ThemeSound.Play();
            Check = 1;
        }
        if(GameStart == false)
        {
            Check = 0;
        }

        if (BlueCount == true && RedCount == true && GreenCount == true)
        {
            timeCost += Time.deltaTime;

            if (timeCost >= 3.0f)
            {
                timeCount.text = "";
                GameStart = true;
            }
            else if (timeCost >= 2.0f)
            {
                timeCount.text = "1";
            }
            else if (timeCost >= 1.0f)
            {
                timeCount.text = "2";
            }
            else
            {
                timeCount.text = "3";
            }
        }
        #endregion
        #region Button Push
        if (Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var rig = hit.collider.GetComponent<Rigidbody>();
                {
                    if (rig != null)
                    {
                        rig.AddTorque(Vector3.up * 100000f);

                        if (hit.transform.tag == "Blue")
                        {
                            if (numb == 0)
                            {
                                this.audioSource_on.PlayOneShot(OnSound);
                                numb++;
                            }

                            Debug.Log("Blue button click");
                            rig.GetComponent<MeshRenderer>().material = hitMaterial1;
                            BlueLight.SetActive(true);
                            BlueCount = true;
                        }
                        if (hit.transform.tag == "Green")
                        {
                            if (numb == 0)
                            {
                                this.audioSource_on.PlayOneShot(OnSound);
                                numb++;
                            }

                            Debug.Log("Green button click");
                            rig.GetComponent<MeshRenderer>().material = hitMaterial2;
                            GreenLight.SetActive(true);
                            GreenCount = true;
                        }
                        if (hit.transform.tag == "Red")
                        {
                            if (numb == 0)
                            {
                                this.audioSource_on.PlayOneShot(OnSound);
                                numb++;
                            }

                            Debug.Log("Red button click");
                            rig.GetComponent<MeshRenderer>().material = hitMaterial3;
                            RedLight.SetActive(true);
                            RedCount = true;
                        }
                    }
                }
            }
        }
        else
        {
            pushButton = true;
        }

        if (pushButton == true && GameStart == false)
        {
            numb = 0;
            if(GameObject.FindWithTag("Blue"))
            {
                GameObject.FindWithTag("Blue").GetComponent<MeshRenderer>().material = mainMaterial1;
            }
            if (GameObject.FindWithTag("Green"))
            {
                GameObject.FindWithTag("Green").GetComponent<MeshRenderer>().material = mainMaterial2;
            }
            if (GameObject.FindWithTag("Red"))
            {
                GameObject.FindWithTag("Red").GetComponent<MeshRenderer>().material = mainMaterial3;
            }
            pushButton = false;
        }
        else if (pushButton == true && GameStart == true)
        {
            numb = 0;
            if (GameObject.FindWithTag("Blue"))
            {
                GameObject.FindWithTag("Blue").GetComponent<MeshRenderer>().material = mainMaterial1;
                BlueLight.SetActive(false);
                BlueCount = false;
            }
            if (GameObject.FindWithTag("Green"))
            {
                GameObject.FindWithTag("Green").GetComponent<MeshRenderer>().material = mainMaterial2;
                GreenLight.SetActive(false);
                GreenCount = false;
            }
            if (GameObject.FindWithTag("Red"))
            {
                GameObject.FindWithTag("Red").GetComponent<MeshRenderer>().material = mainMaterial3;
                RedLight.SetActive(false);
                RedCount = false;
            }
            pushButton = false;
        }
        #endregion
    }
}