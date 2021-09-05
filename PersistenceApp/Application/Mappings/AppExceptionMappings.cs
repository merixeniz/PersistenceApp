using Application.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class AppExceptionMappings : ExceptionMappings
    {
        public AppExceptionMappings()
        {
            #region NotFound
            //CreateMap<UserNotFoundException, NotFoundException>(ErrorCodes.UserNotFound);
          
            #endregion

            #region BadRequest
            //CreateMap<ParameterAlreadyExistsException, BadRequestException>(ErrorCodes.ParameterAlreadyExists);
           

            #endregion
        }
    }
}
