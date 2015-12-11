/*
*   Writen by: Jonathan Hunter
*   Originally used in:  https://github.com/JonathanHunter/CardNinjas
*   
*   Summary:  
*       This is a simple AudioSource wrapper that allows automatic looping and easy handling of intros to songs.
*       It also easily facilitates the storage and playback of sound effects.  Also when set up properly, 
*       it allows all music and sound effects to be played at the same relative volumes which allows for more easy audio balancing.
*
*   Example use:
*       // Player hits shoot button
*       if(CustomInput.BoolsFreshPress(CustomInput.UserInput.Shoot, 1))
*       {
*           shoot logic
*           sfx.PlaySong(0); // Play shot sound
*       }
*
*/
using UnityEngine;

/// <summary> Simple class for holding and playing sounds. </summary>
public class SoundPlayer : MonoBehaviour
{
    /// <summary> The sounds to play from. </summary>
    public AudioClip[] song;
    /// <summary> The AudioSource to use to play the sounds. </summary>
    public AudioSource audio;
    /// <summary> Is this a sound effect. </summary>
    public bool SFX;
    /// <summary> Have first song play on scene load. </summary>
    public bool playOnLoad;
    /// <summary> Loop the current sound. </summary>
    public bool loop;
    /// <summary> Does the song have an intro before the loop. </summary>
    public bool intro;
    /// <summary> The sound to loop after playing the intro. </summary>
    public int loopSong;
    /// <summary> Sets this object to DontDestroyOnLoad. </summary>
    public bool dontDestroy;

    void Start()
	{
        if (playOnLoad)
            PlaySong(0);
        if (dontDestroy)
            DontDestroyOnLoad(this.gameObject);
        if (SFX)
            audio.volume = Managers.GameManager.SFXVol;
        else
            audio.volume = Managers.GameManager.MusicVol;
    }

    void Update()
    {
        if (intro && !audio.isPlaying)
        {
            intro = false;
            PlaySong(1);
        }
    }

    /// <summary> Plays sound at specified index. </summary>
    /// <param name="index"> The sound to play. </param>
    public void PlaySong(int index)
    {
        audio.Stop();
        audio.loop = loop && index == loopSong;
        audio.clip = song[index];
        audio.Play();
    }

    /// <summary> Pauses the current audio. </summary>
    public void Pause()
    {
        audio.Pause();
    }

    /// <summary> Stops the current audio. </summary>
    public void Stop()
    {
        audio.loop = false;
        audio.Stop();
    }

    /// <summary> Sets the volume of the current audio. </summary>
    /// <param name="vol"> The new volume level. </param>
    public void SetVolume(float vol)
    {
        audio.volume = vol;
    }
}

