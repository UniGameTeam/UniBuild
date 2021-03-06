﻿using UnityEditor.Build.Reporting;

namespace UniModules.UniGame.UniBuild.Editor.ClientBuild.BuildConfiguration
{
    using Extensions;
    using Interfaces;
    using Parsers;
    using UnityEditor;
    using UnityEngine;

    public class UniBuilderConsoleConfiguration : IUniBuilderConfiguration
    {
        private EnumArgumentParser<BuildTarget> buildTargetParser;
        private EnumArgumentParser<BuildTargetGroup> buildTargetGroupParser;
        
        private ArgumentsProvider argumentsProvider;
        private BuildParameters buildParameters;
        private BuildReport _buildReport;

        public UniBuilderConsoleConfiguration(string[] commandLineArgs)
        {
            argumentsProvider = new ArgumentsProvider(commandLineArgs);

            var buildTarget      = argumentsProvider.GetBuildTarget();
            var buildTargetGroup = argumentsProvider.GetBuildTargetGroup();

            buildParameters = new BuildParameters(buildTarget,buildTargetGroup, argumentsProvider);

            Debug.Log(argumentsProvider);
            
        }

        public IArgumentsProvider Arguments => argumentsProvider;

        public IBuildParameters BuildParameters => buildParameters;

        public BuildReport BuildReport
        {
            get => _buildReport;
            set => _buildReport = value;
        }
    }
}
