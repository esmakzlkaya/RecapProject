using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileOperations;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImagelimit(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileOperation.CreateImageFile(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            var oldImagePath = _carImageDal.Get(ci => ci.Id == carImage.Id).ImagePath;
            var oldPath = $@"{Environment.CurrentDirectory}\{oldImagePath}";
            FileOperation.DeleteImageFile(oldPath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == id));
        }
        public IDataResult<List<CarImage>> GetImageByCarId(int carId)
        {
            var carImage = _carImageDal.GetAll(ci => ci.CarId == carId);
            var result = BusinessRules.Run(CheckIfImageExists(carImage));
            if (result != null)
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci=>ci.CarId==carId));
            }
            return new SuccessDataResult<List<CarImage>>(carImage);
        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var oldImagePath = _carImageDal.Get(ci => ci.Id == carImage.Id).ImagePath;
            var oldPath = $@"{Environment.CurrentDirectory}\{oldImagePath}";
            carImage.ImagePath = FileOperation.UpdateImageFile(oldPath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfImagelimit(int carId)
        {
            var imageCount = (_carImageDal.GetAll(ci => ci.CarId == carId).Count);
            if (imageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceed);
            }
            return new SuccessResult();
        }
        private IResult CheckIfImageExists(List<CarImage> carImage)
        {
            var defaultPath = "\\wwwroot\\images\\default.jpg";
            for (int i = 0; i < carImage.Count; i++)
            {
                if (carImage[i].ImagePath == "")
                {
                    _carImageDal.Update(new CarImage { Id = carImage[i].Id, CarId=carImage[i].CarId, Date=DateTime.Now, ImagePath = defaultPath });
                }
            }
            return new ErrorResult();
        }
    }
}
