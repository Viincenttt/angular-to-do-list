import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TodoItemModel } from '../models/todoitem.model';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class TodoListService {
    public todoItemsChanged = new Subject<TodoItemModel[]>();

    constructor(private httpClient: HttpClient) {
        this.httpClient.get<TodoItemModel[]>(`${environment.apiUrl}/api/todo`).subscribe((list) => {
            this.todoItemsChanged.next(list);
        });
    }
}