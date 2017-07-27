using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class lastfind : MonoBehaviour {
    public Texture sunaarasi;
    public RawImage damage;
    public Camera main;
    public GameObject player;
    Animator anim;
    float time;
    Vector3 apos, arot;
	// Use this for initialization
	void Start () {
        apos = transform.position;
        arot = transform.localEulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        if (time >= 0.5f)
        {
            anim.SetBool("is_running", false);
            time = 0;
            arot = transform.localEulerAngles;
            apos = transform.position;
        }
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "last")
        {
            anim=col.transform.FindChild("mayoibi_walk7 (3)").GetComponent<Animator>();
            main.cullingMask |= 1 << LayerMask.NameToLayer("hell");
            col.transform.FindChild("mayoibi_walk7 (3)").GetComponent<NavMeshAgent>().SetDestination(transform.position);
            StartCoroutine("finish");
        }
    }
    IEnumerator finish(){
        player.GetComponents<AudioSource>()[1].Play();
        for (int i = 0; i <4; i++)
        {
            Handheld.Vibrate();
            yield return new WaitForSeconds(0.5f);
        }
        player.GetComponents<AudioSource>()[1].Stop();
        damage.color = new Color(1, 1, 1, 1);
        StartCoroutine("suna");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("title");
    }

    IEnumerator suna()
    {
        damage.texture = sunaarasi;
        bool a = true;
        int z = 0;
        while (a)
        {
            if (z == 180)
            {
                z = 0;
            }
            else
            {
                z = 180;
            }

            damage.transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));
            yield return new WaitForSeconds(0.05f);
        }
    }
}
