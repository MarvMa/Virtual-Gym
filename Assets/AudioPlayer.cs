using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void play()
    {
        switch (CrossSceneInfo1.animation_id)
        {
            case "air_squat":
                play(back_squat);
                break;
            case "back_squat":
                play(back_squat);
                break;
            case "biceps_curl":
                play(biceps_curl);
                break;
            case "burpee":
                play(burpee);
                break;
            case "clean_and_jerk":
                play(clean_and_jerk);
                break;
            case "front_raises":
                play(front_raises);
                break;
            case "jump_push_up":
                play(jump_push_up);
                break;
            case "jumping_jacks":
                play(jumping_jacks);
                break;
            case "overhead_squat":
                play(overhead_squat);
                break;
            case "pike_walk":
                play(pike_walk);
                break;
            case "pistol_squat":
                play(pistol_squat);
                break;
            case "push_up":
                play(push_up);
                break;
            case "situps":
                play(situps);
                break;
            case "snatch":
                play(snatch);
                break;
            case "sumo_high_pull":
                play(sumo_high_pull);
                break;
            default:
                break;
        }

    }

    private void play(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip, 0.7f);
    }

    // Update is called once per frame
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
