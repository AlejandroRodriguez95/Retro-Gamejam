using UnityEngine;
using Sirenix.OdinInspector;

public class AudioManager : MonoBehaviour
{
    [Title("AUDIO CLIPS")]
    [SerializeField] [Tooltip("This sound will play when the ball goes off-screen, for now (we will change it later)")] AudioClip destructionClip;
    [SerializeField] AudioClip[] ballBounceClips;

    [Space]
    [Title("Script references")]
    [SerializeField] BallLauncher ballLauncher;
    [SerializeField] BallDestroyer ballDestroyer;
    private void Awake()
    {
        BallBehavior.OnBallCollidesWithObjectAUDIO += PlayRandomBounceClip;
        BallDestroyer.OnBallIsDestroyedAUDIO += PlayDestructionClip;
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

