import { Component, OnInit } from '@angular/core';
import { RegisterUser } from 'src/app/Models/registerUser';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-login-register-dialog',
  templateUrl: './login-register-dialog.component.html',
  styleUrls: ['./login-register-dialog.component.css']
})
export class LoginRegisterDialogComponent implements OnInit {
  register = false;
  registerUser: RegisterUser;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.registerUser = new RegisterUser();
  }

  onRegisterUser() {
    this.accountService.register(this.registerUser);
  }

}
