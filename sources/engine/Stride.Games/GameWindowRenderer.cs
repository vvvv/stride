// Copyright (c) Stride contributors (https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
//
// Copyright (c) 2010-2013 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Stride.Core;
using Stride.Core.Mathematics;
using Stride.Graphics;

namespace Stride.Games
{
    /// <summary>
    /// A GameSystem that allows to draw to another window or control. Currently only valid on desktop with Windows.Forms.
    /// </summary>
    public class GameWindowRenderer : GameSystemBase
    {
        private GraphicsPresenter savedPresenter;
        private bool beginDrawOk;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameWindowRenderer" /> class.
        /// </summary>
        /// <param name="registry">The registry.</param>
        /// <param name="gameContext">The window context.</param>
        public GameWindowRenderer(IServiceRegistry registry, GameContext gameContext)
            : base(registry)
        {
            GameContext = gameContext;
            WindowManager = new GameWindowRendererManager();
        }

        /// <summary>
        /// Gets the underlying native window.
        /// </summary>
        /// <value>The underlying native window.</value>
        public GameContext GameContext { get; private set; }

        /// <summary>
        /// Gets the window.
        /// </summary>
        /// <value>The window.</value>
        public GameWindow Window { get; private set; }

        /// <summary>
        /// Gets or sets the presenter.
        /// </summary>
        /// <value>The presenter.</value>
        public GraphicsPresenter Presenter { get; protected set; }

        /// <summary>
        /// Gets the window manager.
        /// </summary>
        /// <value>
        /// The window manager.
        /// </value>
        public GameWindowRendererManager WindowManager { get; private set; }

        public override void Initialize()
        {
            var gamePlatform = Services.GetService<IGamePlatform>();
            GameContext.RequestedWidth = WindowManager.PreferredBackBufferWidth;
            GameContext.RequestedHeight = WindowManager.PreferredBackBufferHeight;
            Window = gamePlatform.CreateWindow(GameContext);

            Window.Visible = true;

            base.Initialize();
        }

        protected override void Destroy()
        {
            if (Presenter != null)
            {
                // Unregister from graphics device
                GraphicsDevice.WindowPresenters.Remove(Presenter);

                // Make sure that the Presenter is reverted to window before shuting down
                // otherwise the Direct3D11.Device will generate an exception on Dispose()
                Presenter.IsFullScreen = false;
                Presenter.Dispose(); 
            }
            Presenter = null;

            WindowManager?.Dispose();
            WindowManager = null;
            Window?.Dispose();
            Window = null;

            base.Destroy();
        }

        protected virtual void EnsurePresenter()
        {
            if (Presenter == null)
            {
                var presentationParameters = new PresentationParameters(
                    WindowManager.PreferredBackBufferWidth,
                    WindowManager.PreferredBackBufferHeight,
                    Window.NativeWindow,
                    WindowManager.PreferredBackBufferFormat)
                {
                    DepthStencilFormat = WindowManager.PreferredDepthStencilFormat,
                    PresentationInterval = PresentInterval.Immediate
                };

#if STRIDE_GRAPHICS_API_DIRECT3D11 && STRIDE_PLATFORM_UWP
                if (Game.Context is GameContextUWPCoreWindow context && context.IsWindowsMixedReality)
                {
                    Presenter = new WindowsMixedRealityGraphicsPresenter(GraphicsDevice, presentationParameters);
                }
                else
#endif
                {
                    Presenter = new SwapChainGraphicsPresenter(GraphicsDevice, presentationParameters);
                }

                WindowManager.Initialize(this, GraphicsDevice, Services.GetService<IGraphicsDeviceFactory>());

                // Register presenter to graphics device
                GraphicsDevice.WindowPresenters.Add(Presenter);
            }
        }

        public override bool BeginDraw()
        {
            if (GraphicsDevice != null && Window.Visible)
            {
                savedPresenter = GraphicsDevice.Presenter;

                EnsurePresenter();

                GraphicsDevice.Presenter = Presenter;
                beginDrawOk = true;
                return true;
            }

            beginDrawOk = false;
            return false;
        }

        public override void EndDraw()
        {
            if (beginDrawOk && GraphicsDevice != null)
            {
                if (savedPresenter != null)
                {
                    GraphicsDevice.Presenter = savedPresenter;
                }
            }
        }
    }
}
