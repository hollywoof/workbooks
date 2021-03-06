// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Xamarin.Interactive.CodeAnalysis.Evaluating;
using Xamarin.Interactive.Core;

namespace Xamarin.Interactive.Protocol
{
    [JsonObject]
    sealed class ResetStateRequest : MainThreadRequest<bool>
    {
        public EvaluationContextId EvaluationContextId { get; }

        [JsonConstructor]
        public ResetStateRequest (EvaluationContextId evaluationContextId)
            => EvaluationContextId = evaluationContextId;

        protected override async Task<bool> HandleAsync (Agent agent)
        {
            await agent.EvaluationContextManager.ResetStateAsync (EvaluationContextId);
            return true;
        }
    }
}