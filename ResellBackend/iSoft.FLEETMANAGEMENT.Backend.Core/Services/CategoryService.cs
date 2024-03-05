using AutoMapper;
using iSoft.FLEETMANAGEMENT.Backend.Core.Database.Context;
using iSoft.FLEETMANAGEMENT.Backend.Core.UnitOfWork;
using ResellBackendCore.Database.Dtos.CategoryDto;
using ResellBackendCore.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResellBackendCore.Services
{
    public class CategoryService
    {
        public EfUnitOfWork _efUnitOfWork { get; set; }
        public ResellDbContext _resellDbContext { get; set; }
        private readonly IMapper _mapper;

        public CategoryService(EfUnitOfWork efUnitOfWork, ResellDbContext resellDbContext, IMapper mapper)
        {
            _efUnitOfWork = efUnitOfWork;
            _resellDbContext = resellDbContext;
            _mapper = mapper;
        }

        public async Task<GetCategoryDto> CreateCategory(AddCategoryDto category)
        {
            var newCategory = _mapper.Map<Category>(category);
            _efUnitOfWork._categoryRepository.Add(newCategory);
            await _efUnitOfWork.SaveAsync();
            return _mapper.Map<GetCategoryDto>(newCategory);
        }
    }
}
