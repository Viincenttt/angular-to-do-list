import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TodoItemModel } from '../models/todoitem.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class TodoListService {
    public todoItems = new Observable<TodoItemModel[]>();

    constructor(private httpClient: HttpClient) {
        this.todoItems = this.httpClient.get<TodoItemModel[]>(`${environment.apiUrl}/api/todo`);
    }
}