using UnityEngine;

public class Sound : MonoBehaviour {

    AudioSource sound;
    AudioClip audioMove;
    AudioClip audioStart;
    AudioClip audioSolved;
	
	void Start ()
    {
        sound = GetComponent<AudioSource>();

        audioMove = Resources.Load<AudioClip>("move");
        audioStart = Resources.Load<AudioClip>("start");
        audioSolved = Resources.Load<AudioClip>("solved");
    }
	
    public void PlayMove()
    {
        sound.PlayOneShot(audioMove);
    }

    public void PlayStart()
    {
        sound.PlayOneShot(audioStart);
    }

    public void PlaySolved()
    {
        sound.PlayOneShot(audioSolved);
    }
}
