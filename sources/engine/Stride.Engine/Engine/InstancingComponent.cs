using Stride.Core;
using Stride.Core.Annotations;
using Stride.Engine.Design;
using Stride.Engine.Processors;

namespace Stride.Engine
{
    [DataContract("InstancingComponent")]
    [Display("Instancing", Expand = ExpandRule.Once)]
    [ComponentCategory("Model")]
    [DefaultEntityComponentRenderer(typeof(InstancingProcessor))]
    public sealed class InstancingComponent : ActivableEntityComponent
    {
        /// <summary>
        /// Gets or sets the type of the instancing.
        /// </summary>
        /// <value>The type of the instancing.</value>
        /// <userdoc>The type of the instancing</userdoc>
        [DataMember(10)]
        [NotNull]
        [Display("Instancing Type", Expand = ExpandRule.Always)]
        public IInstancing Type { get; set; } = new InstancingEntityTransform();
    }
}
