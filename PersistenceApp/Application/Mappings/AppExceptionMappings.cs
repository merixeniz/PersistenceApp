using Application.Exeptions;

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
