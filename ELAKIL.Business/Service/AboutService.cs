﻿using System;
using System.Collections.Generic;
using System.Text;
using ELAKIL.Business.IService;
using ELAKIL.Business.Contexts;
using ELAKIL.Business.Entities;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ELAKIL.Business.Service
{
    public class AboutService : IAboutService
    {
        private ApplicationDbContext context;
        
        public AboutService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<About> GetAboutAsync()
        {
            About about = await context.Abouts.FirstOrDefaultAsync();
            if (about is null)
                about = new About();
            return about;
        }

        public async Task<int> EditAddAboutAsync(About updatedAbout)
        {
            About about;
            if (updatedAbout.Id == 0)
            {
                about = new About();
                await context.Abouts.AddAsync(about);
            }
            else
            {
                about = await context.Abouts.FindAsync(updatedAbout.Id);
            }
            about.AboutUs = updatedAbout.AboutUs;
            about.FaceBook = updatedAbout.FaceBook;
            about.Twitter = updatedAbout.Twitter;
            about.Whatsapp = updatedAbout.Whatsapp;
            about.Number = updatedAbout.Number;
            about.Image = updatedAbout.Image;
            await context.SaveChangesAsync();
            return about.Id;
        }
    }
}
