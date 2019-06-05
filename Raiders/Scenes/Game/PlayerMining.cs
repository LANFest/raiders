using MG = Microsoft.Xna.Framework;

namespace Raiders.Scenes.Game
{
    class PlayerMining : Nez.Component, Nez.IUpdatable
    {
        public bool Enabled = true;
        public Nez.Particles.ParticleEmitter emitter;
        public int UpdateOrder => 1;
        public int layerDepth = 2;

        public override void onAddedToEntity()
        {
            base.onAddedToEntity();
            Nez.Particles.ParticleEmitterConfig emitterConfig = new Nez.Particles.ParticleEmitterConfig
            {
                angle = 244f,
                angleVariance = 140f,
                blendFuncDestination = MG.Graphics.Blend.Zero,
                blendFuncSource = MG.Graphics.Blend.InverseDestinationColor,
                duration = 60f,
                emissionRate = 10f,
                emitterType = Nez.Particles.ParticleEmitterType.Gravity,
                finishColor = new MG.Color(0, 0, 0, 0),
                finishColorVariance = new MG.Color(0),
                finishParticleSize = 65f,
                finishParticleSizeVariance = 65f,
                gravity = new MG.Vector2(0f, 490f),
                maxParticles = 100,
                maxRadius = 0f,
                maxRadiusVariance = 75f,
                minRadius = 0f,
                minRadiusVariance = 0f,
                particleLifespan = 1f,
                particleLifespanVariance = 0f,
                radialAcceleration = 0f,
                radialAccelVariance = 0f,
                rotatePerSecond = 0f,
                rotatePerSecondVariance = 150f,
                rotationEnd = 0f,
                rotationEndVariance = 0f,
                rotationStart = 0f,
                rotationStartVariance = 0f,
                simulateInWorldSpace = true,
                sourcePosition = new MG.Vector2(150f, 50f),
                sourcePositionVariance = new MG.Vector2(0f, 0f),
                speed = 0f,
                speedVariance = 190f,
                startColor = new MG.Color(0.84f, 0.3f, 0f),
                startColorVariance = new MG.Color(0),
                startParticleSize = 50f,
                startParticleSizeVariance = 25f,
                subtexture = null,
                tangentialAcceleration = 0f,
                tangentialAccelVariance = 0f,
            };
            this.emitter = new Nez.Particles.ParticleEmitter(emitterConfig, true)
            {
                enabled = true,
            };
            this.entity.addComponent(this.emitter);
        }

        #region Nez.IUpdatable
        public void update()
        {
            if (!this.emitter.isPlaying)
            {
                this.emitter.play();
            }
            if (Nez.Input.leftMouseButtonDown)
            {
                this.emitter.resumeEmission();
            }
            else
            {
                this.emitter.pauseEmission();
            }
        }
        #endregion
    }
}
