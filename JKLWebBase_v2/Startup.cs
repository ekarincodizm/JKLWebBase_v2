﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JKLWebBase_v2.Startup))]
namespace JKLWebBase_v2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
