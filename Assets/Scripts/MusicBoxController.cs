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
    List<SongEntry> currentPlaylist;

    void Start()
    {
        updatePlaylist(playlist.Beginning);
        updateSong(0);
        musicPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void updatePlaylist(List<SongEntry> _playlist)
    {
        currentPlaylist = _playlist;
    }

    private void updateSong(int i)
    {
        musicPlayer.clip = currentPlaylist[i].audio;
    }
}
