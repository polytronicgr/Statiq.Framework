﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Statiq.Common;

namespace Statiq.Core
{
    /// <summary>
    /// Replaces documents in the current pipeline.
    /// </summary>
    /// <category>Control</category>
    public class ReplaceDocuments : ChildDocumentsModule
    {
        public ReplaceDocuments()
            : base(Array.Empty<IModule>())
        {
        }

        public ReplaceDocuments(params IModule[] modules)
            : base(modules)
        {
        }

        public ReplaceDocuments(params string[] pipelines)
            : base(new ExecuteConfig(Config.FromContext(ctx => ctx.Outputs.FromPipelines(pipelines))))
        {
        }

        protected override Task<IEnumerable<IDocument>> ExecuteAsync(
            IExecutionContext context,
            IReadOnlyList<IDocument> childOutputs) =>
            Task.FromResult<IEnumerable<IDocument>>(childOutputs);
    }
}