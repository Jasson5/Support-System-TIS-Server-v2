﻿using Entities;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IAnnouncementRepository
    {
        Announcement Add(Announcement announcement);
        ICollection<Announcement> ListAnnouncements(string search);
        void Update(Announcement announcement);
        Announcement FindById(int id);
        void Delete(Announcement announcement);
    }
}
