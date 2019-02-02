import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.less']
})
export class RegisterComponent implements OnInit {
  public registrationForm: FormGroup;

  constructor() { }

  ngOnInit() {
    this.initRegistrationForm();
  }

  public initRegistrationForm(): void {
    this.registrationForm = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.email]),
      'password': new FormControl(null, Validators.required)
    });
  }

  public onRegister(): void {
    if (this.registrationForm.invalid) {
      return;
    }

    console.log('register');
  }
}
