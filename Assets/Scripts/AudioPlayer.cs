using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  contains all TTS audio files, can play the one of the central animation based on animation_id from CrossSceneInfo1
/// </summary>

public class AudioPlayer : MonoBehaviour
{
    
    private AudioSource audioSource;
    public AudioClip air_squat;
    public AudioClip back_squat;
    public AudioClip biceps_curl;
    public AudioClip burpee;
    public AudioClip clean_and_jerk;
    public AudioClip front_raises;
    public AudioClip jump_push_up;
    public AudioClip jumping_jacks;
    public AudioClip overhead_squat;
    public AudioClip pike_walk;
    public AudioClip pistol_squat;
    public AudioClip push_up;
    public AudioClip situps;
    public AudioClip snatch;
    public AudioClip sumo_high_pull;

    /// <summary>
    // Start is called before the first frame update
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    ///  Plays a specific tts audio file
    /// </summary>
    public void play()
    {
        switch (CrossSceneInfo1.animation_id)
        {
            case "air_squat":
                toggleClip(back_squat);
                break;
            case "back_squat":
                toggleClip(back_squat);
                break;
            case "biceps_curl":
                toggleClip(biceps_curl);
                break;
            case "burpee":
                toggleClip(burpee);
                break;
            case "clean_and_jerk":
                toggleClip(clean_and_jerk);
                break;
            case "front_raises":
                toggleClip(front_raises);
                break;
            case "jump_push_up":
                toggleClip(jump_push_up);
                break;
            case "jumping_jacks":
                toggleClip(jumping_jacks);
                break;
            case "overhead_squat":
                toggleClip(overhead_squat);
                break;
            case "pike_walk":
                toggleClip(pike_walk);
                break;
            case "pistol_squat":
                toggleClip(pistol_squat);
                break;
            case "push_up":
                toggleClip(push_up);
                break;
            case "situps":
                toggleClip(situps);
                break;
            case "snatch":
                toggleClip(snatch);
                break;
            case "sumo_high_pull":
                toggleClip(sumo_high_pull);
                break;
            default:
                break;
        }

    }

    /// <summary>
    ///  Toggles the audio on or off
    /// </summary>
    /// <param name="audioClip">audioclip to toggle</param>
    private void toggleClip(AudioClip audioClip)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.PlayOneShot(audioClip, 0.7f);
        }
    }
    /// <summary>
    /// Update is called once per frame
    /// </summary>

    void Update()
    {
        // audioSource.Play();
    }
    
        // private void stopAudio()
        // {
        //     if (audioPlaying)
        //     {
        //         audioSource.Stop();
        //         audioPlaying = false;
        //     }
        // }
}
