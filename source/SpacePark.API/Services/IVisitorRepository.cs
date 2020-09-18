﻿using SpacePark.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpacePark.API.Services
{
    public interface IVisitorRepository
    {
        Task<List<Visitor>> GetVisitors();
        Task<Visitor> AddVisitor(Visitor visitor);
    }
}
