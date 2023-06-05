using UnityEngine;
using Sirenix.OdinInspector;

public class AudioManager : MonoBehaviour
{
    [Title("AUDIO CLIPS")]
    [SerializeField] AudioClip ballBounceClip;
    [SerializeField] [Tooltip("This sound will play when the ball goes off-screen, for now (we will change it later)")] AudioClip destructionClip;

    [Space]
    [Title("Script references")]
    [SerializeField] BallLauncher ballLauncher;
    [SerializeField] BallDestroyer ballDestroyer;
    private void Awake()
    {
        BallBehavior.OnBallCollidesWithObjectAUDIO += PlayClip;
        BallDestroyer.OnBallIsDestroyedAUDIO += PlayClip;
        ballLauncher.BallBounceClip = ballBounceClip;

        ballDestroyer.AudioSource.clip = destructionClip;
    }

    private void PlayClip(AudioSource audioSource)
    {
        if(audioSource.clip != null)
            audioSource.Play();
    }

}

