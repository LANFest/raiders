using MG = Microsoft.Xna.Framework;

namespace Raiders.Scenes.Game
{
    [SampleScene("Game Map", 0, "The main gameplay arena.")]
    public class GameMap : SampleScene
    {
        public GameMap() : base(true, true) { }

        public override void initialize()
        {
            base.initialize();

            var moonTex = content.Load<MG.Graphics.Texture2D>(Content.Shared.moon);

            var playerEntity = this.createEntity("player");
            playerEntity.transform.position = new MG.Vector2(250, 250);
            playerEntity.addComponent(new Nez.Sprites.Sprite(moonTex));
            playerEntity.addComponent(new PlayerMover());
        }
    }
}
