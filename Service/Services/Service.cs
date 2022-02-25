using AutoMapper;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        async Task<T> IService<T>.AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        async Task<IEnumerable<T>> IService<T>.AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        async Task<bool> IService<T>.AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);


        }

        async Task<IEnumerable<T>> IService<T>.GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        async Task<T> IService<T>.GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        async Task IService<T>.RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }

        async Task IService<T>.RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        async Task IService<T>.UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        IQueryable<T> IService<T>.Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
        T IService<T>.Find(string email)
        {
            return _repository.Find(email);

        }
    }
}
