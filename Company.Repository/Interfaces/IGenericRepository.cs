﻿using Company.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Interfaces
{
    public interface IGenericRepository <T> where T : BaseEntity
    {
        T GetById(int id);
        ICollection<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
