﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialEF.Context;
using TutorialEF.Models;

namespace TutorialEF.Repository
{
    public class ClientRepository
    {
        public void AddWithUser(Client client, User user)
        {
            using (var db = new TutorialEFContext())
            {
                db.Add(client);
                db.Add(user);
                db.SaveChanges();
            }
        }

        public void AddWithAddresses(Client client, List<Address> addresses)
        {
            using (var db = new TutorialEFContext())
            {
                db.Add(client);
                db.AddRange(addresses);
                db.SaveChanges();
            }
        }

        public Client GetById(int id)
        {
            using (var db = new TutorialEFContext())
            {
                var client = db.Clients.Find(id);

                return client;
            }
        }

        public Client GetByIdWithAddress(int id)
        {
            using (var db = new TutorialEFContext())
            {
                var client = db.Clients
                               .Where(x => x.Id == id)
                               .Include(x => x.Addresses)
                               .SingleOrDefault();
                return client;
            }
        }

        public List<Client> GetByName(string name)
        {
            using (var db = new TutorialEFContext())
            {
                return db.Clients.Where(x => x.Name.Contains(name)).ToList();
            }
        }

        public void Add(Client client)
        {
            using (var db = new TutorialEFContext())
            {
                db.Add(client);
                db.SaveChanges();
            }
        }

        public void Update(Client client)
        {
            using (var db = new TutorialEFContext())
            {
                db.Entry(client).State = EntityState.Modified;
                db.Entry(client).Property(p => p.CreationDate).IsModified = false;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new TutorialEFContext())
            {
                var entity = db.Clients.Find(id);

                db.Remove(entity);
                db.SaveChanges();
            }
        }
    }
}
