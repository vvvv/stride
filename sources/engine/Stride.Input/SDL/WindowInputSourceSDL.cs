// Copyright (c) Stride contributors (https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

#if STRIDE_UI_SDL
using System;
using System.Collections.Generic;
using SDL2;
using Stride.Games;
using Stride.Graphics.SDL;

namespace Stride.Input
{
    /// <summary>
    /// Provides support for mouse/touch/keyboard/gamepads using SDL
    /// </summary>
    internal class WindowInputSourceSDL : InputSourceSDL
    {
        public WindowInputSourceSDL(Window window)
        {
            uiControl = window;
        }

        private Window uiControl;
        private MouseSDL mouse;
        private KeyboardSDL keyboard;
        private PointerSDL pointer; // Touch

        public override void Initialize(InputManager inputManager)
        {
            mouse = new MouseSDL(this, inputManager.Game, uiControl);
            keyboard = new KeyboardSDL(this, uiControl);
            pointer = new PointerSDL(this, uiControl);

            RegisterDevice(mouse);
            RegisterDevice(keyboard);
            RegisterDevice(pointer);
        }

        public override void Dispose()
        {
            // Remove all devices, done by clearing the tracking dictionary
            Devices.Clear();
        }

        public override void Update()
        {

        }

        public override void Scan()
        {

        }
    }
}

#endif
