using System;
using MG = Microsoft.Xna.Framework;

namespace Raiders.Scenes.Game
{
    public class PlayerMover : Nez.Component, Nez.IUpdatable
    {
        float _speed = 200f;
        MG.Vector2 _direction;

        Nez.Mover _mover;
        Nez.Sprites.Sprite _sprite;

        public bool Enabled => true;

        public int UpdateOrder => 1;

        public event EventHandler<EventArgs> EnabledChanged
        {
            add
            {
                
            }

            remove
            {
                
            }
        }

        public event EventHandler<EventArgs> UpdateOrderChanged
        {
            add
            {
                
            }

            remove
            {
                
            }
        }

        public override void onAddedToEntity()
        {
            base.onAddedToEntity();

            _sprite = entity.getComponent<Nez.Sprites.Sprite>();
            _mover = new Nez.Mover();
            this.entity.addComponent(_mover);
        }

        public void update()
        {
            entity.scene.camera.position = new MG.Vector2(entity.scene.sceneRenderTargetSize.X / 2, entity.scene.sceneRenderTargetSize.Y / 2);
            _direction.X = 0f;
            _direction.Y = 0f;
            if (Nez.Input.isKeyDown(MG.Input.Keys.A))
            {
                _direction.X = -1f;
                _sprite.flipY = false;
                entity.rotationDegrees = 90f;
            }
            if (Nez.Input.isKeyDown(MG.Input.Keys.D))
            {
                _direction.X = 1f;
                _sprite.flipY = false;
                entity.rotationDegrees = -90f;
            }
            if (Nez.Input.isKeyDown(MG.Input.Keys.W))
            {
                _direction.Y = -1f;
                _sprite.flipY = true;
                entity.rotationDegrees = 0f;
            }
            if (Nez.Input.isKeyDown(MG.Input.Keys.S))
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
