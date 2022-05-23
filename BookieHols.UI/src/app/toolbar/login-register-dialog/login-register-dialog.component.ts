import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { RegisterUser } from 'src/app/Models/registerUser';
import { AccountService } from 'src/app/services/account.service';
import { EmailValidator } from 'src/app/shared/validators/email-validator';
import { UsernameValidator } from 'src/app/shared/validators/username-validator';

@Component({
  selector: 'app-login-register-dialog',
  templateUrl: './login-register-dialog.component.html',
  styleUrls: ['./login-register-dialog.component.css']
})
export class LoginRegisterDialogComponent implements OnInit {
  register = false;
  // registerUser: RegisterUser;
  registerForm: FormGroup;
  loginForm: FormGroup;

  constructor(private accountService: AccountService, private fb: FormBuilder) { }

  ngOnInit(): void {
    // this.registerUser = new RegisterUser();
    this.buildLoginForm();
  }

  switchToRegisterUser() {
    this.buildRegisterForm();
    this.register = true;
  }

  registerUser() {
    this.accountService.register(this.registerForm.value);
  }

  loginUser() {
    this.accountService.login(this.loginForm.value);
  }

  buildRegisterForm() {
    this.registerForm = this.fb.group({
      'username': ['', [Validators.required], [UsernameValidator.uniqueUsernameValidatorFn(this.accountService)]],
      'password': ['', [Validators.required, Validators.pattern("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]],
      'email': ['', [Validators.required, Validators.email], [EmailValidator.uniqueEmailValidatorFn(this.accountService)]]
    });
  }

  buildLoginForm() {
    this.loginForm = this.fb.group({
      'username': ['', [Validators.required]],
      'password': ['', [Validators.required, Validators.minLength(6)]],
    });
  }
}
