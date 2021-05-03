using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialEF.Context;
using TutorialEF.Models;

namespace TutorialEF.Repository
{
    public class UserRepository
    {
        public User GetById(int id)
        {
            using (var db = new TutorialEFContext())
            {
                var user = db.Users.Find(id);

                return user;
            }
        }

        public User GetByIdWithClient(int id)
        {
            using (var db = new TutorialEFContext())
            {
                var user = db.Users
                             .Where(x => x.Id == id)
                             .Include(x => x.Client)
                             .SingleOrDefault();
                return user;
            }
        }

        public void AddWithPermission(User user, int clientId, List<int> permissions)
        {
            using (var db = new TutorialEFContext())
            {
                var client = db.Clients.Find(clientId);
                var permissionsModel = db.Permissions.Where(x => permissions.Contains(x.Id)).ToList();

                user.Client = client;
                user.Permission = permissionsModel;

                db.Add(user);

                db.SaveChanges();
            }
        }

        public User GetByIdWithPermissions(int id)
        {
            using (var db = new TutorialEFContext())
            {
                var user = db.Users
                             .Where(x => x.Id == id)
                             .Include(x => x.Permission)
                             .SingleOrDefault();
                return user;
            }
        }
    }
}
