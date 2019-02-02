import { Component, OnInit, OnDestroy } from '@angular/core';
import { TodoListService } from 'src/app/services/todolist.service';
import { BehaviorSubject } from 'rxjs';
import { TodoItemModel } from 'src/app/models/todoitem.model';

@Component({
  selector: 'app-todo-edit',
  templateUrl: './todo-edit.component.html',
  styleUrls: ['./todo-edit.component.less']
})
export class TodoEditComponent implements OnInit, OnDestroy {
  
  public idToEdit = new BehaviorSubject<number>(null);
  public editItem: TodoItemModel;

  constructor(private todoListService: TodoListService) { }

  ngOnInit() {
    this.idToEdit.subscribe((id: number) => {
      this.editItem = this.todoListService.get(id);
    });
  }

  ngOnDestroy(): void {
    this.idToEdit.unsubscribe();
  }
}
