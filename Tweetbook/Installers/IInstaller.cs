﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tweetbook.Installers
{
    interface IInstaller
    {
        void InstallServices(IServiceCollection services,IConfiguration configuration);
    }
}
