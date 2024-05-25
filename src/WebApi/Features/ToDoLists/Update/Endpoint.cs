﻿using FastEndpoints;
using Shared.DTOS.ToDoLists.Update;
using webapi.Infastructure.Data;

namespace webapi.Features.ToDoLists.Update
{
    internal sealed class Endpoint(ApplicationDbContext context) : Endpoint<Request, EmptyResponse>
    {
        public override void Configure()
        {
            Put("/api/todo-list/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request r, CancellationToken c)
        {
            var toDoList = await context.ToDoLists.FindAsync(r.id);
            if (toDoList is null)
            {
                await SendNotFoundAsync();
                return;
            }
            if (!string.IsNullOrWhiteSpace(r.Title)) 
            {
                toDoList.Title = r.Title;
            }
            if(toDoList.IsDone != r.IsDone)
            {
                toDoList.IsDone = r.IsDone;
            }
            await context.SaveChangesAsync();
            await SendNoContentAsync();
        }
    }
}