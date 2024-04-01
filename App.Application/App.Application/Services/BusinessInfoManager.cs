using App.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class BusinessInfoManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly BusinessDetailsSettings _businessDetailsSettings;

        public BusinessInfoManager(IHttpContextAccessor httpContextAccessor
                                      , IOptions<BusinessDetailsSettings> options)
        {
            _httpContextAccessor = httpContextAccessor;
            _businessDetailsSettings = options.Value;
        }

        public string DomainName
        {
            get
            {
                if (_httpContextAccessor.HttpContext is not null)
                {
                    return _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host.Value;
                }
                else
                {
                    return _businessDetailsSettings.HostName;
                }
            }
        }

        public string SiteLogo
        {
            get
            {
                return _businessDetailsSettings.SiteLogo;
            }
        }
        public string SiteLogoFullPath
        {
            get
            {
                return string.Concat(DomainName, SiteLogo);
            }
        }

        public string BusinessName
        {
            get
            {
                return _businessDetailsSettings.BusinessName;
            }
        }

        public string Address
        {
            get
            {
                return _businessDetailsSettings.Address;
            }
        }

        public string Telphone
        {
            get
            {
                return _businessDetailsSettings.Telphone;
            }
        }

        public string Email
        {
            get
            {
                return _businessDetailsSettings.Email;
            }
        }

    }
}
