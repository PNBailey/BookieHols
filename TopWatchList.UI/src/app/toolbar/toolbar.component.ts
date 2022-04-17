import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UserService } from '../services/user.service';
import { LoginRegisterDialogComponent } from './login-register-dialog/login-register-dialog.component';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {
  @Output() showSideNav = new EventEmitter();
  // displayLoginDialog = false;

  constructor(private userService: UserService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.userService.getUsers().subscribe(users => console.log(users));
  }

  openSideNav() {
    this.showSideNav.emit();
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(LoginRegisterDialogComponent, {
      width: '350px'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

}
