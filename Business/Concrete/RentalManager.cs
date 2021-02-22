using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var check = CheckAvailable(rental);
            if (check == 1)
            {
                return new ErrorResult(Messages.NotAvailable);
            }
            else if(check == 0)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentSuccess);
            }
            else
            {
                return new ErrorResult(Messages.UnknownError);
            }

        }

        public int CheckAvailable(Rental rental)
        {
            var count = 0;
            var result = _rentalDal.GetAll(p => p.CarId == rental.CarId);
            foreach (var rent in result)
            {
                if (rent.ReturnDate == null)
                {
                    count++;
                }
            }
            return count;
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdate);
        }
    }
}
