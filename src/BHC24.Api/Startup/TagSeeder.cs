﻿using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;

namespace BHC24.Api.Startup;

public class TagSeeder
{
    public static void Seed(BhcDbContext dbContext)
    {
        if (dbContext.Tags.Any())
        {
            return;
        }

        var tags = new Tag[]
        {
            new()
            {
                Name = "html",
                ImagePath = "https://cdn.pixabay.com/photo/2017/08/05/11/16/logo-2582748_960_720.png"
            },

            new()
            {
                Name = "css",
                ImagePath = "https://cdn.pixabay.com/photo/2017/08/05/11/16/logo-2582747_960_720.png"
            },
            
            new()
            {
                Name = "javascript",
                ImagePath = "https://upload.wikimedia.org/wikipedia/commons/d/d4/Javascript-shield.svg"
            },
            new()
            {
                Name = "c#",
                ImagePath = "https://upload.wikimedia.org/wikipedia/commons/1/17/C_Sharp_Icon.png"
            },
            new()
            {
                Name = "java",
                ImagePath = "https://upload.wikimedia.org/wikipedia/en/3/30/Java_programming_language_logo.svg"
            },
            new()
            {   
                Name ="python",
                ImagePath = "https://upload.wikimedia.org/wikipedia/commons/c/c3/Python-logo-notext.svg"
            },
            new()
            {
                Name = "php",
                ImagePath = "https://upload.wikimedia.org/wikipedia/commons/2/27/PHP-logo.svg"
            }
        };

        dbContext.Tags.AddRange(tags);
        dbContext.SaveChanges();
    }
}