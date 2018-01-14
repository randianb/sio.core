﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Swastika.Cms.Lib.Services;
using Swastika.Identity.Data;

namespace Swastika.Cms.Lib.Models.Account
{
    public partial class SiocCmsAccountContext : ApplicationDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public SiocCmsAccountContext(DbContextOptions<ApplicationDbContext> options)
                    : base(options)
        {
        }

        public SiocCmsAccountContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile(Common.Utility.Const.CONST_FILE_APPSETTING)
                .Build();

            

                optionsBuilder.UseSqlServer(GlobalConfigurationService.Instance.GetConnectionString());

            //optionsBuilder.UseSqlServer(config.GetConnectionString("AccountConnection"));

        }

    }
}