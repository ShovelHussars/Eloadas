using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Dropdown dropdown;
    public Dropdown qualityDropdown;
    Resolution[] resolutions;
    public AudioMixer audioMixer;
    private void Start()
    {
        qualityDropdown.value = (int)QualitySettings.currentLevel;
        dropdown.ClearOptions();
        resolutions = Screen.resolutions;

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; ++i)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        dropdown.AddOptions(options);
        dropdown.value = currentResolutionIndex;
        dropdown.RefreshShownValue();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void toggleFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        print(isFullScreen);
    }
    
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("mainVolume",volume);
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
