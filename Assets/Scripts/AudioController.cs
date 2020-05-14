using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    public AudioSource Song;

    public AudioSource Jump;

    public AudioSource Damage;

    public AudioSource Shoot;

    public AudioSource Item;

    public AudioSource PowerUp;

    public AudioSource Timer;

    public AudioSource GameOver;

    public AudioSource Win;
    

    private void Awake()
    {
        Instance = this;
    }
    
    public enum SoundEffect
    {
        Song,

        Jump,

        Damage,

        Shoot,

        Item,

        PowerUp,

        Timer,

        GameOver,
        
        Win
    }
    

    public void PlaySoundEffect(SoundEffect type)
    {
        switch (type)
        {

        case SoundEffect.Song:
            Song.Play();
            break;
            
        case SoundEffect.Jump:
            Jump.Play();
            break;

        case SoundEffect.Damage:
            Damage.Play();
            break;

        case SoundEffect.Shoot:
            Shoot.Play();
            break;

        case SoundEffect.Item:
            Item.Play();
            break;

        case SoundEffect.PowerUp:
            PowerUp.Play();
            break;

        case SoundEffect.Timer:
            Song.Stop();
            Timer.Play();
            break;

        case SoundEffect.GameOver:
            Song.Stop();
            Timer.Stop();
            GameOver.Play();
            break;

        case SoundEffect.Win:
            Song.Stop();
            Timer.Stop();
            Win.Play();
            break;

        }
    }
}
