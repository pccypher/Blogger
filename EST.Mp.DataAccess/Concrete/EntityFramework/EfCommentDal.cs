﻿using EST.Mp.Core.DataAccess.EntityFramework;
using EST.Mp.DataAccess.Abstract;
using EST.Mp.Entities.Concrete;

namespace EST.Mp.DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : EfEntityRepositoryBase<Comments, MpContext>, ICommentDal
    {

    }
}
