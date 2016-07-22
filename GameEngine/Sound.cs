using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace GameEngine
{
    public class Sound
    {
        private SoundEffect soundEPacdead;
        private SoundEffect soundEPaceat;
        private SoundEffect soundEbegin;
        private SoundBank soundBank;

        public Sound(Game game)
        {
            this.soundEPaceat = game.Content.Load<SoundEffect>("Sound/paceat");
            this.soundEPacdead = game.Content.Load<SoundEffect>("Sound/pacdead");
            this.soundEbegin = game.Content.Load<SoundEffect>("Sound/pacbegin");
        }

        public void Dead()
        {
            this.soundEPacdead.Play();
        }

        public void Eat()
        {
            this.soundEPaceat.Play();
        }

        public void Begin()
        {
            this.soundEbegin.Play();
        }

        public void Ghostmove()
        {
            this.soundBank.GetCue("Sound/pacghost").Play();
        }
    }
}
