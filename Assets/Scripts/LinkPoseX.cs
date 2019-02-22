using UnityEngine;
using System.Collections;


public class LinkPoseX : MonoBehaviour
{
   
    public GameObject GamePose1, GamePose2;
    public Vector3 position2, position1;
    public Vector3 pos_tempX;
    public float Euclidian_distance;

    Vector3 position_difference, size_temp;
    float C, B;
    Animator dragonAnime;
    Animator witchAnime;

    public static AudioClip dragonFireSound, dragonRoarSound, fireBallSound, magicSound, wingsSound;
    static AudioSource audioSrc;
    public string[] sounds = { "dragonFire", "dragonRoar", "fireball", "magic", "wings" };

    // Use this for initialization
    void Start()
    {
        
        //sound
        //Initializing sound
        dragonFireSound = Resources.Load<AudioClip>("dragonFire");
        dragonRoarSound = Resources.Load<AudioClip>("dragonRoar");
        fireBallSound = Resources.Load<AudioClip>("fireball");
        magicSound = Resources.Load<AudioClip>("magic");
        wingsSound = Resources.Load<AudioClip>("wings");


        audioSrc = GetComponent<AudioSource>();

        Debug.LogWarningFormat("Starting game", GetType());

        witchAnime = GameObject.Find("sj004_skin").GetComponent<Animator>();
        dragonAnime = GameObject.Find("DarkDragon").GetComponent<Animator>();
        /*
        GamePose1.GetComponent<Animator>();
        dragonAnime = GamePose1.GetComponent<Animator>();*/
        dragonAnime.SetTrigger("run");
        dragonAnime.SetTrigger("run");

    }

    // Update is called once per frame
    void Update()
    {
        position_difference = transform.position;
        size_temp = transform.localScale;
        pos_tempX = transform.position;
        position1 = GamePose1.GetComponent<Pose>().pos;
        position2 = GamePose2.GetComponent<Pose2>().pos2;
        
        Euclidian_distance = Mathf.Sqrt(Mathf.Pow((position1.x - position2.x),2) * Mathf.Pow((position1.y - position2.y),2));
        Debug.LogWarningFormat("Euclidian_distance: " + Euclidian_distance, GetType());

        if (Euclidian_distance < 100)
        {
            Debug.LogWarningFormat("Attack triggered", GetType());
            dragonAnime.SetTrigger("attack");
            witchAnime.SetTrigger("attack");

            Random rnd = new Random();
            int rIndex = Random.Range(0, 5);
            PlaySound(sounds[rIndex]);


        }
        else
        {
            Debug.LogWarningFormat("run triggered", GetType());

            dragonAnime.SetTrigger("run");
            witchAnime.SetTrigger("run");
        }
    }

    public void PlaySound(string clip)
    { 
        switch (clip)
        {
            case "dragonFire":
                audioSrc.PlayOneShot(dragonFireSound);
                break;
            case "dragonRoar":
                audioSrc.PlayOneShot(dragonRoarSound);
                break;
            case "fireball":
                audioSrc.PlayOneShot(fireBallSound);
                break;
            case "magic":
                audioSrc.PlayOneShot(magicSound);
                break;
            case "wings":
                audioSrc.PlayOneShot(wingsSound);
                break;
        }
    }


}
