// Copyright (c) Stride contributors (https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using Stride.Core;
using Stride.Core.Mathematics;

namespace Stride.Rendering.Materials.ComputeColors
{
    /// <summary>
    /// A node that describe a binary operation between two <see cref="IComputeColor"/>
    /// </summary>
    [DataContract("ComputeBinaryColor")]
    [Display("Binary Operator")]
    public class ComputeBinaryColor : ComputeBinaryBase<Vector4>, IComputeColor
    {
        public ComputeBinaryColor()
        {
        }

        public ComputeBinaryColor(IComputeNode<Vector4> leftChild, IComputeNode<Vector4> rightChild, BinaryOperator binaryOperator)
            : base(leftChild, rightChild, binaryOperator)
        {
        }
    }
}
