using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicBoxController : MonoBehaviour
{

    public TextMeshProUGUI songNameUI;
    public TextMeshProUGUI songThemeUI;
    public Playlist playlist;
    public AudioSource musicPlayer;
    public Button next;
    public Button previous;
    public TMP_Dropdown genres;
    List<SongEntry> currentPlaylist;
    int songIndex = 0;

    void Start()
    {
        next.onClick.AddListener(IncreaseSongIndex);
        previous.onClick.AddListener(DecreaseSongIndex);
        
        UpdatePlaylist(playlist.Beginning);
        UpdateSong(songIndex);
     
        UpdateUI(songIndex);
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void UpdatePlaylist(List<SongEntry> _playlist)
    {
        currentPlaylist = _playlist;
    }

    private void UpdateSong(int i)
    {
        musicPlayer.clip = currentPlaylist[i].audio;
        musicPlayer.Play();
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
            songIndex = 0;
        }else
        {
            songIndex++;
        }
        
        UpdateUI(songIndex);
        UpdateSong(songIndex);
        
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
        UpdateSong(songIndex);
    }

    public void UpdateGenre()
    {
        switch (genres.value)
        {
            case 0:
                UpdatePlaylist(playlist.Beginning);
                UpdateSong(songIndex);
                UpdateUI(songIndex);
                break;

            case 1:
                UpdatePlaylist(playlist.Journey);
                UpdateSong(songIndex);
                UpdateUI(songIndex);
                break;

            case 2:
                UpdatePlaylist(playlist.Combat);
                UpdateSong(songIndex);
                UpdateUI(songIndex);
                break;

            case 3:
                UpdatePlaylist(playlist.Running);
                UpdateSong(songIndex);
                UpdateUI(songIndex);
                break;
        }
    }
}
