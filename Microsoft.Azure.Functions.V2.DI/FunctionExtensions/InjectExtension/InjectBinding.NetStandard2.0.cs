﻿using Microsoft.Azure.Functions.V2.DI.Models;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Azure.WebJobs.Host.Bindings;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Functions.V2.DI
{
    internal partial class InjectBinding
    {
        private static FunctionRequest GetFunctionRequest(BindingContext context)
        {
            var defaultHttpRequest = context.BindingData.TryGetValue("$request", out var defaultHttpRequestObject)
                ? (DefaultHttpRequest)defaultHttpRequestObject
                : null;

            if (defaultHttpRequest == null) return null;

            return new FunctionRequest
            {
                Headers = defaultHttpRequest.Headers
                    .Select(header => new KeyValuePair<string, IEnumerable<string>>(header.Key, header.Value))
            };
        }
    }
}