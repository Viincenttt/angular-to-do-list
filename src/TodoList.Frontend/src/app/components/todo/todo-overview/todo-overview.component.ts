import { Component, OnInit } from '@angular/core';
import { TodoListService } from 'src/app/services/todolist.service';
import { TodoItemModel } from 'src/app/models/todoitem.model';

@Component({
  selector: 'app-todo-overview',
  templateUrl: './todo-overview.component.html',
  styleUrls: ['./todo-overview.component.less']
})
export class TodoOverviewComponent implements OnInit {
  public todoItems: TodoItemModel[] = [];

  constructor(private todoListService: TodoListService) { }

  ngOnInit() {
    this.todoListService.todoItemsChanged.subscribe((todoItems) => {
      this.todoItems = todoItems;
    });
  }
}
