using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TutorialEF.Models;
using TutorialEF.Repository;

namespace TutorialEF
{
    class Program
    {
        static void Main(string[] args)
        {
            // Descomente para executar os métodos =)

            //AddClientWithUser();
            //GetUserWithClient();
            //AddClientWithAddresses();
            //GetClientWithAddresses();
            //AddUserWithPermission();
            //GetUsersWithPermissions();
            //GetPermissionsWithUsers();
        }

        private static void GetPermissionsWithUsers()
        {
            var permissionRepository = new PermissionRepository();
            var permissions = permissionRepository.GetPermissionsWithUsers(2);

            Console.WriteLine(JsonConvert.SerializeObject(permissions, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        private static void GetUsersWithPermissions()
        {
            var userRepository = new UserRepository();
            var user = userRepository.GetByIdWithPermissions(2);

            Console.WriteLine(JsonConvert.SerializeObject(user, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        private static void AddUserWithPermission()
        {
            var userRepository = new UserRepository();

            var user = new User { Login = "test", Password = "test" };

            userRepository.AddWithPermission(user, 13, new List<int> { 2, 3 });
        }

        private static void GetClientWithAddresses()
        {
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetByIdWithAddress(13);

            Console.WriteLine(JsonConvert.SerializeObject(client, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        private static void AddClientWithAddresses()
        {
            var clientRepository = new ClientRepository();

            var client = new Client { Name = "Test", Email = "test@test.com", Active = true, CreationDate = DateTime.Now };
            var addresses = new List<Address>
            {
                new Address { StreetAddress = "Rua de teste", ZipCode = "0000000", Client = client } ,
                new Address { StreetAddress = "Rua de teste 2", ZipCode = "1111111", Client = client }
            };

            clientRepository.AddWithAddresses(client, addresses);
        }

        private static void GetUserWithClient()
        {
            var userRepository = new UserRepository();

            var user = userRepository.GetByIdWithClient(1);
            Console.WriteLine(JsonConvert.SerializeObject(user, Formatting.Indented));
        }

        private static void AddClientWithUser()
        {
            var clientRepository = new ClientRepository();

            var client = new Client { Name = "Test", Email = "test@test.com", Active = true, CreationDate = DateTime.Now };
            var user = new User { Login = "teste", Password = "teste", Client = client };

            clientRepository.AddWithUser(client, user);
        }
    }
}
