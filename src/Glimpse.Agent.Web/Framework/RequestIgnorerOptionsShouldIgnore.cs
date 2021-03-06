﻿using System;
using Microsoft.AspNet.Http;
using Microsoft.Framework.OptionsModel;

namespace Glimpse.Agent.Web.Framework
{
    public class RequestIgnorerOptionsShouldIgnore : IRequestIgnorer
    {
        private readonly Func<HttpContext, bool> _shouldIgnore;

        public RequestIgnorerOptionsShouldIgnore(IOptions<GlimpseAgentWebOptions> optionsAccessor)
        {
            _shouldIgnore = optionsAccessor.Value.ShouldIgnore;
        }
        
        public bool ShouldIgnore(HttpContext context)
        {
            return _shouldIgnore != null ? _shouldIgnore(context) : false;
        }
    }
}
