﻿
using Courses.API.DTOs;
using Courses.Core.Entities;
using Courses.Core.Interfaces.Repositories;
using Courses.Core.Responses;

namespace Courses.API.Endpoints.Courses
{
    public class GetCourseByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/{id:guid}", HandleAsync).Produces<Response<GetCourseDTO?>>();

        public static async Task<IResult> HandleAsync(ICourseRepository courseRepository,
                                                      Guid id)
        {
            var course = await courseRepository.GetById(id);
            if (course is null)
                return TypedResults.NotFound();

            var result = GetCourseDTO.MapFromEntity(course);
            return TypedResults.Ok(result);
        }

    }
}