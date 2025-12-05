using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioConfig : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixir;
    [SerializeField] AudioSource seAudioSource;
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] Slider seSlider;
    [SerializeField] Slider bgmSlider;
    // Start is called before the first frame update
    void Start()
    {
        bgmSlider.onValueChanged.AddListener((value) =>
        {
            value = Mathf.Clamp01(value);

            float decibel =20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);
            audioMixir.SetFloat("BGM", decibel);

        });

        seSlider.onValueChanged.AddListener((value) =>
        {
            value = Mathf.Clamp01(value);

            float decibel = 20f * Mathf.Log10(value);
            decibel = Mathf.Clamp(decibel, -80f, 0f);
            audioMixir.SetFloat("SE", decibel);

        });
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            seAudioSource.Play();
        }
    }
}
