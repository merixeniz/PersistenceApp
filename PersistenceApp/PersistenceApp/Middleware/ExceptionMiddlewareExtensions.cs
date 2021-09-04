using Application.Exeptions;
using Entities.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersistenceApp.Middleware
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly JsonSerializerOptions _jsonOptions;
        private readonly ExceptionMappings _mappings;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(
            IOptions<JsonOptions> jsonOptions,
            ILogger<ExceptionMiddleware> logger,
            ExceptionMappings mappings = null)
        {
            _jsonOptions = jsonOptions.Value.JsonSerializerOptions;
            _mappings = mappings;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (BadRequestException ex)
            {
                _logger.LogError(ex, "Bad request error");

                if (httpContext.Response.HasStarted)
                    throw;

                await WriteResponse(httpContext, MapExceptionToStatusCode(ex), new ResponseModel()
                {
                    Status = new ResponseStatus()
                    {
                        Type = ResponseStatus.Types.Error,
                        Title = ex.Title,
                        Body = ex.Message,
                    },
                    Data = ex.ResponseData,
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogError(ex, "Not found error");

                if (httpContext.Response.HasStarted)
                    throw;

                await WriteResponse(httpContext, MapExceptionToStatusCode(ex), new ResponseModel()
                {
                    Status = new ResponseStatus()
                    {
                        Type = ResponseStatus.Types.Error,
                        Title = ex.Title,
                        Body = ex.Message,
                    }
                });
            }
            catch (InvalidTokenException ex)
            {
                _logger.LogError(ex, "Invalid token error");

                if (httpContext.Response.HasStarted)
                    throw;

                await WriteResponse(httpContext, MapExceptionToStatusCode(ex), new ResponseModel()
                {
                    Status = new ResponseStatus()
                    {
                        Type = ResponseStatus.Types.Error,
                        Title = ex.Title,
                        Body = ex.Message
                    }
                });
            }
            catch (ForbiddenException ex)
            {
                _logger.LogError(ex, "Forbidden access");

                if (httpContext.Response.HasStarted)
                    throw;

                await WriteResponse(httpContext, MapExceptionToStatusCode(ex), new ResponseModel()
                {
                    Status = new ResponseStatus()
                    {
                        Type = ResponseStatus.Types.Error,
                        Title = ex.Title,
                        Body = ex.Message,
                    }
                });
            }
            catch (Exception ex)
            {
                if (httpContext.Response.HasStarted)
                {
                    _logger.LogCritical(ex, "Unspecified exception occured");
                    throw;
                }

                if (_mappings != null)
                {
                    if (_mappings.Mappings.TryGetValue(ex.GetType(), out var mapping))
                    {
                        var ex1 = (Exception)Activator.CreateInstance(mapping.type, mapping.code);

                        _logger.LogError(ex1, "Exception of type {Type} occured with code {Code}", mapping.type, mapping.code);

                        await WriteResponse(httpContext, MapExceptionToStatusCode(ex1), new ResponseModel()
                        {
                            Status = new ResponseStatus()
                            {
                                Type = ResponseStatus.Types.Error,
                                Title = "Error",
                                Body = mapping.code,
                            },
                            Data = ex.Data?.Count > 0 ? ex.Data : null
                        });

                        return;
                    }
                }

                _logger.LogError(ex, "Unmapped exception occured");

                await WriteResponse(httpContext, MapExceptionToStatusCode(ex), new ResponseModel()
                {
                    Status = new ResponseStatus()
                    {
                        Type = ResponseStatus.Types.Error,
                        Title = "Internal server error",
                        Body = ex.Message,
                    }
                });

                throw;
            }
        }

        private async Task WriteResponse(HttpContext httpContext, int statusCode, ResponseModel response)
        {
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response, _jsonOptions));
        }

        private static int MapExceptionToStatusCode(Exception e)
        {
            switch (e)
            {
                case BadRequestException:
                    return StatusCodes.Status400BadRequest;
                case InvalidTokenException:
                    return StatusCodes.Status401Unauthorized;
                case ForbiddenException:
                    return StatusCodes.Status403Forbidden;
                case NotFoundException:
                    return StatusCodes.Status404NotFound;
                default:
                    return StatusCodes.Status500InternalServerError;
            }
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IServiceCollection AddExceptionMiddleware(this IServiceCollection services)
        {
            return services.AddSingleton<ExceptionMiddleware>();
        }

        public static IServiceCollection AddExceptionMappings<T>(this IServiceCollection services) where T : ExceptionMappings
        {
            return services.AddSingleton<ExceptionMappings, T>();
        }

        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
