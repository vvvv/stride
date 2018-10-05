// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;

namespace Xenko.Graphics
{
    //
    // Summary:
    //     Identifies options for resources.
    //
    // Remarks:
    //     This enumeration is used in SharpDX.Direct3D11.BufferDescription, SharpDX.Direct3D11.Texture1DDescription,
    //     SharpDX.Direct3D11.Texture2DDescription, SharpDX.Direct3D11.Texture3DDescription.
    //     These flags can be combined by bitwise OR. The SharpDX.Direct3D11.ResourceOptionFlags
    //     must be 'None' when creating resources with D3D11_CPU_ACCESS flags.
    [Flags]
    public enum TextureOptions
    {
        //
        // Summary:
        //     None.
        None = 0,
        ////
        //// Summary:
        ////     Enables MIP map generation by using SharpDX.Direct3D11.DeviceContext.GenerateMips(SharpDX.Direct3D11.ShaderResourceView)
        ////     on a texture resource. The resource must be created with the bind flags that
        ////     specify that the resource is a render target and a shader resource.
        //GenerateMipMaps = 1,
        //
        // Summary:
        //     Enables resource data sharing between two or more Direct3D devices. The only
        //     resources that can be shared are 2D non-mipmapped textures. SharpDX.Direct3D11.ResourceOptionFlags.Shared
        //     and SharpDX.Direct3D11.ResourceOptionFlags.SharedKeyedmutex are mutually exclusive.
        //     WARP and REF devices do not support shared resources. If you try to create a
        //     resource with this flag on either a WARP or REF device, the create method will
        //     return an E_OUTOFMEMORY error code. Note?? Starting with Windows?8, WARP devices
        //     fully support shared resources. ? Note?? Starting with Windows?8, we recommend
        //     that you enable resource data sharing between two or more Direct3D devices by
        //     using a combination of the SharpDX.Direct3D11.ResourceOptionFlags.SharedNthandle
        //     and SharpDX.Direct3D11.ResourceOptionFlags.SharedKeyedmutex flags instead. ?
        Shared = 2,
        ////
        //// Summary:
        ////     Sets a resource to be a cube texture created from a Texture2DArray that contains
        ////     6 textures.
        //TextureCube = 4,
        ////
        //// Summary:
        ////     Enables instancing of GPU-generated content.
        //DrawIndirectArguments = 16,
        ////
        //// Summary:
        ////     Enables a resource as a byte address buffer.
        //BufferAllowRawViews = 32,
        ////
        //// Summary:
        ////     Enables a resource as a structured buffer.
        //BufferStructured = 64,
        ////
        //// Summary:
        ////     Enables a resource with MIP map clamping for use with SharpDX.Direct3D11.DeviceContext.SetMinimumLod(SharpDX.Direct3D11.Resource,System.Single).
        //ResourceClamp = 128,
        ////
        //// Summary:
        ////     Enables the resource to be synchronized by using the SharpDX.DXGI.KeyedMutex.Acquire(System.Int64,System.Int32)
        ////     and SharpDX.DXGI.KeyedMutex.Release(System.Int64) APIs. The following Direct3D?11
        ////     resource creation APIs, that take SharpDX.Direct3D11.ResourceOptionFlags parameters,
        ////     have been extended to support the new flag. SharpDX.Direct3D11.Device.CreateTexture1D(SharpDX.Direct3D11.Texture1DDescription@,SharpDX.DataBox[],SharpDX.Direct3D11.Texture1D)
        ////     SharpDX.Direct3D11.Device.CreateTexture2D(SharpDX.Direct3D11.Texture2DDescription@,SharpDX.DataBox[],SharpDX.Direct3D11.Texture2D)
        ////     SharpDX.Direct3D11.Device.CreateTexture3D(SharpDX.Direct3D11.Texture3DDescription@,SharpDX.DataBox[],SharpDX.Direct3D11.Texture3D)
        ////     SharpDX.Direct3D11.Device.CreateBuffer(SharpDX.Direct3D11.BufferDescription@,System.Nullable{SharpDX.DataBox},SharpDX.Direct3D11.Buffer)
        ////     If you call any of these methods with the SharpDX.Direct3D11.ResourceOptionFlags.SharedKeyedmutex
        ////     flag set, the interface returned will support the SharpDX.DXGI.KeyedMutex interface.
        ////     You can retrieve a reference to the SharpDX.DXGI.KeyedMutex interface from the
        ////     resource by using IUnknown::QueryInterface. The SharpDX.DXGI.KeyedMutex interface
        ////     implements the SharpDX.DXGI.KeyedMutex.Acquire(System.Int64,System.Int32) and
        ////     SharpDX.DXGI.KeyedMutex.Release(System.Int64) APIs to synchronize access to the
        ////     surface. The device that creates the surface, and any other device that opens
        ////     the surface by using OpenSharedResource, must call SharpDX.DXGI.KeyedMutex.Acquire(System.Int64,System.Int32)
        ////     before they issue any rendering commands to the surface. When those devices finish
        ////     rendering, they must call SharpDX.DXGI.KeyedMutex.Release(System.Int64). SharpDX.Direct3D11.ResourceOptionFlags.Shared
        ////     and SharpDX.Direct3D11.ResourceOptionFlags.SharedKeyedmutex are mutually exclusive.
        ////     WARP and REF devices do not support shared resources. If you try to create a
        ////     resource with this flag on either a WARP or REF device, the create method will
        ////     return an E_OUTOFMEMORY error code. Note?? Starting with Windows?8, WARP devices
        ////     fully support shared resources. ?
        //SharedKeyedmutex = 256,
        ////
        //// Summary:
        ////     Enables a resource compatible with GDI. You must set the SharpDX.Direct3D11.ResourceOptionFlags.GdiCompatible
        ////     flag on surfaces that you use with GDI. Setting the SharpDX.Direct3D11.ResourceOptionFlags.GdiCompatible
        ////     flag allows GDI rendering on the surface via SharpDX.DXGI.Surface1.GetDC(SharpDX.Mathematics.Interop.RawBool).
        ////     Consider the following programming tips for using SharpDX.Direct3D11.ResourceOptionFlags.GdiCompatible
        ////     when you create a texture or use that texture in a swap chain: SharpDX.Direct3D11.ResourceOptionFlags.SharedKeyedmutex
        ////     and SharpDX.Direct3D11.ResourceOptionFlags.GdiCompatible are mutually exclusive.
        ////     Therefore, do not use them together. SharpDX.Direct3D11.ResourceOptionFlags.ResourceClamp
        ////     and SharpDX.Direct3D11.ResourceOptionFlags.GdiCompatible are mutually exclusive.
        ////     Therefore, do not use them together. You must bind the texture as a render target
        ////     for the output-merger stage. For example, set the SharpDX.Direct3D11.BindFlags.RenderTarget
        ////     flag in the BindFlags member of the SharpDX.Direct3D11.Texture2DDescription structure.
        ////     You must set the maximum number of MIP map levels to 1. For example, set the
        ////     MipLevels member of the SharpDX.Direct3D11.Texture2DDescription structure to
        ////     1. You must specify that the texture requires read and write access by the GPU.
        ////     For example, set the Usage member of the SharpDX.Direct3D11.Texture2DDescription
        ////     structure to SharpDX.Direct3D11.ResourceUsage.Default. You must set the texture
        ////     format to one of the following types. SharpDX.DXGI.Format.B8G8R8A8_UNorm SharpDX.DXGI.Format.B8G8R8A8_Typeless
        ////     SharpDX.DXGI.Format.B8G8R8A8_UNorm_SRgb For example, set the Format member of
        ////     the SharpDX.Direct3D11.Texture2DDescription structure to one of these types.
        ////     You cannot use SharpDX.Direct3D11.ResourceOptionFlags.GdiCompatible with multisampling.
        ////     Therefore, set the Count member of the SharpDX.DXGI.SampleDescription structure
        ////     to 1. Then, set the SampleDesc member of the SharpDX.Direct3D11.Texture2DDescription
        ////     structure to this SharpDX.DXGI.SampleDescription structure.
        //GdiCompatible = 512,
        ////
        //// Summary:
        ////     Set this flag to enable the use of NT HANDLE values when you create a shared
        ////     resource. By enabling this flag, you deprecate the use of existing HANDLE values.
        ////     When you use this flag, you must combine it with the SharpDX.Direct3D11.ResourceOptionFlags.SharedKeyedmutex
        ////     flag by using a bitwise OR operation. The resulting value specifies a new shared
        ////     resource type that directs the runtime to use NT HANDLE values for the shared
        ////     resource. The runtime then must confirm that the shared resource works on all
        ////     hardware at the specified feature level. Without this flag set, the runtime does
        ////     not strictly validate shared resource parameters (that is, formats, flags, usage,
        ////     and so on). When the runtime does not validate shared resource parameters, behavior
        ////     of much of the Direct3D API might be undefined and might vary from driver to
        ////     driver. Direct3D 11 and earlier:??This value is not supported until Direct3D
        ////     11.1.
        //SharedNthandle = 2048,
        ////
        //// Summary:
        ////     Set this flag to indicate that the resource might contain protected content;
        ////     therefore, the operating system should use the resource only when the driver
        ////     and hardware support content protection. If the driver and hardware do not support
        ////     content protection and you try to create a resource with this flag, the resource
        ////     creation fails. Direct3D 11:??This value is not supported until Direct3D 11.1.
        //RestrictedContent = 4096,
        ////
        //// Summary:
        ////     Set this flag to indicate that the operating system restricts access to the shared
        ////     surface. You can use this flag together with the SharpDX.Direct3D11.ResourceOptionFlags.RestrictSharedResourceDriver
        ////     flag and only when you create a shared surface. The process that creates the
        ////     shared resource can always open the shared resource. Direct3D 11:??This value
        ////     is not supported until Direct3D 11.1.
        //RestrictSharedResource = 8192,
        ////
        //// Summary:
        ////     Set this flag to indicate that the driver restricts access to the shared surface.
        ////     You can use this flag in conjunction with the SharpDX.Direct3D11.ResourceOptionFlags.RestrictSharedResource
        ////     flag and only when you create a shared surface. The process that creates the
        ////     shared resource can always open the shared resource. Direct3D 11:??This value
        ////     is not supported until Direct3D 11.1.
        //RestrictSharedResourceDriver = 16384,
        ////
        //// Summary:
        ////     Set this flag to indicate that the resource is guarded. Such a resource is returned
        ////     by the SharpDX.DirectComposition.Surface.BeginDraw (DirectComposition) and SharpDX.DXGI.ISurfaceImageSourceNative.BeginDraw(SharpDX.Mathematics.Interop.RawRectangle,SharpDX.Mathematics.Interop.RawPoint@)
        ////     (Windows Runtime) APIs. For these APIs, you provide a region of interest (ROI)
        ////     on a surface to update. This surface isn't compatible with multiple render targets
        ////     (MRT). A guarded resource automatically restricts all writes to the region that
        ////     is related to one of the preceding APIs. Additionally, the resource enforces
        ////     access to the ROI with these restrictions: Copy operations from the resource
        ////     by using SharpDX.Direct3D11.DeviceContext.CopyResource_(SharpDX.Direct3D11.Resource,SharpDX.Direct3D11.Resource)
        ////     or SharpDX.Direct3D11.DeviceContext.CopySubresourceRegion_(SharpDX.Direct3D11.Resource,System.Int32,System.Int32,System.Int32,System.Int32,SharpDX.Direct3D11.Resource,System.Int32,System.Nullable{SharpDX.Direct3D11.ResourceRegion})
        ////     are restricted to only copy from the ROI. When a guarded resource is set as a
        ////     render target, it must be the only target. Direct3D 11:??This value is not supported
        ////     until Direct3D 11.1.
        //Guarded = 32768,
        ////
        //// Summary:
        ////     Set this flag to indicate that the resource is a tile pool. Direct3D 11:??This
        ////     value is not supported until Direct3D 11.2.
        //TilePool = 131072,
        ////
        //// Summary:
        ////     Set this flag to indicate that the resource is a tiled resource. Direct3D 11:??This
        ////     value is not supported until Direct3D 11.2.
        //Tiled = 262144,
        ////
        //// Summary:
        ////     Set this flag to indicate that the resource should be created such that it will
        ////     be protected by the hardware. Resource creation will fail if hardware content
        ////     protection is not supported. This flag has the following restrictions: This flag
        ////     cannot be used with the following SharpDX.Direct3D11.ResourceUsage values: SharpDX.Direct3D11.ResourceUsage.Dynamic
        ////     SharpDX.Direct3D11.ResourceUsage.Staging This flag cannot be used with the following
        ////     SharpDX.Direct3D11.BindFlags values. SharpDX.Direct3D11.BindFlags.VertexBuffer
        ////     SharpDX.Direct3D11.BindFlags.IndexBuffer No CPU access flags can be specified.
        ////     Note??Creating a texture using this flag does not automatically guarantee that
        ////     hardware protection will be enabled for the underlying allocation. Some implementations
        ////     require that the DRM components are first initialized prior to any guarantees
        ////     of protection. ? Note?? This enumeration value is supported starting with Windows?10.
        //HwProtected = 524288
    }
}
