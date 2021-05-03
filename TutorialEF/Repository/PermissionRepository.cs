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
    public class PermissionRepository
    {
        public Permission GetPermissionsWithUsers(int id)
        {
            using (var db = new TutorialEFContext())
            {
                var user = db.Permissions
                             .Where(x => x.Id == id)
                             .Include(x => x.User)
                             .SingleOrDefault();
                return user;
            }
        }
    }
}
