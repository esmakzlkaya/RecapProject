using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var carAvaliable = CheckReturnDate(rental.CarId);
            if (!carAvaliable.Success)
            {
                return new ErrorResult(carAvaliable.Message);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(carAvaliable.Message);
        }

        //ReturnDate'i ==null denedim ancak bir türlü olmadı, hata verdi
        // bu şekilde de yine çalışmıyor
        public IResult CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate==null);
            if (result.Count>0)
            {
                return new ErrorResult(Messages.CarUndelivered);
            }
            return new SuccessResult(Messages.CarRented);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            var result = _rentalDal.GetAllRentalDetails();
            return new SuccessDataResult<List<RentalDetailDto>>(result);
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId);
            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<Rental> GetById(int id)
        {
            var result = _rentalDal.Get(r => r.Id == id);
            return new SuccessDataResult<Rental>(result);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
