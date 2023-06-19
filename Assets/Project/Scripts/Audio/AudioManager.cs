using UnityEngine;
using Sirenix.OdinInspector;

public class AudioManager : MonoBehaviour
{
    [Title("SOUNDTRACK")]
    [SerializeField] private AudioClip levelMusic;
    [Title("AUDIO CLIPS")]
    [SerializeField] [Tooltip("This sound will play when the ball goes off-screen, for now (we will change it later)")] AudioClip destructionClip;
    [SerializeField] AudioClip[] ballBounceClips;

    [Space]
    [Title("Script references")]
    [SerializeField] BallLauncher ballLauncher;
    [SerializeField] BallDestroyer ballDestroyer;

    private AudioSource source;
    private void Awake()
    {
        BallBehavior.OnBallCollidesWithObjectAUDIO += PlayRandomBounceClip;
        BallDestroyer.OnBallIsDestroyedAUDIO += PlayDestructionClip;
        this.source = GetComponent<AudioSource>();
    }

    private void Start() {
        this.PlaySoundrackByScene("level");
    }

    private void PlaySoundrackByScene(string scene)
    {
        if (this.source == null)
        {
            Debug.Log("Audio Source failed");
            return;
        }
        switch (scene)
        {
            case "level":
                this.source.clip = this.levelMusic;
                break;
        }
        this.source.loop = true;
        this.source.Play();
    }

    private void PlayDestructionClip(AudioSource audioSource)
    {
        if(audioSource.clip == null)
            audioSource.clip = destructionClip;

            audioSource.PlayOneShot(destructionClip);
    }

    private void PlayRandomBounceClip(AudioSource audioSource)
    {
        audioSource.clip = ballBounceClips[Random.Range(0, ballBounceClips.Length)];
        audioSource.PlayOneShot(audioSource.clip);
    }

}

