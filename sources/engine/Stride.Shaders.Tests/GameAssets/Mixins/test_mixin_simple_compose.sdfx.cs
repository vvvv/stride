﻿// <auto-generated>
// Do not edit this file yourself!
//
// This code was generated by Stride Shader Mixin Code Generator.
// To generate it yourself, please install Stride.VisualStudio.Package .vsix
// and re-save the associated .sdfx.
// </auto-generated>

using System;
using Stride.Core;
using Stride.Rendering;
using Stride.Graphics;
using Stride.Shaders;
using Stride.Core.Mathematics;
using Buffer = Stride.Graphics.Buffer;

namespace Test6
{
    internal static partial class ShaderMixins
    {
        internal partial class DefaultSimpleCompose  : IShaderMixinBuilder
        {
            public void Generate(ShaderMixinSource mixin, ShaderMixinContext context)
            {
                context.Mixin(mixin, "A");
                context.Mixin(mixin, "B");
                context.Mixin(mixin, "C");

                {
                    var __mixinToCompose__ = "X";
                    var __subMixin = new ShaderMixinSource();
                    context.PushComposition(mixin, "x", __subMixin);
                    context.Mixin(__subMixin, __mixinToCompose__);
                    context.PopComposition();
                }
            }

            [ModuleInitializer]
            internal static void __Initialize__()

            {
                ShaderMixinManager.Register("DefaultSimpleCompose", new DefaultSimpleCompose());
            }
        }
    }
}
