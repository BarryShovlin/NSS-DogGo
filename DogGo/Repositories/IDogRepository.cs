using DogGo.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IDogRepository
    {
        List<Dog> GetAllDogs();
        Dog GetDogById(int id);
        void UpdateDog(Dog dog);
        void DeleteDog(int dogId);
        void AddDog(Dog dog);
        List<Dog> GetDogsByOwnerId(int ownerId);
    }
}