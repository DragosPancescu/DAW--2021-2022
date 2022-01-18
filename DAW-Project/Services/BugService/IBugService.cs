using DAW_Project.Models;
using DAW_Project.Models.CustomTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Services
{
    public interface IBugService
    {
        // GetAll 
        IEnumerable<BugReport> GetAllBugsOfVersion(Guid versionId);

        //GetByAdd
        BugReport GetById(Guid id);

        // Create
        void Create(BugReport bug);

        // Delete
        void Delete(BugReport bug);

        // Update
        void Update(BugReport bug);
    }
}
