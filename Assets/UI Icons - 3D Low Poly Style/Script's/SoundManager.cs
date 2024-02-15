using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

namespace FWC
{
    public class SoundManager : MonoBehaviour
    {
        private Music music;
        public Button SFXToggleButton;
        public Button MusicToggleButton;
        //public Button MToggleLevel;

        public Sprite musicOnSprite;
        public Sprite musicOffSprite;
        public Sprite sfxOnSprite;
        public Sprite sfxOffSprite;

        public AudioMixer masterMixer;
        private float volume_sfx = 1;
        private float volume_music = 1;

        public AudioClip[] clip_SFX; 
        public AudioClip[] clip_Music; 

        public AudioSource source_SFX; 
        public AudioSource source_Music;

        AudioSource audioSource;

        public static SoundManager Instance;
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            music = GameObject.FindObjectOfType<Music>();
            UpdateIconandSFX();
            UpdateIconandMusic();
            source_Music.volume = volume_music;            
            source_SFX.volume = volume_sfx;            
        }

        public void PlaySFX(AudioClip clip)
        {
            if (!source_SFX.isPlaying)
            {
                source_SFX.clip = clip;
                source_SFX.PlayOneShot(source_SFX.clip);
            }

        }

        public void PlaySFX(int i)
        {  
           source_SFX.clip = clip_SFX[i];
           source_SFX.PlayOneShot(source_SFX.clip);           

        }

        public void PlayMusic(int i)
        {
            source_Music.clip = clip_Music[i];
            source_Music.PlayOneShot(source_Music.clip);
        }


        public void MuteMusic()
        {

            music.ToggleSoundMusic();
            UpdateIconandMusic();

        }
        public void MusicLevelMuteButton()
        {
            music.ToggleSoundMusic();
            if (PlayerPrefs.GetInt("Muted", 0) == 0)
            {
                masterMixer.SetFloat("VolumeMusic", volume_music);
                MusicToggleButton.GetComponent<Image>().sprite = musicOnSprite;
            }
            else
            {
                masterMixer.SetFloat("VolumeMusic", -80f);
                MusicToggleButton.GetComponent<Image>().sprite = musicOffSprite;
            }
        }
        void UpdateIconandMusic()
        {
            if (PlayerPrefs.GetInt("Muted", 0) == 0)
            {
                masterMixer.SetFloat("VolumeMusic", volume_music);
                MusicToggleButton.GetComponent<Image>().sprite = musicOnSprite;
            }
            else
            {
                masterMixer.SetFloat("VolumeMusic", -80f);
                MusicToggleButton.GetComponent<Image>().sprite = musicOffSprite;
            }
        }

        public void MuteSFX()
        {
            music.ToggleSoundSFX();
            UpdateIconandSFX();
        }
        void UpdateIconandSFX()
        {
            if(PlayerPrefs.GetInt("SMuted", 0) == 0)
            {
                masterMixer.SetFloat("VolumeSFX", volume_sfx);
                SFXToggleButton.GetComponent<Image>().sprite = sfxOnSprite;
            }
            else
            {
                masterMixer.SetFloat("VolumeSFX", -80f);
                SFXToggleButton.GetComponent<Image>().sprite = sfxOffSprite;
            }
        }
        public void SFXLevelMuteButton()
        {
            music.ToggleSoundSFX();
            if (PlayerPrefs.GetInt("SMuted", 0) == 0)
            {
                masterMixer.SetFloat("VolumeSFX", volume_sfx);
                SFXToggleButton.GetComponent<Image>().sprite = sfxOnSprite;
            }
            else
            {
                masterMixer.SetFloat("VolumeSFX", -80f);
                SFXToggleButton.GetComponent<Image>().sprite = sfxOffSprite;
            }
        }
    }

}
