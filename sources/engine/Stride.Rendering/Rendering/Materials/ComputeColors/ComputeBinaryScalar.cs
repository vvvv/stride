// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using Stride.Core;

namespace Stride.Rendering.Materials.ComputeColors
{
    /// <summary>
    /// A node that describe a binary operation between two <see cref="IComputeScalar"/>
    /// </summary>
    [DataContract("ComputeBinaryScalar")]
    [Display("Binary Operator")]
    public class ComputeBinaryScalar : ComputeBinaryBase<float>, IComputeScalar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComputeBinaryScalar"/> class.
        /// </summary>
        public ComputeBinaryScalar()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComputeBinaryScalar"/> class.
        /// </summary>
        /// <param name="leftChild">The left child.</param>
        /// <param name="rightChild">The right child.</param>
        /// <param name="binaryOperator">The material binary operand.</param>
        public ComputeBinaryScalar(IComputeNode<float> leftChild, IComputeNode<float> rightChild, BinaryOperator binaryOperator)
            : base(leftChild, rightChild, binaryOperator)
        {
        }
    }
}
