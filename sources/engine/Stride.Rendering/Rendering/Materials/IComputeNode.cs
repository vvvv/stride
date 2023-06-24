// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System.Collections.Generic;
using Stride.Shaders;

namespace Stride.Rendering.Materials
{
    /// <summary>
    /// Base interface for all <see cref="IComputeNode"/>
    /// </summary>
    public interface IComputeNode
    {
        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <param name="context">The context to get the children.</param>
        /// <returns>The list of children.</returns>
        IEnumerable<IComputeNode> GetChildren(object context = null);

        /// <summary>
        /// Generates the shader source equivalent for this node
        /// </summary>
        /// <returns>ShaderSource.</returns>
        ShaderSource GenerateShaderSource(ShaderGeneratorContext context, MaterialComputeColorKeys baseKeys);

        /// <summary>
        /// Indicates if the <see cref="IComputeNode"/> has changed since the last time it was checked, which might require recompilation of the shader mixins.
        /// Once polled, it will reset all cached states and revert to false until other changes have been triggered.
        /// </summary>
        bool HasChanged { get; }
    }

    /// <summary>
    /// Base interface for all <see cref="IComputeNode"/> 
    /// that restricts the connectability of this compute node to a certain type giving you compile-time type safety
    /// </summary>
    /// <typeparam name="T">Any type that in this context allows to restrict the set of connectable nodes to the ones that make sense</typeparam>
    public interface IComputeNode<T> : IComputeNode
    { 
    }
}
