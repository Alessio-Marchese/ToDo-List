﻿namespace HybridMauiApp.DTOS.ToDoLists.CreateToDoList;
public record CreateToDoListRequest(string title);
public record CreateToDoListResponse(Guid id);
