namespace GameEngine
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    public class Sound
    {
        private readonly SoundEffect soundPacManChomp;
        private readonly SoundEffect soundPacManDead;
        private readonly SoundEffect soundPaceatFruit;
        private readonly SoundEffect soundPacManBegin;
        private readonly SoundEffect soundPacmanEatghost;
        private readonly SoundEffect ghostDies;

        public Sound(Game game)
        {
            this.soundPacManChomp = game.Content.Load<SoundEffect>("Sound/pacman_chomp");
            this.soundPacmanEatghost = game.Content.Load<SoundEffect>("Sound/pacman_eatghost");
            this.soundPaceatFruit = game.Content.Load<SoundEffect>("Sound/paceat");
            this.soundPacManDead = game.Content.Load<SoundEffect>("Sound/pacdead");
            this.soundPacManBegin = game.Content.Load<SoundEffect>("Sound/pacbegin");
            this.ghostDies = game.Content.Load<SoundEffect>("Sound/pacghost");
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
        public void GhostDies()
        {
            this.ghostDies.Play();
        }
    }
}