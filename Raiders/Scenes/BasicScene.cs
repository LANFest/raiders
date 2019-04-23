using MG = Microsoft.Xna.Framework;

namespace Raiders.Scenes
{
    [SampleScene("Basic Scene", 9999, "Scene with a single Entity. The minimum to have something to show")]
    public class BasicScene : SampleScene
    {
        public override void initialize()
        {
            base.initialize();

            // default to 1280x720 with no SceneResolutionPolicy
            setDesignResolution(1280, 720, Nez.Scene.SceneResolutionPolicy.None);
            Nez.Screen.setSize(1280, 720);

            var moonTex = content.Load<MG.Graphics.Texture2D>(Content.Shared.moon);
            var playerEntity = createEntity("player", new MG.Vector2(Nez.Screen.width / 2, Nez.Screen.height / 2));
            playerEntity.addComponent(new Nez.Sprites.Sprite(moonTex));
        }
    }
}
