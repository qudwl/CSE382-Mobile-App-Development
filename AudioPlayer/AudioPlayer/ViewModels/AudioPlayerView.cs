using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer.ViewModels
{
    public class AudioPlayerView : INotifyPropertyChanged
    {
        bool loop;
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IAudioManager audioManager;
        private IAudioPlayer player;
        private int volume;
        private string playButtonText;

        public AudioPlayerView()
        {
            loop = false;
            volume = 5;
            this.audioManager = AudioManager.Current;
            playButtonText = "Play";

            PlayCommand = new Command(
                execute: async () =>
                {
                    if (player == null)
                    {
                        player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("car-skid.wav"));
                        player.Volume = (double)volume / 10;
                    }
                    player.PlaybackEnded += PlayAgain;
                    PlayButtonText = "Playing";
                    player.Play();
                });
            PauseCommand = new Command(
                execute: () =>
                {
                    if (player != null)
                    {
                        player.Pause();
                        PlayButtonText = "Play";
                    }
                });
            IncCommand = new Command(
                execute: () =>
                {
                    Volume += 1;
                    RefreshButtons();
                }, canExecute: () => Volume < 10);
            DecCommand = new Command(
                execute: () =>
                {
                    Volume -= 1;
                    RefreshButtons();
                }, canExecute: () => Volume > 0);
        }

        public bool Loop
        {
            get { return loop; }
            set
            {
                if (value != loop)
                {
                    loop = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Loop"));
                }
            }
        }

        public int Volume
        {
            get { return volume; }
            set
            {
                if (value != volume)
                {
                    volume = value;
                    if (player != null) player.Volume = (double)volume / 10;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Volume"));
                }
            }
        }

        public string PlayButtonText
        {
            get { return playButtonText; }
            set
            {
                if (value != playButtonText)
                {
                    playButtonText = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PlayButtonText"));
                }
            }
        }

        private void RefreshButtons()
        {
            ((Command)PlayCommand).ChangeCanExecute();
            ((Command)IncCommand).ChangeCanExecute();
            ((Command)DecCommand).ChangeCanExecute();
        }

        public Command PlayCommand { private set; get; }
        public Command PauseCommand { private set; get; }
        public Command IncCommand { private set; get; }
        public Command DecCommand { private set; get; }

        private void PlayAgain(object sender, EventArgs e)
        {
            if (loop) { 
                player.Play();
            }
            else
            {
                PlayButtonText = "Play";
            }
        }
    }
}
