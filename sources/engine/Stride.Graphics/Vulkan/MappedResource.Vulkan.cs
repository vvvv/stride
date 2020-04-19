// Copyright (c) Stride contributors (https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

#if STRIDE_GRAPHICS_API_VULKAN
namespace Stride.Graphics
{
    public partial struct MappedResource
    {
        internal SharpVulkan.Buffer UploadResource;
        internal int UploadOffset;
    }
}
#endif
