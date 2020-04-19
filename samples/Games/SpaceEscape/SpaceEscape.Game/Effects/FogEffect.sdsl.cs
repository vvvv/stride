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

namespace Stride.Rendering
{
    public static partial class FogEffectKeys
    {
        public static readonly ValueParameterKey<Color4> FogColor = ParameterKeys.NewValue<Color4>(new Color4(1,1,1,1));
        public static readonly ValueParameterKey<float> fogNearPlaneZ = ParameterKeys.NewValue<float>(80.0f);
        public static readonly ValueParameterKey<float> fogFarPlaneZ = ParameterKeys.NewValue<float>(250.0f);
        public static readonly ValueParameterKey<float> fogNearPlaneY = ParameterKeys.NewValue<float>(0.0f);
        public static readonly ValueParameterKey<float> fogFarPlaneY = ParameterKeys.NewValue<float>(120.0f);
    }
}
