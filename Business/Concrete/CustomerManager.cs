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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var result = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(result);
        }

        public IDataResult<List<CustomerDetailDto>> GetAllCustomerDetails()
        {
            var result = _customerDal.GetAllCustomerDetails();
            return new SuccessDataResult<List<CustomerDetailDto>>(result);
        }

        public IDataResult<Customer> GetById(int id)
        {
            var result = _customerDal.Get(c => c.Id == id);
            return new SuccessDataResult<Customer>(result);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }
    }
}
