using System;
using MG = Microsoft.Xna.Framework;

namespace Raiders.Scenes.Game
{
    public class PlayerMover : Nez.Component, MG.IUpdateable
    {
        float _speed = 800f;
        MG.Vector2 _direction;

        Nez.Mover _mover;
        Nez.Sprites.Sprite _sprite;

        public bool Enabled => true;

        public int UpdateOrder => 0;

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public override void onAddedToEntity()
        {
            base.onAddedToEntity();

            _sprite = entity.getComponent<Nez.Sprites.Sprite>();
            _mover = new Nez.Mover();
            entity.addComponent(_mover);
        }

        void MG.IUpdateable.Update(MG.GameTime gameTime)
        {
            string gtstr = gameTime.ToString();
            Nez.Debug.log(gtstr);
            entity.scene.camera.position = new MG.Vector2(entity.scene.sceneRenderTargetSize.X / 2, entity.scene.sceneRenderTargetSize.Y / 2);
            if (Nez.Input.isKeyPressed(MG.Input.Keys.A))
            {
                _direction.X = -1f;
                _sprite.flipY = false;
                entity.rotationDegrees = 90f;
            }
            else if (Nez.Input.isKeyPressed(MG.Input.Keys.D))
            {
                _direction.X = 1f;
                _sprite.flipY = false;
                entity.rotationDegrees = -90f;
            }
            else if (Nez.Input.isKeyPressed(MG.Input.Keys.W))
            {
                _direction.Y = -1f;
                _sprite.flipY = true;
                entity.rotationDegrees = 0f;
            }
            else if (Nez.Input.isKeyPressed(MG.Input.Keys.S))
            {
                _direction.Y = 1f;
                _sprite.flipY = false;
                entity.rotationDegrees = 0f;
            }

            if (_direction != MG.Vector2.Zero)
            {
                var movement = _direction * _speed * Nez.Time.deltaTime;
                Nez.CollisionResult collision;
                _mover.move(movement, out collision);
            }
        }
    }
}
