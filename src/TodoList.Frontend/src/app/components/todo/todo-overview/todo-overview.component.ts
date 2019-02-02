import { Component, OnInit } from '@angular/core';
import { TodoListService } from 'src/app/services/todolist.service';
import { TodoItemModel } from 'src/app/models/todoitem.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TodoEditComponent } from '../todo-edit/todo-edit.component';

@Component({
  selector: 'app-todo-overview',
  templateUrl: './todo-overview.component.html',
  styleUrls: ['./todo-overview.component.less']
})
export class TodoOverviewComponent implements OnInit {
  public todoItems: TodoItemModel[] = [];

  constructor(private todoListService: TodoListService, private modalService: NgbModal) { }

  ngOnInit() {
    this.todoListService.todoItemsChanged.subscribe((todoItems) => {
      this.todoItems = todoItems;
    });
  }

  public onEdit(id: number): void {
    const modalRef = this.modalService.open(TodoEditComponent);
    const component = <TodoEditComponent>modalRef.componentInstance;
    component.idToEdit.next(id);
  }
}
