using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour {
    public GameObject mayoibi;
    public GameObject[] obj;
    public Image[] image;
    GameObject player;
    public RawImage damage;
    public GameObject maincamera;
    public stickset st;
    public Text sankyu;
    public GameObject findplayer;
    // Use this for initialization
    AudioSource[] bgm;

    void Start()
    {
        bgm = gameObject.GetComponents<AudioSource>();
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.tag);
        if (col.gameObject.tag == "Player")
        {
            st.enabled = false;
            Screen.autorotateToLandscapeRight = true;
            Screen.autorotateToLandscapeLeft = true;
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].SetActive(false);
            }
            for (int i = 0; i < image.Length; i++)
            {
                image[i].enabled=false;
            }
            player = col.gameObject;
            player.GetComponent<Camerakirikae>().enabled = false;
            player.GetComponent<PLstatus>().HP = 100;
            player.GetComponent<PLstatus>().enabled = false;
            mayoibi.SetActive(true);
            GameObject obj2 = (GameObject)Instantiate(findplayer, player.transform.FindChild("MainCamera").position, Quaternion.identity);
            obj2.transform.GetComponentInChildren<lastfind>().damage = damage;
            obj2.transform.GetComponentInChildren<lastfind>().player = player;
            obj2.transform.GetComponentInChildren<lastfind>().main = player.transform.FindChild("MainCamera").GetComponent<Camera>();
            obj2.transform.parent = player.transform.FindChild("MainCamera");
        }

    }
}
