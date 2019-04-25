using MG = Microsoft.Xna.Framework;

namespace Raiders.Scenes.Game
{
    class PlayerMining : Nez.Component, Nez.IUpdatable
    {
        public bool Enabled = true;
        public Nez.Particles.ParticleEmitter emitter;

        public override void onAddedToEntity()
        {
            base.onAddedToEntity();
            Nez.Particles.ParticleEmitterConfig emitterConfig = new Nez.Particles.ParticleEmitterConfig
            {
                duration = 60f,
                emissionRate = 1f,
                gravity = new MG.Vector2(0f, 4.9f),
                maxParticles = 100,
                simulateInWorldSpace = false,
                subtexture = null,
            };
            this.emitter = new Nez.Particles.ParticleEmitter(emitterConfig, false);
            this.entity.addComponent(this.emitter);
        }

        #region Nez.IUpdatable
        public void update()
        {
            if (Nez.Input.leftMouseButtonDown)
            {
                if (Nez.Input.mousePosition.X > 250 && Nez.Input.mousePosition.Y > 250)
                {
                    this.emitter.play();
                }
            }
            else
            {
                this.emitter.stop();
            }
        }
        #endregion
    }
}
