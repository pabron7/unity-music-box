using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicBoxController : MonoBehaviour
{

    [Header("Attachments")]
    public TextMeshProUGUI songNameUI;
    public TextMeshProUGUI songThemeUI;
    public Playlist playlist;
    public AudioSource musicPlayer;
    public TMP_Dropdown playlistsDropdown;

    [Header("Buttons")]
    public Button next;
    public Button previous;
    public Button play;
    public Button pause;


    List<SongEntry> currentPlaylist;

    int songIndex = 0;

    void Start()
    {
        next.onClick.AddListener(IncreaseSongIndex);
        previous.onClick.AddListener(DecreaseSongIndex);
        play.onClick.AddListener(PlaySong);
        pause.onClick.AddListener(PauseSong);
        
        SelectPlaylist(playlist.Beginning);
        SelectSong(songIndex);
     
        UpdateUI(songIndex);
    }

    private void SelectPlaylist(List<SongEntry> _playlist)
    {
        currentPlaylist = _playlist;
    }

    private void SelectSong(int i)
    {
        musicPlayer.clip = currentPlaylist[i].audio;
        PlaySong();
    }

    private void PlaySong()
    {
        musicPlayer.Play();
    }

    private void PauseSong()
    {
        musicPlayer.Pause();
    }

    private void ResetIndex()
    {
        songIndex = 0;
    }

    private void UpdateUI(int i)
    {
        if (currentPlaylist == playlist.Journey)
        {
            songThemeUI.text = "Journey";
        }
        else if (currentPlaylist == playlist.Beginning)
        {
            songThemeUI.text = "Beginning";
        }
        else if (currentPlaylist == playlist.Running)
        {
            songThemeUI.text = "Running";
        }
        else if (currentPlaylist == playlist.Combat)
        {
            songThemeUI.text = "Combat";
        }
        else
        {
            songThemeUI.text = "SOMETHING WRONG!";
        }

        songNameUI.text = currentPlaylist[i].name;
    }

    private void IncreaseSongIndex()
    {
        if (songIndex>=currentPlaylist.Count-1)
        {
            ResetIndex();
        }else
        {
            songIndex++;
        }
        
        UpdateUI(songIndex);
        SelectSong(songIndex);
        
    }

    private void DecreaseSongIndex()
    {
        if (songIndex == 0){
            songIndex = currentPlaylist.Count-1;
        }else
        {
            songIndex--;
        }
       
        UpdateUI(songIndex);
        SelectSong(songIndex);
    }

    public void UpdatePlaylist()
    {
        switch (playlistsDropdown.value)
        {
            case 0:
                ResetIndex();
                SelectPlaylist(playlist.Beginning);
                SelectSong(songIndex);
                UpdateUI(songIndex);
                break;

            case 1:
                ResetIndex();
                SelectPlaylist(playlist.Journey);
                SelectSong(songIndex);
                UpdateUI(songIndex);
                break;

            case 2:
                ResetIndex();
                SelectPlaylist(playlist.Combat);
                SelectSong(songIndex);
                UpdateUI(songIndex);
                break;

            case 3:
                ResetIndex();
                SelectPlaylist(playlist.Running);
                SelectSong(songIndex);
                UpdateUI(songIndex);
                break;
        }
    }
}
