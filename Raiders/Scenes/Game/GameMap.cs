using MG = Microsoft.Xna.Framework;
using Nez.Tiled;

namespace Raiders.Scenes.Game
{
    [SampleScene("Game Map", 0, "The main gameplay arena.")]
    public class GameMap : SampleScene
    {
        public GameMap() : base(true, true) { }

        public override void initialize()
        {
            base.initialize();

            var defaultMap = content.Load<TiledMap>(Content.Maps.defaultmap);
            var moonTex = content.Load<MG.Graphics.Texture2D>(Content.Shared.moon);

            var mapEntity = createEntity("map");
            var mapComponent = new Nez.TiledMapComponent(defaultMap);
            mapComponent.setRenderLayer(20);
            mapEntity.addComponent(mapComponent);

            var playerEntity = this.createEntity("player");
            playerEntity.transform.position = new MG.Vector2(250, 250);
            playerEntity.addComponent(new Nez.Sprites.Sprite(moonTex));
            playerEntity.addComponent(new PlayerMover());
            playerEntity.addComponent(new PlayerMining());
        }
    }
}
