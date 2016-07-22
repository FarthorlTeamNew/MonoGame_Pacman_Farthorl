using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace GameEngine
{
    public class Sound
    {
        private SoundEffect soundPacManChomp;
        private SoundEffect soundPacManDead;
        private SoundEffect soundPaceatFruit;
        private SoundEffect soundPacManBegin;
        private SoundEffect soundPacmanEatghost;
        private SoundBank soundBank;

        public Sound(Game game)
        {
            this.soundPacManChomp = game.Content.Load<SoundEffect>("Sound/pacman_chomp");
            this.soundPacmanEatghost = game.Content.Load<SoundEffect>("Sound/pacman_eatghost");
            this.soundPaceatFruit = game.Content.Load<SoundEffect>("Sound/paceat");
            this.soundPacManDead = game.Content.Load<SoundEffect>("Sound/pacdead");
            this.soundPacManBegin = game.Content.Load<SoundEffect>("Sound/pacbegin");
        }

        public void Dead()
        {
            this.soundPacManDead.Play();
        }

        public void EatFruit()
        {
            this.soundPaceatFruit.Play();
        }

        public void Begin()
        {
            this.soundPacManBegin.Play();
        }

        public void PacManEatChomp()
        {
            this.soundPacManChomp.Play();
        }
        public void PacManEatGhost()
        {
            this.soundPacmanEatghost.Play();
        }

        public void Ghostmove()
        {
            this.soundBank.GetCue("Sound/pacghost").Play();
        }
    }
}
