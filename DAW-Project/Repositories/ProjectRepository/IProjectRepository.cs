﻿using DAW_Project.Models;
using DAW_Project.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Repositories.ProjectRepository
{
    interface IProjectRepository: IGenericRepository<Project>
    {
    }
}