using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetAudioLevels : MonoBehaviour {
        
    public AudioMixer mainMixer;    // Reference to main audio mixer

    public void SetMusicVol(float musicVol) {
        mainMixer.SetFloat("MusicVol", musicVol);
    }

    public void SetFXVol(float fxVol)
    {
        mainMixer.SetFloat("SFXVol", fxVol);
    }

    public void SetMasterVol(float masterVol)
    {
        mainMixer.SetFloat("MasterVol", masterVol);
    }
}
