﻿using eFirebase4CSharp.Classes;
using eFirebase4CSharp.Interfaces;
using eTranslate;
using Microsoft.Extensions.DependencyInjection;

namespace eTasks.Shared.Extensions
{
    public static class IServiceCollectionExtension
    {
        private static string _baseURL = string.Empty;

        public static void LoadServices(this IServiceCollection Services, string BaseURL)
        {
            _baseURL = BaseURL;
            Services.AddScoppedServices();
            Services.AddSingletonServices();
        }

        private static void AddScoppedServices(this IServiceCollection Services)
        {
            Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(_baseURL) });
            Services.AddScoped<IeFirebase, eFirebase>();
        }

        private static void AddSingletonServices(this IServiceCollection Services)
        {
            Services.AddeTranslateSingletonService(TranslationFileFullPath: _baseURL + "translation.json");
        }
    }
}