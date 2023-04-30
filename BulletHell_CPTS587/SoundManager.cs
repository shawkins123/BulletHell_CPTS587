using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell_CPTS587
{
    class SoundManager
    {
        private Song backgroundMusic;
        private SoundEffectInstance bulletSoundInstance;

        public SoundManager(Song backgroundMusic)
        {
            this.backgroundMusic = backgroundMusic;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);
            MediaPlayer.Pause();
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                PauseBackgroundMusic();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                StopBackgroundMusic();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                ResumeBackgroundMusic();
            }

        }
        public void PlayBackgroundMusic()
        {
            if (MediaPlayer.State == MediaState.Paused)
            {
                MediaPlayer.Resume();
            }
            else if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(backgroundMusic);
            }
        }

        public void PauseBackgroundMusic()
        {
            if (MediaPlayer.State == MediaState.Playing)
            {
                MediaPlayer.Pause();
            }
        }

        public void StopBackgroundMusic()
        {
            if (MediaPlayer.State == MediaState.Playing || MediaPlayer.State == MediaState.Paused)
            {
                MediaPlayer.Stop();
            }
        }

        public void ResumeBackgroundMusic()
        {
            if (MediaPlayer.State == MediaState.Paused)
            {
                MediaPlayer.Resume();
            }
        }
    }
}
