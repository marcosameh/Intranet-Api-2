﻿using App.UI.InfraStructure;
using Microsoft.Extensions.DependencyInjection;

namespace App.UI.Configurations
{
    public static class Routes
    {
        public static IServiceCollection AddCustomRoutes(this IServiceCollection services)
        {
            services.AddRazorPages(options =>
            {
                options.Conventions.AddPageRoute("/index", "{culture:culture}");
                options.Conventions.AddPageRoute("/contact-us", "{culture:culture}/contact-us");
                options.Conventions.AddPageRoute("/about-us", "{culture:culture}/about-us");
                options.Conventions.AddPageRoute("/error", "{culture:culture}/error");
                options.Conventions.AddPageRoute("/faqs", "{culture:culture}/faqs");
                options.Conventions.AddPageRoute("/blog", "/blog/{year?}/{month?}");
                options.Conventions.AddPageRoute("/blog", "{culture:culture}/blog/{year?}/{month?}");
                options.Conventions.AddPageRoute("/article", "/blog/{ArticleUrlName:regex(^[[a-zA-Z]])}");
                options.Conventions.AddPageRoute("/article", "{culture:culture}/blog/{ArticleUrlNameregex(^[[a-zA-Z]])}");
            });

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.ConstraintMap.Add("culture", typeof(CultureConstraint));
            });

            return services;
        }


    }
}
