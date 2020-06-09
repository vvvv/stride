using Stride.Core;
using Stride.Core.Mathematics;
using Stride.Engine.Processors;

namespace Stride.Engine
{
    [DataContract]
    public abstract class InstancingBase : IInstancing
    {
        /// <summary>
        /// The instance count
        /// </summary>
        [DataMemberIgnore]
        public virtual int InstanceCount { get; set; }

        /// <summary>
        /// The bounding box of the world matrices, updated automatically by the <see cref="InstancingProcessor"/>.
        /// </summary>
        [DataMemberIgnore]
        public virtual BoundingBox BoundingBox { get; set; } = BoundingBox.Empty;

        [DataMember(10)]
        [Display("Model Transformation Usage")]
        public virtual ModelTransformUsage ModelTransformUsage { get; set; }

        public virtual void Update()
        {
            
        }
    }
}
