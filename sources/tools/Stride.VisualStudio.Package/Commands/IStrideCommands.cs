// Copyright (c) Stride contributors (https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using EnvDTE80;

using NShader;

namespace Stride.VisualStudio.Commands
{
    /// <summary>
    /// Describes stride commands accessed by VS Package to current stride package (so that VSPackage doesn't depend on Stride assemblies).
    /// </summary>
    /// <remarks>
    /// WARNING: Modifying this contract or any of it's dependencies will break backwards compatibility!
    /// Introduce a new contract instead (e.g. IStrideCommands2).
    /// </remarks>
    public interface IStrideCommands
    {
        /// <summary>
        /// Initialize parsing (this method can be called from a separate thread).
        /// </summary>
        void Initialize(string strideSdkDir);

        /// <summary>
        /// Test whether we should reload these commands (assemblies changed)
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool ShouldReload();

        void StartRemoteBuildLogServer(IBuildMonitorCallback buildMonitorCallback, string logPipeUrl);

        byte[] GenerateShaderKeys(string inputFileName, string inputFileContent);

        RawShaderNavigationResult AnalyzeAndGoToDefinition(string sourceCode, RawSourceSpan span);
    }

    public interface IStrideCommands2
    {
        RawShaderNavigationResult AnalyzeAndGoToDefinition(string projectPath, string sourceCode, RawSourceSpan span);
    }

    public interface IBuildMonitorCallback
    {
        void Message(string type, string module, string text);
    }
}
