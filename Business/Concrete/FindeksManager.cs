using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {
        IFindeksDal _findeksDal;

        //CarManager nesnesi oluşturulduğunda, ICarDal referansı versin diye
        public FindeksManager(IFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }

        public IDataResult<Findeks> GetByUserId(int userId)
        {
            var result = _findeksDal.GetFindeksByUserId(userId);
            
                return new SuccessDataResult<Findeks>(result);
            
        }
        public IDataResult<Findeks> GetByNatId(string natId)
        {
            return new SuccessDataResult<Findeks>(_findeksDal.Get(f => f.NationalityId == natId));
        }

    }
}