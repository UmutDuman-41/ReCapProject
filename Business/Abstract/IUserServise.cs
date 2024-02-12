﻿using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserServise
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IResult Insert(User user);
        IResult Delete(User user);
        IResult Update(User user);
    }
}
