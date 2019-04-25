using MG = Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Raiders.Scenes.Menus
{
    class Main : Nez.Scene, Nez.IFinalRenderDelegate
    {
        public const int SCREEN_SPACE_RENDER_LAYER = 999;
        public Nez.UICanvas canvas;
        List<Nez.UI.Button> _sceneButtons = new List<Nez.UI.Button>();
        Nez.ScreenSpaceRenderer _screenSpaceRenderer;

        public override void initialize()
        {
            base.initialize();

            this.addRenderer(new Nez.ScreenSpaceRenderer(100, SCREEN_SPACE_RENDER_LAYER));
            this.addRenderer(new Nez.RenderLayerExcludeRenderer(0, SCREEN_SPACE_RENDER_LAYER));
            canvas = this.createEntity("ui").addComponent(new Nez.UICanvas());
            canvas.isFullScreen = true;
            canvas.renderLayer = SCREEN_SPACE_RENDER_LAYER;

            Nez.UI.PrimitiveDrawable basecolor = new Nez.UI.PrimitiveDrawable(new MG.Color(78, 91, 98), 10f);
            var buttonStyle = new Nez.UI.TextButtonStyle(basecolor,
                new Nez.UI.PrimitiveDrawable(new MG.Color(244, 23, 135)),
                new Nez.UI.PrimitiveDrawable(new MG.Color(168, 207, 115))
                )
                {
                    downFontColor = MG.Color.Black
                };
            var button = new Nez.UI.TextButton("Start Game", buttonStyle);
            _sceneButtons.Add(button);
            button.onClicked += butt =>
            {
                Nez.Tweens.TweenManager.stopAllTweens();
                // Nez.Core.startSceneTransition(new Nez.FadeTransition(() => System.Activator.CreateInstance("Raiders.Scenes.Game.GameMap") as Nez.Scene));
            };
            // setDesignResolution(1280, 720, Nez.Scene.SceneResolutionPolicy.None);
            // Nez.Screen.setSize(1280, 720);
        }

        #region IFinalRenderDelegate

        public void onAddedToScene(Nez.Scene scene) { }


        public void onSceneBackBufferSizeChanged(int newWidth, int newHeight)
        {
            _screenSpaceRenderer.onSceneBackBufferSizeChanged(newWidth, newHeight);
        }


        public void handleFinalRender(MG.Graphics.RenderTarget2D finalRenderTarget, MG.Color letterboxColor, MG.Graphics.RenderTarget2D source, MG.Rectangle finalRenderDestinationRect, MG.Graphics.SamplerState samplerState)
        {
            Nez.Core.graphicsDevice.SetRenderTarget(null);
            Nez.Core.graphicsDevice.Clear(letterboxColor);
            Nez.Graphics.instance.batcher.begin(MG.Graphics.BlendState.Opaque, samplerState, MG.Graphics.DepthStencilState.None, MG.Graphics.RasterizerState.CullNone, null);
            Nez.Graphics.instance.batcher.draw(source, finalRenderDestinationRect, MG.Color.White);
            Nez.Graphics.instance.batcher.end();

            _screenSpaceRenderer.render(this);
        }

        #endregion
    }
}
