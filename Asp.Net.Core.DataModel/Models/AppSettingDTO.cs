using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.DataModel.Models
{
    public class AppSettingDTO
    {
        public void AddToConfiguration(IConfiguration configuration)
        {
            FilePaths filePaths = new FilePaths();
            configuration.GetSection("FilePaths").Bind(filePaths);
            value = filePaths;
        }
        private static FilePaths value;
        public static FilePaths GetValue
        {
            get
            {
                // Reads are usually simple
                return value;
            }
            set
            {
                // Set Details
                value = value;
            }
        }
    }
    public class FilePaths
    {
        public string ImagePath { get; set; }
    }
}
