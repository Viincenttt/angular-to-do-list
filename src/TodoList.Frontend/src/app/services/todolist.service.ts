import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TodoItemModel } from '../models/todoitem.model';
import { Subject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { tap } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class TodoListService {
    public todoItemsChanged = new Subject<TodoItemModel[]>();

    public todoItems: TodoItemModel[] = [];

    constructor(private httpClient: HttpClient) {
        this.httpClient.get<TodoItemModel[]>(`${environment.apiUrl}/api/todo`).subscribe((list) => {
            this.todoItems = list;
            this.todoItemsChanged.next(list);
        });
    }
    // TODO: Not happy about the naming here... implies retrieving from server
    public get(id: number): TodoItemModel {
        return this.todoItems.find(x => x.id === id);
    }

    public save(todoItem: TodoItemModel): Observable<TodoItemModel> {
        const baseSaveUrl = `${environment.apiUrl}/api/todo`;
        if (todoItem.id) {
            return this.httpClient.put<TodoItemModel>(`${baseSaveUrl}/${todoItem.id}`, todoItem)
                .pipe(tap(updatedTodoItem => {
                    todoItem = updatedTodoItem;
                }));
        } else {
            return this.httpClient.post<TodoItemModel>(`${baseSaveUrl}`, todoItem)
                .pipe(tap(insertedTodoItem => {
                    this.todoItems.push(insertedTodoItem);
                }));
        }
    }
}